using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using Dapper;

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
      //_dbConnection = new SQLiteConnection("Data source=" + dbName + ";Version=3;");
      //_dbConnection.Open();
      //_dbConnection.Close();
      DataList=new List<IModels>();
    }

    public static List<IModels> LoadData()
    {
      using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
      {
        var output = cnn.Query<IModels>("SELECT * FROM Documents", new DynamicParameters());
        return output.ToList();
      }
    }

    public static void AddDocument(Document doc)
    {
      using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
      {
        cnn.Execute("INSERT IN TO Documents (AssociationId,ValidationDate,ExpirationDate,Text,Visible) Values (@AssociationId,@ValidationDate,@ExpirationDate,@Text,@Visible)", doc);
      }
    }

    public static string LoadConnectionString(string id = "Default")
    {
      return ConfigurationManager.ConnectionStrings[id].ConnectionString;
    }

  }
}
