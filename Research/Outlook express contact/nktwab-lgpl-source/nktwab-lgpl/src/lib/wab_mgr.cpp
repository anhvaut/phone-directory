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

#include "wab_mgr.h"
#include "folder.h"
#include "WABLib.h"


static const SizedSPropTagArray(ieidMax, ptaEid)=
{
    ieidMax,
    {
        PR_DISPLAY_NAME,
        PR_ENTRYID, // Binary
		PR_OBJECT_TYPE,
		PR_CONTAINER_FLAGS,
		PR_EMAIL_ADDRESS,
		PR_GIVEN_NAME,
		PR_SURNAME,
		PR_DISPLAY_NAME_PREFIX,
		PR_HOME_ADDRESS_CITY,
		PR_COMPANY_NAME,
		PR_HOME_ADDRESS_COUNTRY,
		PR_CONTACT_EMAIL_ADDRESSES,
		PR_CONTACT_DEFAULT_ADDRESS_INDEX,
		PR_HOME_FAX_NUMBER,
		PR_HOME_ADDRESS_STREET,
		PR_TITLE,
		PR_MIDDLE_NAME,
		PR_CELLULAR_TELEPHONE_NUMBER,
		PR_HOME_TELEPHONE_NUMBER,
		PR_HOME_ADDRESS_POSTAL_CODE,
		PR_HOME_ADDRESS_STATE_OR_PROVINCE,
		PR_STREET_ADDRESS,
		PR_LOCALITY,
		PR_COUNTRY,
		PR_BUSINESS_HOME_PAGE,
		PR_BUSINESS_FAX_NUMBER,
		PR_BUSINESS_TELEPHONE_NUMBER,
		PR_POSTAL_CODE,
		PR_STATE_OR_PROVINCE,
		PR_BIRTHDAY,
		PR_LAST_MODIFICATION_TIME,
		PR_CREATION_TIME,
    }
};


static const SizedSPropTagArray(iemailMax, ptaEmail)=
{
    iemailMax,
    {
        PR_DISPLAY_NAME,
        PR_ENTRYID,
        PR_EMAIL_ADDRESS,
        PR_OBJECT_TYPE,
		PR_CONTAINER_FLAGS,
		PR_GIVEN_NAME,
		PR_SURNAME,
		PR_DISPLAY_NAME_PREFIX,
		PR_HOME_ADDRESS_CITY,
		PR_COMPANY_NAME,
		PR_HOME_ADDRESS_COUNTRY,
		PR_CONTACT_EMAIL_ADDRESSES,
		PR_HOME_FAX_NUMBER,
		PR_HOME_ADDRESS_STREET,
		PR_TITLE,
		PR_MIDDLE_NAME,
		PR_CELLULAR_TELEPHONE_NUMBER,
		PR_HOME_TELEPHONE_NUMBER,
		PR_HOME_ADDRESS_POSTAL_CODE,
		PR_HOME_ADDRESS_STATE_OR_PROVINCE,
		PR_STREET_ADDRESS,
		PR_LOCALITY,
		PR_COUNTRY,
		PR_BUSINESS_HOME_PAGE,
		PR_BUSINESS_FAX_NUMBER,
		PR_BUSINESS_TELEPHONE_NUMBER,
		PR_POSTAL_CODE,
		PR_STATE_OR_PROVINCE,
		PR_BIRTHDAY,
		PR_LAST_MODIFICATION_TIME,
		PR_CREATION_TIME,
    }
};


NKTWABMgr::NKTWABMgr()
{
	_lpAdrBook = NULL;
	_lpWABObject = NULL;
	_hinstWAB = NULL;
}

NKTWABMgr::~NKTWABMgr()
{
	if(_lpWABObject) {
		_lpWABObject->Release();
		_lpWABObject = NULL;
	}
	if(_lpAdrBook) {
		_lpAdrBook->Release();
		_lpAdrBook = NULL;
	}

	//WABLib::Release();
}

