using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAPI.Fluent.ForProfile;
using FluentAPI.Fluent.ForAssociation;

namespace FluentAPI.Fluent
{
  class Documents
  {
    public IForProfile ForProfile(int id)
    {
      return new ForProfile.ForProfile();
    }

    public ForAssociation.ForAssociation ForAssociation(int id)
    {
      return new ForAssociation.ForAssociation();
    }
  }

  public enum Status
  {
    Signed,
    Paid,
    Valid
  }
}
