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

#include "wab_item.h"



NKTItem::NKTItem()
{
	_mapiProp = NULL;
	_isNew = TRUE;
	_container = NULL;
	_objType = 0;
}

NKTItem::~NKTItem()
{
	if(_mapiProp) {
		_mapiProp->Release();
	}

	if(_container) {
		_container->Release();
	}

	for(PropMap::iterator it=_cachedProps.begin(); it!=_cachedProps.end(); it++) {
		LPSPropValue lpPropArray = it->second;
		if(lpPropArray) {
			_mgr->FreeBuffer(lpPropArray);
		}
	}

	for(it=_changedProps.begin(); it!=_changedProps.end(); it++) {
		LPSPropValue lpPropArray = it->second;
		if(lpPropArray) {
			_mgr->FreeBuffer(lpPropArray);
		}
	}
}

void NKTItem::SetObjectData(NKTWABMgrPtr mgr, LPSRowSet rowAB, BOOL rowOrdered, LPABCONT container, BOOL newObject)
{
	LPENTRYID lpEntryID = NULL;
	ULONG cbEntryID = NULL;

	if(!newObject && rowAB) {
		lpEntryID = mgr->GetRowEntryID(rowAB, rowOrdered);
		cbEntryID = mgr->GetRowCbEntryID(rowAB, rowOrdered);
	}

	SetObjectData(mgr, lpEntryID, cbEntryID, container, newObject);
}

void NKTItem::SetObjectData(NKTWABMgrPtr mgr, LPENTRYID lpEntryID, ULONG cbEntryID, 
							LPABCONT container, BOOL newObject)
{

	HRESULT hr;
	LPENTRYID lpCopyEntryID = NULL;
	LPSPropValue entryIDProp;

	_isNew = newObject;
	_mgr = mgr;
	_container = container;

	if(_container) {
		_container->AddRef();
	}

	if(!newObject) {
		// set object type if it's an existing object
		hr = _mgr->OpenEntry(lpEntryID, cbEntryID, &_objType, &_mapiProp);
		if(FAILED(hr)) {
			_mapiProp = NULL;
		}

		_mgr->AllocateBuffer(sizeof(SPropValue), (LPVOID *) &entryIDProp);

		if(cbEntryID != 0) {
			_mgr->AllocateMore(cbEntryID, entryIDProp, (LPVOID *) &lpCopyEntryID);
		}

		entryIDProp->ulPropTag = PR_ENTRYID;
		entryIDProp->Value.bin.cb = cbEntryID;
		entryIDProp->Value.bin.lpb = (LPBYTE) lpCopyEntryID;

		memcpy(lpCopyEntryID, lpEntryID, cbEntryID);

		_cachedProps[PR_ENTRYID] = entryIDProp;
	}
}

LPENTRYID NKTItem::GetEntryID()
{
	LPSPropValue entryProp = GetField(PR_ENTRYID);
	if(entryProp && entryProp->Value.bin.cb != 0) {
		return (LPENTRYID) entryProp->Value.bin.lpb;
	}

	return NULL;
}

ULONG NKTItem::GetEntryIDSize()
{
	LPSPropValue entryProp = GetField(PR_ENTRYID);
	if(entryProp) {
		return entryProp->Value.bin.cb;
	}

	return NULL;
}

LPSPropValue NKTItem::GetField(ULONG tag)
{
	LPSPropValue lpPropArray;
	ULONG       ulcValues;
	SPropTagArray propTagArray;
	HRESULT hr;
	PropMap::iterator it;

	// if it was added, return it
	it = _changedProps.find(tag);
	if(it != _changedProps.end()) {
		lpPropArray = it->second;
		return lpPropArray;
	}

	// new objects only have changed props.
	if(IsNew() || _mapiProp == NULL) {
		return NULL;
	}

	if(_notFoundProps.find(tag) != _notFoundProps.end()) {
		return NULL;
	}

	// if it cached, return it
	it = _cachedProps.find(tag);
	if(it != _cachedProps.end()) {
		lpPropArray = it->second;
		return lpPropArray;
	}

	propTagArray.cValues = 1;
	propTagArray.aulPropTag[0] = tag;
	
	hr = _mapiProp->GetProps(&propTagArray, 0, &ulcValues, &lpPropArray);

	if(SUCCEEDED(hr)) {
		// if it doesn't exist free the buffer and return a empty prop
		if(hr == MAPI_W_ERRORS_RETURNED) {
			_notFoundProps.insert(tag);
			_mgr->FreeBuffer(lpPropArray);
		}
		else {
			_cachedProps[tag] = lpPropArray;
			return lpPropArray;
		}
	}

	return NULL;
}

