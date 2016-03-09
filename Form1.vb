Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.ScrollBars = ScrollBars.Vertical
    End Sub

    Private Sub Form1_FormClosing(sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.FormClosing
        If TextBox1.Modified Then
            Dim ask As MsgBoxResult
            ask = MsgBox("Do you want to save the changes you made?", MsgBoxStyle.YesNoCancel, "Save Changes")
            If ask = MsgBoxResult.No Then
            ElseIf ask = MsgBoxResult.Cancel Then
                e.Cancel = True
            ElseIf ask = MsgBoxResult.Yes Then
                If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                    My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, TextBox1.Text, False)
                End If
            End If
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, TextBox1.Text, False)
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub MoreAppsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MoreAppsToolStripMenuItem.Click
        Process.Start("http://dvt32.blogspot.com/")
    End Sub

    Private Sub SaveFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk

    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        If TextBox1.Modified Then
            Dim ask As MsgBoxResult
            ask = MsgBox("Do you want to save the changes you made?", MsgBoxStyle.YesNoCancel, "New Document")
            If ask = MsgBoxResult.No Then
                TextBox1.Clear()
            ElseIf ask = MsgBoxResult.Cancel Then
            ElseIf ask = MsgBoxResult.Yes Then
                If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                    My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, TextBox1.Text, False)
                    TextBox1.Clear()
                End If
            Else
                TextBox1.Clear()
            End If
        End If
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        Dim message = "SimplePad v1.0" + Environment.NewLine + Environment.NewLine + "More apps @ http://dvt32.blogspot.com "
        MsgBox(message, MsgBoxStyle.Information, "About SimplePad")
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        If TextBox1.Modified Then
            Dim ask As MsgBoxResult
            ask = MsgBox("Do you want to save the changes you made?", MsgBoxStyle.YesNoCancel, "Open Document")
            If ask = MsgBoxResult.No Then
                OpenFileDialog1.ShowDialog()
                TextBox1.Text = My.Computer.FileSystem.ReadAllText(OpenFileDialog1.FileName)
            ElseIf ask = MsgBoxResult.Cancel Then
            ElseIf ask = MsgBoxResult.Yes Then
                If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                    My.Computer.FileSystem.WriteAllText(SaveFileDialog1.FileName, TextBox1.Text, False)
                End If
                OpenFileDialog1.ShowDialog()
                TextBox1.Text = My.Computer.FileSystem.ReadAllText(OpenFileDialog1.FileName)
            End If
        Else
            OpenFileDialog1.ShowDialog()
            TextBox1.Text = My.Computer.FileSystem.ReadAllText(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub SetFontToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetFontToolStripMenuItem.Click
        If FontDialog1.ShowDialog() = DialogResult.OK Then
            TextBox1.Font = FontDialog1.Font
        End If
    End Sub

    Private Sub SetColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetColorToolStripMenuItem.Click
        If ColorDialog1.ShowDialog() = DialogResult.OK Then
            TextBox1.ForeColor = ColorDialog1.Color
        End If
    End Sub

    Private Sub SetBackgroundColorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetBackgroundColorToolStripMenuItem.Click
        If ColorDialog1.ShowDialog() = DialogResult.OK Then
            TextBox1.BackColor = ColorDialog1.Color
        End If
    End Sub
End Class
