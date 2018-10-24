namespace FluentAPI.Fluent.ForProfile
{
  interface IForProfile
  {
    void List();
    IForProfile Is(Status status);
    IForProfile Not(Status status);
  }
}
