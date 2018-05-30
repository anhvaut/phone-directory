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

#ifndef __FOLDER_H__
#define __FOLDER_H__

#include "wab_item.h"

#define TFolder coclass_implementation<Folder>

template<>
class TFolder: public coclass<Folder>
{
public:
	TFolder();
	~TFolder();

	static TCHAR *get_progid();
	static com_ptr<IFolder> newInstance();

	tagWABITEMTYPE GetType() { return WAB_FOLDER; }

	/**
	Set parent table and object row of the item.
	If it's the root folder the parent table is NULL and rowAB is NULL.
	*/
	void SetObjectData(NKTWABMgrPtr mgr, LPSRowSet rowAB, BOOL rowOrdered, BOOL newObject=FALSE);
	void SetObjectData(NKTWABMgrPtr mgr, LPENTRYID lpEntryID, ULONG cbEntryID);

	BOOL IsValid();

	void Save();
	void Delete();
	
	bstr_t GetEntryID();
	bstr_t GetName();
	void PutName(bstr_t);
	TFoldersPtr GetFolders();
	TContactsPtr GetContacts();
	TGroupsPtr GetGroups();

private:
	NKTItem _item;
	NKTWABMgrPtr _mgr;

	LPABCONT _container;
	LPMAPITABLE _mt;
	BOOL _mtOrdered;
};
#endif