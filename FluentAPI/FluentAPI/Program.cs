using System;
using FluentAPI.API;
using FluentAPI.Models;


namespace FluentAPI
{
  class Program
  {
    static void Main(string[] args)
    {
      //Testing Fluent Api SQLite querry to JSON
      var documents = new Documents();
      documents.Create(new Document(1,DateTime.Now, DateTime.Now+TimeSpan.FromDays(10),"Patobulinta eilute" ,true));
      documents.ForProfile(1).Create(2);
      documents.ForProfile(1)
        .Is(DocumentStatus.Visible)
        .Not(DocumentStatus.Valid)
        .OrderDESC(DocumentColumns.AssociationId)
      .Read();


    }
  }
}