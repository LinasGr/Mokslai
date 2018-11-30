using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityCodeFirst.Tools;

namespace EntityCodeFirst.Tools
{
  class Menu
  {
    private List<string> _items;
    private List<Action> _actions;
    private List<int> _indexes;

    private void init()
    {
      _items = new List<string>();
      _actions = new List<Action>();
      _indexes = new List<int>();
    }

    public Menu()
    {
      init();
    }

    public Menu(bool Populated)
    {
      init();
      if (Populated)
      {
        Add("Clear screen",Console.Clear);
        Add("Exit",null);
      }
    }

    public void Clear()
    {
      _items.Clear();
      _actions.Clear();
      _indexes.Clear();
    }

    public void Insert(string item, Action action)
    {
      _items.Insert(_items.Count - 1, item);
      _actions.Insert(_actions.Count - 1, action);
    }

    public void Add(string item,Action action)
    {
      _items.Add( item);
      _actions.Add(action);
    }
    public void Add(string item, int index)
    {
      _items.Add(item);
      _indexes.Add(index);
    }

    public void Act(int index)
    {
      _actions[index].Invoke();
    }

    public void PrintMenu()
    {
      Console.WriteLine("\n   MENU");
      for (var i = 0; i < _items.Count; i++)
      {
        Console.WriteLine($"[{i + 1}] - {_items[i]}.");
      }
    }

    private int GetSelectedMenuNumber(string text)
    {
      var result = WriteRead.WRL(text);
      int index;
      while (!int.TryParse(result,out index))
        result = WriteRead.WRL(text);
      return index;
    }

    public bool SelectAct()
    {
      PrintMenu();
      var index = GetSelectedMenuNumber("Select menu number: ");
      if (index > 0 && index <= _items.Count)
      {
        if (_actions[index-1] == null) return false;
        Act(index-1);
      }
      return true;
    }

    public string SelectMenuString()
    {
      PrintMenu();
      var index = GetSelectedMenuNumber("Select menu number: ");
      if (index > 0 && index <= _items.Count)
      {
        return _items[index - 1];
      }
      return "";
    }

    public int SelectMenuIndex()
    {
      PrintMenu();
      var index = GetSelectedMenuNumber("Select menu number: ");
      if (index > 0 && index <= _items.Count)
      {
        return _indexes[index - 1];
      }
      return -1;
    }

    public int Count()
    {
      return _items.Count();
    }
  }
}
