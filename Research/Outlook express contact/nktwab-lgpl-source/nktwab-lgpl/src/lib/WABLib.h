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

// WABLib.h: interface for the WABLib class.
//
//////////////////////////////////////////////////////////////////////

class WABLib  
{

protected:

	static HINSTANCE hInst;
	static TCHAR szWABDllPath[MAX_PATH*4];

public:

	static HINSTANCE GetModule() {
		return hInst;
	}

	static TCHAR* GetLibraryPath() {
		if (szWABDllPath[0] != '\0') {
			return szWABDllPath;
		}

		TCHAR tmpszWABDllPath[MAX_PATH*4];

		DWORD  dwType = 0;
		ULONG  cbData = sizeof(tmpszWABDllPath);
		HKEY hKey = NULL;
		
		// First we look under the default WAB DLL path location in the
		// Registry. 
		// WAB_DLL_PATH_KEY is defined in wabapi.h
		//
		if(ERROR_SUCCESS == RegOpenKeyEx(HKEY_LOCAL_MACHINE, WAB_DLL_PATH_KEY, 0, KEY_READ, &hKey)) {
			RegQueryValueEx(hKey, _T(""), NULL, &dwType, (LPBYTE) tmpszWABDllPath, &cbData);
		}

		if(hKey) {
			RegCloseKey(hKey);
		}
		
		// if the Registry came up blank, we do a load library on the wab32.dll
		// WAB_DLL_NAME is defined in wabapi.h
		//

		// Environment Variable Replace
		ExpandEnvironmentStrings((lstrlen(tmpszWABDllPath)) ? tmpszWABDllPath : WAB_DLL_NAME, szWABDllPath, MAX_PATH*4);
		
		return szWABDllPath;
	}

	
	static HINSTANCE WABLib::Load() {
		hInst = ::LoadLibrary( GetLibraryPath() );
		
		if (!hInst) {
			throw std::runtime_error("NKTWABLib::Init: Cannot Load NKTWAB Library.");
		}

		return (HINSTANCE)hInst;
	}

	static void WABLib::Release() {
		FreeLibrary(hInst);
		hInst = NULL;
	}
};