using NUnit.Framework.Constraints;

namespace Matrix.Tests
{
    public class Size
    {
        private int height;
        private int width;

        public Size(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public int Width => width;
        public int Height => height;

 
        public bool IsSquare => width == height;

        public static bool operator ==(Size sizeA, Size sizeB)
        {
            return sizeA.height == sizeB.height && sizeA.width ==sizeB.width;
        }

        public static bool operator !=(Size sizeA, Size sizeB)
        {
            return sizeA.height != sizeB.height && sizeA.width != sizeB.width;
        }
        public override bool Equals(object obj)
        {
            return this == (Size)obj;
        }
    }
}