using FluentAPI.Fluent.ForProfile;
using FluentAPI.Fluent.ForAssociation;
using FluentAPI.Models;


namespace FluentAPI.Fluent
{
  /// <summary>
  /// Class to play with intuitive/fluent API
  /// It suppose to provide fluent CRUD working with SQLite db
  /// DB suppose to have 3 tables (Documents, Association, Profile)
  /// Documents class works from side of Documents
  /// </summary>
  class Documents:Document
  {
    public IForProfile ForProfile(int id=0)
    {
      return new ForProfile.ForProfile(id);
    }

    public IForAssociation ForAssociation(int id=0)
    {
      return new ForAssociation.ForAssociation(id);
    }
  }

  
}
