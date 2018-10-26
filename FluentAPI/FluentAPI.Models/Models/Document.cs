using System;
using System.Web.Script.Serialization;


namespace FluentAPI.Models
{
  /// <summary>
  /// Document model with variables names matching db.table columns
  /// </summary>
  public class Document
  {
    public int Id { get;  }
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
      string str = "" + Id +",";
      str += AssociationId + ",";
      str += ValidationDate + ",";
      str += ExpirationDate + ",";
      str += Text + ",";
      str += Visible + ",";
      str += ProfileId+",";
      str += Signed+",";
      str += Paid+",";
      str += SignedDate+",";
      str += PaidDate+".";
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
  }
}
