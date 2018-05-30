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

#include "nktwab.h"
#include "folder.h"
#include "group.h"
#include "contact.h"


TNKTWAB::TNKTWAB()
{
	_isInitialized = false;
}

TNKTWAB::~TNKTWAB()
{
}

TCHAR *TNKTWAB::get_progid()
{
	return _T("NKTWABLib.NKTWAB");
}

com_ptr<INKTWAB> TNKTWAB::newInstance()
{
	com_ptr<INKTWAB> ret(uuidof<NKTWAB>());
	return ret;
}

void TNKTWAB::SetFilename(const bstr_t &filename)
{
	_filename = filename;
}

void TNKTWAB::Init()
{
	LPCTSTR pszFileName = _T("");

	// if the filename is specified -> use it
	if(!_filename.is_empty()) {
		pszFileName = _filename.t_str().c_str();
	}

	if(!_isInitialized)
	{
		_mgr = new NKTWABMgr;
		_mgr->Init(pszFileName, WAB_ENABLE_PROFILES);
		_isInitialized = true;
	}
}

TFolderPtr TNKTWAB::GetRootFolder()
{
	Init();

	TFolderPtr ret = TFolder::newInstance();
	TFolder *folder = (TFolder *) ret.get();

	folder->SetObjectData(_mgr, 0, FALSE);

	return ret;
}

TFolderPtr TNKTWAB::GetDefaultFolder()
{
	Init();

	TFolderPtr ret = TFolder::newInstance();
	TFolder *folder = (TFolder *) ret.get();

	folder->SetObjectData(_mgr, 0, FALSE);

	ret = folder->GetFolders()->GetItem(1);

	return ret;
}

TNKTWABItemPtr TNKTWAB::GetItem(const variant_t &itemId)
{
	Init();

	TNKTWABItemPtr ret;
	LPENTRYID lpEntryID;
	NKTItem item;
	string entryIDString;
	LPENTRYID entryID = NULL;
	ULONG cbEntryID;
	long lidx = -1;

	if(itemId.is_string()) {
		entryIDString = (string) itemId;

		lpEntryID = _mgr->CreateEntryIDFromString(entryIDString.c_str(), &cbEntryID);

		item.SetObjectData(_mgr, lpEntryID, cbEntryID);
		if(item.IsValid()) {
			if(item.GetObjectType() == MAPI_ABCONT) {
				ret = TFolder::newInstance();

				TFolder *folder = (TFolder *) ret.get();
				folder->SetObjectData(_mgr, lpEntryID, cbEntryID);
			}
			else if(item.GetObjectType() == MAPI_DISTLIST) {
				ret = TGroup::newInstance();

				TGroup *group = (TGroup *) ret.get();
				group->SetObjectData(_mgr, lpEntryID, cbEntryID);
			}
			else if(item.GetObjectType() == MAPI_MAILUSER) {
				ret = TContact::newInstance();

				TContact *contact = (TContact *) ret.get();
				contact->SetObjectData(_mgr, lpEntryID, cbEntryID);
			}
		}

		if(lpEntryID) {
			_mgr->FreeBuffer(lpEntryID);
		}
	}

	return ret;
}