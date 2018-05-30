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

VERSION 5.00
Object = "{6B7E6392-850A-101B-AFC0-4210102A8DA7}#1.3#0"; "comctl32.ocx"
Begin VB.Form frmMain 
   Caption         =   "Address Book"
   ClientHeight    =   5955
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   9000
   Icon            =   "frmMain.frx":0000
   LinkTopic       =   "Form1"
   ScaleHeight     =   5955
   ScaleWidth      =   9000
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton btnDeleteFromGroup 
      Caption         =   "Delete from Group"
      Enabled         =   0   'False
      Height          =   615
      Left            =   3480
      TabIndex        =   6
      Top             =   120
      Width           =   735
   End
   Begin ComctlLib.TreeView tvFolders 
      Height          =   4935
      Left            =   120
      TabIndex        =   0
      Top             =   960
      Width           =   2055
      _ExtentX        =   3625
      _ExtentY        =   8705
      _Version        =   327682
      HideSelection   =   0   'False
      Indentation     =   353
      LineStyle       =   1
      Style           =   7
      ImageList       =   "imlTreeView"
      Appearance      =   1
   End
   Begin ComctlLib.ListView lvContacts 
      Height          =   4935
      Left            =   2280
      TabIndex        =   1
      Top             =   960
      Width           =   6615
      _ExtentX        =   11668
      _ExtentY        =   8705
      View            =   3
      LabelEdit       =   1
      Sorted          =   -1  'True
      LabelWrap       =   -1  'True
      HideSelection   =   0   'False
      _Version        =   327682
      ForeColor       =   -2147483640
      BackColor       =   -2147483643
      Appearance      =   1
      NumItems        =   5
      BeginProperty ColumnHeader(1) {0713E8C7-850A-101B-AFC0-4210102A8DA7} 
         Key             =   ""
         Object.Tag             =   ""
         Text            =   "Name"
         Object.Width           =   2540
      EndProperty
      BeginProperty ColumnHeader(2) {0713E8C7-850A-101B-AFC0-4210102A8DA7} 
         SubItemIndex    =   1
         Key             =   ""
         Object.Tag             =   ""
         Text            =   "E-Mail"
         Object.Width           =   2540
      EndProperty
      BeginProperty ColumnHeader(3) {0713E8C7-850A-101B-AFC0-4210102A8DA7} 
         SubItemIndex    =   2
         Key             =   ""
         Object.Tag             =   ""
         Text            =   "Business Phone"
         Object.Width           =   2540
      EndProperty
      BeginProperty ColumnHeader(4) {0713E8C7-850A-101B-AFC0-4210102A8DA7} 
         SubItemIndex    =   3
         Key             =   ""
         Object.Tag             =   ""
         Text            =   "Home Phone"
         Object.Width           =   2540
      EndProperty
      BeginProperty ColumnHeader(5) {0713E8C7-850A-101B-AFC0-4210102A8DA7} 
         SubItemIndex    =   4
         Key             =   ""
         Object.Tag             =   ""
         Text            =   ""
         Object.Width           =   2540
      EndProperty
   End
   Begin VB.CommandButton btnDelete 
      Caption         =   "Delete"
      Height          =   615
      Left            =   2640
      TabIndex        =   5
      Top             =   120
      Width           =   735
   End
   Begin VB.CommandButton btnNewGroup 
      Caption         =   "New Group"
      Height          =   615
      Left            =   1800
      TabIndex        =   4
      Top             =   120
      Width           =   735
   End
   Begin VB.CommandButton btnNewFolder 
      Caption         =   "New Folder"
      Height          =   615
      Left            =   960
      TabIndex        =   3
      Top             =   120
      Width           =   735
   End
   Begin VB.CommandButton btnNewContact 
      Caption         =   "New Contact"
      Height          =   615
      Left            =   120
      TabIndex        =   2
      Top             =   120
      Width           =   735
   End
   Begin ComctlLib.ImageList imlTreeView 
      Left            =   5880
      Top             =   240
      _ExtentX        =   1005
      _ExtentY        =   1005
      BackColor       =   -2147483643
      ImageWidth      =   16
      ImageHeight     =   16
      MaskColor       =   12632256
      _Version        =   327682
      BeginProperty Images {0713E8C2-850A-101B-AFC0-4210102A8DA7} 
         NumListImages   =   2
         BeginProperty ListImage1 {0713E8C3-850A-101B-AFC0-4210102A8DA7} 
            Picture         =   "frmMain.frx":23D2
            Key             =   ""
         EndProperty
         BeginProperty ListImage2 {0713E8C3-850A-101B-AFC0-4210102A8DA7} 
            Picture         =   "frmMain.frx":40DC
            Key             =   ""
         EndProperty
      EndProperty
   End