void NKTItem::SetField(LPSPropValue propProp)
{
	LPSPropValue oldValue;
	PropMap::iterator it;

	it = _changedProps.find(propProp->ulPropTag);
	if(it != _changedProps.end()) {
		oldValue = it->second;
		if(oldValue) {
			_mgr->FreeBuffer(oldValue);
		}
	}

	_changedProps[propProp->ulPropTag] = propProp;
}

void NKTItem::RemoveField(ULONG tag)
{
	LPSPropValue oldValue;
	PropMap::iterator it;

	it = _changedProps.find(tag);
	if(it != _changedProps.end()) {
		oldValue = it->second;
		if(oldValue) {
			_mgr->FreeBuffer(oldValue);
		}
	}

	_changedProps[tag] = NULL;
}

BOOL NKTItem::HasField(ULONG tag)
{
	LPSPropValue lpPropArray;
	ULONG       ulcValues;
	SPropTagArray propTagArray;
	HRESULT hr;
	BOOL ret = FALSE;

	// if it was added, return TRUE
	if(_changedProps.find(tag) != _changedProps.end()) {
		return TRUE;
	}

	// new objects only have changed props.
	if(IsNew()) {
		return FALSE;
	}

	if(_notFoundProps.find(tag) != _notFoundProps.end()) {
		return FALSE;
	}

	// if it cached, return TRUE
	if(_cachedProps.find(tag) != _cachedProps.end()) {
		return TRUE;
	}

	propTagArray.cValues = 1;
	propTagArray.aulPropTag[0] = tag;
	
	hr = _mapiProp->GetProps(&propTagArray, 0, &ulcValues, &lpPropArray);

	if(SUCCEEDED(hr)) {
		// if it doesn't exist free the buffer and return FALSE
		if(hr == MAPI_W_ERRORS_RETURNED) {
			_notFoundProps.insert(tag);
			_mgr->FreeBuffer(lpPropArray);
		}
		else {
			ret = TRUE;
			_cachedProps[tag] = lpPropArray;
		}
	}

	return ret;
}

bstr_t NKTItem::GetFieldOrBlank(ULONG tag)
{
	bstr_t strValue = bstr_t("");

	LPSPropValue lpVal = GetField(tag);
	if(lpVal) {
		strValue = ConvertToString(lpVal);
	}

	return strValue;
}

void NKTItem::SetStringField(ULONG tag, bstr_t propValue)
{
	LPSPropValue lpProp;
	tstring s = (tstring) propValue;
	TCHAR *newValue;

	if(propValue.empty()) {
		RemoveField(tag);
	}
	else {
		_mgr->AllocateBuffer(sizeof(SPropValue), (LPVOID *) &lpProp);

		_mgr->AllocateMore((s.length()+1)*sizeof(TCHAR), lpProp, (LPVOID *) &newValue);
		lpProp->dwAlignPad = 0;
		lpProp->ulPropTag = tag;

		// it's a union so we can set the pointer to unicode or ansi
		lpProp->Value.lpszA = (char *) newValue;
		
		_tcscpy(newValue, s.data());

		SetField(lpProp);
	}
}

datetime_t NKTItem::GetDateTimeField(ULONG tag)
{
	datetime_t dtValue;
	LPSPropValue lpProp = GetField(tag);

	if(lpProp) {
		FILETIME ft = lpProp->Value.ft;
		SYSTEMTIME st;

		if(FileTimeToSystemTime(&ft, &st)) {
			dtValue.from_systemtime(st);
		}
	}

	return dtValue;
}

bstr_t NKTItem::GetEmailAddressOrBlank(int index)
{
	bstr_t strValue;
	LPSPropValue lpProp;

	lpProp = GetField(PR_CONTACT_EMAIL_ADDRESSES_W);
	if(lpProp) {
		if((int)lpProp->Value.MVszW.cValues > index) {
			strValue = bstr_t(lpProp->Value.MVszW.lppszW[index]);
		}
	}
	// use this property only when the other's not set
	else if(index == 0) {
		strValue = GetFieldOrBlank(PR_EMAIL_ADDRESS);
		if(!strValue.empty()) {
			return strValue;
		}
	}

	return strValue;
}

