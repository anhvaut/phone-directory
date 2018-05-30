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

#ifndef __CONTACTS_H__
#define __CONTACTS_H__

#include "wab_item.h"

#define TContacts coclass_implementation<Contacts>
#define TGroupContacts coclass_implementation<GroupContacts>
#define TFolderContacts coclass_implementation<FolderContacts>

template<>
class TGroupContacts : public coclass<GroupContacts>
{
public:
	TGroupContacts();

	static TCHAR *get_progid();
	static com_ptr<IGroupContacts> newInstance();

	/**
	Set object info.
	*/
	void SetObjectData(NKTWABMgrPtr wab, LPENTRYID lpEntryID, ULONG cbEntryID);

	/**
	Deletes the contact with the specified entry id to the contacts of this group.
	*/
	void Delete(const bstr_t &entryIDString);

	/**
	Adds the contact with the specified entry id to the contacts of this group.
	*/
	void Add(const bstr_t &entryID);

	long GetCount();

	TContactPtr GetItem(const variant_t& idx);

private:
	NKTWABMgrPtr _mgr;
	int _count;
	NKTItem _item;
};

template<>
class TFolderContacts : public coclass<FolderContacts>
{
public:
	TFolderContacts();
	~TFolderContacts();

	static TCHAR *get_progid();
	static com_ptr<IFolderContacts> newInstance();

	/**
	Set object info.
	*/
	void SetObjectData(NKTWABMgrPtr mgr, LPENTRYID lpEntryID, ULONG cbEntryID,
						LPABCONT container, LPMAPITABLE mt, BOOL mtOrdered);

	/**
	Deletes the contact with the specified entry id to the contacts of this group.
	*/
	void Delete(const bstr_t &entryIDString);

	/**
	Adds the contact with the specified entry id to the contacts of this group.
	*/
	TContactPtr Add();

	/**
	Returns the number of contacts in this folder.
	*/
	long GetCount();

	TContactPtr GetItem(const variant_t& idx);

private:
	LPABCONT  _container;
	LPMAPITABLE _mt;
	NKTWABMgrPtr _mgr;
	int _count;
	BOOL _mtOrdered;
};

template<>
class TContacts : public coclass<Contacts>
{
public:
	TContacts() {}

	static TCHAR *get_progid();

	long GetCount() { return 0; }

	TContactPtr GetItem(const variant_t& idx) { return NULL; }
};
#endif // __CONTACTS_H__