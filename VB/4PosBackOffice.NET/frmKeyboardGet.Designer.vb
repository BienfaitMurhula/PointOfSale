<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmKeyboardGet
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'This call is required by the Windows Form Designer.
		InitializeComponent()
	End Sub
	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
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
	Public WithEvents Command1 As System.Windows.Forms.Button
	Public WithEvents cmdAccept As System.Windows.Forms.Button
	Public WithEvents Text1 As System.Windows.Forms.TextBox
	Public WithEvents lblName As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents lblKey As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmKeyboardGet))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.Command1 = New System.Windows.Forms.Button
		Me.cmdAccept = New System.Windows.Forms.Button
		Me.Text1 = New System.Windows.Forms.TextBox
		Me.lblName = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.lblKey = New System.Windows.Forms.Label
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.ControlBox = False
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.ClientSize = New System.Drawing.Size(250, 76)
		Me.Location = New System.Drawing.Point(3, 3)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmKeyboardGet"
		Me.Command1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.Command1.Text = "Decline"
		Me.Command1.Size = New System.Drawing.Size(73, 22)
		Me.Command1.Location = New System.Drawing.Point(174, 42)
		Me.Command1.TabIndex = 3
		Me.Command1.TabStop = False
		Me.Command1.BackColor = System.Drawing.SystemColors.Control
		Me.Command1.CausesValidation = True
		Me.Command1.Enabled = True
		Me.Command1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Command1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Command1.Name = "Command1"
		Me.cmdAccept.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdAccept.Text = "Accept"
		Me.cmdAccept.Size = New System.Drawing.Size(73, 22)
		Me.cmdAccept.Location = New System.Drawing.Point(99, 42)
		Me.cmdAccept.TabIndex = 2
		Me.cmdAccept.TabStop = False
		Me.cmdAccept.BackColor = System.Drawing.SystemColors.Control
		Me.cmdAccept.CausesValidation = True
		Me.cmdAccept.Enabled = True
		Me.cmdAccept.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdAccept.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdAccept.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdAccept.Name = "cmdAccept"
		Me.Text1.AutoSize = False
		Me.Text1.Size = New System.Drawing.Size(149, 25)
		Me.Text1.Location = New System.Drawing.Point(0, 108)
		Me.Text1.TabIndex = 0
		Me.Text1.Text = "Text1"
		Me.Text1.AcceptsReturn = True
		Me.Text1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.Text1.BackColor = System.Drawing.SystemColors.Window
		Me.Text1.CausesValidation = True
		Me.Text1.Enabled = True
		Me.Text1.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Text1.HideSelection = True
		Me.Text1.ReadOnly = False
		Me.Text1.Maxlength = 0
		Me.Text1.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.Text1.MultiLine = False
		Me.Text1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Text1.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.Text1.TabStop = True
		Me.Text1.Visible = True
		Me.Text1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Text1.Name = "Text1"
		Me.lblName.Text = "..."
		Me.lblName.Size = New System.Drawing.Size(241, 16)
		Me.lblName.Location = New System.Drawing.Point(3, 21)
		Me.lblName.TabIndex = 5
		Me.lblName.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblName.BackColor = System.Drawing.Color.Transparent
		Me.lblName.Enabled = True
		Me.lblName.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblName.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblName.UseMnemonic = True
		Me.lblName.Visible = True
		Me.lblName.AutoSize = False
		Me.lblName.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.lblName.Name = "lblName"
		Me.Label1.Text = "Press the desired Key combination"
		Me.Label1.Size = New System.Drawing.Size(241, 16)
		Me.Label1.Location = New System.Drawing.Point(3, 0)
		Me.Label1.TabIndex = 4
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
		Me.lblKey.Text = "Label1"
		Me.lblKey.Size = New System.Drawing.Size(86, 20)
		Me.lblKey.Location = New System.Drawing.Point(6, 42)
		Me.lblKey.TabIndex = 1
		Me.lblKey.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.lblKey.BackColor = System.Drawing.SystemColors.Control
		Me.lblKey.Enabled = True
		Me.lblKey.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblKey.Cursor = System.Windows.Forms.Cursors.Default
		Me.lblKey.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.lblKey.UseMnemonic = True
		Me.lblKey.Visible = True
		Me.lblKey.AutoSize = False
		Me.lblKey.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblKey.Name = "lblKey"
		Me.Controls.Add(Command1)
		Me.Controls.Add(cmdAccept)
		Me.Controls.Add(Text1)
		Me.Controls.Add(lblName)
		Me.Controls.Add(Label1)
		Me.Controls.Add(lblKey)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class