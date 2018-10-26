using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using Dapper;

namespace FluentAPI.Models
{
  /// <summary>
  /// SQLite db query class
  /// </summary>
  public class Db
  {
    /// <summary>
    /// Get list of Documents from db by query
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    public static List<Document> LoadDocuments(string query= "SELECT * FROM Documents")
    {
      using (var cnn = new SQLiteConnection(LoadConnectionString()))
      {
        var output = cnn.Query<Document>(query, new DynamicParameters());
        return output.ToList();
      }
    }

    /// <summary>
    /// Add Document to db
    /// </summary>
    /// <param name="doc"></param>
    public static void AddDocument(Document doc)
    {
      using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
      {
        cnn.Execute("INSERT INTO Documents (AssociationId,ValidationDate,ExpirationDate,Text,Visible,ProfileId,Signed,Paid,SignedDate,PaidDate) Values (@AssociationId,@ValidationDate,@ExpirationDate,@Text,@Visible,@ProfileId,@Signed,@Paid,@SignedDate,@PaidDate)", doc);
      }
    }

    private static string LoadConnectionString(string id = "Default")
    {
      return ConfigurationManager.ConnectionStrings[id].ConnectionString;
    }

  }
}
