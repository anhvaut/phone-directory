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
Friend Class frmContact
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
	Public WithEvents tbPager As System.Windows.Forms.TextBox
	Public WithEvents rbEmail3 As System.Windows.Forms.RadioButton
	Public WithEvents rbEmail2 As System.Windows.Forms.RadioButton
	Public WithEvents rbEmail1 As System.Windows.Forms.RadioButton
	Public WithEvents tbEmail3 As System.Windows.Forms.TextBox
	Public WithEvents tbEmail2 As System.Windows.Forms.TextBox
	Public WithEvents tbEmail1 As System.Windows.Forms.TextBox
	Public WithEvents btnCancel As System.Windows.Forms.Button
	Public WithEvents btnOk As System.Windows.Forms.Button
	Public WithEvents tbBusinessPhone As System.Windows.Forms.TextBox
	Public WithEvents tbHomePhone As System.Windows.Forms.TextBox
	Public WithEvents tbDisplay As System.Windows.Forms.TextBox
	Public WithEvents tbTitle As System.Windows.Forms.TextBox
	Public WithEvents tbLast As System.Windows.Forms.TextBox
	Public WithEvents tbMiddle As System.Windows.Forms.TextBox
	Public WithEvents tbFirst As System.Windows.Forms.TextBox
	Public WithEvents Label13 As System.Windows.Forms.Label
	Public WithEvents Label12 As System.Windows.Forms.Label
	Public WithEvents Label11 As System.Windows.Forms.Label
	Public WithEvents Label10 As System.Windows.Forms.Label
	Public WithEvents Label9 As System.Windows.Forms.Label
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmContact))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.ToolTip1.Active = True
		Me.tbPager = New System.Windows.Forms.TextBox
		Me.rbEmail3 = New System.Windows.Forms.RadioButton
		Me.rbEmail2 = New System.Windows.Forms.RadioButton
		Me.rbEmail1 = New System.Windows.Forms.RadioButton
		Me.tbEmail3 = New System.Windows.Forms.TextBox
		Me.tbEmail2 = New System.Windows.Forms.TextBox
		Me.tbEmail1 = New System.Windows.Forms.TextBox
		Me.btnCancel = New System.Windows.Forms.Button
		Me.btnOk = New System.Windows.Forms.Button
		Me.tbBusinessPhone = New System.Windows.Forms.TextBox
		Me.tbHomePhone = New System.Windows.Forms.TextBox
		Me.tbDisplay = New System.Windows.Forms.TextBox
		Me.tbTitle = New System.Windows.Forms.TextBox
		Me.tbLast = New System.Windows.Forms.TextBox
		Me.tbMiddle = New System.Windows.Forms.TextBox
		Me.tbFirst = New System.Windows.Forms.TextBox
		Me.Label13 = New System.Windows.Forms.Label
		Me.Label12 = New System.Windows.Forms.Label
		Me.Label11 = New System.Windows.Forms.Label
		Me.Label10 = New System.Windows.Forms.Label
		Me.Label9 = New System.Windows.Forms.Label
		Me.Label8 = New System.Windows.Forms.Label
		Me.Label7 = New System.Windows.Forms.Label
		Me.Label6 = New System.Windows.Forms.Label
		Me.Label5 = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.Text = "Contact Properties"
		Me.ClientSize = New System.Drawing.Size(551, 289)
		Me.Location = New System.Drawing.Point(4, 30)
		Me.Icon = CType(resources.GetObject("frmContact.Icon"), System.Drawing.Icon)
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
		Me.Name = "frmContact"
		Me.tbPager.AutoSize = False
		Me.tbPager.Size = New System.Drawing.Size(153, 25)
		Me.tbPager.Location = New System.Drawing.Point(80, 216)
		Me.tbPager.TabIndex = 27
		Me.tbPager.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.tbPager.AcceptsReturn = True
		Me.tbPager.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.tbPager.BackColor = System.Drawing.SystemColors.Window
		Me.tbPager.CausesValidation = True
		Me.tbPager.Enabled = True
		Me.tbPager.ForeColor = System.Drawing.SystemColors.WindowText
		Me.tbPager.HideSelection = True
		Me.tbPager.ReadOnly = False
		Me.tbPager.Maxlength = 0
		Me.tbPager.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.tbPager.MultiLine = False
		Me.tbPager.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.tbPager.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.tbPager.TabStop = True
		Me.tbPager.Visible = True
		Me.tbPager.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.tbPager.Name = "tbPager"
		Me.rbEmail3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.rbEmail3.Size = New System.Drawing.Size(65, 25)
		Me.rbEmail3.Location = New System.Drawing.Point(416, 144)
		Me.rbEmail3.TabIndex = 25
		Me.rbEmail3.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.rbEmail3.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.rbEmail3.BackColor = System.Drawing.SystemColors.Control
		Me.rbEmail3.CausesValidation = True
		Me.rbEmail3.Enabled = True
		Me.rbEmail3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.rbEmail3.Cursor = System.Windows.Forms.Cursors.Default
		Me.rbEmail3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.rbEmail3.Appearance = System.Windows.Forms.Appearance.Normal
		Me.rbEmail3.TabStop = True
		Me.rbEmail3.Checked = False
		Me.rbEmail3.Visible = True
		Me.rbEmail3.Name = "rbEmail3"
		Me.rbEmail2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.rbEmail2.Size = New System.Drawing.Size(57, 25)
		Me.rbEmail2.Location = New System.Drawing.Point(224, 144)
		Me.rbEmail2.TabIndex = 24
		Me.rbEmail2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.rbEmail2.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.rbEmail2.BackColor = System.Drawing.SystemColors.Control
		Me.rbEmail2.CausesValidation = True
		Me.rbEmail2.Enabled = True
		Me.rbEmail2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.rbEmail2.Cursor = System.Windows.Forms.Cursors.Default
		Me.rbEmail2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.rbEmail2.Appearance = System.Windows.Forms.Appearance.Normal
		Me.rbEmail2.TabStop = True
		Me.rbEmail2.Checked = False
		Me.rbEmail2.Visible = True
		Me.rbEmail2.Name = "rbEmail2"
		Me.rbEmail1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.rbEmail1.Size = New System.Drawing.Size(49, 25)
		Me.rbEmail1.Location = New System.Drawing.Point(56, 144)
		Me.rbEmail1.TabIndex = 23
		Me.rbEmail1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.rbEmail1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.rbEmail1.BackColor = System.Drawing.SystemColors.Control
		Me.rbEmail1.CausesValidation = True
		Me.rbEmail1.Enabled = True
		Me.rbEmail1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.rbEmail1.Cursor = System.Windows.Forms.Cursors.Default
		Me.rbEmail1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.rbEmail1.Appearance = System.Windows.Forms.Appearance.Normal
		Me.rbEmail1.TabStop = True
		Me.rbEmail1.Checked = False
		Me.rbEmail1.Visible = True
		Me.rbEmail1.Name = "rbEmail1"
		Me.tbEmail3.AutoSize = False
		Me.tbEmail3.Size = New System.Drawing.Size(129, 25)
		Me.tbEmail3.Location = New System.Drawing.Point(416, 112)
		Me.tbEmail3.TabIndex = 22
		Me.tbEmail3.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.tbEmail3.AcceptsReturn = True
		Me.tbEmail3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.tbEmail3.BackColor = System.Drawing.SystemColors.Window
		Me.tbEmail3.CausesValidation = True
		Me.tbEmail3.Enabled = True
		Me.tbEmail3.ForeColor = System.Drawing.SystemColors.WindowText
		Me.tbEmail3.HideSelection = True
		Me.tbEmail3.ReadOnly = False
		Me.tbEmail3.Maxlength = 0
		Me.tbEmail3.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.tbEmail3.MultiLine = False
		Me.tbEmail3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.tbEmail3.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.tbEmail3.TabStop = True
		Me.tbEmail3.Visible = True
		Me.tbEmail3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.tbEmail3.Name = "tbEmail3"
		Me.tbEmail2.AutoSize = False
		Me.tbEmail2.Size = New System.Drawing.Size(121, 25)
		Me.tbEmail2.Location = New System.Drawing.Point(224, 112)
		Me.tbEmail2.TabIndex = 20
		Me.tbEmail2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.tbEmail2.AcceptsReturn = True
		Me.tbEmail2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.tbEmail2.BackColor = System.Drawing.SystemColors.Window
		Me.tbEmail2.CausesValidation = True
		Me.tbEmail2.Enabled = True
		Me.tbEmail2.ForeColor = System.Drawing.SystemColors.WindowText
		Me.tbEmail2.HideSelection = True
		Me.tbEmail2.ReadOnly = False
		Me.tbEmail2.Maxlength = 0
		Me.tbEmail2.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.tbEmail2.MultiLine = False
		Me.tbEmail2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.tbEmail2.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.tbEmail2.TabStop = True
		Me.tbEmail2.Visible = True
		Me.tbEmail2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.tbEmail2.Name = "tbEmail2"
		Me.tbEmail1.AutoSize = False
		Me.tbEmail1.Size = New System.Drawing.Size(105, 25)
		Me.tbEmail1.Location = New System.Drawing.Point(56, 112)
		Me.tbEmail1.TabIndex = 17
		Me.tbEmail1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.tbEmail1.AcceptsReturn = True
		Me.tbEmail1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.tbEmail1.BackColor = System.Drawing.SystemColors.Window
		Me.tbEmail1.CausesValidation = True
		Me.tbEmail1.Enabled = True
		Me.tbEmail1.ForeColor = System.Drawing.SystemColors.WindowText
		Me.tbEmail1.HideSelection = True
		Me.tbEmail1.ReadOnly = False
		Me.tbEmail1.Maxlength = 0
		Me.tbEmail1.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.tbEmail1.MultiLine = False
		Me.tbEmail1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.tbEmail1.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.tbEmail1.TabStop = True
		Me.tbEmail1.Visible = True
		Me.tbEmail1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.tbEmail1.Name = "tbEmail1"
		Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CancelButton = Me.btnCancel
		Me.btnCancel.Text = "Cancel"
		Me.btnCancel.CausesValidation = False
		Me.btnCancel.Size = New System.Drawing.Size(81, 25)
		Me.btnCancel.Location = New System.Drawing.Point(464, 256)
		Me.btnCancel.TabIndex = 16
		Me.btnCancel.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
		Me.btnCancel.Enabled = True
		Me.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnCancel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnCancel.TabStop = True
		Me.btnCancel.Name = "btnCancel"
		Me.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnOk.Text = "Ok"
		Me.btnOk.Size = New System.Drawing.Size(81, 25)
		Me.btnOk.Location = New System.Drawing.Point(376, 256)
		Me.btnOk.TabIndex = 15
		Me.btnOk.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnOk.BackColor = System.Drawing.SystemColors.Control
		Me.btnOk.CausesValidation = True
		Me.btnOk.Enabled = True
		Me.btnOk.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnOk.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnOk.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnOk.TabStop = True
		Me.btnOk.Name = "btnOk"
		Me.tbBusinessPhone.AutoSize = False
		Me.tbBusinessPhone.Size = New System.Drawing.Size(153, 25)
		Me.tbBusinessPhone.Location = New System.Drawing.Point(320, 184)
		Me.tbBusinessPhone.TabIndex = 14
		Me.tbBusinessPhone.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.tbBusinessPhone.AcceptsReturn = True
		Me.tbBusinessPhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.tbBusinessPhone.BackColor = System.Drawing.SystemColors.Window
		Me.tbBusinessPhone.CausesValidation = True
		Me.tbBusinessPhone.Enabled = True
		Me.tbBusinessPhone.ForeColor = System.Drawing.SystemColors.WindowText
		Me.tbBusinessPhone.HideSelection = True
		Me.tbBusinessPhone.ReadOnly = False
		Me.tbBusinessPhone.Maxlength = 0
		Me.tbBusinessPhone.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.tbBusinessPhone.MultiLine = False
		Me.tbBusinessPhone.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.tbBusinessPhone.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.tbBusinessPhone.TabStop = True
		Me.tbBusinessPhone.Visible = True
		Me.tbBusinessPhone.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.tbBusinessPhone.Name = "tbBusinessPhone"
		Me.tbHomePhone.AutoSize = False
		Me.tbHomePhone.Size = New System.Drawing.Size(153, 25)
		Me.tbHomePhone.Location = New System.Drawing.Point(80, 184)
		Me.tbHomePhone.TabIndex = 12
		Me.tbHomePhone.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.tbHomePhone.AcceptsReturn = True
		Me.tbHomePhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.tbHomePhone.BackColor = System.Drawing.SystemColors.Window
		Me.tbHomePhone.CausesValidation = True
		Me.tbHomePhone.Enabled = True
		Me.tbHomePhone.ForeColor = System.Drawing.SystemColors.WindowText
		Me.tbHomePhone.HideSelection = True
		Me.tbHomePhone.ReadOnly = False
		Me.tbHomePhone.Maxlength = 0
		Me.tbHomePhone.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.tbHomePhone.MultiLine = False
		Me.tbHomePhone.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.tbHomePhone.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.tbHomePhone.TabStop = True
		Me.tbHomePhone.Visible = True
		Me.tbHomePhone.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.tbHomePhone.Name = "tbHomePhone"
		Me.tbDisplay.AutoSize = False
		Me.tbDisplay.Size = New System.Drawing.Size(193, 25)
		Me.tbDisplay.Location = New System.Drawing.Point(152, 48)
		Me.tbDisplay.TabIndex = 9
		Me.tbDisplay.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.tbDisplay.AcceptsReturn = True
		Me.tbDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.tbDisplay.BackColor = System.Drawing.SystemColors.Window
		Me.tbDisplay.CausesValidation = True
		Me.tbDisplay.Enabled = True
		Me.tbDisplay.ForeColor = System.Drawing.SystemColors.WindowText
		Me.tbDisplay.HideSelection = True
		Me.tbDisplay.ReadOnly = False
		Me.tbDisplay.Maxlength = 0
		Me.tbDisplay.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.tbDisplay.MultiLine = False
		Me.tbDisplay.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.tbDisplay.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.tbDisplay.TabStop = True
		Me.tbDisplay.Visible = True
		Me.tbDisplay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.tbDisplay.Name = "tbDisplay"
		Me.tbTitle.AutoSize = False
		Me.tbTitle.Size = New System.Drawing.Size(41, 25)
		Me.tbTitle.Location = New System.Drawing.Point(48, 48)
		Me.tbTitle.TabIndex = 7
		Me.tbTitle.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.tbTitle.AcceptsReturn = True
		Me.tbTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.tbTitle.BackColor = System.Drawing.SystemColors.Window
		Me.tbTitle.CausesValidation = True
		Me.tbTitle.Enabled = True
		Me.tbTitle.ForeColor = System.Drawing.SystemColors.WindowText
		Me.tbTitle.HideSelection = True
		Me.tbTitle.ReadOnly = False
		Me.tbTitle.Maxlength = 0
		Me.tbTitle.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.tbTitle.MultiLine = False
		Me.tbTitle.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.tbTitle.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.tbTitle.TabStop = True
		Me.tbTitle.Visible = True
		Me.tbTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.tbTitle.Name = "tbTitle"
		Me.tbLast.AutoSize = False
		Me.tbLast.Size = New System.Drawing.Size(129, 25)
		Me.tbLast.Location = New System.Drawing.Point(416, 16)
		Me.tbLast.TabIndex = 2
		Me.tbLast.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.tbLast.AcceptsReturn = True
		Me.tbLast.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.tbLast.BackColor = System.Drawing.SystemColors.Window
		Me.tbLast.CausesValidation = True
		Me.tbLast.Enabled = True
		Me.tbLast.ForeColor = System.Drawing.SystemColors.WindowText
		Me.tbLast.HideSelection = True
		Me.tbLast.ReadOnly = False
		Me.tbLast.Maxlength = 0
		Me.tbLast.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.tbLast.MultiLine = False
		Me.tbLast.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.tbLast.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.tbLast.TabStop = True
		Me.tbLast.Visible = True
		Me.tbLast.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.tbLast.Name = "tbLast"
		Me.tbMiddle.AutoSize = False
		Me.tbMiddle.Size = New System.Drawing.Size(121, 25)
		Me.tbMiddle.Location = New System.Drawing.Point(224, 16)
		Me.tbMiddle.TabIndex = 1
		Me.tbMiddle.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.tbMiddle.AcceptsReturn = True
		Me.tbMiddle.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.tbMiddle.BackColor = System.Drawing.SystemColors.Window
		Me.tbMiddle.CausesValidation = True
		Me.tbMiddle.Enabled = True
		Me.tbMiddle.ForeColor = System.Drawing.SystemColors.WindowText
		Me.tbMiddle.HideSelection = True
		Me.tbMiddle.ReadOnly = False
		Me.tbMiddle.Maxlength = 0
		Me.tbMiddle.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.tbMiddle.MultiLine = False
		Me.tbMiddle.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.tbMiddle.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.tbMiddle.TabStop = True
		Me.tbMiddle.Visible = True
		Me.tbMiddle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.tbMiddle.Name = "tbMiddle"
		Me.tbFirst.AutoSize = False
		Me.tbFirst.Size = New System.Drawing.Size(113, 25)
		Me.tbFirst.Location = New System.Drawing.Point(48, 16)
		Me.tbFirst.TabIndex = 0
		Me.tbFirst.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.tbFirst.AcceptsReturn = True
		Me.tbFirst.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.tbFirst.BackColor = System.Drawing.SystemColors.Window
		Me.tbFirst.CausesValidation = True
		Me.tbFirst.Enabled = True
		Me.tbFirst.ForeColor = System.Drawing.SystemColors.WindowText
		Me.tbFirst.HideSelection = True
		Me.tbFirst.ReadOnly = False
		Me.tbFirst.Maxlength = 0
		Me.tbFirst.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.tbFirst.MultiLine = False
		Me.tbFirst.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.tbFirst.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.tbFirst.TabStop = True
		Me.tbFirst.Visible = True
		Me.tbFirst.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.tbFirst.Name = "tbFirst"
		Me.Label13.Text = "Pager:"
		Me.Label13.Size = New System.Drawing.Size(65, 25)
		Me.Label13.Location = New System.Drawing.Point(8, 216)
		Me.Label13.TabIndex = 28
		Me.Label13.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label13.BackColor = System.Drawing.SystemColors.Control
		Me.Label13.Enabled = True
		Me.Label13.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label13.UseMnemonic = True
		Me.Label13.Visible = True
		Me.Label13.AutoSize = False
		Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label13.Name = "Label13"
		Me.Label12.Text = "Primary:"
		Me.Label12.Size = New System.Drawing.Size(41, 17)
		Me.Label12.Location = New System.Drawing.Point(8, 144)
		Me.Label12.TabIndex = 26
		Me.Label12.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label12.BackColor = System.Drawing.SystemColors.Control
		Me.Label12.Enabled = True
		Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label12.UseMnemonic = True
		Me.Label12.Visible = True
		Me.Label12.AutoSize = False
		Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label12.Name = "Label12"
		Me.Label11.Text = "Third:"
		Me.Label11.Size = New System.Drawing.Size(41, 25)
		Me.Label11.Location = New System.Drawing.Point(352, 112)
		Me.Label11.TabIndex = 21
		Me.Label11.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label11.BackColor = System.Drawing.SystemColors.Control
		Me.Label11.Enabled = True
		Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label11.UseMnemonic = True
		Me.Label11.Visible = True
		Me.Label11.AutoSize = False
		Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label11.Name = "Label11"
		Me.Label10.Text = "Second:"
		Me.Label10.Size = New System.Drawing.Size(41, 25)
		Me.Label10.Location = New System.Drawing.Point(168, 112)
		Me.Label10.TabIndex = 19
		Me.Label10.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label10.BackColor = System.Drawing.SystemColors.Control
		Me.Label10.Enabled = True
		Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label10.UseMnemonic = True
		Me.Label10.Visible = True
		Me.Label10.AutoSize = False
		Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label10.Name = "Label10"
		Me.Label9.Text = "First:"
		Me.Label9.Size = New System.Drawing.Size(33, 17)
		Me.Label9.Location = New System.Drawing.Point(8, 112)
		Me.Label9.TabIndex = 18
		Me.Label9.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label9.BackColor = System.Drawing.SystemColors.Control
		Me.Label9.Enabled = True
		Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label9.UseMnemonic = True
		Me.Label9.Visible = True
		Me.Label9.AutoSize = False
		Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label9.Name = "Label9"
		Me.Label8.Text = "Business Phone:"
		Me.Label8.Size = New System.Drawing.Size(89, 25)
		Me.Label8.Location = New System.Drawing.Point(240, 184)
		Me.Label8.TabIndex = 13
		Me.Label8.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label8.BackColor = System.Drawing.SystemColors.Control
		Me.Label8.Enabled = True
		Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label8.UseMnemonic = True
		Me.Label8.Visible = True
		Me.Label8.AutoSize = False
		Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label8.Name = "Label8"
		Me.Label7.Text = "Home Phone:"
		Me.Label7.Size = New System.Drawing.Size(65, 25)
		Me.Label7.Location = New System.Drawing.Point(8, 184)
		Me.Label7.TabIndex = 11
		Me.Label7.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label7.BackColor = System.Drawing.SystemColors.Control
		Me.Label7.Enabled = True
		Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label7.UseMnemonic = True
		Me.Label7.Visible = True
		Me.Label7.AutoSize = False
		Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label7.Name = "Label7"
		Me.Label6.Text = "E-Mail:"
		Me.Label6.Size = New System.Drawing.Size(137, 17)
		Me.Label6.Location = New System.Drawing.Point(8, 88)
		Me.Label6.TabIndex = 10
		Me.Label6.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label6.BackColor = System.Drawing.SystemColors.Control
		Me.Label6.Enabled = True
		Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label6.UseMnemonic = True
		Me.Label6.Visible = True
		Me.Label6.AutoSize = False
		Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label6.Name = "Label6"
		Me.Label5.Text = "Display:"
		Me.Label5.Size = New System.Drawing.Size(81, 25)
		Me.Label5.Location = New System.Drawing.Point(96, 48)
		Me.Label5.TabIndex = 8
		Me.Label5.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label5.BackColor = System.Drawing.SystemColors.Control
		Me.Label5.Enabled = True
		Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label5.UseMnemonic = True
		Me.Label5.Visible = True
		Me.Label5.AutoSize = False
		Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label5.Name = "Label5"
		Me.Label4.Text = "Title:"
		Me.Label4.Size = New System.Drawing.Size(41, 25)
		Me.Label4.Location = New System.Drawing.Point(8, 48)
		Me.Label4.TabIndex = 6
		Me.Label4.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label4.BackColor = System.Drawing.SystemColors.Control
		Me.Label4.Enabled = True
		Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label4.UseMnemonic = True
		Me.Label4.Visible = True
		Me.Label4.AutoSize = False
		Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label4.Name = "Label4"
		Me.Label3.Text = "Last:"
		Me.Label3.Size = New System.Drawing.Size(49, 25)
		Me.Label3.Location = New System.Drawing.Point(352, 16)
		Me.Label3.TabIndex = 5
		Me.Label3.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label3.BackColor = System.Drawing.SystemColors.Control
		Me.Label3.Enabled = True
		Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label3.UseMnemonic = True
		Me.Label3.Visible = True
		Me.Label3.AutoSize = False
		Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label3.Name = "Label3"
		Me.Label2.Text = "Middle:"
		Me.Label2.Size = New System.Drawing.Size(57, 25)
		Me.Label2.Location = New System.Drawing.Point(168, 16)
		Me.Label2.TabIndex = 4
		Me.Label2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label2.BackColor = System.Drawing.SystemColors.Control
		Me.Label2.Enabled = True
		Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = False
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.Label1.Text = "First:"
		Me.Label1.Size = New System.Drawing.Size(41, 25)
		Me.Label1.Location = New System.Drawing.Point(8, 16)
		Me.Label1.TabIndex = 3
		Me.Label1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.BackColor = System.Drawing.SystemColors.Control
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.Controls.Add(tbPager)
		Me.Controls.Add(rbEmail3)
		Me.Controls.Add(rbEmail2)
		Me.Controls.Add(rbEmail1)
		Me.Controls.Add(tbEmail3)
		Me.Controls.Add(tbEmail2)
		Me.Controls.Add(tbEmail1)
		Me.Controls.Add(btnCancel)
		Me.Controls.Add(btnOk)
		Me.Controls.Add(tbBusinessPhone)
		Me.Controls.Add(tbHomePhone)
		Me.Controls.Add(tbDisplay)
		Me.Controls.Add(tbTitle)
		Me.Controls.Add(tbLast)
		Me.Controls.Add(tbMiddle)
		Me.Controls.Add(tbFirst)
		Me.Controls.Add(Label13)
		Me.Controls.Add(Label12)
		Me.Controls.Add(Label11)
		Me.Controls.Add(Label10)
		Me.Controls.Add(Label9)
		Me.Controls.Add(Label8)
		Me.Controls.Add(Label7)
		Me.Controls.Add(Label6)
		Me.Controls.Add(Label5)
		Me.Controls.Add(Label4)
		Me.Controls.Add(Label3)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label1)
	End Sub
