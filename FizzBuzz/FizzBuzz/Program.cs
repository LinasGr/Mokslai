using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz
{
  class Program
  {
    static void Main(string[] args)
    {
      FB();

    }

    static void FB()
    {
      for (int i = 0; i <=100; i++)
      {
        if(i%3==0) Console.Write("fizz");
        if(i%5==0) Console.Write("buzz");
        if(i%3!=0&&i%5!=0)Console.Write(i);
        Console.WriteLine();
      }
    }
  }
}
