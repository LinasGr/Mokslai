using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI.Fluent.ForAssociation
{
  interface IForAssociation
  {
    void List();
    IForAssociation Is(Status status);
    IForAssociation Not(Status status);
  }
}