void NKTItem::SetEmailAddress(bstr_t strValue, ULONG index)
{
	std::wstring wStr = (std::wstring) strValue;
	LPSPropValue lpProp = NULL, lpChangedProp = NULL;
	PropMap::iterator it;
	int i;
	WCHAR *newValue;
	BOOL isInChanged = FALSE;

	if(index > 2) {
		throw std::runtime_error("NKTItem: Email Subscript out of range");
	}

	lpProp = GetField(PR_CONTACT_EMAIL_ADDRESSES_W);
	if(lpProp != NULL) {
		it = _changedProps.find(PR_CONTACT_EMAIL_ADDRESSES_W);
		if(it == _changedProps.end()) {
			it = _cachedProps.find(PR_CONTACT_EMAIL_ADDRESSES_W);
			if(it != _cachedProps.end()) {
				lpProp = it->second;

				// remove it and it'll be added to changed if not empty.
				_cachedProps.erase(it);
				
				if(lpProp->Value.MVszW.cValues == 0) {
					_mgr->FreeBuffer(lpProp);
					lpProp = NULL;
				}
			}
		}
		else {
			isInChanged = TRUE;
		}
	}

	// if it is in _changedProps it is ok
	if(!isInChanged && (lpProp == NULL || lpProp->Value.MVszW.cValues == 0)) {
		// nothing to do
		if(strValue.empty()) {
			return;
		}

		// I'm safe here: I don't know if the pointer in lpProp->Value.MVszW is valid or
		// not, so we start again releasing previous buffer and allocating again.
		if(lpProp) {
			_cachedProps.erase(lpProp->ulPropTag);
			_mgr->FreeBuffer(lpProp);
			lpProp = NULL;
		}

		_mgr->AllocateBuffer(sizeof(SPropValue), (LPVOID *) &lpProp);
		// allocate the pointer linked to the property.
		_mgr->AllocateMore(sizeof(LPVOID)*3, lpProp, (LPVOID *) &lpProp->Value.MVszW.lppszW);

		lpProp->Value.MVszW.lppszW[0] = NULL;
		lpProp->Value.MVszW.lppszW[1] = NULL;
		lpProp->Value.MVszW.lppszW[2] = NULL;

		lpProp->ulPropTag = PR_CONTACT_EMAIL_ADDRESSES_W;
		lpProp->Value.MVszW.cValues = 0;
	}

	_changedProps[PR_CONTACT_EMAIL_ADDRESSES_W] = lpProp;

	// NOTE: when I override a string pointer I'm not releasing the previous buffer
	// because I cannot do it here because it is liked to the lpProp buffer. It will 
	// be released when lpProp is released
	if(!wStr.empty()) {
		_mgr->AllocateMore((wStr.length()+1)*sizeof(WCHAR), lpProp, (LPVOID *) &newValue);

		wcscpy(newValue, wStr.data());

		// set the lower empty string if index is greater
		if(lpProp->Value.MVszA.cValues <= index) {
			lpProp->Value.MVszW.lppszW[lpProp->Value.MVszW.cValues++] = newValue;
		}
		else {
			// don't release previous buffer
			lpProp->Value.MVszW.lppszW[index] = newValue;
		}
	}
	else {
		// if a string of the middle is cleared move all the upper strings to the lower
		// places
		if(lpProp->Value.MVszA.cValues != 0 && lpProp->Value.MVszA.cValues > index) {
			// don't release previous buffer
			for(i=index; i<(int)lpProp->Value.MVszA.cValues-1; i++) {
				lpProp->Value.MVszW.lppszW[i] = lpProp->Value.MVszW.lppszW[i+1];
			}

			lpProp->Value.MVszW.lppszW[lpProp->Value.MVszW.cValues-1] = NULL;

			if(--lpProp->Value.MVszW.cValues == 0) {
				_mgr->FreeBuffer(lpProp);
				lpProp = NULL;

				_changedProps[PR_CONTACT_EMAIL_ADDRESSES_W] = NULL;
			}
		}
	}

	// update the email property if this email is the default.
	if(index == GetDefaultEmailAddressIndex()) {
		if(wStr.empty()) {
			// only clear the default email if there are no more mails.
			if(lpProp == NULL) {
				SetStringField(PR_EMAIL_ADDRESS, strValue);
			}
		}
		else {
			SetStringField(PR_EMAIL_ADDRESS, strValue);
		}
	}
}

