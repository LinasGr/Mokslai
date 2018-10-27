namespace FluentAPI.Fluent.ForProfile
{
  interface IForProfile
  {
    void List();
    IForProfile Is(DocumentStatus status);
    IForProfile Not(DocumentStatus status);
    IForProfile OrderDESCColumn(DocumentColumns columns);
    IForProfile OrderASCColumn(DocumentColumns columns);
  }
}
