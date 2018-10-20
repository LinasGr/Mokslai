using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI.Fluent.ForProfile
{
  interface IForProfile
  {
    void List();
    IForProfile Is(Status status);
    IForProfile Not(Status status);
  }
}
