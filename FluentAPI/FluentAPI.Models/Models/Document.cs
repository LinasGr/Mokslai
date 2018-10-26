using System;

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
  }
}
