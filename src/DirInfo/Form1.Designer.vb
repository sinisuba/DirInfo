<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Me.ButtonNewDir = New System.Windows.Forms.Button()
        Me.TextBoxPath = New System.Windows.Forms.TextBox()
        Me.LabelDirPath = New System.Windows.Forms.Label()
        Me.LabelDriveInfo = New System.Windows.Forms.Label()
        Me.LabelFajlovi = New System.Windows.Forms.Label()
        Me.ListBoxFajlovi = New System.Windows.Forms.ListBox()
        Me.LabelFolderi = New System.Windows.Forms.Label()
        Me.ButtonIspis = New System.Windows.Forms.Button()
        Me.ListBoxFolderi = New System.Windows.Forms.ListBox()
        Me.ButtonDelDir = New System.Windows.Forms.Button()
        Me.ButtonDirSearch = New System.Windows.Forms.Button()
        Me.ButtonFileSearch = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ButtonNewDir
        '
        Me.ButtonNewDir.Enabled = False
        Me.ButtonNewDir.Location = New System.Drawing.Point(21, 438)
        Me.ButtonNewDir.Name = "ButtonNewDir"
        Me.ButtonNewDir.Size = New System.Drawing.Size(157, 37)
        Me.ButtonNewDir.TabIndex = 17
        Me.ButtonNewDir.Text = "Novi direktorijum"
        Me.ButtonNewDir.UseVisualStyleBackColor = True
        '
        'TextBoxPath
        '
        Me.TextBoxPath.Location = New System.Drawing.Point(140, 49)
        Me.TextBoxPath.Name = "TextBoxPath"
        Me.TextBoxPath.Size = New System.Drawing.Size(113, 23)
        Me.TextBoxPath.TabIndex = 16
        '
        'LabelDirPath
        '
        Me.LabelDirPath.AutoSize = True
        Me.LabelDirPath.Location = New System.Drawing.Point(155, 21)
        Me.LabelDirPath.Name = "LabelDirPath"
        Me.LabelDirPath.Size = New System.Drawing.Size(82, 15)
        Me.LabelDirPath.TabIndex = 15
        Me.LabelDirPath.Text = "Directory path"
        '
        'LabelDriveInfo
        '
        Me.LabelDriveInfo.Location = New System.Drawing.Point(0, 140)
        Me.LabelDriveInfo.Name = "LabelDriveInfo"
        Me.LabelDriveInfo.Size = New System.Drawing.Size(400, 26)
        Me.LabelDriveInfo.TabIndex = 14
        Me.LabelDriveInfo.Text = "LabelDriveInfo"
        Me.LabelDriveInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LabelDriveInfo.Visible = False
        '
        'LabelFajlovi
        '
        Me.LabelFajlovi.AutoSize = True
        Me.LabelFajlovi.Location = New System.Drawing.Point(273, 179)
        Me.LabelFajlovi.Name = "LabelFajlovi"
        Me.LabelFajlovi.Size = New System.Drawing.Size(41, 15)
        Me.LabelFajlovi.TabIndex = 13
        Me.LabelFajlovi.Text = "Fajlovi"
        '
        'ListBoxFajlovi
        '
        Me.ListBoxFajlovi.FormattingEnabled = True
        Me.ListBoxFajlovi.HorizontalScrollbar = True
        Me.ListBoxFajlovi.ItemHeight = 15
        Me.ListBoxFajlovi.Location = New System.Drawing.Point(215, 202)
        Me.ListBoxFajlovi.Name = "ListBoxFajlovi"
        Me.ListBoxFajlovi.Size = New System.Drawing.Size(157, 214)
        Me.ListBoxFajlovi.TabIndex = 12
        '
        'LabelFolderi
        '
        Me.LabelFolderi.AutoSize = True
        Me.LabelFolderi.Location = New System.Drawing.Point(78, 179)
        Me.LabelFolderi.Name = "LabelFolderi"
        Me.LabelFolderi.Size = New System.Drawing.Size(43, 15)
        Me.LabelFolderi.TabIndex = 11
        Me.LabelFolderi.Text = "Folderi"
        '
        'ButtonIspis
        '
        Me.ButtonIspis.Location = New System.Drawing.Point(140, 89)
        Me.ButtonIspis.Name = "ButtonIspis"
        Me.ButtonIspis.Size = New System.Drawing.Size(113, 37)
        Me.ButtonIspis.TabIndex = 10
        Me.ButtonIspis.Text = "Ispis"
        Me.ButtonIspis.UseVisualStyleBackColor = True
        '
        'ListBoxFolderi
        '
        Me.ListBoxFolderi.FormattingEnabled = True
        Me.ListBoxFolderi.HorizontalScrollbar = True
        Me.ListBoxFolderi.ItemHeight = 15
        Me.ListBoxFolderi.Location = New System.Drawing.Point(21, 202)
        Me.ListBoxFolderi.Name = "ListBoxFolderi"
        Me.ListBoxFolderi.Size = New System.Drawing.Size(157, 214)
        Me.ListBoxFolderi.TabIndex = 9
        '
        'ButtonDelDir
        '
        Me.ButtonDelDir.Enabled = False
        Me.ButtonDelDir.Location = New System.Drawing.Point(215, 438)
        Me.ButtonDelDir.Name = "ButtonDelDir"
        Me.ButtonDelDir.Size = New System.Drawing.Size(157, 37)
        Me.ButtonDelDir.TabIndex = 18
        Me.ButtonDelDir.Text = "Brisi direktorijum"
        Me.ButtonDelDir.UseVisualStyleBackColor = True
        '
        'ButtonDirSearch
        '
        Me.ButtonDirSearch.Enabled = False
        Me.ButtonDirSearch.Location = New System.Drawing.Point(21, 488)
        Me.ButtonDirSearch.Name = "ButtonDirSearch"
        Me.ButtonDirSearch.Size = New System.Drawing.Size(157, 37)
        Me.ButtonDirSearch.TabIndex = 19
        Me.ButtonDirSearch.Text = "Pretraga direktorijuma"
        Me.ButtonDirSearch.UseVisualStyleBackColor = True
        '
        'ButtonFileSearch
        '
        Me.ButtonFileSearch.Enabled = False
        Me.ButtonFileSearch.Location = New System.Drawing.Point(215, 488)
        Me.ButtonFileSearch.Name = "ButtonFileSearch"
        Me.ButtonFileSearch.Size = New System.Drawing.Size(157, 37)
        Me.ButtonFileSearch.TabIndex = 20
        Me.ButtonFileSearch.Text = "Pretraga fajlova"
        Me.ButtonFileSearch.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(401, 546)
        Me.Controls.Add(Me.ButtonFileSearch)
        Me.Controls.Add(Me.ButtonDirSearch)
        Me.Controls.Add(Me.ButtonDelDir)
        Me.Controls.Add(Me.ButtonNewDir)
        Me.Controls.Add(Me.TextBoxPath)
        Me.Controls.Add(Me.LabelDirPath)
        Me.Controls.Add(Me.LabelDriveInfo)
        Me.Controls.Add(Me.LabelFajlovi)
        Me.Controls.Add(Me.ListBoxFajlovi)
        Me.Controls.Add(Me.LabelFolderi)
        Me.Controls.Add(Me.ButtonIspis)
        Me.Controls.Add(Me.ListBoxFolderi)
        Me.Name = "Form1"
        Me.Text = "Directory Info"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ButtonNewDir As Button
    Friend WithEvents TextBoxPath As TextBox
    Friend WithEvents LabelDirPath As Label
    Friend WithEvents LabelDriveInfo As Label
    Friend WithEvents LabelFajlovi As Label
    Friend WithEvents ListBoxFajlovi As ListBox
    Friend WithEvents LabelFolderi As Label
    Friend WithEvents ButtonIspis As Button
    Friend WithEvents ListBoxFolderi As ListBox
    Friend WithEvents ButtonDelDir As Button
    Friend WithEvents ButtonDirSearch As Button
    Friend WithEvents ButtonFileSearch As Button
End Class
