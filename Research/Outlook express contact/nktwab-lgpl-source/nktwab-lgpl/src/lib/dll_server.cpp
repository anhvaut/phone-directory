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

#include "folder.h"
#include "folders.h"
#include "group.h"
#include "groups.h"
#include "nktwab.h"
#include "contact.h"
#include "contacts.h"
#include "abstract_classes.h"
#include "WABLib.h"

using namespace comet;

typedef com_server< NKTWABLib::type_library > SERVER;

// Declare and implement DllMain, DllGetClassObject, DllRegisterServer,
// DllUnregisterServer and DllCanUnloadNow.
// These are implemented by simple forwarding onto a static method of
// the same name on SERVER:
// i.e. DllMain simply calls SERVER::DllMain.
//COMET_DECLARE_DLL_FUNCTIONS(SERVER)

extern "C" BOOL WINAPI DllMain(HINSTANCE hInstance, DWORD dwReason, LPVOID)
{
	switch(dwReason) {
	case DLL_PROCESS_ATTACH:
		{

		OSVERSIONINFO OSversion;
		OSversion.dwOSVersionInfoSize=sizeof(OSVERSIONINFO);
		::GetVersionEx(&OSversion);
		if( OSversion.dwMajorVersion >= 6 ) {
			OutputDebugStringA("warning: NKTWAB is not 100% compatible with Windows Vista");
		}
			WABLib::Load();
			break;
		}

	case DLL_PROCESS_DETACH:
		{
			WABLib::Release();
			break;
		}
	}

	return SERVER::DllMain(hInstance, dwReason, 0);
}

STDAPI DllCanUnloadNow()
{
	return SERVER::DllCanUnloadNow();
}

STDAPI DllGetClassObject(REFCLSID rclsid, REFIID riid, LPVOID* ppv)
{
	return SERVER::DllGetClassObject(rclsid, riid, ppv);
}

STDAPI DllRegisterServer()
{
	return SERVER::DllRegisterServer();
}

STDAPI DllUnregisterServer()
{
	return SERVER::DllUnregisterServer();
}
