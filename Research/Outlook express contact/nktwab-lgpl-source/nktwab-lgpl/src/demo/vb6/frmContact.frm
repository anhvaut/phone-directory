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
Begin VB.Form frmContact 
   Caption         =   "Contact Properties"
   ClientHeight    =   4335
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   8265
   Icon            =   "frmContact.frx":0000
   LinkTopic       =   "Form1"
   ScaleHeight     =   4335
   ScaleWidth      =   8265
   StartUpPosition =   3  'Windows Default
   Begin VB.TextBox tbPager 
      Height          =   375
      Left            =   1200
      TabIndex        =   27
      Top             =   3240
      Width           =   2295
   End
   Begin VB.OptionButton rbEmail3 
      Height          =   375
      Left            =   6240
      TabIndex        =   25
      Top             =   2160
      Width           =   975
   End
   Begin VB.OptionButton rbEmail2 
      Height          =   375
      Left            =   3360
      TabIndex        =   24
      Top             =   2160
      Width           =   855
   End
   Begin VB.OptionButton rbEmail1 
      Height          =   375
      Left            =   840
      TabIndex        =   23
      Top             =   2160
      Width           =   735
   End
   Begin VB.TextBox tbEmail3 
      Height          =   375
      Left            =   6240
      TabIndex        =   22
      Top             =   1680
      Width           =   1935
   End
   Begin VB.TextBox tbEmail2 
      Height          =   375
      Left            =   3360
      TabIndex        =   20
      Top             =   1680
      Width           =   1815
   End
   Begin VB.TextBox tbEmail1 
      Height          =   375
      Left            =   840
      TabIndex        =   17
      Top             =   1680
      Width           =   1575
   End
   Begin VB.CommandButton btnCancel 
      Cancel          =   -1  'True
      Caption         =   "Cancel"
      CausesValidation=   0   'False
      Height          =   375
      Left            =   6960
      TabIndex        =   16
      Top             =   3840
      Width           =   1215
   End
   Begin VB.CommandButton btnOk 
      Caption         =   "Ok"
      Height          =   375
      Left            =   5640
      TabIndex        =   15
      Top             =   3840
      Width           =   1215
   End
   Begin VB.TextBox tbBusinessPhone 
      Height          =   375
      Left            =   4800
      TabIndex        =   14
      Top             =   2760
      Width           =   2295
   End
   Begin VB.TextBox tbHomePhone 
      Height          =   375
      Left            =   1200
      TabIndex        =   12
      Top             =   2760
      Width           =   2295
   End
   Begin VB.TextBox tbDisplay 
      Height          =   375
      Left            =   2280
      TabIndex        =   9
      Top             =   720
      Width           =   2895
   End
   Begin VB.TextBox tbTitle 
      Height          =   375
      Left            =   720
      TabIndex        =   7
      Top             =   720
      Width           =   615
   End
   Begin VB.TextBox tbLast 
      Height          =   375
      Left            =   6240
      TabIndex        =   2
      Top             =   240
      Width           =   1935
   End
   Begin VB.TextBox tbMiddle 
      Height          =   375
      Left            =   3360
      TabIndex        =   1
      Top             =   240
      Width           =   1815
   End
   Begin VB.TextBox tbFirst 
      Height          =   375
      Left            =   720
      TabIndex        =   0
      Top             =   240
      Width           =   1695
   End
   Begin VB.Label Label13 
      Caption         =   "Pager:"
      Height          =   375
      Left            =   120
      TabIndex        =   28
      Top             =   3240
      Width           =   975
   End
   Begin VB.Label Label12 
      Caption         =   "Primary:"
      Height          =   255
      Left            =   120
      TabIndex        =   26
      Top             =   2160
      Width           =   615
   End
   Begin VB.Label Label11 
      Caption         =   "Third:"
      Height          =   375
      Left            =   5280
      TabIndex        =   21
      Top             =   1680
      Width           =   615
   End
   Begin VB.Label Label10 
      Caption         =   "Second:"
      Height          =   375
      Left            =   2520
      TabIndex        =   19
      Top             =   1680
      Width           =   615
   End
   Begin VB.Label Label9 
      Caption         =   "First:"
      Height          =   255
      Left            =   120
      TabIndex        =   18
      Top             =   1680
      Width           =   495
   End
   Begin VB.Label Label8 
      Caption         =   "Business Phone:"
      Height          =   375
      Left            =   3600
      TabIndex        =   13
      Top             =   2760
      Width           =   1335
   End
   Begin VB.Label Label7 
      Caption         =   "Home Phone:"
      Height          =   375
      Left            =   120
      TabIndex        =   11
      Top             =   2760
      Width           =   975
   End
   Begin VB.Label Label6 
      Caption         =   "E-Mail:"
      Height          =   255
      Left            =   120
      TabIndex        =   10
      Top             =   1320
      Width           =   2055
   End
   Begin VB.Label Label5 
      Caption         =   "Display:"
      Height          =   375
      Left            =   1440
      TabIndex        =   8
      Top             =   720
      Width           =   1215
   End
   Begin VB.Label Label4 
      Caption         =   "Title:"
      Height          =   375
      Left            =   120
      TabIndex        =   6
      Top             =   720
      Width           =   615
   End
   Begin VB.Label Label3 
      Caption         =   "Last:"
      Height          =   375
      Left            =   5280
      TabIndex        =   5
      Top             =   240
      Width           =   735
   End
   Begin VB.Label Label2 
      Caption         =   "Middle:"
      Height          =   375
      Left            =   2520
      TabIndex        =   4
      Top             =   240
      Width           =   855
   End
   Begin VB.Label Label1 
      Caption         =   "First:"
      Height          =   375
      Left            =   120
      TabIndex        =   3
      Top             =   240
      Width           =   615
   End
