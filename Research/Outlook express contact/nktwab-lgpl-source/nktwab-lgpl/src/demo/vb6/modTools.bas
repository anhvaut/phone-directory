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

Attribute VB_Name = "modTools"
Dim NKT As NKTWAB
Dim RootFolder As NKTWABLib.folder

Public Enum WabItemType
    WabFolder = 1
    WabGroup = 2
    WabContact = 3
End Enum

Public Sub Initialize()
    Set NKT = New NKTWAB
    Set RootFolder = NKT.RootFolder
    ' workaround: to refresh folders after creating a new one
    ' two refreshes are necessary (why???)
    Set NKT = New NKTWAB
    Set RootFolder = NKT.RootFolder
End Sub

Public Sub RefreshFolders(tvFolders As TreeView)
    Dim mainFolder As NKTWABLib.folder
    Dim folder As NKTWABLib.folder
    Dim newItem As Node

    tvFolders.Nodes.Clear
    
    For i = 1 To RootFolder.Folders.Count
        Set folder = RootFolder.Folders.item(i)
        If Not folder Is Nothing Then
'            Set newItem = tvFolders.Nodes.Add(, , "F" + folder.entryID, folder.name + " " + folder.entryID, 1)
            Set newItem = tvFolders.Nodes.Add(, , "F" + folder.entryID, folder.name, 1)
            If i = 1 Then
                tvFolders.SelectedItem = tvFolders.Nodes.item(1)
            End If

            For j = 1 To folder.Groups.Count
                tvFolders.Nodes.Add newItem, tvwChild, "G" + folder.Groups.item(j).entryID, folder.Groups.item(j).name, 2
'                tvFolders.Nodes.Add newItem, tvwChild, "G" + folder.Groups.item(j).entryID, folder.Groups.item(j).name + " " + folder.Groups.item(j).entryID, 2
            Next
        End If
    Next
End Sub

Public Sub RefreshItem(lvContacts As ListView, lvItem As ComctlLib.ListItem)
    Dim contact As NKTWABLib.contact

    If Not lvItem Is Nothing Then
        Set contact = NKT.item(GetEntryID(lvItem.key))

        If Not contact Is Nothing Then
            lvContacts.ListItems.Remove lvItem.Index
            
            Set lvItem = lvContacts.ListItems.Add(, CreateItemKeyInListView(contact, lvContacts), contact.DisplayName)

            lvItem.SubItems(1) = contact.DefaultEmailAddress
            lvItem.SubItems(2) = contact.BusinessTelephoneNumber
'            lvItem.SubItems(2) = contact.BusinessTelephoneNumber + " " + contact.entryID
            lvItem.SubItems(3) = contact.HomeTelephoneNumber
        End If
    End If
End Sub

Public Sub RefreshItems(tvItem As Node, lvContacts As ListView)
    Dim entryID As String
    Dim i As Integer
    Dim j As Integer
    Dim item As NKTWABLib.contact
    Dim lvItem As ListItem
    Dim contCont As NKTWABLib.ContactContainer
    Dim parentFolder As NKTWABLib.folder
    Dim parentEntryID As String

    lvContacts.ListItems.Clear

    If Not tvItem Is Nothing Then
        Set contCont = NKT.item(GetEntryID(tvItem.key))
        
        If Not contCont Is Nothing Then
            For i = 1 To contCont.Contacts.Count
                Set item = contCont.Contacts.item(i)
                If Not item Is Nothing And item.IsValid Then
                    Set lvItem = lvContacts.ListItems.Add(, CreateItemKeyInListView(item, lvContacts), item.DisplayName)
                    
                    lvItem.SubItems(1) = item.DefaultEmailAddress
                    lvItem.SubItems(2) = item.BusinessTelephoneNumber
'                    lvItem.SubItems(2) = item.BusinessTelephoneNumber + " " + item.entryID
                    lvItem.SubItems(3) = item.HomeTelephoneNumber
                End If
            Next
        End If
    End If
End Sub

Public Function GetItemType(key As String) As WabItemType
    If Mid(key, 1, 1) = "C" Then
        GetItemType = WabContact
    Else
        If Mid(key, 1, 1) = "G" Then
            GetItemType = WabGroup
        Else
            GetItemType = WabFolder
        End If
    End If
End Function

Public Function GetEntryID(key As String) As String
    Dim endPos As Integer
    
    endPos = InStr(key, "&")
    If endPos = 0 Then
        endPos = Len(key)
    End If
    
    endPos = endPos - 1
    
    GetEntryID = Mid(key, 2, endPos)
End Function

Public Function CreateItemKeyInListView(item As NKTWABLib.NKTWABItem, lvContacts As ListView) As String
    Dim j As Integer
    Dim t As String
    Dim key As String

    If item.Type = WAB_CONTACT Then
        t = "C"
    End If
    If item.Type = WAB_FOLDER Then
        t = "F"
    End If
    If item.Type = WAB_GROUP Then
        t = "G"
    End If

    j = 0

    ' find a unique id
    While Err.Number = 0 Or j = 0
        On Error Resume Next
        key = t + item.entryID + "&" + Str(j)
        Set lvItem = lvContacts.ListItems.item(key)
        j = j + 1
    Wend

    CreateItemKeyInListView = key
End Function
