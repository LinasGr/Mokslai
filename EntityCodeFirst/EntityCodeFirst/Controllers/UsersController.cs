using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using EntityCodeFirst.Models;
using EntityCodeFirst.Tools;

namespace EntityCodeFirst.Controllers
{
  class UsersController
  {

    public void Add()
    {
      var User =new User()
        { UserName = WriteRead.WRL("Enter user name: ")};
      using (var db=new EntityContext())
      {
        db.Users.Add(User);
        db.SaveChanges();
      }
    }



    public void ListAll()
    {
      using (var db = new EntityContext())
      {
        foreach (var user in db.Users)
        {
          Console.WriteLine($"{user.UserName}   Created on - {user.DateCreated}");
        }
      }
    }

    public string Select()
    {
      var menu = new Menu();
      using (var db = new EntityContext())
      {
        foreach (var dbuser in db.Users)
        {
          menu.Add(dbuser.UserName,null);
        }
      }
      string userName = menu.SelectMenuString();
      while (userName == "") userName = menu.SelectMenuString();
      return userName;
    }
  }
}
