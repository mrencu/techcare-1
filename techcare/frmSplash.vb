' Formulario que muestra información del sistema, como lo es, la versión actual, el nombre del autor, etc.

Public NotInheritable Class frmSplash

    Private Sub frmSplash_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblVersion.Text = "Version: " & My.Application.Info.Version.ToString
    End Sub

    Private Sub lblVersion_Click(sender As Object, e As EventArgs) Handles lblVersion.Click

    End Sub
End Class
