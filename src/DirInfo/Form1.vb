Imports System.IO ' System.IO.Directory, System.IO.File

#Disable Warning IDE1006 ' Disable Naming Styles Warning in VS

Public Class Form1
    Dim prev_paths(0) As String
    Dim index As Integer = -1
    Dim index_incremented As Boolean = False
    Dim dir_changed As Boolean = True
    Dim prev_TextBoxPath As String

    Private Sub printDirs(ByRef folderi() As String)
        For Each folder In folderi
            Try
                If File.GetAttributes(folder).HasFlag(FileAttributes.Hidden) Then
                    ListBoxFolderi.Items.Add("[Hidden] " & folder)
                Else
                    ListBoxFolderi.Items.Add(folder)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit For
            End Try
        Next
    End Sub

    Private Sub printFiles(ByRef fajlovi() As String)
        For Each fajl In fajlovi
            Try
                If File.GetAttributes(fajl).HasFlag(FileAttributes.Hidden) Then
                    ListBoxFajlovi.Items.Add("[Hidden] " & fajl)
                Else
                    ListBoxFajlovi.Items.Add(fajl)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit For
            End Try
        Next
    End Sub

    Private Sub ButtonIspis_Click(sender As Object, e As EventArgs) Handles ButtonIspis.Click
        Dim hidden_attempt As Boolean = False

        ' Allow the user to browse directories via ListBox selection
        If ListBoxFolderi.SelectedIndex >= 0 Then ' An item is selected in ListBoxFolderi
            If ListBoxFolderi.SelectedItem.Length >= 8 Then ' Substring throws exception if unhandled
                If ListBoxFolderi.SelectedItem.Substring(0, 8) = "[Hidden]" Then
                    MessageBox.Show("Nije dozvoljen prikaz skrivenih direktorijuma!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    hidden_attempt = True
                End If
            End If
            If hidden_attempt = False Then
                TextBoxPath.Text = ListBoxFolderi.SelectedItem
            End If
        End If

        Dim path As String = TextBoxPath.Text

        ListBoxFolderi.Items.Clear()
        ListBoxFajlovi.Items.Clear()

        TextBoxPathInfo.Visible = True

        If Directory.Exists(path) Then
            Try
                Directory.GetDirectories(path)
            Catch noAuth As System.UnauthorizedAccessException ' Attempting to access certain directories can throw an UnauthorizedAccessException
                MessageBox.Show(noAuth.Message, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            If (TextBoxPath.Text(TextBoxPath.Text.Length - 1) <> "/" And TextBoxPath.Text(TextBoxPath.Text.Length - 1) <> "\") Then
                TextBoxPath.Text &= "\" ' Handles path ending; avoids issues with directory creation
            End If

            Dim folderi() As String = Directory.GetDirectories(path)
            Dim fajlovi() As String = Directory.GetFiles(path)

            TextBoxPathInfo.Text = "Pronadjen directory path '" & TextBoxPath.Text & "'"

            If TextBoxPath.Text = prev_TextBoxPath Then
                dir_changed = False
            Else
                dir_changed = True
            End If

            prev_TextBoxPath = TextBoxPath.Text

            If hidden_attempt = False And dir_changed = True Then ' Avoid index increment if a hidden directory is selected, or if user is attempting to load the same dir
                index += 1
                ReDim Preserve prev_paths(index)
                prev_paths(index) = TextBoxPath.Text
            End If

            ButtonNewDir.Enabled = True
            ButtonDelDir.Enabled = True
            ButtonReturn.Enabled = True
            ButtonDirSearch.Enabled = True
            ButtonFileSearch.Enabled = True

            printDirs(folderi)
            printFiles(fajlovi)
        Else
            My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Asterisk) ' Warn user on unknown dir attempt

            If String.IsNullOrWhiteSpace(TextBoxPath.Text) Then
                TextBoxPathInfo.Text = "Unesite directory path!"
            Else
                TextBoxPathInfo.Text = "Navedeni directory path " & "'" & TextBoxPath.Text & "' " & "ne postoji!"
            End If

            If hidden_attempt = False And index_incremented = False Then
                index += 1 ' Handles return to previous dir
                index_incremented = True
            End If

            ButtonNewDir.Enabled = False
            ButtonDelDir.Enabled = False
            ButtonDirSearch.Enabled = False
            ButtonFileSearch.Enabled = False
        End If
    End Sub
    Private Sub ButtonReturn_Click(sender As Object, e As EventArgs) Handles ButtonReturn.Click
        index -= 1

        If index >= 0 Then
            Dim folderi As String() = Directory.GetDirectories(prev_paths(index))
            Dim fajlovi As String() = Directory.GetFiles(prev_paths(index))

            TextBoxPath.Text = prev_paths(index)
            TextBoxPathInfo.Text = "Pronadjen directory path '" & TextBoxPath.Text & "'"

            ListBoxFolderi.Items.Clear()
            ListBoxFajlovi.Items.Clear()

            ButtonIspis.PerformClick() ' If the user navigates to an existing directory from an unknown one, enables buttons; Increments index
            index -= 1

            printDirs(folderi)
            printFiles(fajlovi)
        Else
            ButtonReturn.Enabled = False ' No previous directories
            index += 1 ' Handles the -1 index/beginning of path return issue
        End If
    End Sub

    Private Sub dirDblClick(sender As Object, e As EventArgs) Handles ListBoxFolderi.DoubleClick
        Dim dirSelected As String = ListBoxFolderi.SelectedItem

        If Not String.IsNullOrWhiteSpace(dirSelected) Then ' Users can double-click empty space ('Nothing') and throw an exception if unhandled
            If dirSelected.Length >= 8 Then
                If dirSelected.Substring(0, 8) = "[Hidden]" Then
                    MessageBox.Show("Nije dozvoljen prikaz skrivenih direktorijuma!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    TextBoxPath.Text = dirSelected
                    ButtonIspis.PerformClick()
                End If
            Else
                TextBoxPath.Text = dirSelected
                ButtonIspis.PerformClick()
            End If
        End If
    End Sub

    Private Sub fileDblClick(sender As Object, e As EventArgs) Handles ListBoxFajlovi.MouseDoubleClick
        Dim showInfo As Boolean = True

        Dim fileSelected As String = ListBoxFajlovi.SelectedItem

        If Not String.IsNullOrWhiteSpace(fileSelected) Then
            If fileSelected.Length >= 8 Then
                If fileSelected.Substring(0, 8) = "[Hidden]" Then
                    MessageBox.Show("Nije dozvoljen prikaz informacija o skrivenim fajlovima!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    showInfo = False
                End If
            End If
        Else
            showInfo = False
        End If

        If showInfo Then
            Dim fileName As String = ""

            Dim i As Integer = fileSelected.Length - 1

            While fileSelected(i) <> "\" And fileSelected(i) <> "/"
                fileName &= fileSelected(i)
                i -= 1
            End While

            Dim fileInfo As New IO.FileInfo(fileSelected)

            Dim info As String = ""

            Dim isReadOnly As Boolean = fileInfo.IsReadOnly
            If isReadOnly Then
                info &= "Fajl je read-only."
            Else
                info &= "Fajl nije read-only."
            End If

            info &= Environment.NewLine
            info &= "Vrijeme kreiranja fajla: " & fileInfo.CreationTime
            info &= Environment.NewLine
            info &= "Vrijeme zadnjeg pristupa: " & fileInfo.LastAccessTime

            MessageBox.Show(info, "Informacije o fajlu: '" & Strings.StrReverse(fileName) & "'", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ButtonNewDir_Click(sender As Object, e As EventArgs) Handles ButtonNewDir.Click
        Dim dirName As String = InputBox("Unesite naziv novog direktorijuma", "New Dir")

        If String.IsNullOrWhiteSpace(dirName) Then
            MessageBox.Show("Unesite pravilan naziv!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If Directory.Exists(TextBoxPath.Text & dirName) Then
                MessageBox.Show("Direktorijum '" & dirName & "' vec postoji.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Try
                    Directory.CreateDirectory(TextBoxPath.Text & dirName)
                    MessageBox.Show("Uspjesno kreiran direktorijum '" & dirName & "'", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ButtonIspis.PerformClick()
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If
    End Sub

    Private Sub ButtonDelDir_Click(sender As Object, e As EventArgs) Handles ButtonDelDir.Click
        MessageBox.Show("Odabrani direktorijum ce biti izbrisan!", "Del Dir", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Dim dirName As String = InputBox("Unesite naziv direktorijuma za brisanje", "Del Dir")

        If String.IsNullOrWhiteSpace(dirName) Then
            MessageBox.Show("Unesite pravilan naziv!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Try
                Directory.Delete(TextBoxPath.Text & dirName)
                MessageBox.Show("Uspjesno obrisan direktorijum '" & dirName & "'", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ButtonIspis.PerformClick()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub ButtonDirSearch_Click(sender As Object, e As EventArgs) Handles ButtonDirSearch.Click
        Dim dir As String = InputBox("* Pretrazivanje skrivenih direktorijuma nije dozvoljeno", "Unesite naziv direktorijuma")

        If String.IsNullOrWhiteSpace(dir) Then
            MessageBox.Show("Unesite pravilan naziv!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim dirSearch As String = TextBoxPath.Text & dir
            Dim found As Boolean = False

            For i = 0 To ListBoxFolderi.Items.Count - 1
                If ListBoxFolderi.Items(i).ToString.ToLower = dirSearch.ToLower() Then ' Ignore case
                    found = True
                    Exit For
                End If
            Next

            If found Then
                MessageBox.Show("Pronadjen direktorijum '" & dirSearch & "'", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TextBoxPath.Text = dirSearch
                ButtonIspis.PerformClick()
            Else
                MessageBox.Show("Direktorijum '" & dirSearch & "' ne postoji!", "Nepostojeci direktorijum", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub ButtonFileSearch_Click(sender As Object, e As EventArgs) Handles ButtonFileSearch.Click
        Dim file As String = InputBox("* Pretrazivanje skrivenih fajlova nije dozvoljeno", "Unesite naziv fajla")

        If String.IsNullOrWhiteSpace(file) Then
            MessageBox.Show("Unesite pravilan naziv sa ekstenzijom!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim fileSearch As String = TextBoxPath.Text & file
            Dim found As Boolean = False

            For i = 0 To ListBoxFajlovi.Items.Count - 1
                If ListBoxFajlovi.Items(i).ToString.ToLower = fileSearch.ToLower() Then ' Ignore case
                    found = True
                    Exit For
                End If
            Next

            If found Then
                MessageBox.Show("Pronadjen fajl '" & fileSearch & "'", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Fajl '" & fileSearch & "' ne postoji!", "Nepostojeci fajl", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub ButtonIspis_MouseHover(sender As Object, e As EventArgs) Handles ButtonIspis.MouseHover
        ToolTipIspis.SetToolTip(ButtonIspis, "Ispis sadrzaja trenutnog direktorijuma")
    End Sub
    Private Sub ButtonReturn_MouseHover(sender As Object, e As EventArgs) Handles ButtonReturn.MouseHover
        ToolTipReturn.SetToolTip(ButtonReturn, "Nazad")
    End Sub

    Private Sub ButtonNewDir_MouseHover(sender As Object, e As EventArgs) Handles ButtonNewDir.MouseHover
        ' No need to check for valid TextBoxPath, already handled in ButtonIspis_Click
        ToolTipNewDir.SetToolTip(ButtonNewDir, "Direktorijum ce biti kreiran u: '" & TextBoxPath.Text & "'")
    End Sub

End Class
