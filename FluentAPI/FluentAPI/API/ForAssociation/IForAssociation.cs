using FluentAPI.Models;

namespace FluentAPI.API.ForAssociation
{
  interface IForAssociation
  {
    void List();
    IForAssociation Is(DocumentStatus status);
    IForAssociation Not(DocumentStatus status);
  }
}
