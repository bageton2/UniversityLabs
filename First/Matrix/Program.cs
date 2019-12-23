using System;
using System.IO;
using System.Runtime.Serialization.Json;

namespace EPAMFirstTask
{
    class Program
    {
        static void Main(string[] args)
        {

            Matrix matrix1 = new Matrix(1,2);
            matrix1[0, 0] = 2;
            matrix1[0, 1] = 3;
            Matrix matrix12 = new Matrix(1, 2);
            matrix12[0, 0] = 3;
            matrix12[0, 1] = 2;

            Matrix matrix2 = Serializer.GetMatrix(@"C:\Users\Anton Hunko\Desktop\matrix.txt");

            var a = matrix1 + matrix12; // 5 5
            var b = matrix1 - matrix12; // -1 1
            var c = matrix1 * matrix2; // 33 9

            Console.WriteLine(c.GetMatrix()); 

            Serializer.SaveMatrix(c, @"C:\Users\Anton Hunko\Desktop\matrix2.txt");
        }
    }
}
