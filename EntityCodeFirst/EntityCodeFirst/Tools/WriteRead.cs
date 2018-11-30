using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCodeFirst.Tools
{
 static class WriteRead
  {
    /// <summary>
    /// WriteLine than ReadLine
    /// </summary>
    /// <param name="text"></param>
    /// <returns>
    /// Returns entered to console text line as String
    /// </returns>
    public static string WLRL(string text = "")
    {
      Console.WriteLine(text);
      return Console.ReadLine();
    }

    /// <summary>
    /// Write text than in same line ReadLine
    /// </summary>
    /// <param name="text"></param>
    /// <returns>
    /// Returns entered to console text line as String
    /// </returns>
    public static string WRL(string text)
    {
      Console.Write(text);
      return Console.ReadLine();
    }
  }
}
