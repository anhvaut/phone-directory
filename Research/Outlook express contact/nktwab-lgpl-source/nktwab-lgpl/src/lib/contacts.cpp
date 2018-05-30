/* NKTWAB is an ActiveX library that allows to create and modify Microsoft's Windows Address Book and Windows Vista's contacts.
* Copyright (C) 2007 Pablo Yabo.
* pablo.yabo@nektra.com
* 
* This library is free software; you can redistribute it and/or
* modify it under the terms of the GNU Lesser General Public
* License as published by the Free Software Foundation; either
* version 2.1 of the License, or (at your option) any later version.
* 
* This library is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
* Lesser General Public License for more details.
* 
* You should have received a copy of the GNU Lesser General Public
* License along with this library; if not, write to the Free Software
* Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA
* 02110-1301  USA
*
* http://www.gnu.org/licenses/lgpl.html
* 
**/

#include "std.h"

#include "contacts.h"
#include "contact.h"


TGroupContacts::TGroupContacts()
{
	_count = -1;
}

TCHAR *TGroupContacts::get_progid()
{
	return _T("NKTWABLib.GroupContacts");
}

com_ptr<IGroupContacts> TGroupContacts::newInstance()
{
	com_ptr<IGroupContacts> ret(uuidof<GroupContacts>());
	return ret;
}

void TGroupContacts::SetObjectData(NKTWABMgrPtr mgr, LPENTRYID lpEntryID, ULONG cbEntryID)
{
	_mgr = mgr;

	// for distribution lists we have to read the PR_DISTLIST_ENTRYIDS to retrieve
	// contact list because it's not a container.
	_item.SetObjectData(_mgr, lpEntryID, cbEntryID);
}

long TGroupContacts::GetCount()
{
	if(_count == -1) {
		_count = 0;

 		SBinaryArray *distList = _item.GetDistributionListArray();
		if(distList) {
			_count = distList->cValues;
		}
	}

	return _count;
}

TContactPtr TGroupContacts::GetItem(const variant_t& idx)
{
	HRESULT hr = E_FAIL;
	TContactPtr ret;
	TContact *contact;
	string entryIDString;
	LPENTRYID entryID = NULL;
	ULONG cbEntryID;
	long lidx = -1;
	LPENTRYID contactEntryID = NULL;
	ULONG cbContactEntryID = 0;

	if(idx.is_string()) {
		entryIDString = (string) idx;

		// entryID cannot be NULL but we verify.
		entryID = _mgr->CreateEntryIDFromString(entryIDString.c_str(), &cbEntryID);
		if(entryID) {
			// find into the array of contacts of the distribution list the specified
			// id
			SBinaryArray *distList = _item.GetDistributionListArray();
			if(distList) {
				DWORD *lpShortEntryIDArray = (DWORD *) distList->lpbin->lpb;
				cbContactEntryID = distList->lpbin->cb;

				for(int i=0;;) {
					contactEntryID = (LPENTRYID) (lpShortEntryIDArray + lidx);

					if(!_mgr->CompareEntryIDs(entryID, cbEntryID, 
						contactEntryID, cbContactEntryID)) {
						hr = S_OK;
						break;
					}

					if(++i >= (int)distList->cValues) {
						break;
					}
				}
			}

			_mgr->FreeBuffer(entryID);
		}
	}
	else {
		// it comes 1 based
		lidx = ((long) idx) - 1;

		// get the contact by index in the distribution list array.
		SBinaryArray *distList = _item.GetDistributionListArray();
		if(distList) {
			if(lidx < (long)distList->cValues) {
				contactEntryID = (LPENTRYID) distList->lpbin[lidx].lpb;
				cbContactEntryID = distList->lpbin[lidx].cb;

				hr = S_OK;
			}
		}
	}

	if(SUCCEEDED(hr)) {
		ret = TContact::newInstance();
		contact = (TContact *) ret.get();

		contact->SetObjectData(_mgr, contactEntryID, cbContactEntryID);
	}

	return ret;
}

void TGroupContacts::Add(const bstr_t &entryIDString)
{
	LPENTRYID lpEntryID;
	ULONG cbEntryID;

	lpEntryID = _mgr->CreateEntryIDFromString(entryIDString.s_str().c_str(), &cbEntryID);
	if(lpEntryID) {
		_item.AppendEntryIDToDistList(lpEntryID, cbEntryID);
		_item.Save();
		_mgr->FreeBuffer(lpEntryID);
	}
}