void NKTWABMgr::Init(LPCTSTR pszFileName, ULONG ulFlags)
{

	_hinstWAB = WABLib::GetModule();

	// if we loaded the dll, get the entry point 
	//
	_lpfnWABOpen = (LPWABOPEN) GetProcAddress(_hinstWAB, "WABOpen");
	if(_lpfnWABOpen)
	{
		HRESULT hr = E_FAIL;
		WAB_PARAM wp = {0};

		wp.ulFlags = ulFlags;
		wp.cbSize = sizeof(WAB_PARAM);
		wp.szFileName = (LPSTR) pszFileName;

		// if we choose not to pass in a WAB_PARAM object, 
		// the default WAB file will be opened up
		//
		hr = _lpfnWABOpen(&_lpAdrBook , &_lpWABObject , &wp, 0);
		if(SUCCEEDED(hr)) {
			_initialized = TRUE;
		}
		else {
			throw std::runtime_error("NKTWABMgr::Init: Cannot Initialize WAB.");
		}
	}
}

void NKTWABMgr::AllocateBuffer(ULONG cbSize, LPVOID *lppBuffer)
{
	HRESULT hr = _lpWABObject->AllocateBuffer(cbSize, lppBuffer);
	if(FAILED(hr)) {
		throw std::runtime_error("NKTWABMgr::AllocateBuffer: Cannot allocate buffer.");
	}
}

void NKTWABMgr::AllocateMore(ULONG cbSize, LPVOID lpObject, LPVOID *lppBuffer)
{
	HRESULT hr = _lpWABObject->AllocateMore(cbSize, lpObject, lppBuffer);
	if(FAILED(hr)) {
		throw std::runtime_error("NKTWABMgr::AllocateMore: Cannot allocate buffer.");
	}
}

void NKTWABMgr::FreeBuffer(void *buf)
{
	_lpWABObject->FreeBuffer(buf);
}

void NKTWABMgr::FreeProws(LPSRowSet rowSet)
{
	ULONG row;

	if(rowSet != NULL) {
		for(row = 0; row < rowSet->cRows; row++) {
			_lpWABObject->FreeBuffer(rowSet->aRow[row].lpProps);
		}

		_lpWABObject->FreeBuffer(rowSet);
	}
}


HRESULT NKTWABMgr::OpenContainer(LPENTRYID lpEntryID, ULONG cbEntryID, 
								 LPABCONT *lpContainer)
{
	static BYTE folderEntryID[] = {0x00, 0x00, 0x00, 0x00, 0xC0, 0x91, 0xAD, 0xD3,
									0x51, 0x9D, 0xCF, 0x11, 0xA4, 0xA9, 0x00, 0xAA,
									0x00, 0x47, 0xFA, 0xA4, 0x07, 0x04, 0x00, 0x00,
									0x00};

	ULONG ulObjType;
	HRESULT hr;

	if(cbEntryID != 4) {
		hr = _lpAdrBook->OpenEntry(cbEntryID,
					    			(LPENTRYID) lpEntryID,
						    		NULL,
									MAPI_MODIFY,
									&ulObjType,
									(LPUNKNOWN *) lpContainer);
	}
	else {
		LPBYTE lpCompleteEntryID;

		// containers must be opened with the long entry id. Otherwise, they are not useful
		// to create contacts / groups. So, we hard code the first part of the entry id and
		// append the id part.
		AllocateBuffer(sizeof(folderEntryID) + 4, (LPVOID *) &lpCompleteEntryID);
		memcpy(lpCompleteEntryID, folderEntryID, sizeof(folderEntryID));
		memcpy(lpCompleteEntryID+sizeof(folderEntryID), lpEntryID, 4);

		hr = _lpAdrBook->OpenEntry(sizeof(folderEntryID)+4,
					    			(LPENTRYID) lpCompleteEntryID,
						    		NULL,
									MAPI_MODIFY,
									&ulObjType,
									(LPUNKNOWN *) lpContainer);

		FreeBuffer(lpCompleteEntryID);
	}

	return hr;
}

