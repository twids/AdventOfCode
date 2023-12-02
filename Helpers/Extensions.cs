using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace AdventOfCode;
public static class Extensions {
    public static string ToOutput<T,V>(this Dictionary<T,V> dict) => string.Join(", ", dict.Select(kvp => kvp.Key + ": " + kvp.Value.ToString()));
  
}