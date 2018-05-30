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

#include "groups.h"
#include "group.h"
#include "nktwab.h"


TGroups::TGroups()
{
	_container = NULL;
	_mt = NULL;
	_count = -1;
}

TGroups::~TGroups()
{
	if(_mt != NULL) {
		_mt->Release();
	}
	if(_container != NULL) {
		_container->Release();
	}
}

TCHAR *TGroups::get_progid()
{
	return _T("NKTWABLib.Groups");
}

com_ptr<IGroups> TGroups::newInstance()
{
	com_ptr<IGroups> ret(uuidof<Groups>());
	return ret;
}

void TGroups::SetObjectData(NKTWABMgrPtr mgr, LPENTRYID lpEntryID, ULONG cbEntryID,
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

long TGroups::GetCount()
{
	if(_count == -1) {
		_count = _mgr->GetRowCount(MAPI_DISTLIST, _mt, _mtOrdered);
	}

	return _count;
}

TGroupPtr TGroups::GetItem(const variant_t &idx)
{
	HRESULT hr = E_FAIL;
	TGroupPtr ret;
	TGroup *group;
	LPSRowSet rowAB;
	string entryIDString;
	LPENTRYID entryID = NULL;
	ULONG cbEntryID;
	long lidx = -1;

	if(idx.is_string()) {
		entryIDString = (string) idx;

		// entryID cannot be NULL but we verify.
		entryID = _mgr->CreateEntryIDFromString(entryIDString.c_str(), &cbEntryID);
		if(entryID) {
			hr = _mgr->GetRowByEntryID(entryID, cbEntryID, MAPI_DISTLIST, _mt, _mtOrdered, &rowAB);
			_mgr->FreeBuffer(entryID);
		}
	}
	else {
		// it comes 1 based
		lidx = (long) idx;

		hr = _mgr->GetRowByIndex(lidx-1, MAPI_DISTLIST, _mt, _mtOrdered, &rowAB);
	}

	if(SUCCEEDED(hr)) {
		ret = TGroup::newInstance();
		group = (TGroup *) ret.get();

		group->SetObjectData(_mgr, rowAB, _mtOrdered, _container);

		_mgr->FreeProws(rowAB);
	}

	return ret;
}

TGroupPtr TGroups::Add()
{
	TGroupPtr ret(TGroup::newInstance());
	TGroup *group = (TGroup *) ret.get();

	group->SetObjectData(_mgr, NULL, _mtOrdered, _container, TRUE);

	return ret;
}
