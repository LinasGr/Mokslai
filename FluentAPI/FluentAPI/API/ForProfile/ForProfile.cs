using System;
using System.Collections.Generic;
using System.Linq;
using FluentAPI.Models;
using FluentAPI.Models.DB;
using FluentAPI.Models.Models;

namespace FluentAPI.API.ForProfile
{
  /// <summary>
  /// ForProfile class to format query, retrieve data and give it in various forms
  /// </summary>
  class ForProfile : IForProfile
  {
    private const int ID_FOR_ALL_PROFILES=0;
    private const string DEFAULT_TABLE_NAME = "Documents";

    //Variable for filtering records
    private Dictionary<DocumentStatus, bool> Filter = new Dictionary<DocumentStatus, bool>();

    //Variable for ordering records
    private Dictionary<DocumentColumns, bool> Order = new Dictionary<DocumentColumns, bool>();

    //Profile id records belong to
    private int ProfileId = ID_FOR_ALL_PROFILES;
    //Table name
    private string _table;


    /// <summary>
    /// Constructor with default value not related to any ProfileID
    /// </summary>
    /// <param name="id"></param>
    public ForProfile(int id = ID_FOR_ALL_PROFILES,string table=DEFAULT_TABLE_NAME)
    {
      ProfileId = id;
      _table = table;
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
      return this as ForProfile;
    }

    /// <summary>
    /// Creates new Document for Profile
    /// </summary>
    public void Create(int DocumentTemplateId)
    {
      if (ProfileId != ID_FOR_ALL_PROFILES)
      {
        //Reads template of document
        var sqlString = $"SELECT * FROM {_table} WHERE id={DocumentTemplateId};";
        var db = new SQLiteDB();
        var docs = db.Read<Document>(sqlString);
        //If template found
        if (docs.Count == 1)
        {
          docs[0].ProfileId = ProfileId;
          db.Create(_table,docs[0]);
        }
      }
    }

    /// <summary>
    /// Get documents with constructed query
    /// </summary>
    public void Read()
    {
      //do query with these filters
      Filter.ToList().ForEach(x => Console.WriteLine(x.Key + " - " + x.Value));
      var sqlString = "SELECT * FROM "+_table;
      sqlString += GetFilterString() + GetOrderString() + ";";

      new SQLiteDB().Read<Document>(sqlString)
        .ForEach(x => Console.WriteLine(x.ToJson()));

      //Db.LoadDocuments(sqlString).ForEach(x =>
      //{
      //  Console.WriteLine(x.ToJson().ToString());
      //});
    }

    /// <summary>
    /// Update particular document which belongs to profile
    /// </summary>
    public void Update()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Delete particular document which belongs to profile
    /// </summary>
    public void Delete()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Order documents by increasing values in selected column
    /// Order can be applied multiple columns
    /// </summary>
    /// <param name="column"></param>
    public IForProfile OrderASC(DocumentColumns column)
    {
      if (Order.ContainsKey(column)) Order.Remove(column);
      Order.Add(column, true);
      return this as ForProfile;
    }


    /// <summary>
    /// Order documents by decreasing values in selected column
    /// Order can be applied for multiple columns
    /// </summary>
    /// <param name="column"></param>
    /// <returns></returns>
    public IForProfile OrderDESC(DocumentColumns column)
    {
      if (Order.ContainsKey(column)) Order.Remove(column);
      Order.Add(column, false);
      return this as ForProfile;
    }

    /// <summary>
    /// Return string with documents query filters
    /// </summary>
    /// <returns></returns>
    private string GetFilterString()
    {
      string sqlString = " WHERE ";
      var noFilter = sqlString.Length;
      if (Filter != null)
      {
        foreach (var arr in Filter)
        {
          switch (arr.Key)
          {
            case DocumentStatus.Visible:
              if (sqlString.Length > noFilter) sqlString += "AND ";
              if (arr.Value) sqlString += "Visible=1 ";
              else sqlString += "Visible=0 ";
              break;
            case DocumentStatus.Paid:
              if (sqlString.Length > noFilter) sqlString += "AND ";
              if (arr.Value) sqlString += "Paid=1 ";
              else sqlString += "Paid=0 ";
              break;
            case DocumentStatus.Signed:
              if (sqlString.Length > noFilter) sqlString += "AND ";
              if (arr.Value) sqlString += "Signed=1 ";
              else sqlString += "Signed=0 ";
              break;
            case DocumentStatus.Valid:
              if (sqlString.Length > noFilter) sqlString += "AND ";
              if (arr.Value)
                sqlString += "date('now') BETWEEN ValidationDate AND ExpirationDate ";
              else
                sqlString += "date('now') NOT BETWEEN ValidationDate AND ExpirationDate ";
              break;
          }
        }
      }
      if (ProfileId > ID_FOR_ALL_PROFILES)
      {
        if (sqlString.Length > noFilter) sqlString += "AND ";
        sqlString += "ProfileId=" + ProfileId;
      }
      return sqlString.Length > noFilter ? sqlString : "";
    }

    /// <summary>
    /// Return string with documents query order
    /// </summary>
    /// <returns></returns>
    private string GetOrderString()
    {
      var order = " ORDER BY ";
      var noOrder = order.Length;
      if (Order != null)
      {
        foreach (var arr in Order)
        {
          switch (arr.Key)
          {
            case DocumentColumns.Id:
              if (order.Length > noOrder) order += ", ";
              if (arr.Value) order += "Id ASC";
              else order += "Id DESC";
              break;
            case DocumentColumns.AssociationId:
              if (order.Length > noOrder) order += ", ";
              if (arr.Value) order += "AssociationId ASC";
              else order += "AssociationId DESC";
              break;
            case DocumentColumns.ExpirationDate:
              if (order.Length > noOrder) order += ", ";
              if (arr.Value) order += "ExpirationDate ASC";
              else order += "ExpirationDate DESC";
              break;
            case DocumentColumns.Text:
              if (order.Length > noOrder) order += ", ";
              if (arr.Value) order += "Text ASC";
              else order += "Text DESC";
              break;
            case DocumentColumns.Visible:
              if (order.Length > noOrder) order += ", ";
              if (arr.Value) order += "Visible ASC";
              else order += "Visible DESC";
              break;
            case DocumentColumns.ProfileId:
              if (order.Length > noOrder) order += ", ";
              if (arr.Value) order += "ProfileId ASC";
              else order += "ProfileId DESC";
              break;
            case DocumentColumns.Paid:
              if (order.Length > noOrder) order += ", ";
              if (arr.Value) order += "Paid ASC";
              else order += "Paid DESC";
              break;
            case DocumentColumns.SignedDate:
              if (order.Length > noOrder) order += ", ";
              if (arr.Value) order += "SignedDate ASC";
              else order += "SignedDate DESC";
              break;
            case DocumentColumns.PaidDate:
              if (order.Length > noOrder) order += ", ";
              if (arr.Value) order += "PaidDate ASC";
              else order += "PaidDate DESC";
              break;
          }
        }
      }
      return order.Length > noOrder ? order : "";
    }
  }
}
