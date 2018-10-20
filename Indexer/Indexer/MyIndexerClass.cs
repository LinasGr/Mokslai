using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexer
{

  class MyIndexerClass<T>
  {
    private T[] _arr = new T[100];

    public T this[int i]
    {
      get => _arr[i];
      set { _arr[i] = value; }
    }
  }
}

