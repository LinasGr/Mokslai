using FluentAPI.API;
using FluentAPI.Models;


namespace FluentAPI
{
  class Program
  {
    static void Main(string[] args)
    {
      //Testing Fluent Api SQLite querry to JSON
      new Documents()
        .ForProfile(1)
          .Is( DocumentStatus.Visible)
          .Not(DocumentStatus.Valid)
          .OrderDESC(DocumentColumns.AssociationId)
        .List();
      //new Documents()
      //  .ForAssociation(1)
      //    .Is(DocumentStatus.Paid)
      //    .Not(DocumentStatus.Valid)
      //  .List();

      //Document doc = new Document();
      //doc.Visible = true;
      //doc.Text = "Text of document...";
      //doc.ExpirationDate = DateTime.Now + TimeSpan.FromDays(10);
      //doc.ValidationDate = DateTime.Now;
      //List<Document> lDoc = new List<Document>();
      //lDoc = Db.LoadDocuments();

      //Db.AddDocument(doc);

    }
  }
}