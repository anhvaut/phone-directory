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
#include "group.h"
#include "groups.h"
#include "contact.h"
#include "contacts.h"


TGroup::TGroup()
{
	_item.SetObjectType(MAPI_DISTLIST);
}

TGroup::~TGroup()
{
}

TCHAR *TGroup::get_progid()
{
	return _T("NKTWABLib.Group");
}

com_ptr<IGroup> TGroup::newInstance()
{
	com_ptr<IGroup> ret(uuidof<Group>());
	return ret;
}

void TGroup::SetObjectData(NKTWABMgrPtr mgr, LPSRowSet rowAB, BOOL rowOrdered, 
						   LPABCONT container, BOOL newObject)
{
	_mgr = mgr;
	_item.SetObjectData(mgr, rowAB, rowOrdered, container, newObject);
}

void TGroup::SetObjectData(NKTWABMgrPtr mgr, LPENTRYID lpEntryID, ULONG cbEntryID)
{
	_mgr = mgr;
	_item.SetObjectData(mgr, lpEntryID, cbEntryID);
}

BOOL TGroup::IsValid()
{
	return _item.IsValid();
}

bstr_t TGroup::GetEntryID()
{
	return _item.GetFieldOrBlank(PR_ENTRYID);
}

bstr_t TGroup::GetName()
{
	return _item.GetFieldOrBlank(PR_DISPLAY_NAME);
}

void TGroup::PutName(bstr_t value)
{
	_item.SetStringField(PR_DISPLAY_NAME, value);
}

TContactsPtr TGroup::GetContacts()
{
	TGroupContactsPtr ret = TGroupContacts::newInstance();
	TGroupContacts *contacts = (TGroupContacts *) ret.get();

	contacts->SetObjectData(_mgr, _item.GetEntryID(), _item.GetEntryIDSize());

	return ret;
}

void TGroup::Save()
{
	_item.Save();
}

void TGroup::Delete()
{
	_item.Delete();
}