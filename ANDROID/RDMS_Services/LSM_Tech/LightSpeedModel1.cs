using System;

using Mindscape.LightSpeed;
using Mindscape.LightSpeed.Validation;
using Mindscape.LightSpeed.Linq;

namespace LSM_Tech
{
  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  [System.ComponentModel.DataObject]
  public partial class TblTechDeployment : Entity<long>
  {
    #region Fields
  
    [ValidateLength(0, 50)]
    private string _username;
    [ValidateLength(0, 50)]
    private string _mobileno;
    [ValidateLength(0, 150)]
    private string _petcname;
    [Column("TECH_TASKS")]
    [ValidateLength(0, 500)]
    private string _techTasks;
    [Column("DATE_DEPLOYMENT")]
    private System.Nullable<System.DateTime> _dateDeployment;
    [Column("TASKS_DESCRIPTION")]
    [ValidateLength(0, 500)]
    private string _tasksDescription;
    [ValidateLength(0, 50)]
    private string _longtitude;
    [ValidateLength(0, 50)]
    private string _latitude;
    [ValidateLength(0, 350)]
    private string _location;
    [Column("UPLOADED_CODE")]
    [ValidateLength(0, 50)]
    private string _uploadedCode;
    [Column("UPLOADED_DATE")]
    private System.Nullable<System.DateTime> _uploadedDate;
    [Column("TECH_IMAGE")]
    private byte[] _techImage;
    [Column("DATE_FILED")]
    private System.Nullable<System.DateTime> _dateFiled;
    [Column("GEN_CODE")]
    [ValidateLength(0, 50)]
    private string _genCode;
    [Column("SERIAL_CODE")]
    [ValidateLength(0, 50)]
    private string _serialCode;

    #endregion
    
    #region Field attribute and view names
    
    /// <summary>Identifies the Username entity attribute.</summary>
    public const string UsernameField = "Username";
    /// <summary>Identifies the Mobileno entity attribute.</summary>
    public const string MobilenoField = "Mobileno";
    /// <summary>Identifies the Petcname entity attribute.</summary>
    public const string PetcnameField = "Petcname";
    /// <summary>Identifies the TechTasks entity attribute.</summary>
    public const string TechTasksField = "TechTasks";
    /// <summary>Identifies the DateDeployment entity attribute.</summary>
    public const string DateDeploymentField = "DateDeployment";
    /// <summary>Identifies the TasksDescription entity attribute.</summary>
    public const string TasksDescriptionField = "TasksDescription";
    /// <summary>Identifies the Longtitude entity attribute.</summary>
    public const string LongtitudeField = "Longtitude";
    /// <summary>Identifies the Latitude entity attribute.</summary>
    public const string LatitudeField = "Latitude";
    /// <summary>Identifies the Location entity attribute.</summary>
    public const string LocationField = "Location";
    /// <summary>Identifies the UploadedCode entity attribute.</summary>
    public const string UploadedCodeField = "UploadedCode";
    /// <summary>Identifies the UploadedDate entity attribute.</summary>
    public const string UploadedDateField = "UploadedDate";
    /// <summary>Identifies the TechImage entity attribute.</summary>
    public const string TechImageField = "TechImage";
    /// <summary>Identifies the DateFiled entity attribute.</summary>
    public const string DateFiledField = "DateFiled";
    /// <summary>Identifies the GenCode entity attribute.</summary>
    public const string GenCodeField = "GenCode";
    /// <summary>Identifies the SerialCode entity attribute.</summary>
    public const string SerialCodeField = "SerialCode";


    #endregion
    
    #region Properties



    [System.Diagnostics.DebuggerNonUserCode]
    public string Username
    {
      get { return Get(ref _username, "Username"); }
      set { Set(ref _username, value, "Username"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string Mobileno
    {
      get { return Get(ref _mobileno, "Mobileno"); }
      set { Set(ref _mobileno, value, "Mobileno"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string Petcname
    {
      get { return Get(ref _petcname, "Petcname"); }
      set { Set(ref _petcname, value, "Petcname"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string TechTasks
    {
      get { return Get(ref _techTasks, "TechTasks"); }
      set { Set(ref _techTasks, value, "TechTasks"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public System.Nullable<System.DateTime> DateDeployment
    {
      get { return Get(ref _dateDeployment, "DateDeployment"); }
      set { Set(ref _dateDeployment, value, "DateDeployment"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string TasksDescription
    {
      get { return Get(ref _tasksDescription, "TasksDescription"); }
      set { Set(ref _tasksDescription, value, "TasksDescription"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string Longtitude
    {
      get { return Get(ref _longtitude, "Longtitude"); }
      set { Set(ref _longtitude, value, "Longtitude"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string Latitude
    {
      get { return Get(ref _latitude, "Latitude"); }
      set { Set(ref _latitude, value, "Latitude"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string Location
    {
      get { return Get(ref _location, "Location"); }
      set { Set(ref _location, value, "Location"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string UploadedCode
    {
      get { return Get(ref _uploadedCode, "UploadedCode"); }
      set { Set(ref _uploadedCode, value, "UploadedCode"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public System.Nullable<System.DateTime> UploadedDate
    {
      get { return Get(ref _uploadedDate, "UploadedDate"); }
      set { Set(ref _uploadedDate, value, "UploadedDate"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public byte[] TechImage
    {
      get { return Get(ref _techImage, "TechImage"); }
      set { Set(ref _techImage, value, "TechImage"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public System.Nullable<System.DateTime> DateFiled
    {
      get { return Get(ref _dateFiled, "DateFiled"); }
      set { Set(ref _dateFiled, value, "DateFiled"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string GenCode
    {
      get { return Get(ref _genCode, "GenCode"); }
      set { Set(ref _genCode, value, "GenCode"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string SerialCode
    {
      get { return Get(ref _serialCode, "SerialCode"); }
      set { Set(ref _serialCode, value, "SerialCode"); }
    }

    #endregion
  }




  /// <summary>
  /// Provides a strong-typed unit of work for working with the LightSpeedModel1 model.
  /// </summary>
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  public partial class LightSpeedModel1UnitOfWork : Mindscape.LightSpeed.UnitOfWork
  {

    public System.Linq.IQueryable<TblTechDeployment> TblTechDeployments
    {
      get { return this.Query<TblTechDeployment>(); }
    }
    
  }

}
