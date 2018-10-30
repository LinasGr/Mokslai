using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using FluentAPI.Models.Models;

namespace FluentAPI.Models.DB
{
  class SQLite : IDB
  {
    public void Create(string table, IRecord record)
    {
      using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
      {
        cnn.Execute($"INSERT INTO {table} ({record.AllColumns()}) Values ({record.AtAllColumns()});", record);
      }
    }

    public void Delete(string table, int id)
    {
      using (var cnn = new SQLiteConnection(LoadConnectionString()))
      {
        cnn.Execute($"DELETE FROM {table} WHERE id={id};");
      }
    }

    public void Read(string query,ref List<IRecord> recordList)
    {
      using (var cnn = new SQLiteConnection(LoadConnectionString()))
      {
        recordList  = cnn.Query<IRecord>(query, new DynamicParameters()).ToList();
      }
    }

    public void Update(string table, IRecord record)
    {
      using (var cnn=new SQLiteConnection(LoadConnectionString()))
      {
        cnn.Execute($"UPDATE {table} ({record.AllColumns()}) VALUES ({record.AtAllColumns()}) WHERE id={record.Id};",record);
      }
    }

    private static string LoadConnectionString(string id = "Default")
    {
      return ConfigurationManager.ConnectionStrings[id].ConnectionString;
    }
  }
}
