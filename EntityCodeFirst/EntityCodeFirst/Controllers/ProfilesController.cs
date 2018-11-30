using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityCodeFirst.Models;
using EntityCodeFirst.Tools;

namespace EntityCodeFirst.Controllers
{
  class ProfilesController
  {
    public void Add(string UserName)
    {
      var pprofile = new Profile();
      pprofile.UserName = UserName;
      Console.WriteLine("Fill the form:");
      pprofile.Name = WriteRead.WRL(" Name: ");
      pprofile.FamilyName = WriteRead.WRL(" Family name: ");
      var date = new DateTime();
      if (DateTime.TryParse(WriteRead.WRL(" Date of birth: "), out date))
        pprofile.BirthDate = date;
      else pprofile.BirthDate = DateTime.Now;

      pprofile.Mobile = WriteRead.WRL(" Mobile number: ");
      pprofile.EMail = WriteRead.WRL(" E_Mail: ");
      using (var db = new EntityContext())
      {
        db.Profiles.Add(pprofile);
        db.SaveChanges();
      }
    }
    public void Add()
    {
      var Users = new UsersController();
      Add(Users.Select());
    }

    public int CountAll()
    {
      var db = new EntityContext();
      return db.Profiles.Count();
    }

    public void ListAll()
    {
      using (var db = new EntityContext())
      {
        foreach (var profile in db.Profiles)
        {
          Console.WriteLine($"User [{profile.UserName}] - {profile.Name} {profile.FamilyName} born on {profile.BirthDate}, mobile number {profile.Mobile}, E_Mail: {profile.EMail}");
        }
      }
    }

    internal int Select()
    {
      var menu = new Menu();
      using (var db = new EntityContext())
      {
        foreach (var dbProfile in db.Profiles)
        {
          menu.Add(dbProfile.Name+" "+dbProfile.FamilyName, dbProfile.ProfileId);
        }
      }
      int ProfileId = menu.SelectMenuIndex();
      while (ProfileId == -1) ProfileId = menu.SelectMenuIndex();
      return ProfileId;
    }
  }
}