HRESULT NKTWABMgr::OpenEntry(LPENTRYID lpEntryID, ULONG cbEntryID, ULONG *objType,
								 LPMAPIPROP *lppMapiProp)
{
	ULONG ulObjType;

	HRESULT hr = _lpAdrBook->OpenEntry(cbEntryID, (LPENTRYID) lpEntryID, NULL, 
										MAPI_MODIFY, &ulObjType, 
										(LPUNKNOWN *) lppMapiProp);

	if(objType) {
		*objType = ulObjType;
	}

	return hr;
}

HRESULT NKTWABMgr::OpenRootContainer(LPABCONT *rootContainer)
{
	ULONG cbEntryID;
	ULONG ulObjType;
	LPENTRYID lpEntryID;
	HRESULT hr;

	hr = GetAdrBook()->GetPAB(&cbEntryID, &lpEntryID);
	if(SUCCEEDED(hr)) {
		hr = GetAdrBook()->OpenEntry(cbEntryID,
					    			(LPENTRYID) lpEntryID,
									(LPCIID) NULL,
									0,
									&ulObjType,
									(LPUNKNOWN *) rootContainer);

		FreeBuffer(lpEntryID);
	}

	return hr;
}

void NKTWABMgr::CreateContainerObjects(LPENTRYID lpEntryID, ULONG cbEntryID, 
									   LPABCONT *lppContainer, LPMAPITABLE *lppMT, 
									   BOOL *mtOrdered)
{
	HRESULT hr = OpenContainer(lpEntryID, cbEntryID, lppContainer);
	if(SUCCEEDED(hr)) {
		hr = GetTable(*lppContainer, lppMT, 0);

		// if it doesn't have a table -> it is a empty folder
		if(SUCCEEDED(hr)) {
			hr = OrderTable(*lppMT);

			if(mtOrdered) {
				*mtOrdered = SUCCEEDED(hr);
			}
		}
	}
	else {
		throw std::runtime_error("NKTWABMgr:CreateContainerObjects: Error opening container object.");
	}
}

HRESULT NKTWABMgr::GetTable(LPABCONT lpContainer, LPMAPITABLE *lpAB, ULONG ulFlags)
{
	return lpContainer->GetContentsTable(ulFlags, lpAB);
}

HRESULT NKTWABMgr::OrderTable(LPMAPITABLE lpAB)
{
    // Order the columns in the ContentsTable to conform to the
    // ones we want - which are mainly DisplayName, EntryID and
    // ObjectType
    // The table is guaranteed to set the columns in the order 
    // requested
    //
	return lpAB->SetColumns((LPSPropTagArray) &ptaEid, 0 );
}

HRESULT NKTWABMgr::SeekTable(LPMAPITABLE lpAB, int i)
{
	return lpAB->SeekRow(BOOKMARK_BEGINNING, i, NULL);
}

HRESULT NKTWABMgr::QueryTable(LPMAPITABLE lpAB, ULONG ulFlags, LPSRowSet* lpRowAB)
{
    HRESULT hr = E_FAIL;

	hr = lpAB->QueryRows(1, ulFlags, lpRowAB);

	if(HR_FAILED(hr)) {
		goto exit;
	}

	if(*lpRowAB) {
		if((*lpRowAB)->cRows == 0) {
			FreeProws(*lpRowAB);
			hr = E_FAIL;
		}
	}

exit:

	return hr;
}

ULONG NKTWABMgr::GetRowType(LPSRowSet lpRowAB, BOOL mtOrdered)
{
	SRow lpRow = lpRowAB->aRow[0];

	if(mtOrdered) {
		return (ULONG) lpRow.lpProps[ieidPR_OBJECT_TYPE].Value.ul;
	}

	int index = GetPropertyIndex(lpRowAB, PR_ENTRYID);
	// assume a simple contact if it does not have the property.
	ULONG ret = MAPI_MAILUSER;

	if(index != -1) {
		HRESULT hr;
		LPMAPIPROP mapiProp;
		
		hr = OpenEntry((LPENTRYID) lpRow.lpProps[index].Value.bin.lpb, 
							(ULONG) lpRow.lpProps[index].Value.bin.cb, 
							&ret, &mapiProp);
		if(FAILED(hr)) {
			ret = MAPI_MAILUSER;
		}
		else {
			mapiProp->Release();
		}
	}

	return ret;
}

