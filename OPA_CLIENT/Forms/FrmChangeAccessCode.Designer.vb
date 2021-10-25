<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmChangeAccessCode
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmChangeAccessCode))
        Me.Button3 = New System.Windows.Forms.Button()
        Me.txtOldAccessCode = New System.Windows.Forms.TextBox()
        Me.txtNewAccessCode = New System.Windows.Forms.TextBox()
        Me.txtRetypeNewAccessCode = New System.Windows.Forms.TextBox()
        Me.btnUpdateAccessCode = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Button3
        '
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(12, 5)
        Me.Button3.Name = "Button3"
        Me.Button3.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.Button3.Size = New System.Drawing.Size(195, 37)
        Me.Button3.TabIndex = 7
        Me.Button3.Text = "    Change Access Code"
        Me.Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button3.UseVisualStyleBackColor = True
        '
        'txtOldAccessCode
        '
        Me.txtOldAccessCode.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtOldAccessCode.BackColor = System.Drawing.Color.White
        Me.txtOldAccessCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOldAccessCode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtOldAccessCode.Location = New System.Drawing.Point(262, 130)
        Me.txtOldAccessCode.MinimumSize = New System.Drawing.Size(229, 22)
        Me.txtOldAccessCode.Name = "txtOldAccessCode"
        Me.txtOldAccessCode.Size = New System.Drawing.Size(254, 22)
        Me.txtOldAccessCode.TabIndex = 220
        Me.txtOldAccessCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtNewAccessCode
        '
        Me.txtNewAccessCode.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtNewAccessCode.BackColor = System.Drawing.Color.White
        Me.txtNewAccessCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNewAccessCode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtNewAccessCode.Location = New System.Drawing.Point(261, 175)
        Me.txtNewAccessCode.Name = "txtNewAccessCode"
        Me.txtNewAccessCode.Size = New System.Drawing.Size(254, 22)
        Me.txtNewAccessCode.TabIndex = 221
        Me.txtNewAccessCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtRetypeNewAccessCode
        '
        Me.txtRetypeNewAccessCode.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtRetypeNewAccessCode.BackColor = System.Drawing.Color.White
        Me.txtRetypeNewAccessCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRetypeNewAccessCode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtRetypeNewAccessCode.Location = New System.Drawing.Point(261, 221)
        Me.txtRetypeNewAccessCode.Name = "txtRetypeNewAccessCode"
        Me.txtRetypeNewAccessCode.Size = New System.Drawing.Size(254, 22)
        Me.txtRetypeNewAccessCode.TabIndex = 222
        Me.txtRetypeNewAccessCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnUpdateAccessCode
        '
        Me.btnUpdateAccessCode.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnUpdateAccessCode.BackColor = System.Drawing.SystemColors.Highlight
        Me.btnUpdateAccessCode.FlatAppearance.BorderSize = 0
        Me.btnUpdateAccessCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpdateAccessCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdateAccessCode.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnUpdateAccessCode.ImageKey = "Check_16x16.png"
        Me.btnUpdateAccessCode.Location = New System.Drawing.Point(261, 249)
        Me.btnUpdateAccessCode.Name = "btnUpdateAccessCode"
        Me.btnUpdateAccessCode.Size = New System.Drawing.Size(253, 39)
        Me.btnUpdateAccessCode.TabIndex = 225
        Me.btnUpdateAccessCode.Text = "Update"
        Me.btnUpdateAccessCode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnUpdateAccessCode.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(340, 114)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 226
        Me.Label1.Text = "Old access code"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(330, 158)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 13)
        Me.Label2.TabIndex = 227
        Me.Label2.Text = "Type new access code"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(323, 205)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(128, 13)
        Me.Label3.TabIndex = 228
        Me.Label3.Text = "Retype new access code"
        '
        'FrmChangeAccessCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnUpdateAccessCode)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.txtOldAccessCode)
        Me.Controls.Add(Me.txtRetypeNewAccessCode)
        Me.Controls.Add(Me.txtNewAccessCode)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmChangeAccessCode"
        Me.Text = "FrmChangeAccessCode"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button3 As Button
    Friend WithEvents txtOldAccessCode As TextBox
    Friend WithEvents txtNewAccessCode As TextBox
    Friend WithEvents txtRetypeNewAccessCode As TextBox
    Friend WithEvents btnUpdateAccessCode As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class
