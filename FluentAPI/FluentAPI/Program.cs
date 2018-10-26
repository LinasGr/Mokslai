using System;
using System.Collections.Generic;
using FluentAPI.Fluent;
using FluentAPI.Models;

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

      //Document doc = new Document();
      //doc.Visible = true;
      //doc.Text = "Text of document...";
      //doc.ExpirationDate = DateTime.Now + TimeSpan.FromDays(10);
      //doc.ValidationDate = DateTime.Now;
      //List<Document> lDoc=new List<Document>();
      //lDoc = Db.LoadDocuments();
      //Db.AddDocument(doc);
    }
  }
}