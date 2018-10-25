using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;

namespace FluentAPI.Models
{
  public class Db
  {
    private SQLiteConnection _dbConnection;
    private string _dbName;
    public List<IModels> DataList;

    public Db(string dbName)
    {
      _dbName = dbName;
      _dbConnection = new SQLiteConnection("Data source=" + dbName + ";Version=3;");
      _dbConnection.Open();
      _dbConnection.Close();
      DataList=new List<IModels>();
    }


  }
}
