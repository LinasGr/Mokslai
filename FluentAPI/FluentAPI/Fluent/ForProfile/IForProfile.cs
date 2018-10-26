namespace FluentAPI.Fluent.ForProfile
{
  interface IForProfile
  {
    void List();
    IForProfile Is(DocumentStatus status);
    IForProfile Not(DocumentStatus status);
    IForProfile OrderDecreaseColumn(DocumentColumns columns);
    IForProfile OrderIncreaseColumn(DocumentColumns columns);
  }
}
