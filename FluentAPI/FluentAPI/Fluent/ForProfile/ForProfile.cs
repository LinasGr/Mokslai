using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FluentAPI.Models;

namespace FluentAPI.Fluent.ForProfile
{
  class ForProfile : IForProfile
  {
    private Dictionary<Status, bool> Filter = new Dictionary<Status, bool>();

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
      //do query with these filters
      Filter.ToList().ForEach(x => Console.WriteLine(x.Key + " - " + x.Value));
      var sqlString = "SELECT * FROM Documents";
      if (Filter != null)
      {
        sqlString += " WHERE ";
        if (Filter.ContainsKey(Status.Visible))
        {
          if (Filter[Status.Visible]) sqlString += "Visible=1 ";
          else sqlString += "Visible=0 ";
        }
        sqlString += ";";
       }
      Db.LoadDocuments(sqlString).ForEach(x =>
      {
        Console.WriteLine(x.ToJson().ToString());
      });
    }

    private void TraceSwitch(Status key)
    {
      throw new NotImplementedException();
    }

    public IForProfile Not(Status status)
    {
      if (Filter.ContainsKey(status))
        Filter[status] = false;
      else
        Filter.Add(status, false);
      return this as IForProfile;
    }
  }
}