End
Attribute VB_Name = "frmMain"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim RootFolder As NKTWABLib.folder
Dim NKT As NKTWAB

' contains the last control that got focus before the delete button
' was pressed
Dim LastControlFocus As Control


'Dim TestFolder As NKTWABLib.folder

Private Sub Form_Load()
    Set NKT = New NKTWAB
    Set RootFolder = NKT.RootFolder
    
    modTools.Initialize
    modTools.RefreshFolders tvFolders
    modTools.RefreshItems tvFolders.SelectedItem, lvContacts
End Sub

Private Function GetSelectedContact() As NKTWABLib.contact
    Dim lvItem As ComctlLib.ListItem

    Set GetSelectedContact = Nothing

    Set lvItem = lvContacts.SelectedItem
    If Not lvItem Is Nothing Then
        Set GetSelectedContact = NKT.item(GetEntryID(lvContacts.SelectedItem.key))
    End If
End Function

Private Function GetSelectedContainer() As NKTWABLib.ContactContainer
    Dim entryID As String

    Set GetSelectedContainer = Nothing

    If Not tvFolders.SelectedItem Is Nothing Then
        entryID = GetEntryID(tvFolders.SelectedItem.key)
        Set GetSelectedContainer = NKT.item(entryID)
    End If
End Function

Private Sub lvContacts_DblClick()
    Dim folder As NKTWABLib.folder
    Dim itemClicked As ComctlLib.ListItem
    Dim contactDlg As New frmContact
    Dim contact As NKTWABLib.contact

    Set itemClicked = lvContacts.SelectedItem
    If Not itemClicked Is Nothing Then
        Set contact = GetSelectedContact
        If Not contact Is Nothing Then
            contactDlg.SetContact contact
            Unload contactDlg

            RefreshItem lvContacts, itemClicked
        End If
    End If
End Sub

Private Sub lvContacts_LostFocus()
    Set LastControlFocus = lvContacts
End Sub

Private Sub tvFolders_BeforeLabelEdit(Cancel As Integer)
    Dim tvItem As Node
    Dim folder As NKTWABLib.folder
    Dim entryID As String

    Set tvItem = tvFolders.SelectedItem
    If Not tvItem Is Nothing Then
        Set folder = NKT.DefaultFolder
        entryID = folder.entryID
        If GetEntryID(tvItem.key) = NKT.DefaultFolder.entryID Then
            Cancel = 1
        End If
    End If
End Sub

Private Sub tvFolders_AfterLabelEdit(Cancel As Integer, NewString As String)
    Dim tvItem As Node
    Dim item As NKTWABLib.NKTWABItem

    Set tvItem = tvFolders.SelectedItem
    If Not tvItem Is Nothing Then
        Set item = NKT.item(GetEntryID(tvItem.key))
        If Not item Is Nothing Then
            item.name = NewString
            item.Save
        Else
            Cancel = 1
        End If
    End If
    
End Sub

Private Sub tvFolders_LostFocus()
    Set LastControlFocus = tvFolders
End Sub

Private Sub tvFolders_NodeClick(ByVal Node As ComctlLib.Node)
    modTools.RefreshItems tvFolders.SelectedItem, lvContacts
    
    If modTools.GetItemType(Node.key) = WabFolder Then
        btnNewContact.Caption = "New Contact"
        btnDeleteFromGroup.Enabled = False
        btnNewGroup.Enabled = True
    Else
        btnNewContact.Caption = "Add Contact"
        btnDeleteFromGroup.Enabled = True
        btnNewGroup.Enabled = False
    End If
End Sub

