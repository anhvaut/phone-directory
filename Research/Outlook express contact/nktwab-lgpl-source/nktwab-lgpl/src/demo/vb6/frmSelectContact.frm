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
Begin VB.Form frmSelectContact 
   Caption         =   "Select Contact"
   ClientHeight    =   4605
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   8025
   Icon            =   "frmSelectContact.frx":0000
   LinkTopic       =   "Form1"
   ScaleHeight     =   4605
   ScaleWidth      =   8025
   StartUpPosition =   3  'Windows Default
   Begin ComctlLib.ListView lvContacts 
      Height          =   3855
      Left            =   2280
      TabIndex        =   1
      Top             =   120
      Width           =   5655
      _ExtentX        =   9975
      _ExtentY        =   6800
      View            =   3
      LabelEdit       =   1
      LabelWrap       =   -1  'True
      HideSelection   =   0   'False
      _Version        =   327682
      ForeColor       =   -2147483640
      BackColor       =   -2147483643
      Appearance      =   1
      NumItems        =   4
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
   End
   Begin VB.CommandButton btnCancel 
      Caption         =   "Cancel"
      Height          =   375
      Left            =   7080
      TabIndex        =   3
      Top             =   4080
      Width           =   855
   End
   Begin VB.CommandButton btnOk 
      Caption         =   "Ok"
      Enabled         =   0   'False
      Height          =   375
      Left            =   6120
      TabIndex        =   2
      Top             =   4080
      Width           =   855
   End
   Begin ComctlLib.TreeView tvFolders 
      Height          =   3855
      Left            =   120
      TabIndex        =   0
      Top             =   120
      Width           =   2055
      _ExtentX        =   3625
      _ExtentY        =   6800
      _Version        =   327682
      Indentation     =   353
      LineStyle       =   1
      Style           =   7
      ImageList       =   "imlTreeView"
      Appearance      =   1
   End
   Begin ComctlLib.ImageList imlTreeView 
      Left            =   1080
      Top             =   4080
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
            Picture         =   "frmSelectContact.frx":23D2
            Key             =   ""
         EndProperty
         BeginProperty ListImage2 {0713E8C3-850A-101B-AFC0-4210102A8DA7} 
            Picture         =   "frmSelectContact.frx":40DC
            Key             =   ""
         EndProperty
      EndProperty
   End
End
Attribute VB_Name = "frmSelectContact"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Dim SelContactID As String

Private Sub btnCancel_Click()
    Hide
End Sub

Private Sub btnOk_Click()
    If Not lvContacts.SelectedItem Is Nothing Then
        SelContactID = modTools.GetEntryID(lvContacts.SelectedItem.key)
    End If
    
    Hide
End Sub

Private Sub Form_Load()
    modTools.RefreshFolders tvFolders
    modTools.RefreshItems tvFolders.SelectedItem, lvContacts
End Sub

Private Sub lvContacts_Click()
    btnOk.Enabled = (Not lvContacts.SelectedItem Is Nothing)
End Sub

Private Sub tvFolders_NodeClick(ByVal Node As ComctlLib.Node)
    modTools.RefreshItems tvFolders.SelectedItem, lvContacts
End Sub

Public Function GetSelectedContact() As String
    GetSelectedContact = SelContactID
End Function
