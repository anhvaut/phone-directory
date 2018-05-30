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
#include "contact.h"


TContact::TContact()
{
	_item.SetObjectType(MAPI_MAILUSER);
}

TContact::~TContact()
{
}

TCHAR *TContact::get_progid()
{
	return _T("NKTWABLib.Contact");
}

com_ptr<IContact> TContact::newInstance()
{
	com_ptr<IContact> ret(uuidof<Contact>());
	return ret;
}

void TContact::SetObjectData(NKTWABMgrPtr mgr, LPSRowSet rowAB, BOOL rowOrdered, LPABCONT container, BOOL newObject)
{
	_item.SetObjectData(mgr, rowAB, rowOrdered, container, newObject);
}

void TContact::SetObjectData(NKTWABMgrPtr mgr, LPENTRYID lpEntryID, ULONG cbEntryID)
{
	_item.SetObjectData(mgr, lpEntryID, cbEntryID);
}
BOOL TContact::IsValid()
{
	return _item.IsValid();
}

// Getters and Setters for all fields
bstr_t TContact::GetEntryID()
{
	return _item.GetFieldOrBlank(PR_ENTRYID);
//	return _item.GetShortEntryIDOrBlank();
}

bstr_t TContact::GetName()
{
	return GetDisplayName();
}

void TContact::PutName(bstr_t name)
{
	PutDisplayName(name);
}

bstr_t TContact::GetDisplayName()
{
	return _item.GetFieldOrBlank(PR_DISPLAY_NAME);
}

void TContact::PutDisplayName(bstr_t value)
{
	_item.SetStringField(PR_DISPLAY_NAME, value);
}

bstr_t TContact::GetFirstName()
{
	return _item.GetFieldOrBlank(PR_GIVEN_NAME);
}

void TContact::PutFirstName(bstr_t value)
{
	_item.SetStringField(PR_GIVEN_NAME, value);
}

bstr_t TContact::GetLastName()
{
	return _item.GetFieldOrBlank(PR_SURNAME);
}

void TContact::PutLastName(bstr_t value)
{
	_item.SetStringField(PR_SURNAME, value);
}

bstr_t TContact::GetMiddleName()
{
	return _item.GetFieldOrBlank(PR_MIDDLE_NAME);
}

void TContact::PutMiddleName(bstr_t value)
{
	_item.SetStringField(PR_MIDDLE_NAME, value);
}

bstr_t TContact::GetTitle()
{
	return _item.GetFieldOrBlank(PR_DISPLAY_NAME_PREFIX);
}

void TContact::PutTitle(bstr_t value)
{
	_item.SetStringField(PR_DISPLAY_NAME_PREFIX, value);
}

bstr_t TContact::GetComment()
{
	return _item.GetFieldOrBlank(PR_COMMENT);
}

void TContact::PutComment(bstr_t value)
{
	_item.SetStringField(PR_COMMENT, value);
}

bstr_t TContact::GetHomeAddressCity()
{
	return _item.GetFieldOrBlank(PR_HOME_ADDRESS_CITY);
}

void TContact::PutHomeAddressCity(bstr_t value)
{
	_item.SetStringField(PR_HOME_ADDRESS_CITY, value);
}

bstr_t TContact::GetCompanyName()
{
	return _item.GetFieldOrBlank(PR_COMPANY_NAME);
}

void TContact::PutCompanyName(bstr_t value)
{
	_item.SetStringField(PR_COMPANY_NAME, value);
}

bstr_t TContact::GetHomeAddressCountry()
{
	return _item.GetFieldOrBlank(PR_HOME_ADDRESS_COUNTRY);
}

void TContact::PutHomeAddressCountry(bstr_t value)
{
	_item.SetStringField(PR_HOME_ADDRESS_COUNTRY, value);
}

bstr_t TContact::GetDefaultEmailAddress()
{
	return _item.GetDefaultEmailAddress();
}

void TContact::PutDefaultEmailAddress(bstr_t value)
{
	_item.SetDefaultEmailAddress(value);
}

long TContact::GetDefaultEmailAddressIndex()
{
	long index = _item.GetDefaultEmailAddressIndex();

	// convert to 1-based
	if(index != -1) {
		++index;
	}

	return index;
}

void TContact::PutDefaultEmailAddressIndex(long index)
{
	// comes 1 based
	_item.SetDefaultEmailAddressIndex(index-1);
}

bstr_t TContact::GetEmail1Address()
{
	return _item.GetEmailAddressOrBlank(0);
}

void TContact::PutEmail1Address(bstr_t value)
{
	_item.SetEmailAddress(value, 0);
}

bstr_t TContact::GetEmail2Address()
{
	return _item.GetEmailAddressOrBlank(1);
}

void TContact::PutEmail2Address(bstr_t value)
{
	_item.SetEmailAddress(value, 1);
}

bstr_t TContact::GetEmail3Address()
{
	return _item.GetEmailAddressOrBlank(2);
}

void TContact::PutEmail3Address(bstr_t value)
{
	_item.SetEmailAddress(value, 2);
}

bstr_t TContact::GetHomeFaxNumber()
{
	return _item.GetFieldOrBlank(PR_HOME_FAX_NUMBER);
}

void TContact::PutHomeFaxNumber(bstr_t value)
{
	_item.SetStringField(PR_HOME_FAX_NUMBER, value);
}

bstr_t TContact::GetHomeAddressStreet()
{
	return _item.GetFieldOrBlank(PR_HOME_ADDRESS_STREET);
}

void TContact::PutHomeAddressStreet(bstr_t value)
{
	_item.SetStringField(PR_HOME_ADDRESS_STREET, value);
}

