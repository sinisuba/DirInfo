﻿Imports System.IO ' System.IO.Directory, System.IO.File

Public Class Form1
    Private Sub ButtonIspis_Click(sender As Object, e As EventArgs) Handles ButtonIspis.Click
        ListBoxFolderi.Items.Clear()
        ListBoxFajlovi.Items.Clear()

        LabelDriveInfo.Visible = True

        Dim path As String = TextBoxPath.Text

        If Directory.Exists(path) Then
            LabelDriveInfo.Text = "Pronadjen directory path '" & path & "'"
            ButtonNewDir.Enabled = True

            Dim folderi As String() = Directory.GetDirectories(path)
            Dim fajlovi As String() = Directory.GetFiles(path)

            For Each folder As String In folderi
                Try
                    If (File.GetAttributes(folder).HasFlag(FileAttributes.Hidden)) Then
                        ListBoxFolderi.Items.Add("[Hidden] " & folder)
                    Else
                        ListBoxFolderi.Items.Add(folder)
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit For
                End Try
            Next

            For Each fajl As String In fajlovi
                Try
                    If (File.GetAttributes(fajl).HasFlag(FileAttributes.Hidden)) Then
                        ListBoxFajlovi.Items.Add("[Hidden] " & fajl)
                    Else
                        ListBoxFajlovi.Items.Add(fajl)
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit For
                End Try
            Next
        Else
            LabelDriveInfo.Text = "Navedeni directory path " & "'" & path & "' " & "ne postoji!"
            ButtonNewDir.Enabled = False
        End If
    End Sub

    Private Sub ButtonNewDir_Click(sender As Object, e As EventArgs) Handles ButtonNewDir.Click
        Dim dirName As String = InputBox("Unesite naziv novog direktorijuma", "New Dir")

        If String.IsNullOrWhiteSpace(dirName) Then
            MessageBox.Show("Unesite pravilan naziv!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If Directory.Exists(TextBoxPath.Text & dirName) Then
                MessageBox.Show("Directory '" & dirName & "' vec postoji.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Try
                    Directory.CreateDirectory(TextBoxPath.Text & dirName)
                    MessageBox.Show("Uspjesno kreiran direktorijum '" & dirName & "'", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If
    End Sub
End Class