LPENTRYID NKTWABMgr::GetRowEntryID(LPSRowSet lpRowAB, BOOL mtOrdered)
{
	SRow lpRow = lpRowAB->aRow[0];

	if(mtOrdered) {
		return (LPENTRYID) lpRow.lpProps[ieidPR_ENTRYID].Value.bin.lpb;
	}

	int index = GetPropertyIndex(lpRowAB, PR_ENTRYID);

	if(index != -1) {
		return (LPENTRYID) lpRow.lpProps[index].Value.bin.lpb;
	}

	return NULL;
}

ULONG NKTWABMgr::GetRowCbEntryID(LPSRowSet lpRowAB, BOOL mtOrdered)
{
	SRow lpRow = lpRowAB->aRow[0];

	if(mtOrdered) {
		return (ULONG) lpRow.lpProps[ieidPR_ENTRYID].Value.bin.cb;
	}

	int index = GetPropertyIndex(lpRowAB, PR_ENTRYID);

	if(index != -1) {
		return (ULONG) lpRow.lpProps[index].Value.bin.cb;
	}

	return NULL;
}

int NKTWABMgr::GetPropertyIndex(LPSRowSet lpRowAB, ULONG tag)
{
	int index = -1;
	SRow lpRow = lpRowAB->aRow[0];

	for(int i=0; i<(int)lpRow.cValues; i++) {
		if(lpRow.lpProps[i].ulPropTag == tag) {
			index = i;
			break;
		}
	}

	return index;
}

HRESULT NKTWABMgr::GetRowByIndex(ULONG index, ULONG objType, LPMAPITABLE mt, BOOL mtOrdered, LPSRowSet *prowAB)
{
	HRESULT hr;
	LPSRowSet rowAB;

	if(mt == NULL) {
		return E_INVALIDARG;
	}

	hr = S_OK;
	
	for(int i=0; SUCCEEDED(hr); i++) {
		hr = SeekTable(mt, i);

		if(SUCCEEDED(hr)) {
			hr = QueryTable(mt, 0, &rowAB);

			if(SUCCEEDED(hr)) {
				if(GetRowType(rowAB, mtOrdered) == objType) {
					if(index-- == 0) {
						break;
					}
				}

				FreeProws(rowAB);
			}
		}
	}

	if(SUCCEEDED(hr)) {
		*prowAB = rowAB;
	}

	return hr;
}

HRESULT NKTWABMgr::GetRowByEntryID(LPENTRYID entryID, ULONG cbEntryID, ULONG objType, LPMAPITABLE mt, BOOL mtOrdered, LPSRowSet *prowAB)
{
	HRESULT hr;
	LPSRowSet rowAB;

	hr = S_OK;
	
	for(int i=0; SUCCEEDED(hr); i++) {
		hr = SeekTable(mt, i);

		if(SUCCEEDED(hr)) {
			hr = QueryTable(mt, 0, &rowAB);

			if(SUCCEEDED(hr)) {
				if(GetRowType(rowAB, mtOrdered) == objType) {
					if(!CompareEntryIDs(NKTWABMgr::GetRowEntryID(rowAB, mtOrdered), NKTWABMgr::GetRowCbEntryID(rowAB, mtOrdered),
						entryID, cbEntryID)) {
						break;
					}
				}

				FreeProws(rowAB);
			}
		}
	}

	if(SUCCEEDED(hr)) {
		*prowAB = rowAB;
	}

	return hr;
}

