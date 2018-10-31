using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI.API.Filter
{
  class Filter
  {
    //Variable for filtering records
    private Dictionary<DocumentStatus, bool> Filter = new Dictionary<DocumentStatus, bool>();

    //Variable for ordering records
    private Dictionary<DocumentColumns, bool> Order = new Dictionary<DocumentColumns, bool>();
  }
}
