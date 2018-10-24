using FluentAPI.Fluent;

namespace FluentAPI
{
  class Program
  {
    static void Main(string[] args)
    {
      new Documents()
        .ForProfile(1)
          .Is(Status.Signed)
          .Not(Status.Paid)
          .Is(Status.Valid)
          .Is(Status.Visible)
        .List();
      //new Documents()
      //  .ForAssociation(1)
      //    .Is(Status.Paid)
      //    .Not(Status.Valid)
      //  .List();
    }
  }
}