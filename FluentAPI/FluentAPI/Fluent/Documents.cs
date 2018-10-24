using System.Collections.Generic;
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

    public IForAssociation ForAssociation(int id)
    {
      return new ForAssociation.ForAssociation();
    }
  }

  public enum Status
  {
    Signed,
    Paid,
    Valid,
    Visible
  }
}
