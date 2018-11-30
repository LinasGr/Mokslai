using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using EntityCodeFirst.Controllers;
using EntityCodeFirst.Models;
using EntityCodeFirst.Tools;

namespace EntityCodeFirst
{
  class Program
  {
    static void Main(string[] args)
    {
      Login();
    }

    static private void Login()
    {
      var users = new UsersController();
      var menu = new Menu(true);
      menu.Insert("List users", users.ListAll);
      menu.Insert("Add user", users.Add);
      menu.Insert("Select user", SelectUser);
      while (menu.SelectAct()) ;
    }

    static private void SelectUser()
    {
      Console.Clear();
      var user = new UsersController();
      var SelectedUserName = user.Select();
      var Profiles = new ProfilesController();
      var menu = new Menu(true);
      menu.Insert("List profiles", Profiles.ListAll);
      menu.Insert("Add profile", Profiles.Add);
      menu.Insert("Select profile", SelectProfile);
      while (menu.SelectAct()) ;
    }

    static private void SelectProfile()
    {
      var Profiles = new ProfilesController();
      var SelectedProfileId = Profiles.Select();
      var Associations = new AssociationsController();
      var Documents = new DocumentsController();
      var menu = new Menu(true);
      menu.Insert("List Associations", Associations.ListAll);
      menu.Insert("Add Association", Associations.Add);
      menu.Insert("Select Association", SelectAssociation);
      menu.Insert("List documents", Documents.ListAll);
      menu.Insert("Add document", Documents.Add);
      menu.Insert("Select document", SelectDocument);
      while (menu.SelectAct()) ;
    }

    static private void SelectDocument()
    {
      var Documents = new DocumentsController();
      var SelectedDocumentId = Documents.Select();

      var menu = new Menu(true);
      menu.Insert("Edit document", Documents.Edit);
      menu.Insert("Delete document", Documents.Delete);
      while (menu.SelectAct()) ;
    }

    static private void SelectAssociation()
    {
      var Associations = new AssociationsController();
      var SelectedAssociationId = Associations.Select();
      var Documents = new DocumentsController();
      var menu = new Menu(true);
      menu.Insert("Edit Association", Associations.Edit);
      menu.Insert("Delete Association", Associations.Delete);
      menu.Insert("List documents", Documents.ListAll);
      menu.Insert("Add document", Documents.Add);
      menu.Insert("Edit document", Documents.Edit);
      menu.Insert("Delete document", Documents.Delete);
      menu.Insert("Select document", SelectDocument);
      while (menu.SelectAct()) ;
    }
  }
}
