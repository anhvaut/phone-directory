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

#ifndef __NKTWAB_ITEM_H__
#define __NKTWAB_ITEM_H__


/* Global Includes */
#pragma warning( disable : 4786 )

#include <windows.h>
#include <string>
#include <wab.h>
#include <map>
#include <set>

#define ROOT 0xffffffff
#define DISTRIBUTIONLIST MAPI_DISTLIST

typedef list<LPSPropValue> PropList;
typedef set<ULONG> PropTagSet;
typedef std::map<ULONG, LPSPropValue> PropMap;


class NKTItem
{
public:
	NKTItem();
	~NKTItem();

	/**
	Set item data.
	*/
	void SetObjectData(NKTWABMgrPtr mgr, LPSRowSet rowAB, BOOL rowOrdered, LPABCONT container=NULL, 
						BOOL newObject=FALSE);

	void SetObjectData(NKTWABMgrPtr mgr, LPENTRYID lpEntryID, ULONG cbEntryID, 
							LPABCONT container=NULL, BOOL newObject=FALSE);

	/**
	Returns TRUE if the contact was created and wasn't saved yet
	*/
	BOOL IsNew() { return _isNew; }

	/**
	Get unique identifier of the object.
	This function returns NULL if it's a new object and it wasn't saved.
	*/
	LPENTRYID GetEntryID();

	/**
	Get unique identifier size of the object.
	This function returns 0 if it's a new object and it wasn't saved.
	*/
	ULONG GetEntryIDSize();

	/**
	Returns TRUE if the specified tag exists.
	*/
	BOOL HasField(ULONG tag);

	/**
	Returns the string that represents the property tag or a empty string if 
	doesn't exist.
	*/
	bstr_t GetFieldOrBlank(ULONG tag);

	/**
	Get the last 4 bytes of the entry id. This id is a unique identifier of each wab item.
	*/
	bstr_t GetShortEntryIDOrBlank();

	/**
	Set a string property.
	*/
	void SetStringField(ULONG tag, bstr_t value);

	/**
	Get index item of the email address array field (PR_CONTACT_EMAIL_ADDRESSES) and the
	primary 
	*/
	bstr_t GetEmailAddressOrBlank(int index);

	/**
	Set index item of the email address array field (PR_CONTACT_EMAIL_ADDRESSES)
	*/
	void SetEmailAddress(bstr_t strValue, ULONG index);

	/**
	Get the contents of PR_CONTACT_DEFAULT_ADDRESS_INDEX or -1 if it doesn't exist.
	*/
	int GetDefaultEmailAddressIndex();

	/**
	Set the contents of PR_CONTACT_DEFAULT_ADDRESS_INDEX.
	*/
	void SetDefaultEmailAddressIndex(int index);

	/**
	Gets default email address.
	*/
	bstr_t GetDefaultEmailAddress();

	/**
	Set the default email address and update index and email array.
	*/
	void SetDefaultEmailAddress(bstr_t emailAddress);

	/**
	Get the number of elements of the email array.
	*/
	long GetEmailAddressCount();

	/**
	Get the specified date time property.
	*/
	datetime_t GetDateTimeField(ULONG tag);

	/**
	Returns TRUE if the contact is valid.
	New contacts are not valid until saved.
	*/
	BOOL IsValid();

	/**
	Save changed properties to the object.
	If the object is new it's stored.
	*/
	void Save();

	/**
	Delete this item.
	*/
	void Delete();

	/**
	Get object type: MAPI_ABCONT, MAPI_DISTLIST or MAPI_MAILUSER
	*/
	ULONG GetObjectType() { return _objType; }

	/**
	Set object type: MAPI_ABCONT, MAPI_DISTLIST or MAPI_MAILUSER
	*/
	void SetObjectType(ULONG objType) { _objType = objType; }

	/**
	Only useful when the item is a MAPI_DISTLIST object.
	It returns a SBinaryArray that contains a list of short entry id (only the last 4 
	bytes) that are the members of the distribution list.
	The returned array will exist while this object is alive.
	*/
	SBinaryArray *GetDistributionListArray();

	/**
	Append a new value to the distribution list of this item.
	*/
	void AppendEntryIDToDistList(LPENTRYID lpContactEntryID, ULONG cbContactEntryID);

	/**
	Remove the entry id from the distribution list of this item.
	*/
	void RemoveEntryIDFromDistList(LPENTRYID lpContactEntryID, ULONG cbContactEntryID);

protected:
	/**
	Get the specified property.
	*/
	LPSPropValue GetField(ULONG tag);
	
	/**
	Set the specified prop.
	*/
	void SetField(LPSPropValue propProp);

	/**
	Remove the specified prop.
	*/
	void RemoveField(ULONG tag);

	/**
	Converts a property value to a string.
	*/
	bstr_t ConvertToString(LPSPropValue lpVal);

private:
	LPMAPIPROP _mapiProp;
	NKTWABMgrPtr _mgr;

	BOOL _isNew;
	LPABCONT _container;

	PropMap _cachedProps;
	PropTagSet _notFoundProps;
	PropMap _changedProps;

	ULONG _objType;
};

#endif // __NKTWAB_ITEM_H__