ULONG NKTWABMgr::GetRowCount(ULONG objType, LPMAPITABLE mt, BOOL mtOrdered)
{
	HRESULT hr;
	LPSRowSet rowAB = NULL;
	ULONG count = 0;

	// if it doesn't have a mapi table it's a empty folder so leave _count = 0 and exit
	if(mt != NULL) {
		hr = S_OK;

		for(int i=0; SUCCEEDED(hr); i++) {
			hr = SeekTable(mt, i);

			if(SUCCEEDED(hr)) {
				hr = QueryTable(mt, 0, &rowAB);

				if(SUCCEEDED(hr)) {
					if(GetRowType(rowAB, mtOrdered) == objType) {
						count++;
					}

					FreeProws(rowAB);
				}
			}
		}
	}

	return count;
}

LPENTRYID NKTWABMgr::CreateEntryIDFromString(const char *entryIDString, ULONG *pcbEntryID)
{
	LPENTRYID entryID;
	char *entryIDPtr;
	ULONG cbEntryID;

	if(entryIDString == NULL || strlen(entryIDString) == 0) {
		cbEntryID = 0;
		entryID = NULL;
	}
	else {
		cbEntryID = strlen(entryIDString)/2;
		AllocateBuffer(cbEntryID, (LPVOID *) &entryID);
		entryIDPtr = (char *) entryID;

		for(int i=0; i<(int)cbEntryID; i++) {
			char first = entryIDString[i*2];
			char second = entryIDString[i*2+1];
			char byteValue;

			// high part of the byte
			byteValue = (isdigit(first) ? first-'0' : first-'a'+10) << 4;
			// low part of the byte
			byteValue += (isdigit(second) ? second-'0' : second-'a'+10);
			entryIDPtr[i] = byteValue;
		}
	}

	if(pcbEntryID) {
		*pcbEntryID = cbEntryID;
	}

	return entryID;
}

void NKTWABMgr::GetShortEntryID(const LPSBinary lpEntryID, LPSBinary lpShortEntryID)
{
	// SUPER HACK: if I use the entry id of the LPMAPIPROP object it doesn't work.
	// But if I use the entry id of LPMAILUSER that returns the LPABCONT::CreateEntry 
	// function it works. This entry id is at the end of the entry id returned by
	// LPMAPIPROP and it has 4 bytes.
	lpShortEntryID->cb = 4;
	// point it to the last 4 bytes.
	lpShortEntryID->lpb = ((LPBYTE) lpEntryID->lpb) 
							+ lpEntryID->cb - 4;
}

LPMAPIPROP NKTWABMgr::CreateContact(LPABCONT lpContainer)
{
	LPMAPIPROP lpMapiPropEntry = NULL;
	HRESULT hr;
	ULONG cbEntryID = 0;

	hr = lpContainer->CreateEntry(cbEntryID, NULL,1, &lpMapiPropEntry);
	if(FAILED(hr)) {
		throw std::runtime_error("NKTWABMgr::CreateContact: CreateEntry.");
	}

	return lpMapiPropEntry;
}

LPMAPIPROP NKTWABMgr::CreateGroup(LPABCONT lpContainer)
{
	HRESULT hr;
	SPropValue groupPropArray[10];
	DWORD auxNum = 0;
	int propCount = 0;
	LPMAPIPROP lpMapiPropEntry = NULL;

	hr = lpContainer->CreateEntry(0, (LPENTRYID) NULL, 
									1, (LPMAPIPROP *) &lpMapiPropEntry);
	if(FAILED(hr)) {
		throw std::runtime_error("NKTWABMgr::CreateGroup: CreateEntry.");
	}

	groupPropArray[propCount].ulPropTag = PR_OBJECT_TYPE;
	groupPropArray[propCount++].Value.l = MAPI_DISTLIST;

	hr = lpMapiPropEntry->SetProps(propCount, groupPropArray, NULL);
	if(FAILED(hr)) {
		throw std::runtime_error("NKTWABMgr::CreateGroup: SetProps.");
	}

	hr = lpMapiPropEntry->SaveChanges(KEEP_OPEN_READWRITE);
	if(FAILED(hr)) {
		throw std::runtime_error("NKTWABMgr::CreateGroup: SaveChanges.");
	}

	return lpMapiPropEntry;
}

