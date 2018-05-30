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

#ifndef __CONTACT_H__
#define __CONTACT_H__

#include "wab_item.h"

#define TContact coclass_implementation<Contact>

template<>
class TContact: public coclass<Contact>
{
public:

	TContact();
	~TContact();

	static TCHAR *get_progid();
	static com_ptr<IContact> newInstance();

	tagWABITEMTYPE GetType() { return WAB_CONTACT; }

	void SetObjectData(NKTWABMgrPtr mgr, LPSRowSet rowAB, BOOL rowOrdered, LPABCONT container, 
						BOOL newObject=FALSE);
	void SetObjectData(NKTWABMgrPtr mgr, LPENTRYID lpEntryID, ULONG cbEntryID);

	BOOL IsValid();
	
	bstr_t GetEntryID();

	/**
	Equivalent to GetDisplayName
	*/
	bstr_t GetName();

	/**
	Equivalent to PutDisplayName
	*/
	void PutName(bstr_t);

	void Save();
	void Delete();

	bstr_t GetDisplayName();
	void PutDisplayName(bstr_t);
	bstr_t GetFirstName();
	void PutFirstName(bstr_t);
	bstr_t GetLastName();
	bstr_t GetMiddleName();
	void PutMiddleName(bstr_t);
	void PutLastName(bstr_t);
	bstr_t GetTitle();
	void PutTitle(bstr_t);
	bstr_t GetComment();
	void PutComment(bstr_t);

	
	bstr_t GetHomeAddressCity();
	void PutHomeAddressCity(bstr_t);
	bstr_t GetCompanyName();
	void PutCompanyName(bstr_t);
	bstr_t GetHomeAddressCountry();
	void PutHomeAddressCountry(bstr_t);

	bstr_t GetDefaultEmailAddress();
	void PutDefaultEmailAddress(bstr_t);
	long GetDefaultEmailAddressIndex();
	void PutDefaultEmailAddressIndex(long index);

	bstr_t GetEmail1Address();
	void PutEmail1Address(bstr_t);
	bstr_t GetEmail2Address();
	void PutEmail2Address(bstr_t);
	bstr_t GetEmail3Address();
	void PutEmail3Address(bstr_t);
	bstr_t GetHomeFaxNumber();
	void PutHomeFaxNumber(bstr_t);
	bstr_t GetHomeAddressStreet();
	void PutHomeAddressStreet(bstr_t);
	bstr_t GetJobTitle();
	void PutJobTitle(bstr_t);
	bstr_t GetMobileTelephoneNumber();
	void PutMobileTelephoneNumber(bstr_t);
	bstr_t GetPagerTelephoneNumber();
	void PutPagerTelephoneNumber(bstr_t value);
	bstr_t GetHomeTelephoneNumber();
	void PutHomeTelephoneNumber(bstr_t);
	bstr_t GetHomeAddressPostalCode();
	void PutHomeAddressPostalCode(bstr_t);
	bstr_t GetHomeAddressState();
	void PutHomeAddressState(bstr_t);
	bstr_t GetBusinessAddressStreet();
	void PutBusinessAddressStreet(bstr_t);
	bstr_t GetBusinessAddressCity();
	void PutBusinessAddressCity(bstr_t);
	bstr_t GetBusinessAddressCountry();
	void PutBusinessAddressCountry(bstr_t);
	bstr_t GetPersonalHomePage();
	void PutPersonalHomePage(bstr_t);
	bstr_t GetBusinessFaxNumber();
	void PutBusinessFaxNumber(bstr_t);
	bstr_t GetBusinessTelephoneNumber();
	void PutBusinessTelephoneNumber(bstr_t);
	bstr_t GetBusinessAddressPostalCode();
	void PutBusinessAddressPostalCode(bstr_t);
	bstr_t GetBusinessAddressState();
	void PutBusinessAddressState(bstr_t);
	bstr_t GetBusinessDepartment();
	void PutBusinessDepartment(bstr_t);
	bstr_t GetBusinessHomePage();
	void PutBusinessHomePage(bstr_t);

	datetime_t GetCreationTime();
	datetime_t GetLastModificationTime();

protected:

private:
	NKTWABMgrPtr _wab;
	NKTItem _item;
};

#endif