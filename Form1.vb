Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim objLogin As New Login
        Dim t As Long
        Try
            t = GetTickCount
            objLogin.Login(txtUsercode.Text, txtPassword.Text)
            MsgBox("登录成功,用时" & GetTickCount - t & "毫秒.")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
 
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim cust As New cCustomersInfo, t As Long
        Try
            t = GetTickCount
            cust = getCustomerInfoBycertNumber(txtCertNum.Text)
            If cust.Customers.Count > 0 Then
                MsgBox(cust.checkRetMsg & cust.Customers(0).CertAddr & ",用时" & GetTickCount - t & "毫秒.")
            Else
                MsgBox(cust.checkRetMsg & cust.contactPerson & ",用时" & GetTickCount - t & "毫秒.")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class
