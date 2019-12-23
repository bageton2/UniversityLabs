using System;
using System.Collections.Generic;
using System.Text;

namespace Practice2_2
{
    class CustomArray
    {
        private int[] massiv;
        private int from;
        private int to;
        public CustomArray(int from, int to)
        {
            this.from = from;
            this.to = to;

            massiv = new int[to - from + 1];
        }

        public int this[int i]
        {
            get
            {
                if (i < from || i > to)
                {
                    throw new IndexOutOfRangeException();
                }
                return massiv[i - from];
            }
            set
            {
                if (i < from || i > to)
                {
                    throw new IndexOutOfRangeException();
                }

                massiv[i - from] = value;
            }
        }
    }
}
