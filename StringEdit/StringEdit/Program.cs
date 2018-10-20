using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringEdit
{
  class Program
  {
    static void Main(string[] args)
    {
      var str = "I have a $ , but don't $ have $ internet.";
      var newStr = Regex.Replace(str, @"(\$[\s\w\,\']+)\$\s([\s\w\,\']+)\$\s", "$1$2");
      Console.WriteLine("from string: "+str);
      Console.WriteLine("to string: "+newStr);
    }
  }
}
