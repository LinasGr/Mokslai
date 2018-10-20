using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAPI.Fluent.ForProfile;

namespace FluentAPI.Fluent
{
  class Documents
  {
    public IForProfile ForProfile(int id)
    {
      return new ForProfile.ForProfile();
    }
  }

  public enum Status
  {
    Signed,
    Paid,
    Valid
  }
}
