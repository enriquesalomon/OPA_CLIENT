<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmWelcome
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmWelcome))
        Me.btnUpdateAccessCode = New System.Windows.Forms.Button()
        Me.SuspendLayout()
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
        Me.btnUpdateAccessCode.Location = New System.Drawing.Point(-3, 184)
        Me.btnUpdateAccessCode.Name = "btnUpdateAccessCode"
        Me.btnUpdateAccessCode.Size = New System.Drawing.Size(386, 39)
        Me.btnUpdateAccessCode.TabIndex = 226
        Me.btnUpdateAccessCode.Text = "Continue..."
        Me.btnUpdateAccessCode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnUpdateAccessCode.UseVisualStyleBackColor = False
        '
        'FrmWelcome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(381, 223)
        Me.Controls.Add(Me.btnUpdateAccessCode)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmWelcome"
        Me.Text = "FrmWelcome"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnUpdateAccessCode As Button
End Class
