using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EPAMFirstTask
{
    class Serializer
    {
        public static Matrix GetMatrix(string path)
        {
            if (path != string.Empty)
            {
                try
                {
                    StreamReader sr = new StreamReader(path);
                    string line;
                    List<string> matrixLines = new List<string>();
                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();
                        if (line.Contains('[') && line.Contains(']'))
                        {
                            matrixLines.Add(line.Substring(line.IndexOf('[') + 1, line.IndexOf(']') - line.IndexOf('[') - 1).Replace(" ", ""));
                        }
                    }
                    sr.Close();

                    if (matrixLines.Count() > 0)
                    {
                        int y = matrixLines[0].Split(',').Count();
                        int x = matrixLines.Count();

                        Matrix matrix = new Matrix(x, y);

                        for (int i = 0; i < x; i++)
                        {
                            for (int j = 0; j < y; j++)
                            {
                                matrix[i, j] = Int32.Parse(matrixLines[i].Split(',')[j]);
                            }
                        }
                        return matrix;
                    }
                    else
                        return null;
                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine("file " + path + " not found" + e.Message + e.InnerException);
                    return null;
                }
            }
            else
            {
                throw new FileNotFoundException();
            }
        }

        public static void SaveMatrix(Matrix matrix, string path)
        {
            try
            {
                StringBuilder matrixString = new StringBuilder();
                matrixString.Append("\"matrix\" : [ \n");

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    string line = "\t[ ";
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        line += j == matrix.GetLength(1) - 1 ?
                            matrix[i, j].ToString() : (matrix[i, j].ToString() + ", ");
                    }
                    line += i == matrix.GetLength(0) - 1 ? "] \n" : "], \n";
                    matrixString.Append(line);
                }

                matrixString.Append("]");
                File.WriteAllText(path, matrixString.ToString());
            }
           
            catch(System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
