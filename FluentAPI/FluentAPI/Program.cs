using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using FluentAPI.Fluent;

namespace FluentAPI
{
  class Program
  {
    static void Main(string[] args)
    {
      new Documents()
        .ForProfile(1)
          .Is(Status.Signed)
          .Not(Status.Paid)
          .Is(Status.Valid)
        .List();
    }
  }
}