void TGroupContacts::Delete(const bstr_t &entryIDString)
{
	NKTItem item;
	LPENTRYID lpEntryID;
	ULONG cbEntryID;

	lpEntryID = _mgr->CreateEntryIDFromString(entryIDString.s_str().c_str(), &cbEntryID);
	if(lpEntryID) {
		_item.RemoveEntryIDFromDistList(lpEntryID, cbEntryID);
		_item.Save();
		_mgr->FreeBuffer(lpEntryID);
	}
}

////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////
TFolderContacts::TFolderContacts()
{
	_container = NULL;
	_mt = NULL;
	_count = -1;
	_mtOrdered = FALSE;
}

TFolderContacts::~TFolderContacts()
{
	if(_container != NULL) {
		_container->Release();
	}
	if(_mt != NULL) {
		_mt->Release();
	}
}

TCHAR *TFolderContacts::get_progid()
{
	return _T("NKTWABLib.FolderContacts");
}

com_ptr<IFolderContacts> TFolderContacts::newInstance()
{
	com_ptr<IFolderContacts> ret(uuidof<FolderContacts>());
	return ret;
}

void TFolderContacts::SetObjectData(NKTWABMgrPtr mgr, LPENTRYID lpEntryID, ULONG cbEntryID,
						LPABCONT container, LPMAPITABLE mt, BOOL mtOrdered)
{
	_mgr = mgr;

	_container = container;
	if(_container) {
		_container->AddRef();
	}
	_mt = mt;
	if(_mt) {
		_mt->AddRef();
	}

	_mtOrdered = mtOrdered;
}

long TFolderContacts::GetCount()
{
	if(_count == -1) {
		_count = 0;

		if(_mt) {
			_count = _mgr->GetRowCount(MAPI_MAILUSER, _mt, _mtOrdered);
		}
	}

	return _count;
}

TContactPtr TFolderContacts::GetItem(const variant_t& idx)
{
	HRESULT hr = E_FAIL;
	TContactPtr ret;
	TContact *contact;
	LPSRowSet rowAB;
	string entryIDString;
	LPENTRYID entryID = NULL;
	ULONG cbEntryID;
	long lidx = -1;
	LPENTRYID contactEntryID = NULL;
	ULONG cbContactEntryID = 0;

	if(idx.is_string()) {
		entryIDString = (string) idx;

		// entryID cannot be NULL but we verify.
		entryID = _mgr->CreateEntryIDFromString(entryIDString.c_str(), &cbEntryID);
		if(entryID) {
			hr = _mgr->GetRowByEntryID(entryID, cbEntryID, MAPI_MAILUSER, _mt, _mtOrdered, &rowAB);
			_mgr->FreeBuffer(entryID);
		}
	}
	else {
		// it comes 1 based
		lidx = ((long) idx) - 1;

		hr = _mgr->GetRowByIndex(lidx, MAPI_MAILUSER, _mt, _mtOrdered, &rowAB);
	}

	if(SUCCEEDED(hr)) {
		ret = TContact::newInstance();
		contact = (TContact *) ret.get();

		contact->SetObjectData(_mgr, rowAB, _mtOrdered, _container);

		_mgr->FreeProws(rowAB);
	}

	return ret;
}

TContactPtr TFolderContacts::Add()
{
	TContactPtr ret(TContact::newInstance());
	TContact *contact = (TContact *) ret.get();

	contact->SetObjectData(_mgr, NULL, FALSE, _container, TRUE);

	return ret;
}

void TFolderContacts::Delete(const bstr_t &entryIDString)
{
	NKTItem item;
	LPENTRYID lpEntryID;
	ULONG cbEntryID;

	lpEntryID = _mgr->CreateEntryIDFromString(entryIDString.s_str().c_str(), &cbEntryID);
	if(lpEntryID) {
		item.SetObjectData(_mgr, lpEntryID, 4);
		item.Delete();
	}
}


////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////
TCHAR *TContacts::get_progid()
{
	return _T("NKTWABLib.Contacts");
}

