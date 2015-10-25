using System;
using System.Globalization;
using System.Text;

namespace Matrix.Tests
{
    public class CoolMatrix
    {
        private int[,] arr;
        public Size Size {
            get { return new Size(width, height);}
}
        public int width; // first param
        public int height; // second param

        public CoolMatrix(int[,] arr)
        {
            if (arr == null) throw new ArgumentNullException();
            this.arr = arr;
            width = arr.GetLength(0);
            height = arr.GetLength(1);
        }

        //public object Size { get; set; }
        
        public bool IsSquare => height == width;

        public static implicit operator CoolMatrix(int[,] myArr)
        {
            return new CoolMatrix(myArr);
        }

        public override string ToString()
        {
            return ReturnArrayString(arr);
        }

        private string ReturnArrayString(int[,] myArr)
        {
            string myStr = "";
            var builder = new StringBuilder();
            for (int i = 0; i < width; i++)
            {
                builder.Append("[");
                for (int j = 0; j < height; j++)
                {
                    //builder.AppendLine($"[{i}, {j}]");
                    builder.Append(arr[i,j].ToString());
                    if (j != height - 1) builder.Append(", ");
                }
                builder.Append("]");
                if (i != width - 1) builder.AppendLine();
            }
            return builder.ToString();
        }


        public int this[int i, int j] => arr[i, j];

        public static bool operator ==(CoolMatrix matrixA, CoolMatrix matrixB)
        {
            if (matrixA.width == matrixB.width && matrixA.height == matrixB.height)
            {
                for (int i = 0; i < matrixA.width; i++)
                {
                    for (int j = 0; j < matrixA.height; j++)
                    {
                       if (matrixA[i, j] != matrixB[i, j])  return false;
                    }
                }
                return true;
            }
            return false;
        }

        public static bool operator !=(CoolMatrix matrixA, CoolMatrix matrixB)
        {
            return !(matrixA == matrixB);
        }

        public static CoolMatrix operator *(CoolMatrix matrixA, int myVar)
        {
            for (int i = 0; i < matrixA.width; i++)
            {
                for (int j = 0; j < matrixA.height; j++)
                {
                    matrixA.arr[i, j] = matrixA[i, j] * myVar;
                }
            }
            return matrixA;
        }

        public override bool Equals(object obj)
        {
            return this == (CoolMatrix) obj;
        }

        public static CoolMatrix operator +(CoolMatrix matrixA, CoolMatrix matrixB)
        {
            if (matrixA.width == matrixB.width && matrixA.height == matrixB.height)
            {
                for (int i = 0; i < matrixA.width; i++)
                {
                    for (int j = 0; j < matrixA.height; j++)
                    {
                        matrixA.arr[i, j] = matrixA[i, j] + matrixB[i, j];
                    }
                }
            }
            else
            {
                throw new ArgumentException();
            }
            return matrixA;
        }


        public CoolMatrix Transpose(CoolMatrix matrixA)
        {
            int[, ] arrResult = new int[matrixA.height, matrixA.width ];
            for (int i = 0; i < matrixA.width; i++)
            {
                for (int j = 0; j < matrixA.height; j++)
                {
                    arrResult[j, i] = matrixA.arr[i, j];
                }
            }
            return arrResult;
        }

        public CoolMatrix Transpose()
        {
           return Transpose(arr);
        }


    }
}