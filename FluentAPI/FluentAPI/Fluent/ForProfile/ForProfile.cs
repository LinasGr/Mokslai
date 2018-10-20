using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI.Fluent.ForProfile
{
  class ForProfile : IForProfile
  {
    public IForProfile Is(Status status)
    {
      return this as IForProfile;
    }

    public void List()
    {
      throw new NotImplementedException();
    }

    public IForProfile Not(Status status)
    {
      return this as IForProfile;
    }
  }
}
