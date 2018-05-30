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

#pragma once

#pragma warning(disable:4786)

#include <windows.h>
#include <vector>
#include <tchar.h>
#include <time.h>
#include <list>
#include <vector>
#include <wab.h>

#include "NKTWABLib.h"

using namespace comet;
using namespace NKTWABLib;
using namespace std;

#include "wab_mgr.h"

#define TNKTWABPtr com_ptr<INKTWAB>
#define TFolderPtr com_ptr<IFolder>
#define TFoldersPtr com_ptr<IFolders>
#define TGroupPtr com_ptr<IGroup>
#define TGroupsPtr com_ptr<IGroups>
#define TContactPtr com_ptr<IContact>
#define TContactsPtr com_ptr<IContacts>
#define TGroupContactsPtr com_ptr<IGroupContacts>
#define TFolderContactsPtr com_ptr<IFolderContacts>
#define TContactContainerPtr com_ptr<IContactContainer>
#define TNKTWABItemPtr com_ptr<INKTWABItem>
