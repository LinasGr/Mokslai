using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityCodeFirst.Models;
using EntityCodeFirst.Tools;

namespace EntityCodeFirst.Controllers
{
  class AssociationsController
  {
    public int Select()
    {
      var menu = new Menu();
      menu.Clear();
      using (var db = new EntityContext())
      {
        foreach (var dbAssoc in db.Associations)
        {
          menu.Add(dbAssoc.Name, dbAssoc.AssociationId);
        }
      }
      if (menu.Count() == 0) return -1;
      var index = menu.SelectMenuIndex();
      while (index < 0) index = menu.SelectMenuIndex();
      return index;
    }

    internal void ListAll()
    {
      using (var db = new EntityContext())
      {
        foreach (var dbAssociation in db.Associations)
        {
          Console.WriteLine($"{dbAssociation.Name} - Created on {dbAssociation.DateCreated}");
        }
      }
    }

    public void Add()
    {
      var assoc = new Association();
      assoc.Name = WriteRead.WRL("Enter association nam: ");
      var db = new EntityContext();
      db.Associations.Add(assoc);
      db.SaveChanges();
    }

    internal void Edit()
    {
      throw new NotImplementedException();
    }

    public void Delete()
    {
      throw new NotImplementedException();
    }
  }
}
