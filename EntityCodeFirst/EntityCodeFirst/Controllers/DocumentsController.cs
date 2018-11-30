using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityCodeFirst.Models;
using EntityCodeFirst.Tools;

namespace EntityCodeFirst.Controllers
{
  class DocumentsController
  {
    public void ListAll()
    {
      using (var db = new EntityContext())
      {
        foreach (var dbDocument in db.Documents.Include("Association").ToList())
        {
          Console.WriteLine($"[{dbDocument.Association.Name}]\n" +
                            $"  Title -  {dbDocument.Title}\n" +
                            $"  Text -{(dbDocument.Text.Length > 10 ? dbDocument.Text.Substring(0,10) : dbDocument.Text)}\n" +
                            $"  Valid for dates: {dbDocument.DateValidFrom} - {dbDocument.DateValidTill}");
        }
      }
    }

    public void Add(int AssociationId)
    {
      var doc = new Document();
      doc.Title = WriteRead.WRL("Enter document title: ");
      doc.Text = WriteRead.WRL("Enter document text: ");
      var date = new DateTime();
      if (DateTime.TryParse(WriteRead.WRL("Enter date document becomes valid: "), out date))
        doc.DateValidFrom = date;
      else doc.DateValidFrom = DateTime.Now;

      if (DateTime.TryParse(WriteRead.WRL("Enter date document valid till"), out date))
        doc.DateValidTill = date;
      else doc.DateValidTill = DateTime.Now.AddYears(1);

      doc.AssociationId = AssociationId;
      using (var db = new EntityContext())
      {
        db.Documents.Add(doc);
        db.SaveChanges();
      }
    }

    public void Add()
    {
      var Associations = new AssociationsController();
      var index = Associations.Select();
      if (index >= 0)
        Add(index);
    }

    public int Select()
    {
      throw new NotImplementedException();
    }

    internal void Edit()
    {
      throw new NotImplementedException();
    }

    internal void Delete()
    {
      throw new NotImplementedException();
    }
  }
}
