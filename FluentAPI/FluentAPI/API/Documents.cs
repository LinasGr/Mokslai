using FluentAPI.API.ForProfile;
using FluentAPI.API.ForAssociation;
using FluentAPI.Models;



namespace FluentAPI.API
{
  /// <summary>
  /// Class to play with intuitive/fluent API
  /// It suppose to provide fluent CRUD working with SQLite db
  /// DB suppose to have 3 tables (Documents, Association, Profile)
  /// Documents class works from side of Documents
  /// </summary>
  class Documents:Document
  {
    private const string TABLE_NAME = "Documents";
    private const int ID_FOR_ALL_RECORDS = 0;
   

    public IForProfile ForProfile(int id=ID_FOR_ALL_RECORDS, string table=TABLE_NAME)
    {
      return new ForProfile.ForProfile(id,table);
    }

    public IForAssociation ForAssociation(int id=ID_FOR_ALL_RECORDS)
    {
      return new ForAssociation.ForAssociation(id);
    }
  }

  
}
