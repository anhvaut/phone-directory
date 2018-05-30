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

#ifndef __ABSTRACT_CLASSES_H__
#define __ABSTRACT_CLASSES_H__


#define TContactContainer coclass_implementation<ContactContainer>
#define TNKTWABItem coclass_implementation<NKTWABItem>

template<>
class TNKTWABItem : public coclass<NKTWABItem>
{
public:
	TNKTWABItem() {}

	static TCHAR *get_progid();

	tagWABITEMTYPE GetType() { return WAB_INVALID; }

	BOOL IsValid() { return FALSE; }

	bstr_t GetEntryID() { return ""; }
	bstr_t GetName() { return ""; }
	void PutName(bstr_t) {}

	void Save() {}
	void Delete() {}
};

template<>
class TContactContainer: public coclass<ContactContainer>
{
public:
	TContactContainer() {}

	static TCHAR *get_progid();

	tagWABITEMTYPE GetType() { return WAB_INVALID; }

	BOOL IsValid() { return FALSE; }

	void Save() {}
	void Delete() {}
	
	bstr_t GetEntryID() { return ""; }
	bstr_t GetName() { return ""; }
	void PutName(bstr_t) {}
	TContactsPtr GetContacts() { return NULL; }
};
#endif // __ABSTRACT_CLASSES_H__