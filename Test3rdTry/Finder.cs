using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guy2TestRedirections
{
  /// <summary>
  /// this is where the learner's answers go. 
  /// </summary>
  public class Finder
  {
    /// <summary>
    /// Very simple function not requiring IO redirection.
    /// This is the user's answer #1
    /// These kinds of answers are expected to arrive later in the year.
    /// </summary>
    /// <param name="ar"></param>
    /// <returns></returns>
    public int FindMax(int[] ar)
    {
      int max = int.MinValue;
      foreach (var item in ar)
        if (item > max)
          max = item;
      return max;
    }

    /// <summary>
    /// An example of a function requiring IO redirection for testing.
    /// This is the user's answer #2
    /// In this example the user Reads, Writes, and returns a value.
    /// The UnitTest can interact with all of these...
    /// </summary>
    /// <returns></returns>
    public int FindMax2()
    {
      int max = int.MinValue;
      while (true)
      {
        int n = int.Parse(Console.ReadLine());
        if (n == 0) //simulate missing an exit condition.
          break;
        else if (n > max)
          max = n;
      }
      Console.WriteLine(max);
      return max;
    }


  }
}
