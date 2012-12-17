<Microsoft.VisualBasic.ComClass()> <System.Serializable()> Public Class cCustomer
    Private _ArrearageFlag As String
    Private _BlackListFlag As String
    Private _CertAddr As String
    Private _CertExpireDate As String
    Private _CertNum As String
    Private _CertType As String
    Private _ContactAddr As String
    Private _CustomerBirth As String
    Private _CustomerID As String
    Private _CustomerLoc As String
    Private _CustomerName As String
    Private _CustomerOccp As String
    Private _CustomerSex As String
    Private _CustomerType As String
    Private _customerTypeName As String
    Private _CustomerZip As String
    Private _Para As System.Collections.ArrayList
    Private _ReleOfficeID As String
    Private _StatusChgTime As String
    Private _ContactPhone As String
    Private _ArrearageMess As System.Collections.ArrayList
    Private _CustomerAddr As String
    Private _CustLoc As String
    Private _ContactPerson As String
    Private _ContactZip As String
    ''' <remarks>客户性别</remarks>
    Public Property CustomerSex() As String
        Get
            CustomerSex = _CustomerSex
        End Get
        Set(ByVal value As String)
            _CustomerSex = value
        End Set
    End Property

    Public Property ReleOfficeID() As String
        Get
            ReleOfficeID = _ReleOfficeID
        End Get
        Set(ByVal value As String)
            _ReleOfficeID = value
        End Set
    End Property

    Public Property CustomerAddr() As String
        Get
            CustomerAddr = _CustomerAddr
        End Get
        Set(ByVal value As String)
            _CustomerAddr = value
        End Set
    End Property

    Public Property CustLoc() As String
        Get
            CustLoc = _CustLoc
        End Get
        Set(ByVal value As String)
            _CustLoc = value
        End Set
    End Property

    Public Property ContactAddr() As String
        Get
            ContactAddr = _ContactAddr
        End Get
        Set(ByVal value As String)
            _ContactAddr = value
        End Set
    End Property

    Public Property BlackListFlag() As String
        Get
            BlackListFlag = _BlackListFlag
        End Get
        Set(ByVal value As String)
            _BlackListFlag = value
        End Set
    End Property

    Public Property CertNum() As String
        Get
            CertNum = _CertNum
        End Get
        Set(ByVal value As String)
            _CertNum = value
        End Set
    End Property

    Public Property CustomerType() As String
        Get
            CustomerType = _CustomerType
        End Get
        Set(ByVal value As String)
            _CustomerType = value
        End Set
    End Property

    Public Property ContactPerson() As String
        Get
            ContactPerson = _ContactPerson
        End Get
        Set(ByVal value As String)
            _ContactPerson = value
        End Set
    End Property

    Public Property CustomerOccp() As String
        Get
            CustomerOccp = _CustomerOccp
        End Get
        Set(ByVal value As String)
            _CustomerOccp = value
        End Set
    End Property

    Public Property StatusChgTime() As String
        Get
            StatusChgTime = _StatusChgTime
        End Get
        Set(ByVal value As String)
            _StatusChgTime = value
        End Set
    End Property

    Public Property customerTypeName() As String
        Get
            customerTypeName = _customerTypeName
        End Get
        Set(ByVal value As String)
            _customerTypeName = value
        End Set
    End Property

    Public Property CertAddr() As String
        Get
            CertAddr = _CertAddr
        End Get
        Set(ByVal value As String)
            _CertAddr = value
        End Set
    End Property
 

    Public Property ContactPhone() As String
        Get
            ContactPhone = _ContactPhone
        End Get
        Set(ByVal value As String)
            _ContactPhone = value
        End Set
    End Property

    Public Property CustomerZip() As String
        Get
            CustomerZip = _CustomerZip
        End Get
        Set(ByVal value As String)
            _CustomerZip = value
        End Set
    End Property

    Public Property CustomerBirth() As String
        Get
            CustomerBirth = _CustomerBirth
        End Get
        Set(ByVal value As String)
            _CustomerBirth = value
        End Set
    End Property

    Public Property ArrearageFlag() As String
        Get
            ArrearageFlag = _ArrearageFlag
        End Get
        Set(ByVal value As String)
            _ArrearageFlag = value
        End Set
    End Property

    Public Property CustomerName() As String
        Get
            CustomerName = _CustomerName
        End Get
        Set(ByVal value As String)
            _CustomerName = value
        End Set
    End Property

    Public Property CertExpireDate() As String
        Get
            CertExpireDate = _CertExpireDate
        End Get
        Set(ByVal value As String)
            _CertExpireDate = value
        End Set
    End Property

    Public Property CustomerLoc() As String
        Get
            CustomerLoc = _CustomerLoc
        End Get
        Set(ByVal value As String)
            _CustomerLoc = value
        End Set
    End Property

    Public Property CertType() As String
        Get
            CertType = _CertType
        End Get
        Set(ByVal value As String)
            _CertType = value
        End Set
    End Property

    Public Property CustomerID() As String
        Get
            CustomerID = _CustomerID
        End Get
        Set(ByVal value As String)
            _CustomerID = value
        End Set
    End Property

    Public Property ContactZip() As String
        Get
            ContactZip = _ContactZip
        End Get
        Set(ByVal value As String)
            _ContactZip = value
        End Set
    End Property

    Public Property Para() As System.Collections.ArrayList
        Get
            Para = _Para
        End Get
        Set(ByVal value As System.Collections.ArrayList)
            _Para = value
        End Set
    End Property

    Public Property ArrearageMess() As System.Collections.ArrayList
        Get
            ArrearageMess = _ArrearageMess
        End Get
        Set(ByVal value As System.Collections.ArrayList)
            _ArrearageMess = value
        End Set
    End Property

































End Class
