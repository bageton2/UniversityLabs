using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EPAMFirstTask
{
    class Matrix : IComparable
    {
        private int[,] matrix;

        public Matrix(int a, int b)
        {
            this.matrix = new int[a, b];
        }

        public int this[int i, int j]
        {
            get
            {
                if (i < matrix.GetLength(0) && i >= 0 &&
                    j < matrix.GetLength(1) && j >= 0)
                {
                    return matrix[i, j];
                }
                else throw new IndexOutOfRangeException();
            }
            set
            {
                if (i < matrix.GetLength(0) && i >= 0 &&
                   j < matrix.GetLength(1) && j >= 0)
                {
                    matrix[i, j] = value;
                }
                else throw new IndexOutOfRangeException();
            }
        }

        public int CompareTo(object o)
        {
            Matrix comparableMatrix = o as Matrix;

            if (comparableMatrix != null)
            {
                if (comparableMatrix.GetLength(0) < matrix.GetLength(0) ||
                     comparableMatrix.GetLength(1) < matrix.GetLength(1))
                {
                    return 1;
                }
                for (int i = 0; i < comparableMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < comparableMatrix.GetLength(1); j++)
                    {
                        try
                        {
                            if (comparableMatrix[i, j] < matrix[i, j])
                            {
                                return 1;
                            }
                        }
                        catch (Exception e)
                        {
                            return -1;
                        }

                    }
                }
                return 0;
            }
            else
            {
                throw new FormatException();
            }
        }

        #region Plus
        private static Matrix simpleAdd(Matrix matrix, int number)
        {
            Matrix newMatrix = new Matrix(matrix.GetLength(0), matrix.GetLength(1));

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    newMatrix[i, j] = matrix[i, j] + number;
                }
            }
            return newMatrix;
        }
        public static Matrix operator +(int number, Matrix matrix)
        {
            return simpleAdd(matrix, number);
        }
        public static Matrix operator +(Matrix matrix, int number)
        {
            return simpleAdd(matrix, number);
        }
        public static Matrix operator +(Matrix firstMatrix, Matrix secondMatrix)
        {
            if (firstMatrix.GetLength(0) == secondMatrix.GetLength(0) &&
                firstMatrix.GetLength(1) == secondMatrix.GetLength(1))
            {
                Matrix newMatrix = new Matrix(firstMatrix.GetLength(0), firstMatrix.GetLength(1));

                for (int i = 0; i < newMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < newMatrix.GetLength(1); j++)
                    {
                        newMatrix[i, j] = firstMatrix[i, j] + secondMatrix[i, j];
                    }
                }
                return newMatrix;
            }
            else
            {
                throw new Exception();
            }
        }
        #endregion

        #region Minus
        public static Matrix operator -(Matrix firstMatrix, Matrix secondMatrix)
        {
            if (firstMatrix.GetLength(0) == secondMatrix.GetLength(0) &&
                firstMatrix.GetLength(1) == secondMatrix.GetLength(1))
            {
                Matrix newMatrix = new Matrix(firstMatrix.GetLength(0), firstMatrix.GetLength(1));

                for (int i = 0; i < newMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < newMatrix.GetLength(1); j++)
                    {
                        newMatrix[i, j] = firstMatrix[i, j] - secondMatrix[i, j];
                    }
                }
                return newMatrix;
            }
            else
            {
                throw new Exception();
            }
        }
        public static Matrix operator -(int number, Matrix matrix)
        {
            return simpleAdd(matrix, number);
        }
        public static Matrix operator -(Matrix matrix, int number)
        {
            return simpleAdd(matrix, number);
        }
        #endregion

        #region Multiply
        private static Matrix simpleMultiply(Matrix matrix, int number)
        {
            Matrix newMatrix = new Matrix(matrix.GetLength(0), matrix.GetLength(1));

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    newMatrix[i, j] = matrix[i, j] * number;
                }
            }
            return newMatrix;
        }

        public static Matrix operator *(Matrix matrix, int number)
        {
            return simpleMultiply(matrix, number);
        }

        public static Matrix operator *(int number, Matrix matrix)
        {
            return simpleMultiply(matrix, number);
        }

        public static Matrix operator *(Matrix firstMatrix, Matrix secondMatrix)
        {
            if (firstMatrix.GetLength(1) == secondMatrix.GetLength(0))
            {
                Matrix newMatrix = new Matrix(firstMatrix.GetLength(0), secondMatrix.GetLength(1));

                for (int i = 0; i < newMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < newMatrix.GetLength(1); j++)
                    {
                        newMatrix[i, j] = GetMultiplyElement(firstMatrix, secondMatrix, i, j);
                    }
                }
                return newMatrix;
            }
            else
            {
                throw new Exception();
            }
        }

        private static int GetMultiplyElement(Matrix firstMatrix, Matrix secondMatrix, int i, int j)
        {
            int result = 0;
            for (int index = 0; index < firstMatrix.GetLength(1); index++)
            {
                result += firstMatrix[i, index] * secondMatrix[index, j];
            }
            return result;
        }

        #endregion

        public int GetLength(int vector)
        {
            return matrix.GetLength(vector);
        }
        public string GetMatrix()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    stringBuilder.Append(matrix[i, j]);
                }
                stringBuilder.AppendLine();
            }
            return stringBuilder.ToString();

        }

    }
}
