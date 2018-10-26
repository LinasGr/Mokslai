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
    public static List<Document> LoadDocuments(string querry= "SELECT * FROM Documents")
    {
      using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
      {
        var output = cnn.Query<Document>(querry, new DynamicParameters());
        return output.ToList();
      }
    }

    public static void AddDocument(Document doc)
    {
      using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
      {
        cnn.Execute("INSERT INTO Documents (AssociationId,ValidationDate,ExpirationDate,Text,Visible) Values (@AssociationId,@ValidationDate,@ExpirationDate,@Text,@Visible)", doc);
      }
    }

    private static string LoadConnectionString(string id = "Default")
    {
      return ConfigurationManager.ConnectionStrings[id].ConnectionString;
    }

  }
}
