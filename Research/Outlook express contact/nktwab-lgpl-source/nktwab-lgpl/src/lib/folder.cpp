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
#include "folder.h"
#include "folders.h"
#include "contacts.h"
#include "groups.h"

#include <string>


TFolder::TFolder()
{
	_item.SetObjectType(MAPI_ABCONT);
	_container = NULL;
	_mt = NULL;
}

TFolder::~TFolder()
{
	if(_container != NULL) {
		_container->Release();
	}
	if(_mt != NULL) {
		_mt->Release();
	}
}

TCHAR *TFolder::get_progid()
{
	return _T("NKTWABLib.Folder");
}

com_ptr<IFolder> TFolder::newInstance()
{
	com_ptr<IFolder> ret(uuidof<Folder>());
	return ret;
}

void TFolder::SetObjectData(NKTWABMgrPtr mgr, LPSRowSet rowAB, BOOL rowOrdered, BOOL newObject)
{
	LPENTRYID lpEntryID = NULL;
	ULONG cbEntryID = 0;

	_mgr = mgr;
	_item.SetObjectData(mgr, rowAB, rowOrdered, NULL, newObject);

	if(rowAB) {
		lpEntryID = _mgr->GetRowEntryID(rowAB, rowOrdered);
		cbEntryID = _mgr->GetRowCbEntryID(rowAB, rowOrdered);
	}

	_mgr->CreateContainerObjects(lpEntryID, cbEntryID, &_container, &_mt, &_mtOrdered);
}

void TFolder::SetObjectData(NKTWABMgrPtr mgr, LPENTRYID lpEntryID, ULONG cbEntryID)
{
	_mgr = mgr;
	_item.SetObjectData(mgr, lpEntryID, cbEntryID);

	_mgr->CreateContainerObjects(lpEntryID, cbEntryID, &_container, &_mt, &_mtOrdered);
}

BOOL TFolder::IsValid()
{
	return _item.IsValid();
}

bstr_t TFolder::GetEntryID()
{
	return _item.GetFieldOrBlank(PR_ENTRYID);
}

bstr_t TFolder::GetName()
{
	return _item.GetFieldOrBlank(PR_DISPLAY_NAME);
}

void TFolder::PutName(bstr_t value)
{
	_item.SetStringField(PR_DISPLAY_NAME, value);
}

TFoldersPtr TFolder::GetFolders()
{
	TFoldersPtr ret(TFolders::newInstance());
	TFolders *folders = (TFolders *) ret.get();

	folders->SetObjectData(_mgr, _item.GetEntryID(), _item.GetEntryIDSize(), _container,
							_mt, _mtOrdered);

	return ret;
}

TContactsPtr TFolder::GetContacts()
{
	TFolderContactsPtr ret = TFolderContacts::newInstance();
	TFolderContacts *contacts = (TFolderContacts *) ret.get();

	contacts->SetObjectData(_mgr, _item.GetEntryID(), _item.GetEntryIDSize(), 
							_container, _mt, _mtOrdered);

	return ret;
}

TGroupsPtr TFolder::GetGroups()
{
	TGroupsPtr ret = TGroups::newInstance();
	TGroups *groups = (TGroups *) ret.get();

	groups->SetObjectData(_mgr, _item.GetEntryID(), _item.GetEntryIDSize(), 
							_container, _mt, _mtOrdered);

	return ret;
}

void TFolder::Save()
{
	OSVERSIONINFO OSversion;
	OSversion.dwOSVersionInfoSize=sizeof(OSVERSIONINFO);
	::GetVersionEx(&OSversion);
	if( OSversion.dwMajorVersion < 6 )
	{
		_item.Save();
	} else
	{
		OutputDebugStringA("warning: Folder::Save() is not compatible with Windows Vista");
	}

}

void TFolder::Delete()
{
	_item.Delete();
}