int NKTItem::GetDefaultEmailAddressIndex()
{
	int index = -1;

	LPSPropValue lpProp;

	lpProp = GetField(PR_CONTACT_DEFAULT_ADDRESS_INDEX);
	if(lpProp) {
		index = lpProp->Value.l;
	}

	return index;
}

void NKTItem::SetDefaultEmailAddressIndex(int index)
{
	LPSPropValue lpProp;

	if(index >= GetEmailAddressCount()) {
		throw std::runtime_error("NKTItem: SetDefaultEmailAddressIndex: Index out of range.");
	}

	_mgr->AllocateBuffer(sizeof(SPropValue), (LPVOID *) &lpProp);

	lpProp->dwAlignPad = 0;
	lpProp->ulPropTag = PR_CONTACT_DEFAULT_ADDRESS_INDEX;
	lpProp->Value.l = index;

	SetField(lpProp);

	if(GetDefaultEmailAddressIndex() == index) {
		bstr_t emailAddress = GetEmailAddressOrBlank(index);

		SetStringField(PR_EMAIL_ADDRESS, emailAddress);
	}
}

bstr_t NKTItem::GetDefaultEmailAddress()
{
	return GetFieldOrBlank(PR_EMAIL_ADDRESS);
}

void NKTItem::SetDefaultEmailAddress(bstr_t emailAddress)
{
	SetStringField(PR_EMAIL_ADDRESS, emailAddress);

	if(GetEmailAddressCount() > 0 && GetDefaultEmailAddressIndex() >= 0) {
		SetEmailAddress(emailAddress, GetDefaultEmailAddressIndex());
	}
}

long NKTItem::GetEmailAddressCount()
{
	int count = 0;
	LPSPropValue lpProp;

	lpProp = GetField(PR_CONTACT_EMAIL_ADDRESSES_W);
	if(lpProp != NULL) {
		count = lpProp->Value.MVszW.cValues;
	}

	return count;
}

bstr_t NKTItem::GetShortEntryIDOrBlank()
{
	bstr_t ret;
	LPSPropValue lpProp;
	SPropValue shortEntryIDProp;

	lpProp = GetField(PR_ENTRYID);
	if(lpProp != NULL) {

		if(lpProp->Value.bin.cb != 0) {
			memcpy(&shortEntryIDProp, lpProp, sizeof(shortEntryIDProp));
			_mgr->GetShortEntryID(&lpProp->Value.bin, &shortEntryIDProp.Value.bin);
			ret = ConvertToString(&shortEntryIDProp);
		}
		else {
			ret = "";
		}
	}

	return ret;
}

SBinaryArray *NKTItem::GetDistributionListArray()
{
	int count = 0;
	LPSPropValue lpProp;

	lpProp = GetField(PR_DISTLIST_ENTRYIDS);
	if(lpProp != NULL) {
		return (&lpProp->Value.MVbin);
	}

	return NULL;
}

void NKTItem::AppendEntryIDToDistList(LPENTRYID lpContactEntryID, ULONG cbContactEntryID)
{
	if(lpContactEntryID) {
		LPSPropValue lpProp;
		SBinary *lpBin, *lpOldBin;
		SBinaryArray *lpOldValue;
		int cValues = 1;
		ULONG arraySize = 0;

		lpOldValue = GetDistributionListArray();
		if(lpOldValue) {
			cValues = lpOldValue->cValues + 1;
			lpOldBin = lpOldValue->lpbin;
		}

		_mgr->AllocateBuffer(sizeof(SPropValue), (LPVOID *) &lpProp);
		_mgr->AllocateMore(sizeof(SBinary)*cValues, lpProp, (LPVOID *) &lpBin);

		lpProp->dwAlignPad = 0;
		lpProp->ulPropTag = PR_DISTLIST_ENTRYIDS;

		lpProp->Value.MVbin.cValues = cValues;
		lpProp->Value.MVbin.lpbin = lpBin;

		for(int i=0; i<(int)cValues; i++) {
			if(lpOldValue && i < (int)lpOldValue->cValues) {
				_mgr->AllocateMore(lpOldValue->lpbin[i].cb, lpProp, 
									(LPVOID *) &lpBin[i].lpb);

				lpBin[i].cb = lpOldValue->lpbin[i].cb;
				memcpy(lpBin[i].lpb, lpOldValue->lpbin[i].lpb, 
						lpOldValue->lpbin[i].cb);
			}
			else {
				_mgr->AllocateMore(cbContactEntryID, lpProp, 
									(LPVOID *) &lpBin[i].lpb);
				lpBin[i].cb = cbContactEntryID;
				memcpy(lpBin[i].lpb, lpContactEntryID, cbContactEntryID);
			}
		}

		SetField(lpProp);
	}
}

