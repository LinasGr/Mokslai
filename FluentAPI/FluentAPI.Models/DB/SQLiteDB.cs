using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using Dapper;
using FluentAPI.Models.Models;

namespace FluentAPI.Models.DB
{
  public class SQLiteDB : IDB
  {
    public void Create(string table, IRecord record)
    {
      using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
      {
        var str = $"INSERT INTO {table} ({record.AllColumns()}) Values ({record.AtAllColumns()});";
        cnn.Execute(str, record);
      }
    }

    public void Delete(string table, int id)
    {
      using (var cnn = new SQLiteConnection(LoadConnectionString()))
      {
        cnn.Execute($"DELETE FROM {table} WHERE id={id};");
      }
    }

    public List<IRecord> Read<IRecord>(string query)
    {
      using (var cnn = new SQLiteConnection(LoadConnectionString()))
      {
        return cnn.Query<IRecord>(query, new DynamicParameters()).ToList();
      }
    }

    public void Update(string table, IRecord record)
    {
      using (var cnn=new SQLiteConnection(LoadConnectionString()))
      {
        cnn.Execute($"UPDATE {table} ({record.AllColumns()}) VALUES ({record.AtAllColumns()}) WHERE id={record.Id};",record);
      }
    }

    private static string LoadConnectionString(string id = "SQLite")
    {
      return ConfigurationManager.ConnectionStrings[id].ConnectionString;
    }
  }
}