LPMAPIPROP NKTWABMgr::CreateFolder(const TCHAR *folderName)
{
	LPABCONT lpRootContainer;
	HRESULT hr;
	SPropTagArray propTagArray;
	LPSPropValue lpPropArray;
	SPropValue folderPropArray[10];
	ULONG ulcValues;
	DWORD auxNum = 0;
	int propCount = 0;
	LPMAILUSER lpMailUser;
	LPENTRYID lpEntryID;
	ULONG cbEntryID;

	hr = OpenRootContainer(&lpRootContainer);
	if(FAILED(hr)) {
		throw std::runtime_error("NKTWABMgr::CreateFolder: OpenRootContainer.");
	}

	propTagArray.cValues = 1;
	propTagArray.aulPropTag[0] = PR_DEF_CREATE_DL;

	hr = lpRootContainer->GetProps(&propTagArray, 0, &ulcValues, &lpPropArray);
	if(FAILED(hr)) {
		throw std::runtime_error("NKTWABMgr::CreateFolder: GetProps.");
	}

	lpEntryID = (LPENTRYID) lpPropArray[0].Value.bin.lpb;
	cbEntryID = lpPropArray[0].Value.li.LowPart;
	

	folderPropArray[propCount].dwAlignPad = 0;
	folderPropArray[propCount].ulPropTag = PR_DISPLAY_NAME;
	// the pointer is the same with UNICODE
	folderPropArray[propCount++].Value.lpszA = (char *) folderName;

	folderPropArray[propCount].ulPropTag = PR_OBJECT_TYPE;
	folderPropArray[propCount++].Value.l = MAPI_ABCONT;

	// HACK: This property is necessary to contacts be created inside it.
	// This property is used in the distribution lists as a array of short entry ids.
	folderPropArray[propCount].ulPropTag = PR_DISTLIST_ENTRYIDS;
	folderPropArray[propCount].Value.bin.lpb = (LPBYTE) &auxNum;
	folderPropArray[propCount++].Value.bin.cb = 1;

	folderPropArray[propCount].ulPropTag = PR_WAB_SHAREDFOLDER; //???
	folderPropArray[propCount++].Value.l = 0;

	folderPropArray[propCount].ulPropTag = PR_WAB_FOLDEROWNER;
	// the pointer is the same with UNICODE
	folderPropArray[propCount++].Value.lpszA = (char*) _T("{E06398C4-87B2-413D-BDE5-B4DE4782D563}");

	hr = lpRootContainer->CreateEntry(cbEntryID, (LPENTRYID) lpEntryID, 
									1, (LPMAPIPROP *) &lpMailUser);
	if(FAILED(hr)) {
		throw std::runtime_error("NKTWABMgr::CreateFolder: CreateEntry.");
	}

	hr = lpMailUser->SetProps(propCount, folderPropArray, NULL);
	if(FAILED(hr)) {
		throw std::runtime_error("NKTWABMgr::CreateFolder: SetProps.");
	}

	hr = lpMailUser->SaveChanges(KEEP_OPEN_READWRITE);

	if(FAILED(hr)) {
		throw std::runtime_error("NKTWABMgr::CreateFolder: SaveChanges.");
	}

	lpRootContainer->Release();

	return lpMailUser;
}

int NKTWABMgr::CompareEntryIDs(LPENTRYID entryID1, ULONG cbEntryID1, 
								LPENTRYID entryID2, ULONG cbEntryID2)
{
	LPBYTE lpbEntryID1 = (LPBYTE) entryID1;
	LPBYTE lpbEntryID2 = (LPBYTE) entryID2;

	// compare only last 4 bytes of the short entry id
	lpbEntryID1 += cbEntryID1-4;
	lpbEntryID2 += cbEntryID2-4;

	return memcmp(lpbEntryID1, lpbEntryID2, 4);
}