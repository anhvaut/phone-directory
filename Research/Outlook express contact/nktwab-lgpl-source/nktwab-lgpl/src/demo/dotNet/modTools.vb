' NKTWAB is an ActiveX library that allows to create and modify Microsoft's Windows Address Book and Windows Vista's contacts.
' Copyright (C) 2007 Pablo Yabo.
' pablo.yabo@nektra.com
' 
' This library is free software; you can redistribute it and/or
' modify it under the terms of the GNU Lesser General Public
' License as published by the Free Software Foundation; either
' version 2.1 of the License, or (at your option) any later version.
' 
' This library is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
' Lesser General Public License for more details.
' 
' You should have received a copy of the GNU Lesser General Public
' License along with this library (LICENSE.TXT); if not, write to the Free Software
' Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA
' 02110-1301  USA
'
' http://www.gnu.org/licenses/lgpl.html

Option Strict Off
Option Explicit On
Module modTools
	Dim NKT As NKTWABLib.NKTWAB
	Dim RootFolder As NKTWABLib.Folder
	
	Public Enum WabItemType
		WabFolder = 1
		WabGroup = 2
		WabContact = 3
	End Enum
	
	Public Sub Initialize()
		NKT = New NKTWABLib.NKTWAB
		RootFolder = NKT.RootFolder
		' workaround: to refresh folders after creating a new one
        ' two refreshes are necessary
		NKT = New NKTWABLib.NKTWAB
		RootFolder = NKT.RootFolder
	End Sub
	
	Public Sub RefreshFolders(ByRef tvFolders As AxComctlLib.AxTreeView)
		Dim j As Object
		Dim i As Object
		Dim mainFolder As NKTWABLib.Folder
		Dim folder As NKTWABLib.Folder
		Dim newItem As ComctlLib.Node
		
		tvFolders.Nodes.Clear()
		
		For i = 1 To RootFolder.Folders.Count
			folder = RootFolder.Folders.item(i)
			If Not folder Is Nothing Then
                '            Set newItem = tvFolders.Nodes.Add(, , "F" + folder.entryID, folder.name + " " + folder.entryID, 1)
                newItem = tvFolders.Nodes.Add(, , "F" + folder.EntryID, folder.Name, 1)
                If i = 1 Then
                    tvFolders.SelectedItem = tvFolders.Nodes.Item(1)
                End If

                For j = 1 To folder.Groups.Count
                    tvFolders.Nodes.Add(newItem, ComctlLib.TreeRelationshipConstants.tvwChild, CDbl("G") + folder.Groups.Item(j).EntryID, folder.Groups.Item(j).Name, 2)
                    '            tvFolders.Nodes.Add newItem, tvwChild, "G" + folder.Groups.item(j).entryID, folder.Groups.item(j).name + " " + folder.Groups.item(j).entryID, 2
                Next
            End If
		Next 
	End Sub
	
	Public Sub RefreshItem(ByRef lvContacts As AxComctlLib.AxListView, ByRef lvItem As ComctlLib.ListItem)
		Dim contact As NKTWABLib.Contact
		
		If Not lvItem Is Nothing Then
			contact = NKT.item(GetEntryID((lvItem.key)))
			
			If Not contact Is Nothing Then
				lvContacts.ListItems.Remove(lvItem.Index)
				
                lvItem = lvContacts.ListItems.Add(, CreateItemKeyInListView(contact, lvContacts), contact.DisplayName)
				
				lvItem.SubItems(1) = contact.DefaultEmailAddress
				lvItem.SubItems(2) = contact.BusinessTelephoneNumber
				'            lvItem.SubItems(2) = contact.BusinessTelephoneNumber + " " + contact.entryID
				lvItem.SubItems(3) = contact.HomeTelephoneNumber
			End If
		End If
	End Sub
	
	Public Sub RefreshItems(ByRef tvItem As ComctlLib.Node, ByRef lvContacts As AxComctlLib.AxListView)
		Dim entryID As String
		Dim i As Short
		Dim j As Short
		Dim item As NKTWABLib.Contact
		Dim lvItem As ComctlLib.ListItem
		Dim contCont As NKTWABLib.ContactContainer
		Dim parentFolder As NKTWABLib.Folder
		Dim parentEntryID As String
		
		lvContacts.ListItems.Clear()
		
		If Not tvItem Is Nothing Then
			contCont = NKT.item(GetEntryID((tvItem.key)))
			
			If Not contCont Is Nothing Then
				For i = 1 To contCont.Contacts.Count
					item = contCont.Contacts.item(i)
                    If Not item Is Nothing And item.IsValid Then
                        lvItem = lvContacts.ListItems.Add(, CreateItemKeyInListView(item, lvContacts), item.DisplayName)

                        lvItem.SubItems(1) = item.DefaultEmailAddress
                        lvItem.SubItems(2) = item.BusinessTelephoneNumber
                        '                    lvItem.SubItems(2) = item.BusinessTelephoneNumber + " " + item.entryID
                        lvItem.SubItems(3) = item.HomeTelephoneNumber
                    End If
                Next
			End If
		End If
	End Sub
	
	Public Function GetItemType(ByRef key As String) As WabItemType
		If Mid(key, 1, 1) = "C" Then
			GetItemType = WabItemType.WabContact
		Else
			If Mid(key, 1, 1) = "G" Then
				GetItemType = WabItemType.WabGroup
			Else
				GetItemType = WabItemType.WabFolder
			End If
		End If
	End Function
	
	Public Function GetEntryID(ByRef key As String) As String
		Dim endPos As Short
		
		endPos = InStr(key, "&")
		If endPos = 0 Then
			endPos = Len(key)
		End If
		
		endPos = endPos - 1
		
		GetEntryID = Mid(key, 2, endPos)
	End Function
	
	Public Function CreateItemKeyInListView(ByRef item As NKTWABLib.NKTWABItem, ByRef lvContacts As AxComctlLib.AxListView) As String
		Dim lvItem As Object
		Dim j As Short
		Dim t As String
		Dim key As String
		
		If item.Type = NKTWABLib.tagWABITEMTYPE.WAB_CONTACT Then
			t = "C"
		End If
		If item.Type = NKTWABLib.tagWABITEMTYPE.WAB_FOLDER Then
			t = "F"
		End If
		If item.Type = NKTWABLib.tagWABITEMTYPE.WAB_GROUP Then
			t = "G"
		End If
		
		j = 0
		
		' find a unique id
		While Err.Number = 0 Or j = 0
			On Error Resume Next
			key = t & item.entryID & "&" & Str(j)
			lvItem = lvContacts.ListItems.item(key)
			j = j + 1
		End While
		
		CreateItemKeyInListView = key
	End Function
End Module