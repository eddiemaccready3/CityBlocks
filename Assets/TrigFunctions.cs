using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    public static class TrigFunctions
    {
        public static float PythagoreanTheorem(float a, float b)
        {
            float c = Mathf.Sqrt(Mathf.Pow(a, 2) + Mathf.Pow(b, 2));
            return c;
        }

        public static float FindDistance(float start, float end)
        {
            return Mathf.Abs(start - end);
        }
    }
}
