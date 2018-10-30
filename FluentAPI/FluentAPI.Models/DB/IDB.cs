using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAPI.Models.Models;

namespace FluentAPI.Models.DB
{
  /// <summary>
  /// Interface to describe methods of CRUD connecting to various db
  /// </summary>
  interface IDB
  {
    void Create(string table, IRecord record);
    void Read(string query,ref List<IRecord> recordList);
    void Update(string table, IRecord record);
    void Delete(string table, int id);
  }
}
