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

#ifndef __NKTWAB_MANAGER_H__
#define __NKTWAB_MANAGER_H__

#include "counted_ptr.h"

enum {
    ieidPR_DISPLAY_NAME = 0,
    ieidPR_ENTRYID,
	ieidPR_OBJECT_TYPE,
	ieidPR_CONTAINER_FLAGS,
	ieidPR_EMAIL_ADDRESS,
	ieidPR_GIVEN_NAME,
	ieidPR_SURNAME,
	ieidPR_DISPLAY_NAME_PREFIX,
	ieidPR_HOME_ADDRESS_CITY,
	ieidPR_COMPANY_NAME,
	ieidPR_HOME_ADDRESS_COUNTRY,
	ieidPR_CONTACT_EMAIL_ADDRESSES,
	ieidPR_CONTACT_DEFAULT_ADDRESS_INDEX,
	ieidPR_HOME_FAX_NUMBER,
	ieidPR_HOME_ADDRESS_STREET,
	ieidPR_TITLE,
	ieidPR_MIDDLE_NAME,
	ieidPR_CELLULAR_TELEPHONE_NUMBER,
	ieidPR_HOME_TELEPHONE_NUMBER,
	ieidPR_HOME_ADDRESS_POSTAL_CODE,
	ieidPR_HOME_ADDRESS_STATE_OR_PROVINCE,
	ieidPR_STREET_ADDRESS,
	ieidPR_LOCALITY,
	ieidPR_COUNTRY,
	ieidPR_BUSINESS_HOME_PAGE,
	ieidPR_BUSINESS_FAX_NUMBER,
	ieidPR_BUSINESS_TELEPHONE_NUMBER,
	ieidPR_POSTAL_CODE,
	ieidPR_STATE_OR_PROVINCE,
	ieidPR_BIRTHDAY,
	ieidPR_C4L_BACKUP_SELECTED,
	ieidPR_C4L_SYNC_SELECTED,
    ieidPR_C4L_MOBILE_LINKED,
	ieidPR_USER_ID,
	ieidPR_SUBSC_ID,
	ieidPR_CONTACT_ID,
	ieidPR_LINKABLE,
	ieidPR_LINKED,
	ieidPR_SYNCFLAG,
	ieidPR_LAST_MODIFICATION_TIME,
	ieidPR_CREATION_TIME,
    ieidMax
};

enum {
    iemailPR_DISPLAY_NAME = 0,
    iemailPR_ENTRYID,
    iemailPR_EMAIL_ADDRESS,
    iemailPR_OBJECT_TYPE,
	iemailPR_CONTAINER_FLAGS,
	iemailPR_GIVEN_NAME,
	iemailPR_SURNAME,
	iemailPR_DISPLAY_NAME_PREFIX,
	iemailPR_HOME_ADDRESS_CITY,
	iemailPR_COMPANY_NAME,
	iemailPR_HOME_ADDRESS_COUNTRY,
	iemailPR_CONTACT_EMAIL_ADDRESSES,
	iemailPR_CONTACT_DEFAULT_ADDRESS_INDEX,
	iemailPR_HOME_FAX_NUMBER,
	iemailPR_HOME_ADDRESS_STREET,
	iemailPR_TITLE,
	iemailPR_MIDDLE_NAME,
	iemailPR_CELLULAR_TELEPHONE_NUMBER,
	iemailPR_HOME_TELEPHONE_NUMBER,
	iemailPR_HOME_ADDRESS_POSTAL_CODE,
	iemailPR_HOME_ADDRESS_STATE_OR_PROVINCE,
	iemailPR_STREET_ADDRESS,
	iemailPR_LOCALITY,
	iemailPR_COUNTRY,
	iemailPR_BUSINESS_HOME_PAGE,
	iemailPR_BUSINESS_FAX_NUMBER,
	iemailPR_BUSINESS_TELEPHONE_NUMBER,
	iemailPR_POSTAL_CODE,
	iemailPR_STATE_OR_PROVINCE,
	iemailPR_BIRTHDAY,
	iemailPR_C4L_BACKUP_SELECTED,
	iemailPR_C4L_SYNC_SELECTED,
	iemailPR_C4L_MOBILE_LINKED,
	iemailPR_USER_ID,
	iemailPR_SUBSC_ID,
	iemailPR_CONTACT_ID,
	iemailPR_LINKABLE,
	iemailPR_LINKED,
	iemailPR_SYNCFLAG,
	iemailPR_LAST_MODIFICATION_TIME,
	iemailPR_CREATION_TIME,
    iemailMax
};

// undocumented properties
#define PR_WAB_FOLDEROWNER                           PROP_TAG( PT_TSTRING,   0x800d)
#define PR_WAB_SHAREDFOLDER							 PROP_TAG( PT_LONG,		 0x800c)
#define PR_DISTLIST_ENTRYIDS						 PROP_TAG( PT_MV_BINARY, 0x6600)


class NKTWABMgr
{
public:
	NKTWABMgr();
	~NKTWABMgr();

	/**
	Initialize object. It calls all the wab library stuff.
	*/
	void Init(LPCTSTR pszFileName=NULL, ULONG ulFlags = 0);

	/**
	Returns TRUE if initialization was successful.
	*/
	BOOL IsInitialized() { return _initialized; }

