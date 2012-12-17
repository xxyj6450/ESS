Imports System.Net.HttpWebRequest
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Text.RegularExpressions
Imports Newtonsoft.Json

Public Class cCustomersInfo
    Private _certType As String
    Private _certNo As String
    Private _custId As String
    Private _custName As String
    Private _paperAddr As String
    Private _paperExpiration As String
    Private _contactPhone As String
    Private _contactAddr As String
    Private _postCode As String
    Private _customerEmail As String
    Private _contactPerson As String
    Private _sex As String
    Private _birthday As String
    Private _showAreaSel As String
    Private _Areacode As String
    Private _checkRetMsg As String
    Private _checkRetCode As String
    Private _checkType As String
    Private _custLoc As String
    Private _custStatus As String
    Private _eparchyCode As String
    Private _eparchyList As String
    Private _eparchyName As String
    Private _numId As String
    Private _usedFlag As String
    Private _serviceType As String
    Private _customers As New System.Collections.Generic.List(Of cCustomer)
    Private _owedCustList As New System.Collections.ArrayList
    Private _provList As String
    Private _provinceCode As String
    Private _provinceName As String
    Private _oldCustList As System.Collections.ArrayList

    Public Property areaCode() As String
        Get
            areaCode = _Areacode
        End Get
        Set(ByVal value As String)
            _Areacode = value
        End Set
    End Property

    Public Property birthday() As String
        Get
            birthday = _birthday
        End Get
        Set(ByVal value As String)
            _birthday = value
        End Set
    End Property

    Public Property certNo() As String
        Get
            certNo = _certNo
        End Get
        Set(ByVal value As String)
            _certNo = value
        End Set
    End Property

    Public Property certType() As String
        Get
            certType = _certType
        End Get
        Set(ByVal value As String)
            _certType = value
        End Set
    End Property

    Public Property checkRetCode() As String
        Get
            checkRetCode = _checkRetCode
        End Get
        Set(ByVal value As String)
            _checkRetCode = value
        End Set
    End Property

    Public Property checkRetMsg() As String
        Get
            checkRetMsg = _checkRetMsg
        End Get
        Set(ByVal value As String)
            _checkRetMsg = value
        End Set
    End Property

    Public Property checkType() As String
        Get
            checkType = _checkType
        End Get
        Set(ByVal value As String)
            _checkType = value
        End Set
    End Property

    Public Property contactAddr() As String
        Get
            contactAddr = _contactAddr
        End Get
        Set(ByVal value As String)
            _contactAddr = value
        End Set
    End Property

    Public Property contactPerson() As String
        Get
            contactPerson = _contactPerson
        End Get
        Set(ByVal value As String)
            _contactPerson = value
        End Set
    End Property

    Public Property contactPhone() As String
        Get
            contactPhone = _contactPhone
        End Get
        Set(ByVal value As String)
            _contactPhone = value
        End Set
    End Property

    Public Property custId() As String
        Get
            custId = _custId
        End Get
        Set(ByVal value As String)
            _custId = value
        End Set
    End Property

    Public Property custLoc() As String
        Get
            custLoc = _custLoc
        End Get
        Set(ByVal value As String)
            _custLoc = value
        End Set
    End Property

    Public Property custName() As String
        Get
            custName = _custName
        End Get
        Set(ByVal value As String)
            _custName = value
        End Set
    End Property

    Public Property custStatus() As String
        Get
            custStatus = _custStatus
        End Get
        Set(ByVal value As String)
            _custStatus = value
        End Set
    End Property

    Public Property customerEmail() As String
        Get
            customerEmail = _customerEmail
        End Get
        Set(ByVal value As String)
            _customerEmail = value
        End Set
    End Property

    Public Property eparchyCode() As String
        Get
            eparchyCode = _eparchyCode
        End Get
        Set(ByVal value As String)
            _eparchyCode = value
        End Set
    End Property

    Public Property eparchyList() As String
        Get
            eparchyList = _eparchyList
        End Get
        Set(ByVal value As String)
            _eparchyList = value
        End Set
    End Property

    Public Property eparchyName() As String
        Get
            eparchyName = _eparchyName
        End Get
        Set(ByVal value As String)
            _eparchyName = value
        End Set
    End Property

    Public Property numId() As String
        Get
            numId = _numId
        End Get
        Set(ByVal value As String)
            _numId = value
        End Set
    End Property

    Public Property oldCustList() As System.Collections.ArrayList

        Get
            oldCustList = _oldCustList
        End Get
        Set(ByVal value As System.Collections.ArrayList)
            Dim objCust As cCustomer
            _oldCustList = value
            For Each o As Newtonsoft.Json.Linq.JObject In value
                objCust = o.ToObject(Of cCustomer)()
                _customers.Add(objCust)
            Next
        End Set
    End Property
    Public Function Customers() As System.Collections.Generic.List(Of cCustomer)

        Customers = _customers

    End Function

    Public Property owedCustList() As System.Collections.ArrayList
        Get
            owedCustList = _owedCustList
        End Get
        Set(ByVal value As System.Collections.ArrayList)
            _owedCustList = value
        End Set
    End Property

    Public Property paperAddr() As String
        Get
            paperAddr = _paperAddr
        End Get
        Set(ByVal value As String)
            _paperAddr = value
        End Set
    End Property

    Public Property paperExpiration() As String
        Get
            paperExpiration = _paperExpiration
        End Get
        Set(ByVal value As String)
            _paperExpiration = value
        End Set
    End Property

    Public Property postCode() As String
        Get
            postCode = _postCode
        End Get
        Set(ByVal value As String)
            _postCode = value
        End Set
    End Property

    Public Property provList() As String
        Get
            provList = _provList
        End Get
        Set(ByVal value As String)
            _provList = value
        End Set
    End Property

    Public Property provinceCode() As String
        Get
            provinceCode = _provinceCode
        End Get
        Set(ByVal value As String)
            _provinceCode = value
        End Set
    End Property

    Public Property provinceName() As String
        Get
            provinceName = _provinceName
        End Get
        Set(ByVal value As String)
            _provinceName = value
        End Set
    End Property

    Public Property serviceType() As String
        Get
            serviceType = _serviceType
        End Get
        Set(ByVal value As String)
            _serviceType = value
        End Set
    End Property

    Public Property sex() As String
        Get
            sex = _sex
        End Get
        Set(ByVal value As String)
            _sex = value
        End Set
    End Property

    Public Property usedFlag() As String
        Get
            usedFlag = _usedFlag
        End Get
        Set(ByVal value As String)
            _usedFlag = value
        End Set
    End Property



End Class
