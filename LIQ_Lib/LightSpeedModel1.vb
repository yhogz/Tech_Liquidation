Imports System

Imports Mindscape.LightSpeed
Imports Mindscape.LightSpeed.Validation
Imports Mindscape.LightSpeed.Linq

Namespace LIQ_Lib

  <Serializable()> _
  <System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")> _
  <System.ComponentModel.DataObject> _
  <Table("tbl_petc")> _
  Public Partial Class TblPetc
    Inherits Entity(Of Long)

    <ValidateLength(0, 30)> _
    Private _authorization As String
    
    <Column("tel_no"), ValidateLength(0, 30)> _
    Private _telNo As String
    
    <ValidatePresence, ValidateLength(0, 255)> _
    Private _name As String
    
    <ValidateLength(0, 300)> _
    Private _address As String
    
    Private _expiry As System.Nullable(Of Date)



    ''' <summary>Identifies the Authorization entity attribute.</summary>
    Public Const AuthorizationField As String = "Authorization"
    ''' <summary>Identifies the TelNo entity attribute.</summary>
    Public Const TelNoField As String = "TelNo"
    ''' <summary>Identifies the Name entity attribute.</summary>
    Public Const NameField As String = "Name"
    ''' <summary>Identifies the Address entity attribute.</summary>
    Public Const AddressField As String = "Address"
    ''' <summary>Identifies the Expiry entity attribute.</summary>
    Public Const ExpiryField As String = "Expiry"





    Public Sub New()
      MyBase.New(False)
      Initialize()
    End Sub
    
    Protected Sub New(initialize As Boolean)
      MyBase.New(initialize)
    End Sub
  
    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property Authorization() As String
      Get
        Return [Get](_authorization, "Authorization")
      End Get
      Set(ByVal value As String)
        [Set](_authorization, value, "Authorization")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property TelNo() As String
      Get
        Return [Get](_telNo, "TelNo")
      End Get
      Set(ByVal value As String)
        [Set](_telNo, value, "TelNo")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property Name() As String
      Get
        Return [Get](_name, "Name")
      End Get
      Set(ByVal value As String)
        [Set](_name, value, "Name")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property Address() As String
      Get
        Return [Get](_address, "Address")
      End Get
      Set(ByVal value As String)
        [Set](_address, value, "Address")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property Expiry() As System.Nullable(Of Date)
      Get
        Return [Get](_expiry, "Expiry")
      End Get
      Set(ByVal value As System.Nullable(Of Date))
        [Set](_expiry, value, "Expiry")
      End Set
    End Property





  End Class


  <Serializable()> _
  <System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")> _
  <System.ComponentModel.DataObject> _
  <Table("tblusers", IdColumnName := "Uid")> _
  Public Partial Class Tbluser
    Inherits Entity(Of Long)

    <ValidateLength(0, 50)> _
    Private _name As String
    
    <ValidateLength(0, 50)> _
    Private _username As String
    
    <ValidateLength(0, 50)> _
    Private _password As String
    
    <ValidateLength(0, 20)> _
    Private _type As String
    
    <Column("date_created")> _
    Private _dateCreated As System.Nullable(Of Date)
    
    Private _active As System.Nullable(Of Integer)
    
    <Column("user_code"), ValidateLength(0, 50)> _
    Private _userCode As String
    
    Private _prev As System.Nullable(Of Integer)



    ''' <summary>Identifies the Name entity attribute.</summary>
    Public Const NameField As String = "Name"
    ''' <summary>Identifies the Username entity attribute.</summary>
    Public Const UsernameField As String = "Username"
    ''' <summary>Identifies the Password entity attribute.</summary>
    Public Const PasswordField As String = "Password"
    ''' <summary>Identifies the Type entity attribute.</summary>
    Public Const TypeField As String = "Type"
    ''' <summary>Identifies the DateCreated entity attribute.</summary>
    Public Const DateCreatedField As String = "DateCreated"
    ''' <summary>Identifies the Active entity attribute.</summary>
    Public Const ActiveField As String = "Active"
    ''' <summary>Identifies the UserCode entity attribute.</summary>
    Public Const UserCodeField As String = "UserCode"
    ''' <summary>Identifies the Prev entity attribute.</summary>
    Public Const PrevField As String = "Prev"





    Public Sub New()
      MyBase.New(False)
      Initialize()
    End Sub
    
    Protected Sub New(initialize As Boolean)
      MyBase.New(initialize)
    End Sub
  
    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property Name() As String
      Get
        Return [Get](_name, "Name")
      End Get
      Set(ByVal value As String)
        [Set](_name, value, "Name")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property Username() As String
      Get
        Return [Get](_username, "Username")
      End Get
      Set(ByVal value As String)
        [Set](_username, value, "Username")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property Password() As String
      Get
        Return [Get](_password, "Password")
      End Get
      Set(ByVal value As String)
        [Set](_password, value, "Password")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property Type() As String
      Get
        Return [Get](_type, "Type")
      End Get
      Set(ByVal value As String)
        [Set](_type, value, "Type")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property DateCreated() As System.Nullable(Of Date)
      Get
        Return [Get](_dateCreated, "DateCreated")
      End Get
      Set(ByVal value As System.Nullable(Of Date))
        [Set](_dateCreated, value, "DateCreated")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property Active() As System.Nullable(Of Integer)
      Get
        Return [Get](_active, "Active")
      End Get
      Set(ByVal value As System.Nullable(Of Integer))
        [Set](_active, value, "Active")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property UserCode() As String
      Get
        Return [Get](_userCode, "UserCode")
      End Get
      Set(ByVal value As String)
        [Set](_userCode, value, "UserCode")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property Prev() As System.Nullable(Of Integer)
      Get
        Return [Get](_prev, "Prev")
      End Get
      Set(ByVal value As System.Nullable(Of Integer))
        [Set](_prev, value, "Prev")
      End Set
    End Property





  End Class


  <Serializable()> _
  <System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")> _
  <System.ComponentModel.DataObject> _
  <Table("tbl_technician")> _
  Public Partial Class TblTechnician
    Inherits Entity(Of Integer)

    <ValidateLength(0, 100)> _
    Private _lastname As String
    
    <ValidatePresence, ValidateLength(0, 50)> _
    Private _cellno As String
    
    <ValidateEmailAddress, ValidateLength(0, 50)> _
    Private _email As String
    
    <ValidatePresence, ValidateLength(0, 100)> _
    Private _firstname As String



    ''' <summary>Identifies the Lastname entity attribute.</summary>
    Public Const LastnameField As String = "Lastname"
    ''' <summary>Identifies the Cellno entity attribute.</summary>
    Public Const CellnoField As String = "Cellno"
    ''' <summary>Identifies the Email entity attribute.</summary>
    Public Const EmailField As String = "Email"
    ''' <summary>Identifies the Firstname entity attribute.</summary>
    Public Const FirstnameField As String = "Firstname"





    Public Sub New()
      MyBase.New(False)
      Initialize()
    End Sub
    
    Protected Sub New(initialize As Boolean)
      MyBase.New(initialize)
    End Sub
  
    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property Lastname() As String
      Get
        Return [Get](_lastname, "Lastname")
      End Get
      Set(ByVal value As String)
        [Set](_lastname, value, "Lastname")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property Cellno() As String
      Get
        Return [Get](_cellno, "Cellno")
      End Get
      Set(ByVal value As String)
        [Set](_cellno, value, "Cellno")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property Email() As String
      Get
        Return [Get](_email, "Email")
      End Get
      Set(ByVal value As String)
        [Set](_email, value, "Email")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property Firstname() As String
      Get
        Return [Get](_firstname, "Firstname")
      End Get
      Set(ByVal value As String)
        [Set](_firstname, value, "Firstname")
      End Set
    End Property





  End Class


  <Serializable()> _
  <System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")> _
  <System.ComponentModel.DataObject> _
  <Table(IdColumnName := "Bid")> _
  Public Partial Class Tblbreakdown
    Inherits Entity(Of Long)

    Private _cost As System.Nullable(Of Decimal)
    
    <ValidateLength(0, 50)> _
    Private _ltype As String
    
    <ValidateLength(0, 150)> _
    Private _description As String
    
    <ValidateLength(0, 50)> _
    Private _lcode As String
    
    <Column("date_encoded")> _
    Private _dateEncoded As System.Nullable(Of Date)
    
    <Column("encoded_by"), ValidateLength(0, 30)> _
    Private _encodedBy As String
    
    <Column("date_updated")> _
    Private _dateUpdated As System.Nullable(Of Date)
    
    <Column("updated_by"), ValidateLength(0, 30)> _
    Private _updatedBy As String
    
    <Column("view_on")> _
    Private _viewOn As System.Nullable(Of Integer)



    ''' <summary>Identifies the Cost entity attribute.</summary>
    Public Const CostField As String = "Cost"
    ''' <summary>Identifies the Ltype entity attribute.</summary>
    Public Const LtypeField As String = "Ltype"
    ''' <summary>Identifies the Description entity attribute.</summary>
    Public Const DescriptionField As String = "Description"
    ''' <summary>Identifies the Lcode entity attribute.</summary>
    Public Const LcodeField As String = "Lcode"
    ''' <summary>Identifies the DateEncoded entity attribute.</summary>
    Public Const DateEncodedField As String = "DateEncoded"
    ''' <summary>Identifies the EncodedBy entity attribute.</summary>
    Public Const EncodedByField As String = "EncodedBy"
    ''' <summary>Identifies the DateUpdated entity attribute.</summary>
    Public Const DateUpdatedField As String = "DateUpdated"
    ''' <summary>Identifies the UpdatedBy entity attribute.</summary>
    Public Const UpdatedByField As String = "UpdatedBy"
    ''' <summary>Identifies the ViewOn entity attribute.</summary>
    Public Const ViewOnField As String = "ViewOn"





    Public Sub New()
      MyBase.New(False)
      Initialize()
    End Sub
    
    Protected Sub New(initialize As Boolean)
      MyBase.New(initialize)
    End Sub
  
    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property Cost() As System.Nullable(Of Decimal)
      Get
        Return [Get](_cost, "Cost")
      End Get
      Set(ByVal value As System.Nullable(Of Decimal))
        [Set](_cost, value, "Cost")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property Ltype() As String
      Get
        Return [Get](_ltype, "Ltype")
      End Get
      Set(ByVal value As String)
        [Set](_ltype, value, "Ltype")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property Description() As String
      Get
        Return [Get](_description, "Description")
      End Get
      Set(ByVal value As String)
        [Set](_description, value, "Description")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property Lcode() As String
      Get
        Return [Get](_lcode, "Lcode")
      End Get
      Set(ByVal value As String)
        [Set](_lcode, value, "Lcode")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property DateEncoded() As System.Nullable(Of Date)
      Get
        Return [Get](_dateEncoded, "DateEncoded")
      End Get
      Set(ByVal value As System.Nullable(Of Date))
        [Set](_dateEncoded, value, "DateEncoded")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property EncodedBy() As String
      Get
        Return [Get](_encodedBy, "EncodedBy")
      End Get
      Set(ByVal value As String)
        [Set](_encodedBy, value, "EncodedBy")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property DateUpdated() As System.Nullable(Of Date)
      Get
        Return [Get](_dateUpdated, "DateUpdated")
      End Get
      Set(ByVal value As System.Nullable(Of Date))
        [Set](_dateUpdated, value, "DateUpdated")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property UpdatedBy() As String
      Get
        Return [Get](_updatedBy, "UpdatedBy")
      End Get
      Set(ByVal value As String)
        [Set](_updatedBy, value, "UpdatedBy")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property ViewOn() As System.Nullable(Of Integer)
      Get
        Return [Get](_viewOn, "ViewOn")
      End Get
      Set(ByVal value As System.Nullable(Of Integer))
        [Set](_viewOn, value, "ViewOn")
      End Set
    End Property





  End Class


  <Serializable()> _
  <System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")> _
  <System.ComponentModel.DataObject> _
  <Table(IdColumnName := "Jid")> _
  Public Partial Class Tbljrf
    Inherits Entity(Of Long)

    <ValidateLength(0, 20)> _
    Private _jrf As String
    
    <Column("Date_Created")> _
    Private _dateCreated As System.Nullable(Of Date)
    
    <Column("assign_person"), ValidateLength(0, 50)> _
    Private _assignPerson As String
    
    Private _active As System.Nullable(Of Integer)
    
    Private _print As System.Nullable(Of Integer)



    ''' <summary>Identifies the Jrf entity attribute.</summary>
    Public Const JrfField As String = "Jrf"
    ''' <summary>Identifies the DateCreated entity attribute.</summary>
    Public Const DateCreatedField As String = "DateCreated"
    ''' <summary>Identifies the AssignPerson entity attribute.</summary>
    Public Const AssignPersonField As String = "AssignPerson"
    ''' <summary>Identifies the Active entity attribute.</summary>
    Public Const ActiveField As String = "Active"
    ''' <summary>Identifies the Print entity attribute.</summary>
    Public Const PrintField As String = "Print"





    Public Sub New()
      MyBase.New(False)
      Initialize()
    End Sub
    
    Protected Sub New(initialize As Boolean)
      MyBase.New(initialize)
    End Sub
  
    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property Jrf() As String
      Get
        Return [Get](_jrf, "Jrf")
      End Get
      Set(ByVal value As String)
        [Set](_jrf, value, "Jrf")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property DateCreated() As System.Nullable(Of Date)
      Get
        Return [Get](_dateCreated, "DateCreated")
      End Get
      Set(ByVal value As System.Nullable(Of Date))
        [Set](_dateCreated, value, "DateCreated")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property AssignPerson() As String
      Get
        Return [Get](_assignPerson, "AssignPerson")
      End Get
      Set(ByVal value As String)
        [Set](_assignPerson, value, "AssignPerson")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property Active() As System.Nullable(Of Integer)
      Get
        Return [Get](_active, "Active")
      End Get
      Set(ByVal value As System.Nullable(Of Integer))
        [Set](_active, value, "Active")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property Print() As System.Nullable(Of Integer)
      Get
        Return [Get](_print, "Print")
      End Get
      Set(ByVal value As System.Nullable(Of Integer))
        [Set](_print, value, "Print")
      End Set
    End Property





  End Class


  <Serializable()> _
  <System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")> _
  <System.ComponentModel.DataObject> _
  <Table(IdColumnName := "Lid")> _
  Public Partial Class Tblliquidation
    Inherits Entity(Of Long)

    <ValidateLength(0, 200)> _
    Private _name As String
    
    <Column("d_date")> _
    Private _dDate As System.Nullable(Of Date)
    
    <ValidateLength(0, 100)> _
    Private _destination As String
    
    <Column("petc_name"), ValidateLength(0, 200)> _
    Private _petcName As String
    
    <ValidateLength(0, 250)> _
    Private _task As String
    
    <Column("l_total")> _
    Private _lTotal As System.Nullable(Of Decimal)
    
    <Column("date_encoded")> _
    Private _dateEncoded As System.Nullable(Of Date)
    
    <Column("user_code"), ValidateLength(0, 50)> _
    Private _userCode As String
    
    Private _checked As System.Nullable(Of Integer)
    
    Private _approved As System.Nullable(Of Integer)
    
    Private _released As System.Nullable(Of Integer)
    
    <ValidateLength(0, 50)> _
    Private _lcode As String
    
    <Column("jrf_number"), ValidateLength(0, 50)> _
    Private _jrfNumber As String
    
    <Column("middle_name"), ValidateLength(0, 50)> _
    Private _middleName As String
    
    <Column("last_name"), ValidateLength(0, 50)> _
    Private _lastName As String
    
    <Column("checked_date")> _
    Private _checkedDate As System.Nullable(Of Date)
    
    <Column("approved_date")> _
    Private _approvedDate As System.Nullable(Of Date)
    
    <Column("released_date")> _
    Private _releasedDate As System.Nullable(Of Date)
    
    <ValidateLength(0, 300)> _
    Private _solutions As String
    
    <ValidateLength(0, 150)> _
    Private _remarks As String
    
    <Column("no_liquidation")> _
    Private _noLiquidation As System.Nullable(Of Integer)



    ''' <summary>Identifies the Name entity attribute.</summary>
    Public Const NameField As String = "Name"
    ''' <summary>Identifies the DDate entity attribute.</summary>
    Public Const DDateField As String = "DDate"
    ''' <summary>Identifies the Destination entity attribute.</summary>
    Public Const DestinationField As String = "Destination"
    ''' <summary>Identifies the PetcName entity attribute.</summary>
    Public Const PetcNameField As String = "PetcName"
    ''' <summary>Identifies the Task entity attribute.</summary>
    Public Const TaskField As String = "Task"
    ''' <summary>Identifies the LTotal entity attribute.</summary>
    Public Const LTotalField As String = "LTotal"
    ''' <summary>Identifies the DateEncoded entity attribute.</summary>
    Public Const DateEncodedField As String = "DateEncoded"
    ''' <summary>Identifies the UserCode entity attribute.</summary>
    Public Const UserCodeField As String = "UserCode"
    ''' <summary>Identifies the Checked entity attribute.</summary>
    Public Const CheckedField As String = "Checked"
    ''' <summary>Identifies the Approved entity attribute.</summary>
    Public Const ApprovedField As String = "Approved"
    ''' <summary>Identifies the Released entity attribute.</summary>
    Public Const ReleasedField As String = "Released"
    ''' <summary>Identifies the Lcode entity attribute.</summary>
    Public Const LcodeField As String = "Lcode"
    ''' <summary>Identifies the JrfNumber entity attribute.</summary>
    Public Const JrfNumberField As String = "JrfNumber"
    ''' <summary>Identifies the MiddleName entity attribute.</summary>
    Public Const MiddleNameField As String = "MiddleName"
    ''' <summary>Identifies the LastName entity attribute.</summary>
    Public Const LastNameField As String = "LastName"
    ''' <summary>Identifies the CheckedDate entity attribute.</summary>
    Public Const CheckedDateField As String = "CheckedDate"
    ''' <summary>Identifies the ApprovedDate entity attribute.</summary>
    Public Const ApprovedDateField As String = "ApprovedDate"
    ''' <summary>Identifies the ReleasedDate entity attribute.</summary>
    Public Const ReleasedDateField As String = "ReleasedDate"
    ''' <summary>Identifies the Solutions entity attribute.</summary>
    Public Const SolutionsField As String = "Solutions"
    ''' <summary>Identifies the Remarks entity attribute.</summary>
    Public Const RemarksField As String = "Remarks"
    ''' <summary>Identifies the NoLiquidation entity attribute.</summary>
    Public Const NoLiquidationField As String = "NoLiquidation"





    Public Sub New()
      MyBase.New(False)
      Initialize()
    End Sub
    
    Protected Sub New(initialize As Boolean)
      MyBase.New(initialize)
    End Sub
  
    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property Name() As String
      Get
        Return [Get](_name, "Name")
      End Get
      Set(ByVal value As String)
        [Set](_name, value, "Name")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property DDate() As System.Nullable(Of Date)
      Get
        Return [Get](_dDate, "DDate")
      End Get
      Set(ByVal value As System.Nullable(Of Date))
        [Set](_dDate, value, "DDate")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property Destination() As String
      Get
        Return [Get](_destination, "Destination")
      End Get
      Set(ByVal value As String)
        [Set](_destination, value, "Destination")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property PetcName() As String
      Get
        Return [Get](_petcName, "PetcName")
      End Get
      Set(ByVal value As String)
        [Set](_petcName, value, "PetcName")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property Task() As String
      Get
        Return [Get](_task, "Task")
      End Get
      Set(ByVal value As String)
        [Set](_task, value, "Task")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property LTotal() As System.Nullable(Of Decimal)
      Get
        Return [Get](_lTotal, "LTotal")
      End Get
      Set(ByVal value As System.Nullable(Of Decimal))
        [Set](_lTotal, value, "LTotal")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property DateEncoded() As System.Nullable(Of Date)
      Get
        Return [Get](_dateEncoded, "DateEncoded")
      End Get
      Set(ByVal value As System.Nullable(Of Date))
        [Set](_dateEncoded, value, "DateEncoded")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property UserCode() As String
      Get
        Return [Get](_userCode, "UserCode")
      End Get
      Set(ByVal value As String)
        [Set](_userCode, value, "UserCode")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property Checked() As System.Nullable(Of Integer)
      Get
        Return [Get](_checked, "Checked")
      End Get
      Set(ByVal value As System.Nullable(Of Integer))
        [Set](_checked, value, "Checked")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property Approved() As System.Nullable(Of Integer)
      Get
        Return [Get](_approved, "Approved")
      End Get
      Set(ByVal value As System.Nullable(Of Integer))
        [Set](_approved, value, "Approved")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property Released() As System.Nullable(Of Integer)
      Get
        Return [Get](_released, "Released")
      End Get
      Set(ByVal value As System.Nullable(Of Integer))
        [Set](_released, value, "Released")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property Lcode() As String
      Get
        Return [Get](_lcode, "Lcode")
      End Get
      Set(ByVal value As String)
        [Set](_lcode, value, "Lcode")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property JrfNumber() As String
      Get
        Return [Get](_jrfNumber, "JrfNumber")
      End Get
      Set(ByVal value As String)
        [Set](_jrfNumber, value, "JrfNumber")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property MiddleName() As String
      Get
        Return [Get](_middleName, "MiddleName")
      End Get
      Set(ByVal value As String)
        [Set](_middleName, value, "MiddleName")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property LastName() As String
      Get
        Return [Get](_lastName, "LastName")
      End Get
      Set(ByVal value As String)
        [Set](_lastName, value, "LastName")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property CheckedDate() As System.Nullable(Of Date)
      Get
        Return [Get](_checkedDate, "CheckedDate")
      End Get
      Set(ByVal value As System.Nullable(Of Date))
        [Set](_checkedDate, value, "CheckedDate")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property ApprovedDate() As System.Nullable(Of Date)
      Get
        Return [Get](_approvedDate, "ApprovedDate")
      End Get
      Set(ByVal value As System.Nullable(Of Date))
        [Set](_approvedDate, value, "ApprovedDate")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property ReleasedDate() As System.Nullable(Of Date)
      Get
        Return [Get](_releasedDate, "ReleasedDate")
      End Get
      Set(ByVal value As System.Nullable(Of Date))
        [Set](_releasedDate, value, "ReleasedDate")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property Solutions() As String
      Get
        Return [Get](_solutions, "Solutions")
      End Get
      Set(ByVal value As String)
        [Set](_solutions, value, "Solutions")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property Remarks() As String
      Get
        Return [Get](_remarks, "Remarks")
      End Get
      Set(ByVal value As String)
        [Set](_remarks, value, "Remarks")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property NoLiquidation() As System.Nullable(Of Integer)
      Get
        Return [Get](_noLiquidation, "NoLiquidation")
      End Get
      Set(ByVal value As System.Nullable(Of Integer))
        [Set](_noLiquidation, value, "NoLiquidation")
      End Set
    End Property





  End Class


  <Serializable()> _
  <System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")> _
  <System.ComponentModel.DataObject> _
  <Table(IdColumnName := "Nid")> _
  Public Partial Class Tblnotification
    Inherits Entity(Of Long)

    <ValidateLength(0, 50)> _
    Private _targettype As String
    
    <ValidateLength(0, 50)> _
    Private _sourcetype As String
    
    <Column("target_id"), ValidateLength(0, 10)> _
    Private _targetId As String
    
    <Column("source_id"), ValidateLength(0, 10)> _
    Private _sourceId As String
    
    <Column("notif_info"), ValidateLength(0, 250)> _
    Private _notifInfo As String
    
    <Column("notif_date")> _
    Private _notifDate As System.Nullable(Of Date)
    
    <Column("view_status")> _
    Private _viewStatus As System.Nullable(Of Integer)
    
    <ValidateLength(0, 50)> _
    Private _lcode As String
    
    <Column("notif_datetime")> _
    Private _notifDatetime As System.Nullable(Of Date)



    ''' <summary>Identifies the Targettype entity attribute.</summary>
    Public Const TargettypeField As String = "Targettype"
    ''' <summary>Identifies the Sourcetype entity attribute.</summary>
    Public Const SourcetypeField As String = "Sourcetype"
    ''' <summary>Identifies the TargetId entity attribute.</summary>
    Public Const TargetIdField As String = "TargetId"
    ''' <summary>Identifies the SourceId entity attribute.</summary>
    Public Const SourceIdField As String = "SourceId"
    ''' <summary>Identifies the NotifInfo entity attribute.</summary>
    Public Const NotifInfoField As String = "NotifInfo"
    ''' <summary>Identifies the NotifDate entity attribute.</summary>
    Public Const NotifDateField As String = "NotifDate"
    ''' <summary>Identifies the ViewStatus entity attribute.</summary>
    Public Const ViewStatusField As String = "ViewStatus"
    ''' <summary>Identifies the Lcode entity attribute.</summary>
    Public Const LcodeField As String = "Lcode"
    ''' <summary>Identifies the NotifDatetime entity attribute.</summary>
    Public Const NotifDatetimeField As String = "NotifDatetime"





    Public Sub New()
      MyBase.New(False)
      Initialize()
    End Sub
    
    Protected Sub New(initialize As Boolean)
      MyBase.New(initialize)
    End Sub
  
    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property Targettype() As String
      Get
        Return [Get](_targettype, "Targettype")
      End Get
      Set(ByVal value As String)
        [Set](_targettype, value, "Targettype")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property Sourcetype() As String
      Get
        Return [Get](_sourcetype, "Sourcetype")
      End Get
      Set(ByVal value As String)
        [Set](_sourcetype, value, "Sourcetype")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property TargetId() As String
      Get
        Return [Get](_targetId, "TargetId")
      End Get
      Set(ByVal value As String)
        [Set](_targetId, value, "TargetId")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property SourceId() As String
      Get
        Return [Get](_sourceId, "SourceId")
      End Get
      Set(ByVal value As String)
        [Set](_sourceId, value, "SourceId")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property NotifInfo() As String
      Get
        Return [Get](_notifInfo, "NotifInfo")
      End Get
      Set(ByVal value As String)
        [Set](_notifInfo, value, "NotifInfo")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property NotifDate() As System.Nullable(Of Date)
      Get
        Return [Get](_notifDate, "NotifDate")
      End Get
      Set(ByVal value As System.Nullable(Of Date))
        [Set](_notifDate, value, "NotifDate")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property ViewStatus() As System.Nullable(Of Integer)
      Get
        Return [Get](_viewStatus, "ViewStatus")
      End Get
      Set(ByVal value As System.Nullable(Of Integer))
        [Set](_viewStatus, value, "ViewStatus")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property Lcode() As String
      Get
        Return [Get](_lcode, "Lcode")
      End Get
      Set(ByVal value As String)
        [Set](_lcode, value, "Lcode")
      End Set
    End Property

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Property NotifDatetime() As System.Nullable(Of Date)
      Get
        Return [Get](_notifDatetime, "NotifDatetime")
      End Get
      Set(ByVal value As System.Nullable(Of Date))
        [Set](_notifDatetime, value, "NotifDatetime")
      End Set
    End Property





  End Class




  ''' <summary>
  ''' Provides a strong-typed unit of work for working with the LightSpeedModel1 model.
  ''' </summary>
  <System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")> _
  Public Partial Class LightSpeedModel1UnitOfWork
    Inherits Mindscape.LightSpeed.UnitOfWork
    

    Public ReadOnly Property TblPetcs As System.Linq.IQueryable(Of TblPetc)
      Get
        Return Query(Of TblPetc)()
      End Get
    End Property
    
    Public ReadOnly Property Tblusers As System.Linq.IQueryable(Of Tbluser)
      Get
        Return Query(Of Tbluser)()
      End Get
    End Property
    
    Public ReadOnly Property TblTechnicians As System.Linq.IQueryable(Of TblTechnician)
      Get
        Return Query(Of TblTechnician)()
      End Get
    End Property
    
    Public ReadOnly Property Tblbreakdowns As System.Linq.IQueryable(Of Tblbreakdown)
      Get
        Return Query(Of Tblbreakdown)()
      End Get
    End Property
    
    Public ReadOnly Property Tbljrves As System.Linq.IQueryable(Of Tbljrf)
      Get
        Return Query(Of Tbljrf)()
      End Get
    End Property
    
    Public ReadOnly Property Tblliquidations As System.Linq.IQueryable(Of Tblliquidation)
      Get
        Return Query(Of Tblliquidation)()
      End Get
    End Property
    
    Public ReadOnly Property Tblnotifications As System.Linq.IQueryable(Of Tblnotification)
      Get
        Return Query(Of Tblnotification)()
      End Get
    End Property
    
    
  End Class
  

End Namespace
