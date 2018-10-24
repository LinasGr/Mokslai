namespace FluentAPI.Fluent.ForAssociation
{
  interface IForAssociation
  {
    void List();
    IForAssociation Is(Status status);
    IForAssociation Not(Status status);
  }
}
