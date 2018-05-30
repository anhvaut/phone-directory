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
Friend Class frmMain
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
	Public WithEvents btnDeleteFromGroup As System.Windows.Forms.Button
	Public WithEvents tvFolders As AxComctlLib.AxTreeView
	Public WithEvents lvContacts As AxComctlLib.AxListView
	Public WithEvents btnDelete As System.Windows.Forms.Button
	Public WithEvents btnNewGroup As System.Windows.Forms.Button
	Public WithEvents btnNewFolder As System.Windows.Forms.Button
	Public WithEvents btnNewContact As System.Windows.Forms.Button
	Public WithEvents imlTreeView As AxComctlLib.AxImageList
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMain))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ToolTip1.Active = True
		Me.btnDeleteFromGroup = New System.Windows.Forms.Button
		Me.tvFolders = New AxComctlLib.AxTreeView
		Me.lvContacts = New AxComctlLib.AxListView
		Me.btnDelete = New System.Windows.Forms.Button
		Me.btnNewGroup = New System.Windows.Forms.Button
		Me.btnNewFolder = New System.Windows.Forms.Button
		Me.btnNewContact = New System.Windows.Forms.Button
		Me.imlTreeView = New AxComctlLib.AxImageList
		CType(Me.tvFolders, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.lvContacts, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.imlTreeView, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Text = "Address Book"
		Me.ClientSize = New System.Drawing.Size(600, 397)
		Me.Location = New System.Drawing.Point(4, 30)
		Me.Icon = CType(resources.GetObject("frmMain.Icon"), System.Drawing.Icon)
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
		Me.Name = "frmMain"
		Me.btnDeleteFromGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnDeleteFromGroup.Text = "Delete from Group"
		Me.btnDeleteFromGroup.Enabled = False
		Me.btnDeleteFromGroup.Size = New System.Drawing.Size(49, 41)
		Me.btnDeleteFromGroup.Location = New System.Drawing.Point(232, 8)
		Me.btnDeleteFromGroup.TabIndex = 6
		Me.btnDeleteFromGroup.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnDeleteFromGroup.BackColor = System.Drawing.SystemColors.Control
		Me.btnDeleteFromGroup.CausesValidation = True
		Me.btnDeleteFromGroup.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnDeleteFromGroup.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnDeleteFromGroup.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnDeleteFromGroup.TabStop = True
		Me.btnDeleteFromGroup.Name = "btnDeleteFromGroup"
		tvFolders.OcxState = CType(resources.GetObject("tvFolders.OcxState"), System.Windows.Forms.AxHost.State)
		Me.tvFolders.Size = New System.Drawing.Size(137, 329)
		Me.tvFolders.Location = New System.Drawing.Point(8, 64)
		Me.tvFolders.TabIndex = 0
		Me.tvFolders.Name = "tvFolders"
		lvContacts.OcxState = CType(resources.GetObject("lvContacts.OcxState"), System.Windows.Forms.AxHost.State)
		Me.lvContacts.Size = New System.Drawing.Size(441, 329)
		Me.lvContacts.Location = New System.Drawing.Point(152, 64)
		Me.lvContacts.TabIndex = 1
		Me.lvContacts.Name = "lvContacts"
		Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnDelete.Text = "Delete"
		Me.btnDelete.Size = New System.Drawing.Size(49, 41)
		Me.btnDelete.Location = New System.Drawing.Point(176, 8)
		Me.btnDelete.TabIndex = 5
		Me.btnDelete.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnDelete.BackColor = System.Drawing.SystemColors.Control
		Me.btnDelete.CausesValidation = True
		Me.btnDelete.Enabled = True
		Me.btnDelete.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnDelete.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnDelete.TabStop = True
		Me.btnDelete.Name = "btnDelete"
		Me.btnNewGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnNewGroup.Text = "New Group"
		Me.btnNewGroup.Size = New System.Drawing.Size(49, 41)
		Me.btnNewGroup.Location = New System.Drawing.Point(120, 8)
		Me.btnNewGroup.TabIndex = 4
		Me.btnNewGroup.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnNewGroup.BackColor = System.Drawing.SystemColors.Control
		Me.btnNewGroup.CausesValidation = True
		Me.btnNewGroup.Enabled = True
		Me.btnNewGroup.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnNewGroup.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnNewGroup.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnNewGroup.TabStop = True
		Me.btnNewGroup.Name = "btnNewGroup"
		Me.btnNewFolder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnNewFolder.Text = "New Folder"
		Me.btnNewFolder.Size = New System.Drawing.Size(49, 41)
		Me.btnNewFolder.Location = New System.Drawing.Point(64, 8)
		Me.btnNewFolder.TabIndex = 3
		Me.btnNewFolder.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnNewFolder.BackColor = System.Drawing.SystemColors.Control
		Me.btnNewFolder.CausesValidation = True
		Me.btnNewFolder.Enabled = True
		Me.btnNewFolder.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnNewFolder.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnNewFolder.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnNewFolder.TabStop = True
		Me.btnNewFolder.Name = "btnNewFolder"
		Me.btnNewContact.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnNewContact.Text = "New Contact"
		Me.btnNewContact.Size = New System.Drawing.Size(49, 41)
		Me.btnNewContact.Location = New System.Drawing.Point(8, 8)
		Me.btnNewContact.TabIndex = 2
		Me.btnNewContact.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnNewContact.BackColor = System.Drawing.SystemColors.Control
		Me.btnNewContact.CausesValidation = True
		Me.btnNewContact.Enabled = True
		Me.btnNewContact.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnNewContact.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnNewContact.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnNewContact.TabStop = True
		Me.btnNewContact.Name = "btnNewContact"
		imlTreeView.OcxState = CType(resources.GetObject("imlTreeView.OcxState"), System.Windows.Forms.AxHost.State)
		Me.imlTreeView.Location = New System.Drawing.Point(392, 16)
		Me.imlTreeView.Name = "imlTreeView"
		Me.Controls.Add(btnDeleteFromGroup)
		Me.Controls.Add(tvFolders)
		Me.Controls.Add(lvContacts)
		Me.Controls.Add(btnDelete)
		Me.Controls.Add(btnNewGroup)
		Me.Controls.Add(btnNewFolder)
		Me.Controls.Add(btnNewContact)
		Me.Controls.Add(imlTreeView)
		CType(Me.imlTreeView, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.lvContacts, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.tvFolders, System.ComponentModel.ISupportInitialize).EndInit()
	End Sub
#End Region 
#Region "Upgrade Support "
	Private Shared m_vb6FormDefInstance As frmMain
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmMain
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmMain()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
	Dim RootFolder As NKTWABLib.Folder
	Dim NKT As NKTWABLib.NKTWAB
	
	' contains the last control that got focus before the delete button
	' was pressed
	Dim LastControlFocus As System.Windows.Forms.Control
	
	
	'Dim TestFolder As NKTWABLib.folder
	
	Private Sub frmMain_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		NKT = New NKTWABLib.NKTWAB
		RootFolder = NKT.RootFolder
		
		modTools.Initialize()
		modTools.RefreshFolders(tvFolders)
		modTools.RefreshItems(tvFolders.SelectedItem, lvContacts)
	End Sub
	
	Private Function GetSelectedContact() As NKTWABLib.Contact
		Dim lvItem As ComctlLib.ListItem
		
        GetSelectedContact = Nothing
		
		lvItem = lvContacts.SelectedItem
		If Not lvItem Is Nothing Then
			GetSelectedContact = NKT.item(GetEntryID(lvContacts.SelectedItem.key))
		End If
	End Function
	
	Private Function GetSelectedContainer() As NKTWABLib.ContactContainer
		Dim entryID As String
		
        GetSelectedContainer = Nothing
		
		If Not tvFolders.SelectedItem Is Nothing Then
			entryID = GetEntryID(tvFolders.SelectedItem.key)
			GetSelectedContainer = NKT.item(entryID)
		End If
	End Function
	
	Private Sub lvContacts_DblClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvContacts.DblClick
		Dim folder As NKTWABLib.Folder
		Dim itemClicked As ComctlLib.ListItem
		Dim contactDlg As New frmContact
		Dim contact As NKTWABLib.Contact
		
		itemClicked = lvContacts.SelectedItem
		If Not itemClicked Is Nothing Then
			contact = GetSelectedContact
			If Not contact Is Nothing Then
				contactDlg.SetContact(contact)
				contactDlg.Close()
				
				RefreshItem(lvContacts, itemClicked)
			End If
		End If
	End Sub
	
	Private Sub lvContacts_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lvContacts.Leave
		LastControlFocus = lvContacts
	End Sub
	
	Private Sub tvFolders_BeforeLabelEdit(ByVal eventSender As System.Object, ByVal eventArgs As AxComctlLib.ITreeViewEvents_BeforeLabelEditEvent) Handles tvFolders.BeforeLabelEdit
		Dim tvItem As ComctlLib.Node
		Dim folder As NKTWABLib.Folder
		Dim entryID As String
		
		tvItem = tvFolders.SelectedItem
		If Not tvItem Is Nothing Then
			folder = NKT.DefaultFolder
            entryID = folder.EntryID
            If GetEntryID((tvItem.Key)) = NKT.DefaultFolder.EntryID Then
                eventArgs.cancel = 1
            End If
        End If
	End Sub
	
	Private Sub tvFolders_AfterLabelEdit(ByVal eventSender As System.Object, ByVal eventArgs As AxComctlLib.ITreeViewEvents_AfterLabelEditEvent) Handles tvFolders.AfterLabelEdit
		Dim tvItem As ComctlLib.Node
		Dim item As NKTWABLib.NKTWABItem
		
		tvItem = tvFolders.SelectedItem
		If Not tvItem Is Nothing Then
			item = NKT.item(GetEntryID((tvItem.key)))
			If Not item Is Nothing Then
				item.name = eventArgs.NewString
				item.Save()
			Else
				eventArgs.Cancel = 1
			End If
		End If
		
	End Sub
	
	Private Sub tvFolders_Leave(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles tvFolders.Leave
		LastControlFocus = tvFolders
	End Sub
	
	Private Sub tvFolders_NodeClick(ByVal eventSender As System.Object, ByVal eventArgs As AxComctlLib.ITreeViewEvents_NodeClickEvent) Handles tvFolders.NodeClick
		modTools.RefreshItems(tvFolders.SelectedItem, lvContacts)
		
		If modTools.GetItemType((eventArgs.Node.key)) = modTools.WabItemType.WabFolder Then
			btnNewContact.Text = "New Contact"
			btnDeleteFromGroup.Enabled = False
			btnNewGroup.Enabled = True
		Else
			btnNewContact.Text = "Add Contact"
			btnDeleteFromGroup.Enabled = True
			btnNewGroup.Enabled = False
		End If
	End Sub
	
	Private Sub btnNewContact_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnNewContact.Click
		Dim entryID As String
		Dim tvItem As ComctlLib.Node
		Dim tvParentItem As ComctlLib.Node
		Dim folder As NKTWABLib.Folder
		Dim group As NKTWABLib.Group
		Dim contact As NKTWABLib.Contact
		Dim contactDlg As New frmContact
		Dim selContactDlg As New frmSelectContact
		
		tvItem = tvFolders.SelectedItem
		
		If Not tvItem Is Nothing Then
            ' if it's a folder -> create a new item in that folder
			If modTools.GetItemType((tvItem.key)) = modTools.WabItemType.WabFolder Then
				folder = NKT.item(modTools.GetEntryID((tvItem.key)))
				If Not folder Is Nothing Then

					contact = folder.Contacts.Add
					
					contactDlg.SetContact(contact)
					contactDlg.Close()
				End If
                ' if it is a group add an item to the group
			Else
				group = NKT.item(modTools.GetEntryID((tvItem.key)))
				If Not group Is Nothing Then
					selContactDlg.ShowDialog()
					
					If selContactDlg.GetSelectedContact <> "" Then
                        group.Contacts.Add(selContactDlg.GetSelectedContact)
                        group.Save()
					End If
					
					selContactDlg.Close()
				End If
			End If
			
			modTools.RefreshItems(tvFolders.SelectedItem, lvContacts)
		End If
	End Sub
	
	Private Sub btnDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnDelete.Click
		If LastControlFocus.Handle.ToInt32 = lvContacts.hWnd Then
			DeleteSelectedContact()
		End If
		If LastControlFocus.Handle.ToInt32 = tvFolders.hWnd Then
			DeleteSelectedContainer()
		End If
	End Sub
	
	Private Sub btnDeleteFromGroup_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnDeleteFromGroup.Click
        Dim container_Renamed As NKTWABLib.ContactContainer
		Dim tvItem As ComctlLib.Node
		Dim contact As NKTWABLib.Contact
		Dim lvItem As ComctlLib.ListItem
		Dim group As NKTWABLib.Group
		
		lvItem = lvContacts.SelectedItem
		contact = GetSelectedContact
		container_Renamed = GetSelectedContainer
		
		If Not contact Is Nothing And Not container_Renamed Is Nothing Then
            If container_Renamed.Type = NKTWABLib.tagWABITEMTYPE.WAB_GROUP Then
                group = container_Renamed
                group.Contacts.Delete(contact.EntryID)
                lvContacts.ListItems.Remove(lvItem.Index)
            End If
        End If
	End Sub
	
	Private Sub DeleteSelectedContact()
		Dim contact As NKTWABLib.Contact
		Dim lvItem As ComctlLib.ListItem
		
		lvItem = lvContacts.SelectedItem
		contact = GetSelectedContact
		If Not contact Is Nothing Then
            contact.Delete()
			lvContacts.ListItems.Remove(lvItem.Index)
		End If
	End Sub
	
	Private Sub DeleteSelectedContainer()
        Dim container_Renamed As NKTWABLib.ContactContainer
		Dim tvItem As ComctlLib.Node
		
		container_Renamed = GetSelectedContainer
		If Not container_Renamed Is Nothing Then
            container_Renamed.Delete()
			tvFolders.Nodes.Remove(tvFolders.SelectedItem.Index)
		End If
	End Sub
	
	Private Sub btnNewFolder_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnNewFolder.Click
		Dim folder As NKTWABLib.Folder
        Dim name_Renamed As String
		
		name_Renamed = InputBox("Enter new folder name", "Create Folder")
		If name_Renamed <> "" Then
			folder = RootFolder.Folders.Add
            folder.Name = name_Renamed
            folder.Save()
			
			' Restart all objects to see the new folder
            folder = Nothing
            NKT = Nothing
            RootFolder = Nothing
			
			' restart module
			modTools.Initialize()
			RefreshFolders(tvFolders)
			
			NKT = New NKTWABLib.NKTWAB
			RootFolder = NKT.RootFolder
		End If
	End Sub
	
	Private Sub btnNewGroup_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnNewGroup.Click
        Dim container_Renamed As NKTWABLib.ContactContainer
		Dim folder As NKTWABLib.Folder
		Dim group As NKTWABLib.Group
		Dim contactDlg As New frmContact
        Dim name_Renamed As String
		
		container_Renamed = GetSelectedContainer
        If Not container_Renamed Is Nothing And container_Renamed.Type = NKTWABLib.tagWABITEMTYPE.WAB_FOLDER Then
            folder = container_Renamed
            name_Renamed = InputBox("Enter new group name", "Create Group")
            If name_Renamed <> "" Then
                group = folder.Groups.Add
                group.Name = name_Renamed
                group.Save()

                RefreshFolders(tvFolders)
            End If
        End If
	End Sub
End Class