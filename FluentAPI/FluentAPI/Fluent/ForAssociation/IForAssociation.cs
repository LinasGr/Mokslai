namespace FluentAPI.Fluent.ForAssociation
{
  interface IForAssociation
  {
    void List();
    IForAssociation Is(DocumentStatus status);
    IForAssociation Not(DocumentStatus status);
  }
}
