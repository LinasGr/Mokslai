using System;
using System.Collections.Generic;
using System.Linq;
using FluentAPI.Models;

namespace FluentAPI.Fluent.ForProfile
{
  /// <summary>
  /// ForProfile class to format query, retrieve data and give it in various forms
  /// </summary>
  class ForProfile : IForProfile
  {
    //Variable for filtering records
    private Dictionary<DocumentStatus, bool> Filter = new Dictionary<DocumentStatus, bool>();

    //Variable for ordering records
    private Dictionary<DocumentColumns, bool> Order = new Dictionary<DocumentColumns, bool>();

    //Profile id records belong to
    //If ProfileId=0 no filtering acoirding ProfileId done
    private int ProfileId = 0;


    /// <summary>
    /// Constructor with default value not related to any ProfileID
    /// </summary>
    /// <param name="id"></param>
    public ForProfile(int id = 0)
    {
      ProfileId = id;
    }

    /// <summary>
    /// Filter out documents without specific status
    /// </summary>
    /// <param name="status"></param>
    /// <returns></returns>
    public IForProfile Is(DocumentStatus status)
    {
      if (Filter.ContainsKey(status))
        Filter[status] = true;
      else
        Filter.Add(status, true);
      return this as IForProfile;
    }

    /// <summary>
    /// Filter out Documents with specific status
    /// </summary>
    /// <param name="status"></param>
    /// <returns></returns>
    public IForProfile Not(DocumentStatus status)
    {
      if (Filter.ContainsKey(status))
        Filter[status] = false;
      else
        Filter.Add(status, false);
      return this as IForProfile;
    }

    /// <summary>
    /// Get documents by formatted query
    /// </summary>
    public void List()
    {
      //do query with these filters
      Filter.ToList().ForEach(x => Console.WriteLine(x.Key + " - " + x.Value));
      var sqlString = "SELECT * FROM Documents";
      sqlString += GetFilterString() + GetOrderString() + ";";
      Db.LoadDocuments(sqlString).ForEach(x =>
      {
        Console.WriteLine(x.ToJson().ToString());
      });
    }

    /// <summary>
    /// Return string with documents query filters
    /// </summary>
    /// <returns></returns>
    private string GetFilterString()
    {
      string sqlString = " WHERE ";
      if (Filter != null)
      {
        foreach (var arr in Filter)
        {
          switch (arr.Key)
          {
            case DocumentStatus.Visible:
              if (sqlString.Length > 7) sqlString += "AND ";
              if (arr.Value) sqlString += "Visible=1 ";
              else sqlString += "Visible=0 ";
              break;
            case DocumentStatus.Paid:
              if (sqlString.Length > 7) sqlString += "AND ";
              if (arr.Value) sqlString += "Paid=1 ";
              else sqlString += "Paid=0 ";
              break;
            case DocumentStatus.Signed:
              if (sqlString.Length > 7) sqlString += "AND ";
              if (arr.Value) sqlString += "Signed=1 ";
              else sqlString += "Signed=0 ";
              break;
            case DocumentStatus.Valid:
              if (sqlString.Length > 7) sqlString += "AND ";
              if (arr.Value)
                sqlString += "ValidationDate<=" + DateTime.Now + " ExpirationDate>=" + DateTime.Now + " ";
              else
                sqlString += "ValidationDate>" + DateTime.Now + " ExpirationDate<" + DateTime.Now + " ";
              break;
          }
        }
      }
      if (ProfileId > 0)
      {
        if (sqlString.Length > 7) sqlString += "AND ";
        sqlString += "ProfileId=" + ProfileId;
      }
      return sqlString.Length > 7 ? sqlString : "";
    }

    /// <summary>
    /// Return string with documents query order
    /// </summary>
    /// <returns></returns>
    private string GetOrderString()
    {
      var order = " ORDER BY ";
      if (Order != null)
      {
        foreach (var arr in Order)
        {
          switch (arr.Key)
          {
            case DocumentColumns.Id:
              if (order.Length > 10) order += ", ";
              if (arr.Value) order += "Id ASC";
              else order += "Id DESC";
              break;
            case DocumentColumns.AssociationId:
              if (order.Length > 10) order += ", ";
              if (arr.Value) order += "AssociationId ASC";
              else order += "AssociationId DESC";
              break;
            case DocumentColumns.ExpirationDate:
              if (order.Length > 10) order += ", ";
              if (arr.Value) order += "ExpirationDate ASC";
              else order += "ExpirationDate DESC";
              break;
            case DocumentColumns.Text:
              if (order.Length > 10) order += ", ";
              if (arr.Value) order += "Text ASC";
              else order += "Text DESC";
              break;
            case DocumentColumns.Visible:
              if (order.Length > 10) order += ", ";
              if (arr.Value) order += "Visible ASC";
              else order += "Visible DESC";
              break;
            case DocumentColumns.ProfileId:
              if (order.Length > 10) order += ", ";
              if (arr.Value) order += "ProfileId ASC";
              else order += "ProfileId DESC";
              break;
            case DocumentColumns.Paid:
              if (order.Length > 10) order += ", ";
              if (arr.Value) order += "Paid ASC";
              else order += "Paid DESC";
              break;
            case DocumentColumns.SignedDate:
              if (order.Length > 10) order += ", ";
              if (arr.Value) order += "SignedDate ASC";
              else order += "SignedDate DESC";
              break;
            case DocumentColumns.PaidDate:
              if (order.Length > 10) order += ", ";
              if (arr.Value) order += "PaidDate ASC";
              else order += "PaidDate DESC";
              break;
          }
        }
      }
      return order.Length > 10 ? order : "";
    }

    /// <summary>
    /// Order documents by increasing values in selected column
    /// Order can be applied multiple columns
    /// </summary>
    /// <param name="column"></param>
    public IForProfile OrderIncreaseColumn(DocumentColumns column)
    {
      if (Order.ContainsKey(column)) Order.Remove(column);
      Order.Add(column, true);
      return this as IForProfile;
    }


    /// <summary>
    /// Order documents by decreasing values in selected column
    /// Order can be applied for multiple columns
    /// </summary>
    /// <param name="column"></param>
    /// <returns></returns>
    public IForProfile OrderDecreaseColumn(DocumentColumns column)
    {
      if (Order.ContainsKey(column)) Order.Remove(column);
      Order.Add(column, false);
      return this as IForProfile;
    }

  }
}