void NKTItem::RemoveEntryIDFromDistList(LPENTRYID lpContactEntryID, ULONG cbContactEntryID)
{
	if(lpContactEntryID) {
		LPSPropValue lpProp;
		SBinary *lpBin;
		SBinary *lpOldBin;
		SBinaryArray *distList;
		LPENTRYID lpEntryID;
		ULONG cbEntryID;

		distList = GetDistributionListArray();
		if(distList == NULL) {
			return;
		}

		lpOldBin = distList->lpbin;

		// try to find it in the list
		for(int i=0; i<(int)distList->cValues; i++) { 
			lpEntryID = (LPENTRYID) lpOldBin[i].lpb;
			cbEntryID = lpOldBin[i].cb;
			
			// generate a new property with a binary array if the item is found
			if(cbEntryID == cbContactEntryID &&
				!memcmp(lpEntryID, lpContactEntryID, cbEntryID)) {
				_mgr->AllocateBuffer(sizeof(SPropValue), (LPVOID *) &lpProp);
				_mgr->AllocateMore(sizeof(SBinary)*(distList->cValues-1), lpProp, 
									(LPVOID *) &lpBin);

				// copy all values until the value that must be deleted.
				for(int j=0; j<i; j++) {
					_mgr->AllocateMore(lpOldBin[j].cb, lpProp, 
										(LPVOID *) &lpBin[j].lpb);
					lpBin[j].cb = lpOldBin[j].cb;
					memcpy(lpBin[j].lpb, lpOldBin[j].lpb, lpOldBin[j].cb);
				}

				// now copy all the values that are above of the one to delete.
				for(j=i; j<(int)distList->cValues-1; j++) {
					_mgr->AllocateMore(lpOldBin[j+1].cb, lpProp, 
										(LPVOID *) &lpBin[j].lpb);
					lpBin[j].cb = lpOldBin[j+1].cb;
					memcpy(lpBin[j].lpb, lpOldBin[j+1].lpb, lpOldBin[j+1].cb);
				}

				lpProp->Value.MVbin.cValues = distList->cValues-1;
				lpProp->ulPropTag = PR_DISTLIST_ENTRYIDS;
				lpProp->Value.MVbin.lpbin = lpBin;

				SetField(lpProp);

				break;
			}
		}
	}
}

BOOL NKTItem::IsValid()
{
	return (_mapiProp != NULL);
}

