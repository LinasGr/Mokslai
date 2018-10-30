using System;
using System.Web.Script.Serialization;
using FluentAPI.Models.Models;


namespace FluentAPI.Models
{
  /// <summary>
  /// Document model with variables names matching db.table columns
  /// </summary>
  public class Document : IRecord
  {
    public int Id { get; }
    public int AssociationId { get; set; }
    public DateTime ValidationDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    public string Text { get; set; }
    public bool Visible { get; set; }
    public int ProfileId { get; set; }
    public bool Signed { get; set; }
    public bool Paid { get; set; }
    public DateTime SignedDate { get; set; }
    public DateTime PaidDate { get; set; }


    /// <summary>
    /// Document values to string
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
      string str = "" + Id + ",";
      str += AssociationId + ",";
      str += ValidationDate + ",";
      str += ExpirationDate + ",";
      str += Text + ",";
      str += Visible + ",";
      str += ProfileId + ",";
      str += Signed + ",";
      str += Paid + ",";
      str += SignedDate + ",";
      str += PaidDate + ".";
      return str;
    }

    /// <summary>
    /// Document values to JSON
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
      return new JavaScriptSerializer().Serialize(this);
    }

    /// <summary>
    /// Returns at all Columns string
    /// </summary>
    /// <returns></returns>
    public string AtAllColumns()
    {
      var str = "";
      foreach (var property in this.GetType().GetProperties())
      {
        str += (property.Name == "Id") ? "" : "@" + property.Name + ",";
      }
      return str.TrimEnd(',');
    }

    /// <summary>
    /// Returns all Columns string
    /// </summary>
    /// <returns></returns>
    public string AllColumns()
    {
      var str = "";
      foreach (var property in this.GetType().GetProperties())
      {
        str += (property.Name == "Id") ? "" : property.Name + ",";
      }
      return str.TrimEnd(',');
    }
  }

  /// <summary>
  /// List of columns in table Documents
  /// </summary>
  public enum DocumentColumns
  {
    Id,
    AssociationId,
    ValidationDate,
    ExpirationDate,
    Text,
    Visible,
    ProfileId,
    Signed,
    Paid,
    SignedDate,
    PaidDate
  }

  /// <summary>
  /// List of document status for filtering records
  /// </summary>
  public enum DocumentStatus
  {
    Signed,
    Paid,
    Valid,
    Visible
  }
}
