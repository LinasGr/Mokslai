using System.Collections.Generic;
using FluentAPI.Models.Models;

namespace FluentAPI.Models.DB
{
  /// <summary>
  /// Interface to describe methods of CRUD connecting to various db
  /// </summary>
  public interface IDB
  {
    void Create(string table, IRecord record);
    List<IRecord> Read<IRecord>(string query);
    void Update(string table, IRecord record);
    void Delete(string table, int id);
  }
}
