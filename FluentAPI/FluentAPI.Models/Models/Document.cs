using System;
using System.Web.Script.Serialization;


namespace FluentAPI.Models
{
  public class Document
  {
    public int Id { get;  }
    public int AssociationId { get; set; }
    public DateTime ValidationDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    public string Text { get; set; }
    public bool Visible { get; set; }

    public override string ToString()
    {
      string str = "" + Id +",";
      str += AssociationId + ",";
      str += ValidationDate + ",";
      str += ExpirationDate + ",";
      str += Text + ",";
      str += Visible + ".";
      return str;
    }

    public string ToJson()
    {
      return new JavaScriptSerializer().Serialize(this);
    }
  }
}
