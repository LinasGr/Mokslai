using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI.Models.Models
{
  interface IRecord
  {
    string[] Columns {get;}
    int Id { get; }
    string ToString();
    string ToJson();
    string AtAllColumns();
    string AllColumns();
  }
}
