using System;
using System.Collections.Generic;
using System.Linq;
using FluentAPI.Models;

namespace FluentAPI.Fluent.ForProfile
{
  class ForProfile : IForProfile
  {
    private Dictionary<Status,bool> Filter=new Dictionary<Status, bool>();
    public IForProfile Is(Status status)
    {
      if (Filter.ContainsKey(status))
        Filter[status] = true;
      else
        Filter.Add(status, true);
      return this as IForProfile;
    }

    public void List()
    {
      List<Document> documents=new List<Document>();
      //do query with these filters
      Filter.ToList().ForEach(x=>Console.WriteLine(x.Key+" - "+ x.Value));
    }

    public IForProfile Not(Status status)
    {
      if (Filter.ContainsKey(status))
        Filter[status] = false;
      else
        Filter.Add(status,false);
      return this as IForProfile;
    }
  }
}