	/**
	Get the address book of this manager.
	*/
	LPADRBOOK GetAdrBook() { return _lpAdrBook; }

	/**
	Allocates a buffer using IWABObject.
	If it cannot allocate it throws a exception.
	*/
	void AllocateBuffer(ULONG cbSize, LPVOID *lppBuffer);

	/**
	Allocates a buffer using IWABObject linked to a previous allocated buffer lpObject.
	Calling FreeBuffer(lpObject) will free this buffer too.
	If it cannot allocate it throws a exception.
	*/
	void AllocateMore(ULONG cbSize, LPVOID lpObject, LPVOID *lppBuffer);

	/**
	Frees buffer allocated by WAB.
	*/
	void FreeBuffer(void *buf);

	/**
	Free the rows in the rowset and the SRowSet itself.
	*/
	void FreeProws(LPSRowSet rowSet);

	/**
	Open container of the address book.
	*/
	HRESULT OpenContainer(LPENTRYID lpEntryID, ULONG cbEntryID, LPABCONT *lppMapiProp);

	/**
	Open entry of the address book.
	objType can be null.
	*/
	HRESULT OpenEntry(LPENTRYID lpEntryID, ULONG cbEntryID, ULONG *objType, LPMAPIPROP *lppMapiProp);

	/**
	Open wab root folder as a container that can be used to create folders.
	*/
	HRESULT OpenRootContainer(LPABCONT *);

	/**
	Creates the container object and its table.
	If it cannot create the table mtOrdered contains FALSE.
	*/
	void CreateContainerObjects(LPENTRYID lpEntryID, ULONG cbEntryID, LPABCONT *lppContainer,
								LPMAPITABLE *mp, BOOL *mtOrdered);

	static HRESULT GetTable(LPABCONT, LPMAPITABLE*, ULONG ulFlags = 0);
	
	static HRESULT OrderTable(LPMAPITABLE lpAB);
	static HRESULT SeekTable(LPMAPITABLE lpAB, int i);
	
	HRESULT QueryTable(LPMAPITABLE lpAB, ULONG ulFlags, LPSRowSet* lpRowAB);

	/**
	Get the PR_OBJECT_TYPE of the object pointed by the row.
	*/
	ULONG GetRowType(LPSRowSet lpRowAB, BOOL mtOrdered);

	/**
	Get the PR_ENTRYID of the object pointed by the row.
	*/
	static LPENTRYID GetRowEntryID(LPSRowSet lpRowAB, BOOL mtOrdered);

	/**
	Get the PR_ENTRYID size of the object pointed by the row.
	*/
	static ULONG GetRowCbEntryID(LPSRowSet lpRowAB, BOOL mtOrdered);

	/**
	Get the index of the row set that is placed the property with the specified tag.
	Returns -1 if the property is not found.
	*/
	static int GetPropertyIndex(LPSRowSet lpRowAB, ULONG tag);

	/**
	Returns the number of rows that are objType.
	*/
	ULONG GetRowCount(ULONG objType, LPMAPITABLE mt, BOOL mtOrdered);

	/**
	Get the row of the specified index (0 based). The index indicates that this function 
	returns	the index'th element of objType in mt.
	*/
	HRESULT GetRowByIndex(ULONG index, ULONG objType, LPMAPITABLE mt, BOOL mtOrdered, LPSRowSet *prowAB);

	/**
	Get the row of the ENTRYID filtered by objType.
	*/
	HRESULT GetRowByEntryID(LPENTRYID entryID, ULONG cbEntryID, ULONG objType, LPMAPITABLE mt, BOOL mtOrdered, 
							LPSRowSet *prowAB);

	/**
	Creates a LPENTRYID from a string that contains the ENTRYID.
	cbEntryID contains (if not NULL) the size of the returned LOENTRYID.
	Caller must release the returned buffer.
	*/
	LPENTRYID CreateEntryIDFromString(const char *entryIDString, ULONG *pcbEntryID);

	/**
	Get an entry id with the last part of the original entry id (only last 4 bytes).
	The returned entry id is pointed to the original so releasing the original will
	destroy the short one too.
	*/
	void GetShortEntryID(const LPSBinary lpEntryID, LPSBinary lpShortEntryID);

	/**
	Create a contact in the specified container.
	*/
	static LPMAPIPROP CreateContact(LPABCONT lpContainer);

	/**
	Create a group in the specified container.
	*/
	static LPMAPIPROP CreateGroup(LPABCONT lpContainer);

	/**
	Creates a folder.
	*/
	LPMAPIPROP NKTWABMgr::CreateFolder(const TCHAR *folderName);

	/**
	Returns 0 if both entry ids are equal.
	NOTE: this comparisson only verifies that the last for bytes are equal (short entry id).
	*/
	int CompareEntryIDs(LPENTRYID entryID1, ULONG cbEntryID1, 
						LPENTRYID entryID2, ULONG cbEntryID2);


protected:

private:
	BOOL _initialized;
    HINSTANCE _hinstWAB;
    LPWABOPEN _lpfnWABOpen;
    LPADRBOOK _lpAdrBook;
    LPWABOBJECT _lpWABObject;
};

typedef CountedPtr<NKTWABMgr> NKTWABMgrPtr;

#endif // __NKTWAB_MANAGER_H__
