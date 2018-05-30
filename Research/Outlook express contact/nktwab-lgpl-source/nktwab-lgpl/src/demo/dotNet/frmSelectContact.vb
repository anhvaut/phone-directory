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
Friend Class frmSelectContact
	Inherits System.Windows.Forms.Form
#Region "Windows Form Designer generated code "
	Public Sub New()
		MyBase.New()
		If m_vb6FormDefInstance Is Nothing Then
			If m_InitializingDefInstance Then
				m_vb6FormDefInstance = Me
			Else
				Try 
					'For the start-up form, the first instance created is the default instance.
					If System.Reflection.Assembly.GetExecutingAssembly.EntryPoint.DeclaringType Is Me.GetType Then
						m_vb6FormDefInstance = Me
					End If
				Catch
				End Try
			End If
		End If
		'This call is required by the Windows Form Designer.
		InitializeComponent()
	End Sub
	'Form overrides dispose to clean up the component list.
	Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents lvContacts As AxComctlLib.AxListView
	Public WithEvents btnCancel As System.Windows.Forms.Button
	Public WithEvents btnOk As System.Windows.Forms.Button
	Public WithEvents tvFolders As AxComctlLib.AxTreeView
	Public WithEvents imlTreeView As AxComctlLib.AxImageList
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSelectContact))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ToolTip1.Active = True
		Me.lvContacts = New AxComctlLib.AxListView
		Me.btnCancel = New System.Windows.Forms.Button
		Me.btnOk = New System.Windows.Forms.Button
		Me.tvFolders = New AxComctlLib.AxTreeView
		Me.imlTreeView = New AxComctlLib.AxImageList
		CType(Me.lvContacts, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.tvFolders, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.imlTreeView, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Text = "Select Contact"
		Me.ClientSize = New System.Drawing.Size(535, 307)
		Me.Location = New System.Drawing.Point(4, 30)
		Me.Icon = CType(resources.GetObject("frmSelectContact.Icon"), System.Drawing.Icon)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
		Me.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.MaximizeBox = True
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmSelectContact"
		lvContacts.OcxState = CType(resources.GetObject("lvContacts.OcxState"), System.Windows.Forms.AxHost.State)
		Me.lvContacts.Size = New System.Drawing.Size(377, 257)
		Me.lvContacts.Location = New System.Drawing.Point(152, 8)
		Me.lvContacts.TabIndex = 1
		Me.lvContacts.Name = "lvContacts"
		Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnCancel.Text = "Cancel"
		Me.btnCancel.Size = New System.Drawing.Size(57, 25)
		Me.btnCancel.Location = New System.Drawing.Point(472, 272)
		Me.btnCancel.TabIndex = 3
		Me.btnCancel.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
		Me.btnCancel.CausesValidation = True
		Me.btnCancel.Enabled = True
		Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnCancel.TabStop = True
		Me.btnCancel.Name = "btnCancel"
		Me.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnOk.Text = "Ok"
		Me.btnOk.Enabled = False
		Me.btnOk.Size = New System.Drawing.Size(57, 25)
		Me.btnOk.Location = New System.Drawing.Point(408, 272)
		Me.btnOk.TabIndex = 2
		Me.btnOk.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnOk.BackColor = System.Drawing.SystemColors.Control
		Me.btnOk.CausesValidation = True
		Me.btnOk.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnOk.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnOk.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnOk.TabStop = True
		Me.btnOk.Name = "btnOk"
		tvFolders.OcxState = CType(resources.GetObject("tvFolders.OcxState"), System.Windows.Forms.AxHost.State)
		Me.tvFolders.Size = New System.Drawing.Size(137, 257)
		Me.tvFolders.Location = New System.Drawing.Point(8, 8)
		Me.tvFolders.TabIndex = 0
		Me.tvFolders.Name = "tvFolders"
		imlTreeView.OcxState = CType(resources.GetObject("imlTreeView.OcxState"), System.Windows.Forms.AxHost.State)
		Me.imlTreeView.Location = New System.Drawing.Point(72, 272)
		Me.imlTreeView.Name = "imlTreeView"
		Me.Controls.Add(lvContacts)
		Me.Controls.Add(btnCancel)
		Me.Controls.Add(btnOk)
		Me.Controls.Add(tvFolders)
		Me.Controls.Add(imlTreeView)
		CType(Me.imlTreeView, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.tvFolders, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.lvContacts, System.ComponentModel.ISupportInitialize).EndInit()
	End Sub
#End Region 
#Region "Upgrade Support "
	Private Shared m_vb6FormDefInstance As frmSelectContact
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmSelectContact
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmSelectContact()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
	
	Dim SelContactID As String
	
	Private Sub btnCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnCancel.Click
		Hide()
	End Sub
	
	Private Sub btnOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOk.Click
		If Not lvContacts.SelectedItem Is Nothing Then
			SelContactID = modTools.GetEntryID(lvContacts.SelectedItem.key)
		End If
		
		Hide()
	End Sub
	
	Private Sub frmSelectContact_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		modTools.RefreshFolders(tvFolders)
		modTools.RefreshItems(tvFolders.SelectedItem, lvContacts)
	End Sub
	
	Private Sub lvContacts_ClickEvent(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvContacts.ClickEvent
		btnOk.Enabled = (Not lvContacts.SelectedItem Is Nothing)
	End Sub
	
	Private Sub tvFolders_NodeClick(ByVal eventSender As System.Object, ByVal eventArgs As AxComctlLib.ITreeViewEvents_NodeClickEvent) Handles tvFolders.NodeClick
		modTools.RefreshItems(tvFolders.SelectedItem, lvContacts)
	End Sub
	
	Public Function GetSelectedContact() As String
		GetSelectedContact = SelContactID
	End Function
End Class