void NKTItem::Save()
{
	SPropTagArray propTag;
	char error[1024];
	HRESULT hr;

	if(IsNew()) {
		if(_objType == MAPI_ABCONT) {
			bstr_t name = GetFieldOrBlank(PR_DISPLAY_NAME);

			_mapiProp = _mgr->CreateFolder(name.t_str().c_str());
			if(_mapiProp == NULL) {
				throw std::runtime_error("NKTItem:Save: Error CreateFolder.");
			}
		}
		else if(_objType == MAPI_DISTLIST) {
			_mapiProp = _mgr->CreateGroup(_container);
			if(_mapiProp == NULL) {
				throw std::runtime_error("NKTItem:Save: Error CreateContact.");
			}
		}
		else {
			_mapiProp = _mgr->CreateContact(_container);
			if(_mapiProp == NULL) {
				throw std::runtime_error("NKTItem:Save: Error CreateContact.");
			}
		}
	}

	propTag.cValues = 1;

	if(_mapiProp) {
		// HACK: folders opened with the long entry id cannot change their names so I
		// reopen it with the short entry id.
		if(!IsNew() && GetObjectType() == MAPI_ABCONT) {
			SBinary bEntryID;
			SBinary bShortEntryID;

			bEntryID.cb = GetEntryIDSize();
			bEntryID.lpb = (LPBYTE) GetEntryID();

			_mgr->GetShortEntryID(&bEntryID, &bShortEntryID);

			_mapiProp->Release();

			hr = _mgr->OpenEntry((LPENTRYID) bShortEntryID.lpb, bShortEntryID.cb, 
									&_objType, &_mapiProp);
			if(FAILED(hr)) {
				throw std::runtime_error("NKTItem:Save: Cannot open object changes.");
			}
		}

		for(PropMap::iterator it=_changedProps.begin(); it!=_changedProps.end(); it++) {
			LPSPropValue propValue = it->second;
			ULONG tag = it->first;

			propTag.aulPropTag[0] = tag;

			// ignore failure in deletion.
			hr = _mapiProp->DeleteProps(&propTag, NULL);


			// if the BinaryArray values count is 0 the 
			// setProp method throws an error. 
			// This is kind a bug-fix
			int shouldSet = 1;
			if( tag == PR_DISTLIST_ENTRYIDS ) {
				shouldSet = 0;
				SBinaryArray distList;
				distList = (SBinaryArray)propValue->Value.MVbin;
				shouldSet = (distList.cValues > 0);
			}


			// if propValue is NULL the property was deleted.
			if(propValue && shouldSet) {
				hr = _mapiProp->SetProps(1, propValue, NULL);
				if(FAILED(hr)) {
					sprintf(error, "NKTItem:Save: Cannot set property tag: %x", propValue->ulPropTag);
					throw std::runtime_error(error);
				}
			}
			// delete the index reference to the array. Otherwise, the SaveChanges fails
			else if(tag == PR_CONTACT_EMAIL_ADDRESSES_W) {
				propTag.aulPropTag[0] = PR_CONTACT_DEFAULT_ADDRESS_INDEX;

				hr = _mapiProp->DeleteProps(&propTag, NULL);
			}
		}

		if(_changedProps.size() > 0) {
			hr = _mapiProp->SaveChanges(FORCE_SAVE | KEEP_OPEN_READWRITE);
			if(FAILED(hr)) {
				if(hr == MAPI_E_COLLISION) {
					throw std::runtime_error("NKTItem:Save: Collision occurred. The entry already exists.");
				}
				else {
					throw std::runtime_error("NKTItem:Save: Cannot save changes.");
				}
			}
		}
	}

	_isNew = FALSE;
}

void NKTItem::Delete()
{
	HRESULT hr;

	if(!IsNew()) {
		ENTRYLIST baEntryID;
		SBinary bEntryID, bShortEntryID;
		LPABCONT rootContainer;

		hr = _mgr->OpenRootContainer(&rootContainer);
		if(FAILED(hr)) {
			throw std::runtime_error("NKTItem:Delete: Error OpenRootContainer.");
		}

		bEntryID.cb = GetEntryIDSize();
		bEntryID.lpb = (LPBYTE) GetEntryID();

		baEntryID.cValues = 1;
		baEntryID.lpbin = &bEntryID;

		// folders cannot be deleted using the long id so we do it with the last 4 bytes
		hr = rootContainer->DeleteEntries((LPENTRYLIST) &baEntryID, 0);
		if(FAILED(hr) || hr == MAPI_W_PARTIAL_COMPLETION) {
			_mgr->GetShortEntryID(&bEntryID, &bShortEntryID);

			baEntryID.cValues = 1;
			baEntryID.lpbin = &bShortEntryID;

			hr = rootContainer->DeleteEntries((LPENTRYLIST) &baEntryID, 0);
			if(FAILED(hr)) {
				throw std::runtime_error("NKTItem: Error deleting object.");
			}
		}

		rootContainer->Release();
	}
}

bstr_t NKTItem::ConvertToString(LPSPropValue lpVal)
{
	bstr_t strValue;

	if(lpVal) {
		// if binary create a string with the hexa value
		if(PROP_TYPE(lpVal->ulPropTag) == PT_BINARY) {
			char *binValue = new char[lpVal->Value.bin.cb*2 + 1];

			memset(binValue, 0, lpVal->Value.bin.cb*2 + 1);
			for(int i = 0; i<(int)lpVal->Value.bin.cb; i++) {
				sprintf(binValue + i*2, "%x%x", (lpVal->Value.bin.lpb[i]>>4), (lpVal->Value.bin.lpb[i]&0xf));
			}

			strValue = binValue;

			delete binValue;
		}
		else if(PROP_TYPE(lpVal->ulPropTag) == PT_STRING8) {
			strValue = bstr_t(lpVal->Value.lpszA);
		}
		else if(PROP_TYPE(lpVal->ulPropTag) == PT_UNICODE) {
			strValue = bstr_t(lpVal->Value.lpszW);
		}
	}

	return strValue;
}