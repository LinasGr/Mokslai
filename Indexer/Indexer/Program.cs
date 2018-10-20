using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Indexer
{

  class Program
  {
  
    static MyIndexerStruct<string> indexerStruct = new MyIndexerStruct<string>();
    static void Main(string[] args)
    {
      var indexerClass=new MyIndexerClass<string>();
      var times=100000;
      var watch=new Stopwatch();
      watch.Start();
      for (int i = 0; i < times; i++)
      {
        for (int j = 0; j < 100; j++)
        {
          indexerClass[j] = "" + i + " " + j;
        }
      }
      watch.Stop();
      Console.WriteLine("Indexer class executed {0}. Time took: {1} milliseconds.",times, watch.ElapsedMilliseconds);
      watch.Reset();
      watch.Start();
      for (int i = 0; i < times; i++)
      {
        for (int j = 0; j < 100; j++)
        {
          indexerStruct[j] = "" + i + " " + j;
        }
      }
      watch.Stop();
      Console.WriteLine("Indexer struct executed {0}. Time took: {1} milliseconds.", times, watch.ElapsedMilliseconds);
    }
  }
}
