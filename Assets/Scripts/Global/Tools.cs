using System.Collections;
using System.Collections.Generic;

namespace sennof
{
    public static class Tools
    {
        public static List<T> Shuffle<T>(List<T> list)
        {
            System.Random rnd = new();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }

            return list;
        }
    }
}

