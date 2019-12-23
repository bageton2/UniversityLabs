using System;
using System.Collections.Generic;

namespace EpamSecondTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Polynom polynom1 = new Polynom();

            polynom1["x0"] = 2;
            polynom1["x1"] = 2;
            polynom1["x2"] = 2;

            Polynom polynom2 = new Polynom();

            polynom2["x0"] = 1;
            polynom2["x1"] = 1;
            polynom2["x5"] = 5;

            var a = polynom1 + polynom2; //[x0, 3],[x1, 3][x2, 2][x5, 5]}
            var b = polynom1 - polynom2; //[x0, 1],[x1, 1][x2, 2][x5, -5]}
            var c = polynom1 * polynom2; //[x0, 2],[x1, 4][x2, 4][x3, 2][x5, 10][x6, 10][x7, 10]}
        }
    }
}
