using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace KmToM
{
  class Program
  {
    static void Main(string[] args)
    {
      string kmStr;
      int km;
      do
      {
        Console.Write("Enter kilometers: ");
        kmStr = Console.ReadLine();
      } while (!int.TryParse(kmStr, out km));

      Console.WriteLine($"{km} kilometers is {km * 1000} meters.");
    }
  }
}
