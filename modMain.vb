Imports Newtonsoft.Json
Module modMain
    Public COOKIE As System.Net.CookieContainer
    Public AUTHKEY As String
    Public VIEWSTATE As String
    Public SESSIONID As String
    Public USERTOKEN As String

    Public Const STRING_USERAGENG As String = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.1 (KHTML, like Gecko) Chrome/21.0.1180.89 Safari/537.1"
    Public Declare Function GetTickCount Lib "kernel32" Alias "GetTickCount" () As Long
    '从HTML中返回ViewState
    Public Function getViewState(ByVal strHTML As String) As String
        Dim i As Integer, j As Integer, str As String
        str = "id=""javax.faces.ViewState"" value="""
        i = strHTML.IndexOf(str)
        j = strHTML.IndexOf("""", i + Len(str) + 1)
        getViewState = strHTML.Substring(i + Len(str), j - i - Len(str))
    End Function

    Public Function getSubstringByWords(ByVal chars As String, ByVal beginChars As String, ByVal endChars As String) As String
        Dim i As Integer, j As Integer, str As String

        i = chars.IndexOf(beginChars)
        j = chars.IndexOf(endChars, i + Len(beginChars) + 1)
        getSubstringByWords = chars.Substring(i + Len(beginChars), j - i - Len(beginChars))
    End Function

    Public Function RequestWEB(ByVal URL As String, Optional ByVal URLRefer As String = "http://esales.10010.com") As String
        Dim httpRequest As System.Net.HttpWebRequest
        Dim httpResponse As System.Net.HttpWebResponse
        Dim html As String, URL_verifycode As String
        Dim bytes() As Byte, RequestBytes() As Byte, ContentData As String
        Dim keycode As String, ret As Long
        Dim URI As System.Uri
        httpRequest = System.Net.HttpWebRequest.Create(URL)
        With httpRequest
            .Method = "get"
            If COOKIE Is Nothing Then COOKIE = New System.Net.CookieContainer
            .CookieContainer = COOKIE
            .KeepAlive = True
            .Referer = URLRefer
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
            httpResponse = httpRequest.GetResponse
            Using reader As New System.IO.StreamReader(httpResponse.GetResponseStream)
                html = reader.ReadToEnd
            End Using
        End With
        httpRequest.GetResponse.Close()
        httpResponse.Close()
        httpRequest = Nothing
        httpResponse = Nothing
        Return html
    End Function


    Public Function getCustomerInfoBycertNumber(ByVal _certNo As String, Optional ByVal _certType As String = "身份证") As cCustomersInfo
        Dim httpRequest As System.Net.HttpWebRequest
        Dim httpResponse As System.Net.HttpWebResponse
        Dim html As String, URL_verifycode As String
        Dim bytes() As Byte, RequestBytes() As Byte, ContentData As String
        Dim keycode As String, ret As Long
        Dim URI As System.Uri
        Dim t As Long
        t = GetTickCount
        httpRequest = System.Net.HttpWebRequest.Create(My.Settings.URL_g3postpaid_sub_new)
        With httpRequest
            .Method = "get"
            If COOKIE Is Nothing Then COOKIE = New System.Net.CookieContainer
 
            .CookieContainer = COOKIE
            .KeepAlive = True
            .Referer = "http://esales.10010.com/pages/sys/frame/frameSide.jsf"
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
            httpResponse = httpRequest.GetResponse
            Using reader As New System.IO.StreamReader(httpResponse.GetResponseStream)
                html = reader.ReadToEnd
                VIEWSTATE = getViewState(html)
                'Debug.Print(html)
            End Using
        End With
        httpResponse.Close()
        httpRequest = Nothing
        httpResponse = Nothing
        Debug.Print("进入页面,耗时" & GetTickCount - t)
        t = GetTickCount
        httpRequest = System.Net.HttpWebRequest.Create("http://esales.10010.com/pages/g3bsp/sub/postpaidsub/g3postpaid_sub_new.jsf")
        ContentData = "AJAXREQUEST=_viewRoot&_authKey=51F0eg%2FkK7cRsL9BNvb567CJdBPx4%3D&form%3Aj_id17=true&checkType=on&form%3Aj_id20=02&form%3Aj_id25=02&custInfo_certNo=" & _certNo & "&custInfo_areaCode=&custInfo_numId=&custInfo_hid_custId=&custInfo_custName=&custInfo_paperAddr=&form%3Aj_id34=&custInfo_contactPhone=&custInfo_contactAddr=&custInfo_postCode=&custInfo_customerEmail=&custInfo_contactPerson=&form%3Aj_id42=1&form%3Aj_id46=&custInfo_custLoc=&custInfo_custStatus=&form%3Aj_id50=&form%3Aj_id55=&form%3Aj_id74=true&refeInfo_refeId=&form%3Aj_id83=true&agentInfo_agentName=&form%3Aj_id87=02&agentInfo_certNo=&agentInfo_agentPhone=&agentInfo_agentAddr=&form%3Aj_id110=true&g3NumselAfter_customNo=&form%3Aj_id135=true&g3NumberPost_usimNo=89860&g3NumberPost_serialNumber=&g3NumberPost_iccid=&g3NumberPost_imsi=&g3NumberPost_cardData=&g3NumberPost_errIccid=&g3NumberPost_busiType=&g3NumberPost_cardType=&g3NumberPost_userType=&g3NumberPost_CardErrCode=&g3NumberPost_CardErrInfo=&g3NumberPost_option=&g3NumberPost_city=&g3NumberPost_brand=&g3NumberPost_rCount=0&g3NumberPost_wCount=0&g3NumberPost_cardDataProcID=&acctInfo_usedFlag=&acctInfo_accountName=&form%3Aj_id155=10&form%3Aj_id160=2&form%3Aj_id165=01&j_id169=&acctInfo_sendPost=&j_id172=&j_id174=&form%3Aj_id176=&form%3Aj_id178=&form%3Aj_id181=true&form%3Aj_id184=true&form%3Aj_id195=true&form%3Aj_id206=true&form%3Aj_id222=true&form%3Aj_id228=true&activity_productID=&activity_groupID=&activity_resType=00&activity_terminalTypeLst=02&activity_tradeClass=01&activity_isCheckRight=false&activity_isBuyTerminal=&activity_actTypeAllowedLst=3%2C4%2C5&jionRadio=2&form%3Aj_id251=&form%3Aj_id257=&form%3Aj_id263=&activity_socialSecurityCardID=&activity_frozenDepositId=&activity_frozenMoney=&activity_terminalId=&form%3Aactivity_actDescSpan=&form%3Aj_id274=true&g3PreSubmit_usedFlag=true&g3PreSubmit_payOrg=&g3PreSubmit_payNum=&g3PreSubmit_bankName=&inputUserPay=&=on&=on&g3FinalSubmit_invoiceNo=&g3FinalSubmit_taxpayerNo=&form%3A_link_hidden_=&form%3A_idcl=&form_SUBMIT=1&javax.faces.ViewState=" & System.Web.HttpUtility.UrlEncode(VIEWSTATE) & "&param=0&form%3Aj_id62=form%3Aj_id62&"
        RequestBytes = System.Text.Encoding.UTF8.GetBytes(ContentData)
        With httpRequest
            .Method = "POST"
            If COOKIE Is Nothing Then COOKIE = New System.Net.CookieContainer
            .CookieContainer = COOKIE
            .KeepAlive = True
            .Referer = My.Settings.URL_g3postpaid_sub_new
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
            Using reader As New System.IO.StreamReader(httpResponse.GetResponseStream)
                html = reader.ReadToEnd
                'VIEWSTATE = getViewState(html)
                'Debug.Print(html)
            End Using
        End With
        Debug.Print("获取数据,耗时" & GetTickCount - t)
        t = GetTickCount
        Dim strJson As String, obj As cCustomersInfo
        strJson = getSubstringByWords(html, "<span id=""_ajax:data""><![CDATA[", "]]></span>")
        Try
            obj = Newtonsoft.Json.JsonConvert.DeserializeAnonymousType(strJson, obj)
        Catch ex As Exception
            Debug.Print(strJson)
            Throw New Exception("解析数据失败." & ex.Message)
        End Try
        Debug.Print("解析数据耗时" & GetTickCount - t)
        httpRequest.GetResponse.Close()
        httpResponse.Close()
        httpRequest = Nothing
        httpResponse = Nothing
        Return obj
    End Function
End Module
