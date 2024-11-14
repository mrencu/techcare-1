' Importamos el espacio de nombres System.Windows.Forms para acceder a ciertas clases del mismo
Imports System.Windows.Forms

Public Class frmLogin

    ' Cuando el usuario haga clic en el botón "Iniciar sesión" llamados al subprocedimiento startLogin()
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        startLogin()
    End Sub
    ' Se evalua cada tecla que el usuario presiona, si la tecla presionada es Enter, se inicia el método StartLogin()
    Private Sub tbPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles tbPassword.KeyDown
        If e.KeyCode = Keys.Enter Then startLogin()
    End Sub
    
    Private Sub tbUsername_KeyDown(sender As Object, e As KeyEventArgs) Handles tbUsername.KeyDown
        If e.KeyCode = Keys.Enter Then startLogin()
    End Sub

    ' Subprocedimiento que verifica las credenciales del usuario
    Public Sub startLogin()
        ' Si el usuario inserto datos, se llama a la función que verifica que la información ingresada corresponda a un usuario registrado
        If tbUsername.TextLength > 0 And tbPassword.TextLength > 0 Then
            Dim empID As String = Convert.ToString(functions.authenticate(tbUsername.Text, tbPassword.Text))
            ' Si el resultado devuelto por la función "authenticate" es 0, se le indica al usuario que las credenciales son inválidas
            If empID = "0" Then
                MsgBox("¡Error de inicio de sesión! El nombre de usuario o la contraseña son incorrectos.", MsgBoxStyle.Critical, "techcare")
                tbPassword.Clear()
                tbPassword.Focus()
            ' Si el resultado devuelto por la función "authenticate" es 1, se procede a redirigir al usuario a la pantalla de inicio
            Else
                frmMainWindow.sidePanel.Visible = True
                frmMainWindow.lblEmpID.Visible = True
                frmMainWindow.lblCurrentUser.Visible = True
                frmMainWindow.lblEmpID.Text = empID
                frmMainWindow.lblCurrentUser.Text = functions.obtainEmployeeDetails(empID, 2).ToString & " " & functions.obtainEmployeeDetails(empID, 3).ToString
                frmMainWindow.Refresh()
                Me.Close()
            End If
            ' Si el usuario no inserto datos, se le devuelve un mensaje de error
        Else
            MsgBox("¡Error de inicio de sesión! Se requiere un nombre de usuario y contraseña válidos para iniciar sesión.", MsgBoxStyle.Critical, "techcare")
            tbPassword.Clear()
            tbPassword.Focus()
        End If
    End Sub
End Class
