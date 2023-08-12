using System;
using System.Collections.Generic;
using System.Linq;

internal static class IEnumerableExtensions
{
   public static IEnumerable<TSource> Randomized<TSource>(this IEnumerable<TSource> source)
   {
      //https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
      var random = new Random();
      var randomized = source.ToList();
      for (int i = randomized.Count - 1; i > 0; i--)
      {
         var randomIndex = random.Next(i + 1);
         var temp = randomized[i];
         randomized[i] = randomized[randomIndex];
         randomized[randomIndex] = temp;
      }
      return randomized;
   }
}