bstr_t TContact::GetJobTitle()
{
	return _item.GetFieldOrBlank(PR_TITLE);
}

void TContact::PutJobTitle(bstr_t value)
{
	_item.SetStringField(PR_TITLE, value);
}

bstr_t TContact::GetMobileTelephoneNumber()
{
	return _item.GetFieldOrBlank(PR_MOBILE_TELEPHONE_NUMBER);
}

void TContact::PutMobileTelephoneNumber(bstr_t value)
{
	_item.SetStringField(PR_MOBILE_TELEPHONE_NUMBER, value);
}

bstr_t TContact::GetPagerTelephoneNumber()
{
	return _item.GetFieldOrBlank(PR_PAGER_TELEPHONE_NUMBER);
}

void TContact::PutPagerTelephoneNumber(bstr_t value)
{
	_item.SetStringField(PR_PAGER_TELEPHONE_NUMBER, value);
}

bstr_t TContact::GetHomeTelephoneNumber()
{
	return _item.GetFieldOrBlank(PR_HOME_TELEPHONE_NUMBER);
}

void TContact::PutHomeTelephoneNumber(bstr_t value)
{
	_item.SetStringField(PR_HOME_TELEPHONE_NUMBER, value);
}

bstr_t TContact::GetHomeAddressPostalCode()
{
	return _item.GetFieldOrBlank(PR_HOME_ADDRESS_POSTAL_CODE);
}

void TContact::PutHomeAddressPostalCode(bstr_t value)
{
	_item.SetStringField(PR_HOME_ADDRESS_POSTAL_CODE, value);
}

bstr_t TContact::GetHomeAddressState()
{
	return _item.GetFieldOrBlank(PR_HOME_ADDRESS_STATE_OR_PROVINCE);
}

void TContact::PutHomeAddressState(bstr_t value)
{
	_item.SetStringField(PR_HOME_ADDRESS_STATE_OR_PROVINCE, value);
}

bstr_t TContact::GetBusinessAddressStreet()
{
	return _item.GetFieldOrBlank(PR_BUSINESS_ADDRESS_STREET);
}

void TContact::PutBusinessAddressStreet(bstr_t value)
{
	_item.SetStringField(PR_BUSINESS_ADDRESS_STREET, value);
}

bstr_t TContact::GetBusinessAddressCity()
{
	return _item.GetFieldOrBlank(PR_BUSINESS_ADDRESS_CITY);
}

void TContact::PutBusinessAddressCity(bstr_t value)
{
	_item.SetStringField(PR_BUSINESS_ADDRESS_CITY, value);
}

bstr_t TContact::GetBusinessAddressCountry()
{
	return _item.GetFieldOrBlank(PR_BUSINESS_ADDRESS_COUNTRY);
}

void TContact::PutBusinessAddressCountry(bstr_t value)
{
	_item.SetStringField(PR_BUSINESS_ADDRESS_COUNTRY, value);
}

bstr_t TContact::GetPersonalHomePage()
{
	return _item.GetFieldOrBlank(PR_PERSONAL_HOME_PAGE);
}

void TContact::PutPersonalHomePage(bstr_t value)
{
	_item.SetStringField(PR_PERSONAL_HOME_PAGE, value);
}

bstr_t TContact::GetBusinessFaxNumber()
{
	return _item.GetFieldOrBlank(PR_BUSINESS_FAX_NUMBER);
}

void TContact::PutBusinessFaxNumber(bstr_t value)
{
	_item.SetStringField(PR_BUSINESS_FAX_NUMBER, value);
}

bstr_t TContact::GetBusinessTelephoneNumber()
{
	return _item.GetFieldOrBlank(PR_BUSINESS_TELEPHONE_NUMBER);
}

void TContact::PutBusinessTelephoneNumber(bstr_t value)
{
	_item.SetStringField(PR_BUSINESS_TELEPHONE_NUMBER, value);
}

bstr_t TContact::GetBusinessAddressPostalCode()
{
	return _item.GetFieldOrBlank(PR_BUSINESS_ADDRESS_POSTAL_CODE);
}

void TContact::PutBusinessAddressPostalCode(bstr_t value)
{
	_item.SetStringField(PR_BUSINESS_ADDRESS_POSTAL_CODE, value);
}

bstr_t TContact::GetBusinessAddressState()
{
	return _item.GetFieldOrBlank(PR_BUSINESS_ADDRESS_STATE_OR_PROVINCE);
}

void TContact::PutBusinessAddressState(bstr_t value)
{
	_item.SetStringField(PR_BUSINESS_ADDRESS_STATE_OR_PROVINCE, value);
}

bstr_t TContact::GetBusinessDepartment()
{
	return _item.GetFieldOrBlank(PR_DEPARTMENT_NAME);
}

void TContact::PutBusinessDepartment(bstr_t value)
{
	_item.SetStringField(PR_DEPARTMENT_NAME, value);
}

bstr_t TContact::GetBusinessHomePage()
{
	return _item.GetFieldOrBlank(PR_BUSINESS_HOME_PAGE);
}

void TContact::PutBusinessHomePage(bstr_t value)
{
	_item.SetStringField(PR_BUSINESS_HOME_PAGE, value);
}

datetime_t TContact::GetCreationTime()
{
	return _item.GetDateTimeField(PR_CREATION_TIME);
}

datetime_t TContact::GetLastModificationTime()
{
	return _item.GetDateTimeField(PR_LAST_MODIFICATION_TIME);
}

void TContact::Save()
{
	_item.Save();
}

void TContact::Delete()
{
	_item.Delete();
}
