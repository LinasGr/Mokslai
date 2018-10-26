using FluentAPI.Fluent.ForProfile;
using FluentAPI.Fluent.ForAssociation;


namespace FluentAPI.Fluent
{
  /// <summary>
  /// Class to play with intuitive/fluent API
  /// It suppose to provide fluent CRUD working with SQLite db
  /// DB suppose to have 3 tables (Documents, Association, Profile)
  /// Documents class works from side of Documents
  /// </summary>
  class Documents
  {
    public IForProfile ForProfile(int id=0)
    {
      return new ForProfile.ForProfile(id);
    }

    public IForAssociation ForAssociation(int id=0)
    {
      return new ForAssociation.ForAssociation(id);
    }
  }

  /// <summary>
  /// List of columns in table Documents
  /// </summary>
  public enum DocumentColumns
  {
    Id,
    AssociationId,
    ValidationDate,
    ExpirationDate,
    Text,
    Visible,
    ProfileId,
    Signed,
    Paid,
    SignedDate,
    PaidDate
  }

  /// <summary>
  /// List of document status for filtering records
  /// </summary>
  public enum DocumentStatus
  {
    Signed,
    Paid,
    Valid,
    Visible
  }
}
