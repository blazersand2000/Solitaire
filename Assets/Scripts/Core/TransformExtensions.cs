using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Core
{
   internal static class TransformExtensions
   {
      public static IEnumerable<GameObject> GetChildren(this Transform transform)
      {
         foreach (Transform child in transform)
         {
            yield return child.gameObject;
         }
      }
   }
}