Private Sub btnNewContact_Click()
    Dim entryID As String
    Dim tvItem As Node
    Dim tvParentItem As Node
    Dim folder As NKTWABLib.folder
    Dim group As NKTWABLib.group
    Dim contact As NKTWABLib.contact
    Dim contactDlg As New frmContact
    Dim selContactDlg As New frmSelectContact
   
    Set tvItem = tvFolders.SelectedItem
    
    If Not tvItem Is Nothing Then
        ' if it is a folder -> create a new item in that folder
        If modTools.GetItemType(tvItem.key) = WabFolder Then
            Set folder = NKT.item(modTools.GetEntryID(tvItem.key))
            If Not folder Is Nothing Then
                Set contact = folder.Contacts.Add
                
                contactDlg.SetContact contact
                Unload contactDlg
            End If
        ' if it is a group add a existing item to the group
        Else
            Set group = NKT.item(modTools.GetEntryID(tvItem.key))
            If Not group Is Nothing Then
                selContactDlg.Show vbModal
                
                If selContactDlg.GetSelectedContact <> "" Then
                    group.Contacts.Add selContactDlg.GetSelectedContact
                    group.Save
                End If
                
                Unload selContactDlg
            End If
        End If
        
        modTools.RefreshItems tvFolders.SelectedItem, lvContacts
    End If
End Sub

Private Sub btnDelete_Click()
    If LastControlFocus.hWnd = lvContacts.hWnd Then
        DeleteSelectedContact
    End If
    If LastControlFocus.hWnd = tvFolders.hWnd Then
        DeleteSelectedContainer
    End If
End Sub

Private Sub btnDeleteFromGroup_Click()
    Dim container As NKTWABLib.ContactContainer
    Dim tvItem As Node
    Dim contact As NKTWABLib.contact
    Dim lvItem As ComctlLib.ListItem
    Dim group As NKTWABLib.group

    Set lvItem = lvContacts.SelectedItem
    Set contact = GetSelectedContact
    Set container = GetSelectedContainer
    
    If Not contact Is Nothing And Not container Is Nothing Then
        If container.Type = WAB_GROUP Then
            Set group = container
            group.Contacts.Delete contact.entryID
            lvContacts.ListItems.Remove lvItem.Index
        End If
    End If
End Sub

Private Sub DeleteSelectedContact()
    Dim contact As NKTWABLib.contact
    Dim lvItem As ComctlLib.ListItem

    Set lvItem = lvContacts.SelectedItem
    Set contact = GetSelectedContact
    If Not contact Is Nothing Then
        contact.Delete
        lvContacts.ListItems.Remove lvItem.Index
    End If
End Sub

Private Sub DeleteSelectedContainer()
    Dim container As NKTWABLib.ContactContainer
    Dim tvItem As Node
    
    Set container = GetSelectedContainer
    If Not container Is Nothing Then
        container.Delete
        tvFolders.Nodes.Remove tvFolders.SelectedItem.Index
    End If
End Sub

Private Sub btnNewFolder_Click()
    Dim folder As NKTWABLib.folder
    Dim name As String
    
    name = InputBox("Enter new folder name", "Create Folder")
    If name <> "" Then
        Set folder = RootFolder.Folders.Add
        folder.name = name
        folder.Save
        
        ' Restart all objects to see the new folder
        Set folder = Nothing
        Set NKT = Nothing
        Set RootFolder = Nothing
        
        ' restart module
        modTools.Initialize
        RefreshFolders tvFolders
        
        Set NKT = New NKTWAB
        Set RootFolder = NKT.RootFolder
    End If
End Sub

Private Sub btnNewGroup_Click()
    Dim container As NKTWABLib.ContactContainer
    Dim folder As NKTWABLib.folder
    Dim group As NKTWABLib.group
    Dim contactDlg As New frmContact
    Dim name As String
    
    Set container = GetSelectedContainer
    If Not container Is Nothing And container.Type = WAB_FOLDER Then
        Set folder = container
        name = InputBox("Enter new group name", "Create Group")
        If name <> "" Then
            Set group = folder.Groups.Add
            group.name = name
            group.Save
            
            RefreshFolders tvFolders
        End If
    End If
End Sub

