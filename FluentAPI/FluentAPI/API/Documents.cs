using System;
using FluentAPI.API.DB;
using FluentAPI.API.ForProfile;
using FluentAPI.API.ForAssociation;
using FluentAPI.Models;
using FluentAPI.Models.DB;


namespace FluentAPI.API
{
  /// <summary>
  /// Class to play with intuitive/fluent API
  /// It suppose to provide fluent CRUD working with SQLite db
  /// DB suppose to have 3 tables (Documents, Association, Profile)
  /// Documents class works from side of Documents
  /// </summary>
  class Documents
  {
    private const string TABLE_NAME = "Documents";
    private const int ID_FOR_ALL_RECORDS = 0;
    private FilterRecords _filter=new FilterRecords();
   

    public IForProfile ForProfile(int id=ID_FOR_ALL_RECORDS, string table=TABLE_NAME)
    {
      return new ForProfile.ForProfile(id,table);
    }

    public IForAssociation ForAssociation(int id=ID_FOR_ALL_RECORDS)
    {
      return new ForAssociation.ForAssociation(id);
    }

    public void Create(Document doc)
    {
      //Creates SQLite record
      new SQLiteDB().Create(TABLE_NAME,doc);
    }

    public void Read()
    {
      throw new NotImplementedException();
    }

    public void Update()
    {
      throw new NotImplementedException();
    }

    public void Delete()
    {
      throw new NotImplementedException();
    }
  }

  
}
