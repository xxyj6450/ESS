Imports System.Net.HttpWebRequest
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Web

Public Class Login

    Public Sub Login(ByVal Usercode As String, ByVal Password As String)

        Dim httpRequest As System.Net.HttpWebRequest
        Dim httpResponse As System.Net.HttpWebResponse
        Dim html As String, URL_verifycode As String
        Dim bytes() As Byte, RequestBytes() As Byte, ContentData As String
        Dim keycode As String, ret As Long
        Dim URI As System.Uri
        USERTOKEN = ""
        If COOKIE Is Nothing Then COOKIE = Nothing
        COOKIE = New CookieContainer
         
        httpRequest = System.Net.HttpWebRequest.Create("http://esales.10010.com")
        With httpRequest
            .Method = "get"
            .CookieContainer = COOKIE
            COOKIE = .CookieContainer
            .UserAgent = STRING_USERAGENG
            .ReadWriteTimeout = 3000
            .Accept = "application/x-ms-application, image/jpeg, application/xaml+xml, image/gif, image/pjpeg, application/x-ms-xbap, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*"
            .Headers.Set("Accept-Language", "zh-CN")
            httpResponse = .GetResponse
            If httpResponse.StatusCode = Net.HttpStatusCode.OK Then
                Using reader As System.IO.StreamReader = New StreamReader(httpResponse.GetResponseStream)
                    html = reader.ReadToEnd
                    'If html.IndexOf("<img src=""/pages/sys/frame/frameValidationServlet?randamCode=") > 0 Then
                    '    URL_verifycode = "http://esales.10010.com/pages/sys/frame/frameValidationServlet?randamCode=" & System.Text.RegularExpressions.Regex.Matches(html, "(?<=randamCode=).+(?="")")(0).ToString
                    'End If
                    '这里直接使用随机数字作为验证码,省去解析HTML的过程
                    URL_verifycode = "http://esales.10010.com/pages/sys/frame/frameValidationServlet?randamCode=" & GetTickCount().ToString
                    VIEWSTATE = getViewState(html)
                End Using
            End If
        End With
        httpResponse.Close()
        httpResponse = Nothing
        httpRequest = Nothing
        URI = Nothing
        URL_verifycode = "http://esales.10010.com/pages/sys/frame/frameValidationServlet?randamCode=" & Now().ToString
        httpRequest = System.Net.HttpWebRequest.Create(URL_verifycode)
        With httpRequest
            .Method = "get"
            .CookieContainer = New CookieContainer
            COOKIE = .CookieContainer
            .Accept = "*/*"
            .Referer = "http://esales.10010.com/"
            .Headers.Set("Accept-Language", "zh-CN")
            .Headers.Set("Accept-Encoding", "gzip, deflate")
            .UserAgent = STRING_USERAGENG
            httpResponse = .GetResponse

            If httpResponse.StatusCode = Net.HttpStatusCode.OK Then
                Using reader As New System.IO.BinaryReader(httpResponse.GetResponseStream)
                    ReDim bytes(httpResponse.ContentLength)
                    bytes = reader.ReadBytes(httpResponse.ContentLength)
                End Using
                Using _fileStream As New System.IO.FileStream("C:\data.jpg", FileMode.Create)
                    _fileStream.Write(bytes, 0, bytes.Length)
                End Using
                'Dim img As Image = Image.FromFile("C:\data.jpg") ' Image.FromStream(httpResponse.GetResponseStream)
                Dim hkey As Int32 = InitKeyCode(0, "10165462---asdfqwerqsdfasdfvzxcasdfqwer234234")

                keycode = Space(255)
                If hkey <> 0 Then
                    Throw New Exception("无法初始化验证码组件.")
                End If
                'ret = GetCodeByBitmap(img, keycode, hkey)
                ret = GetCode("C:\data.jpg", keycode, hkey)
                FreeKeyCode(hkey)
                If ret > 0 Then

                Else
                    Throw New Exception("验证码识别失败.")
                End If

            End If
        End With
        httpResponse.Close()
        httpResponse = Nothing
        httpRequest = Nothing
        URI = Nothing
        URI = Nothing

        URI = New System.Uri("http://esales.10010.com/pages/sys/sys_login.jsf")
        httpRequest = System.Net.HttpWebRequest.Create(URI)
        ContentData = "AJAXREQUEST=_viewRoot&_authKey=&j_id2%3Aprovince=51&username=" & Usercode & "&password=" & Password & "&" & _
           "tokenPwd=&verifyCode=" & Left(keycode, 4) & "&j_id2_link_hidden_=%5Bobject%5D&j_id2_SUBMIT=1&javax.faces.ViewState=" & System.Web.HttpUtility.UrlEncode(VIEWSTATE) & "&j_id2%3Aj_id6=j_id2%3Aj_id6&"

        RequestBytes = System.Text.Encoding.UTF8.GetBytes(ContentData)
        With httpRequest
            .Method = "POST"
            .Accept = "*/*"
            .CookieContainer = COOKIE
            .KeepAlive = True
            .Referer = "http://esales.10010.com/"
            .Headers.Set("Accept-Language", "zh-CN")
            .Headers.Set("Accept-Encoding", "gzip, deflate")
            .Headers.Set("Cache-Control", "no-cache")
            .ContentType = "application/x-www-form-urlencoded; charset=UTF-8"
            .UserAgent = STRING_USERAGENG
            '.ReadWriteTimeout = 10000
            '.ServicePoint.Expect100Continue = False
            '.ProtocolVersion = HttpVersion.Version11
            '.UnsafeAuthenticatedConnectionSharing = True
            '.ServicePoint.ConnectionLimit = 1
            'Net.ServicePointManager.DefaultConnectionLimit = 1
            .ContentLength = RequestBytes.Length
            httpRequest.GetRequestStream.Write(RequestBytes, 0, RequestBytes.Length)
            httpResponse = httpRequest.GetResponse
            
            Dim cks As System.Net.CookieCollection
            cks = COOKIE.GetCookies(New Uri("http://esales.10010.com"))
            For Each ck As System.Net.Cookie In cks

                If ck.Name = "UserToken" Then USERTOKEN = ck.Value : Exit For
            Next
            If USERTOKEN = "" Then
                '确认登录成功,再取出ViewState
                Using reader As New System.IO.StreamReader(httpResponse.GetResponseStream)
                    html = reader.ReadToEnd
                End Using
                If html.IndexOf("name=""hidMmaximumSeverity"" value=""Error""") > 0 Then
                    Throw New Exception("登录失败" & vbCrLf & getErrorInfo(html))
                Else
                    Throw New Exception("登录失败!" & vbCrLf & html)
                End If
            End If
            cks = Nothing
        End With
        httpResponse.Close()
        httpResponse = Nothing
        httpRequest = Nothing
        URI = Nothing
        '初始化一下,这步很关键,省略这步,后续所有操作都会失败.
        RequestWEB("http://esales.10010.com")
        '从导航页中取出各个页面访问方式.经观察,导航页面的AuthKey会每天改变,所以每天第一次都要重新访问导航页获取页面访问的AuthKey.
        If My.Settings.Datetime <> FormatDateTime(Now(), DateFormat.ShortDate) Then
            html = RequestWEB("http://esales.10010.com/pages/sys/frame/frameNav.jsf")
            My.Settings.Datetime = FormatDateTime(Now(), DateFormat.ShortDate)
            My.Settings.URL_g3postpaid_sub_new = "http://esales.10010.com" & getSubstringByWords(html, "3G后付费客户开户（白/成卡独立受理）', '", "'")
            My.Settings.Save()
        End If
       
    End Sub
    Private Function getErrorInfo(ByVal strHTML As String) As String
        Dim i As Integer, j As Integer, str As String
        str = "class=""rich-messages-label"">"
        i = strHTML.IndexOf(str)
        j = strHTML.IndexOf("<", i + Len(str))
        getErrorInfo = strHTML.Substring(i + Len(str), j - i - Len(str))
    End Function
End Class
