<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Me.cbotype = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtdata = New System.Windows.Forms.TextBox()
        Me.btnfind = New System.Windows.Forms.Button()
        Me.dgvrecord = New System.Windows.Forms.DataGridView()
        Me.btnback = New System.Windows.Forms.Button()
        CType(Me.dgvrecord, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbotype
        '
        Me.cbotype.FormattingEnabled = True
        Me.cbotype.Location = New System.Drawing.Point(44, 67)
        Me.cbotype.Name = "cbotype"
        Me.cbotype.Size = New System.Drawing.Size(226, 23)
        Me.cbotype.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label1.Location = New System.Drawing.Point(299, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Search"
        '
        'txtdata
        '
        Me.txtdata.Location = New System.Drawing.Point(378, 67)
        Me.txtdata.Name = "txtdata"
        Me.txtdata.Size = New System.Drawing.Size(210, 23)
        Me.txtdata.TabIndex = 2
        '
        'btnfind
        '
        Me.btnfind.Location = New System.Drawing.Point(619, 66)
        Me.btnfind.Name = "btnfind"
        Me.btnfind.Size = New System.Drawing.Size(131, 23)
        Me.btnfind.TabIndex = 3
        Me.btnfind.Text = "Find Record"
        Me.btnfind.UseVisualStyleBackColor = True
        '
        'dgvrecord
        '
        Me.dgvrecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvrecord.Location = New System.Drawing.Point(44, 112)
        Me.dgvrecord.Name = "dgvrecord"
        Me.dgvrecord.RowTemplate.Height = 25
        Me.dgvrecord.Size = New System.Drawing.Size(706, 244)
        Me.dgvrecord.TabIndex = 4
        '
        'btnback
        '
        Me.btnback.Location = New System.Drawing.Point(654, 375)
        Me.btnback.Name = "btnback"
        Me.btnback.Size = New System.Drawing.Size(75, 43)
        Me.btnback.TabIndex = 5
        Me.btnback.Text = "Back"
        Me.btnback.UseVisualStyleBackColor = True
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnback)
        Me.Controls.Add(Me.dgvrecord)
        Me.Controls.Add(Me.btnfind)
        Me.Controls.Add(Me.txtdata)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbotype)
        Me.Name = "Form2"
        Me.Text = "Form2"
        CType(Me.dgvrecord, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cbotype As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtdata As TextBox
    Friend WithEvents btnfind As Button
    Friend WithEvents dgvrecord As DataGridView
    Friend WithEvents btnback As Button
End Class