#End Region 
#Region "Upgrade Support "
	Private Shared m_vb6FormDefInstance As frmContact
	Private Shared m_InitializingDefInstance As Boolean
	Public Shared Property DefInstance() As frmContact
		Get
			If m_vb6FormDefInstance Is Nothing OrElse m_vb6FormDefInstance.IsDisposed Then
				m_InitializingDefInstance = True
				m_vb6FormDefInstance = New frmContact()
				m_InitializingDefInstance = False
			End If
			DefInstance = m_vb6FormDefInstance
		End Get
		Set
			m_vb6FormDefInstance = Value
		End Set
	End Property
#End Region 
	Dim OkPressed As Boolean
	
	Private Sub btnCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnCancel.Click
		Me.Hide()
	End Sub
	
	Private Sub btnRemoveEmail_Click()
		Dim lbEmail As Object
        lbEmail.RemoveItem(lbEmail.ListIndex)
	End Sub
	
	Private Sub frmContact_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		OkPressed = False
	End Sub
	Private Sub btnAddEmail_Click()
		Dim tbEmail As Object
		Dim lbEmail As Object
        If tbEmail.Text <> "" Then
            lbEmail.AddItem(tbEmail.Text)
            tbEmail.Text = ""
        End If
	End Sub
	
	Private Sub btnOk_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnOk.Click
		Me.Hide()
		OkPressed = True
	End Sub
	
	Private Sub lbEmail_Click()
		Dim btnRemoveEmail As Object
		Dim lbEmail As Object
        btnRemoveEmail.Enabled = (lbEmail.SelCount > 0)
	End Sub
	
	Public Function GetOkPressed() As Boolean
		GetOkPressed = OkPressed
	End Function
	
	Public Sub SetContact(ByRef contact As NKTWABLib.Contact)
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
			rbEmail1.Checked = True
		End If
		If contact.DefaultEmailAddressIndex = 2 Then
			rbEmail2.Checked = True
		End If
		If contact.DefaultEmailAddressIndex = 3 Then
			rbEmail3.Checked = True
		End If
		
		ShowDialog()
		
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
            ' first and email1 is empty, email1 will get the value
			' because email2 can be defined if email1 is defined and
			' email3 can be defined if email1 and email2 are defined
			' Otherwise, the value set in emailx is set in the first
			' empty value
			contact.Email1Address = tbEmail1.Text
			contact.Email2Address = tbEmail2.Text
			contact.Email3Address = tbEmail3.Text
			
			If rbEmail1.Checked Then
				contact.DefaultEmailAddressIndex = 1
			End If
			If rbEmail2.Checked Then
				contact.DefaultEmailAddressIndex = 2
			End If
			If rbEmail3.Checked Then
				contact.DefaultEmailAddressIndex = 3
			End If
			
            contact.Save()
		End If
		
	End Sub
End Class