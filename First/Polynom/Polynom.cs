using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EpamSecondTask
{
    class Polynom : IEnumerable, ICloneable
    {
        private int Length;

        private Dictionary<string, int> polynom;

        public Polynom()
        {
            polynom = new Dictionary<string, int>();
        }

        public int this[string key]
        {
            get
            {
                try
                {
                    return polynom[key];
                }
                catch (System.Collections.Generic.KeyNotFoundException e)
                {
                    Console.WriteLine(e.Message + "But we set 0 in that place");
                }
                return 0;
            }
            set
            {
                polynom[key] = value;
                Length = polynom.Count;
            }
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var val in polynom)
            {
                yield return val;
            }
        }
        public object Clone()
        {
            Polynom newPoly = new Polynom();
            foreach (KeyValuePair<string, int> pair in this)
            {
                newPoly.Add(pair.Key, pair.Value);
            }
            return newPoly;
        }

        public Dictionary<string, int>.ValueCollection Values()
        {
            return polynom.Values;
        }

        public Dictionary<string, int>.KeyCollection Keys()
        {
            return polynom.Keys;
        }

        public void Add(string key, int value)
        {
            polynom.Add(key, value);
        }

        public static Polynom operator +(Polynom a, Polynom b)
        {
            var smaller = (Polynom)(a.Length >= b.Length ? b : a).Clone();
            var bigger = (Polynom)(a.Length < b.Length ? b : a).Clone();

            foreach (KeyValuePair<string, int> pair in smaller)
            {
                bigger[pair.Key] += pair.Value;
            }
            return bigger;
        }
        public static Polynom operator -(Polynom a, Polynom b)
        {
            var first = (Polynom)a.Clone();
            var second = (Polynom)b.Clone();

            foreach (KeyValuePair<string, int> pair in second)
            {
                first[pair.Key] -= pair.Value;
            }
            return first;
        }
        public static Polynom operator *(Polynom a, Polynom b)
        {
            var firstPolynom = (Polynom)a.Clone();
            var secondPolynom = (Polynom)b.Clone();

            List<Polynom> polynomsToAdd = new List<Polynom>();

            foreach (KeyValuePair<string, int> pairFirst in firstPolynom)
            {
                Polynom poly = new Polynom();
                foreach (KeyValuePair<string, int> pairSecond in secondPolynom)
                {
                    int value = pairFirst.Value * pairSecond.Value;
                    string key = pairSecond.Key[0] + (Int32.Parse(pairSecond.Key.Remove(0, 1)) + Int32.Parse(pairFirst.Key.Remove(0, 1))).ToString();
                    poly[key] = value;
                }
                polynomsToAdd.Add(poly);
            }

            Polynom result = new Polynom();
            foreach (Polynom polynom in polynomsToAdd)
            {
                result += polynom;
            }

            return result;
        }

    }
}
