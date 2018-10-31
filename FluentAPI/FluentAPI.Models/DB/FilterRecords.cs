using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI.API.DB
{
  public class FilterRecords
  {
    //Variable for filtering records
    private Dictionary<Enum, bool> Filters = new Dictionary<Enum, bool>();

    //Variable for ordering records
    private Dictionary<Enum, bool> Orders = new Dictionary<Enum, bool>();

    //Variable for ID columns to select
    private Dictionary<string, int> WithID = new Dictionary<string, int>();

    //Variable for ID columns to discard
    private Dictionary<string, int> WithoutID = new Dictionary<string, int>();


    /// <summary>
    /// Filter out records without specific status
    /// </summary>
    /// <param name="status"></param>
    /// <returns></returns>
    public void IS(Enum status)
    {
      if (Filters.ContainsKey(status))
        Filters[status] = true;
      else
        Filters.Add(status, true);
    }


    /// <summary>
    /// Filter out records with specific status
    /// </summary>
    /// <param name="status"></param>
    /// <returns></returns>
    public void Not(Enum status)
    {
      if (Filters.ContainsKey(status))
        Filters[status] = false;
      else
        Filters.Add(status, false);
    }

    /// <summary>
    /// Adding ID to skip
    /// </summary>
    /// <param name="column"></param>
    /// <param name="id"></param>
    public void WithoutId(string column,int id)
    {
      if (WithoutID.ContainsKey(column)) WithoutID[column] = id;
      else WithoutID.Add(column,id);
    }

    /// <summary>
    /// Adding ID to select
    /// </summary>
    /// <param name="column"></param>
    /// <param name="id"></param>
    public void WithId(string column, int id)
    {
      if (WithID.ContainsKey(column)) WithID[column] = id;
      else WithID.Add(column, id);
    }

    /// <summary>
    /// Order records by increasing values in selected column
    /// Order can be applied multiple columns
    /// </summary>
    /// <param name="column"></param>
    public void OrderASC(Enum column)
    {
      if (Orders.ContainsKey(column)) Orders.Remove(column);
      Orders.Add(column, true);
    }


    /// <summary>
    /// Order records by decreasing values in selected column
    /// Order can be applied for multiple columns
    /// </summary>
    /// <param name="column"></param>
    /// <returns></returns>
    public void OrderDESC(Enum column)
    {
      if (Orders.ContainsKey(column)) Orders.Remove(column);
      Orders.Add(column, false);
    }

    /// <summary>
    /// Return string with documents query filters
    /// </summary>
    /// <returns></returns>
    public string GetFilterString()
    {
      string sqlString = " WHERE ";
      var noFilter = sqlString.Length;
      if (Filters != null)
      {
        foreach (var arr in Filters)
        {
          if (sqlString.Length > noFilter) sqlString += "AND ";
          if (arr.Value) sqlString += $"{arr.Key}=1";
          else sqlString += $"{arr.Key}=0";
        }
      }
      if (WithoutID != null)
      {
        foreach (var ID in WithoutID)
        {
          if (sqlString.Length > noFilter) sqlString += "AND ";
          sqlString += $"{ID.Key}<>{ID.Value}";
        }
      }
      if (WithID != null)
      {
        foreach (var ID in WithID)
        {
          if (sqlString.Length > noFilter) sqlString += "AND ";
          sqlString += $"{ID.Key}!={ID.Value}";
        }
      }
      return sqlString.Length > noFilter ? sqlString : "";
    }

    /// <summary>
    /// Return string with documents query order
    /// </summary>
    /// <returns></returns>
    public string GetOrderString()
    {
      var order = " ORDER BY ";
      var noOrder = order.Length;
      if (Orders != null)
      {
        foreach (var arr in Orders)
        {
          if (order.Length > noOrder) order += ", ";
          if (arr.Value) order += $"{arr.Key} ASC";
          else order += $"{arr.Key} DESC";
        }
      }
      return order.Length > noOrder ? order : "";
    }

  }
}
