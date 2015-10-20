using System;

namespace Matrix.Tests
{
    public class CoolMatrix
    {
        private int[,] arr;
        public int width; // first param
        public int height; // second param

        public CoolMatrix(int[,] arr)
        {
            if (arr == null) throw new ArgumentNullException();
            this.arr = arr;
            width = arr.GetLength(0);
            height = arr.GetLength(1);

        }

        public object Size { get; set; }
        public bool IsSquare => height == width;

        public static implicit operator CoolMatrix(int[,] myArr)
        {
            return new CoolMatrix(myArr);
        }
    }
}