End
Attribute VB_Name = "frmContact"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim OkPressed As Boolean

Private Sub btnCancel_Click()
    Me.Hide
End Sub

Private Sub btnRemoveEmail_Click()
    lbEmail.RemoveItem lbEmail.ListIndex
End Sub

Private Sub Form_Load()
    OkPressed = False
End Sub
Private Sub btnAddEmail_Click()
    If tbEmail.Text <> "" Then
        lbEmail.AddItem tbEmail.Text
        tbEmail.Text = ""
    End If
End Sub

Private Sub btnOk_Click()
    Me.Hide
    OkPressed = True
End Sub

Private Sub lbEmail_Click()
    btnRemoveEmail.Enabled = (lbEmail.SelCount > 0)
End Sub

Public Function GetOkPressed() As Boolean
    GetOkPressed = OkPressed
End Function

Public Sub SetContact(contact As NKTWABLib.contact)
    tbBusinessPhone.Text = contact.BusinessTelephoneNumber
    tbDisplay.Text = contact.DisplayName
    tbFirst.Text = contact.FirstName
    tbMiddle.Text = contact.MiddleName
    tbLast.Text = contact.LastName
    tbHomePhone.Text = contact.HomeTelephoneNumber
    tbPager.Text = contact.PagerTelephoneNumber
    tbTitle.Text = contact.Title
    
    tbEmail1.Text = contact.Email1Address
    tbEmail2.Text = contact.Email2Address
    tbEmail3.Text = contact.Email3Address
    
    If contact.DefaultEmailAddressIndex = 1 Then
        rbEmail1.Value = True
    End If
    If contact.DefaultEmailAddressIndex = 2 Then
        rbEmail2.Value = True
    End If
    If contact.DefaultEmailAddressIndex = 3 Then
        rbEmail3.Value = True
    End If
    
    Show vbModal
    
    If GetOkPressed = True Then
        contact.BusinessTelephoneNumber = tbBusinessPhone.Text
        contact.DisplayName = tbDisplay.Text
        contact.FirstName = tbFirst.Text
        contact.MiddleName = tbMiddle.Text
        contact.LastName = tbLast.Text
        contact.HomeTelephoneNumber = tbHomePhone.Text
        contact.PagerTelephoneNumber = tbPager.Text
        contact.Title = tbTitle.Text
        
        ' set the email1 first because if we set the email3
        ' first and email1 is empty, email1 will got the value
        ' because email2 can be defined if email1 is defined and
        ' email3 can be defined if email1 and email2 are defined
        ' Otherwise, the value set in emailx is set in the first
        ' empty value
        contact.Email1Address = tbEmail1.Text
        contact.Email2Address = tbEmail2.Text
        contact.Email3Address = tbEmail3.Text
        
        If rbEmail1.Value Then
            contact.DefaultEmailAddressIndex = 1
        End If
        If rbEmail2.Value Then
            contact.DefaultEmailAddressIndex = 2
        End If
        If rbEmail3.Value Then
            contact.DefaultEmailAddressIndex = 3
        End If
        
        contact.Save
    End If

End Sub
