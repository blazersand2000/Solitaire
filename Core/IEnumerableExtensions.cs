using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
   internal static class IEnumerableExtensions
   {
      public static IEnumerable<TSource> Shuffled<TSource>(this IEnumerable<TSource> source)
      {
         var random = new Random();
         var shuffled = source.ToList();
         for (int i = shuffled.Count - 1; i > 0; i--)
         {
            var randomIndex = random.Next(i + 1);
            var temp = shuffled[i];
            shuffled[i] = shuffled[randomIndex];
            shuffled[randomIndex] = temp;
         }
         return shuffled;
      }
   }
}
