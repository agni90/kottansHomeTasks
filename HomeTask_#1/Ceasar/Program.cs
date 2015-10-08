using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceasar
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    public class CeasarCipher
    {
        public CeasarCipher(int offset)
        {
            Offset = offset;
        }

        public int Offset { get; set;}
    
        public string Encrypt(string param)
        {
            if (param == null)
            {
                throw new ArgumentNullException();
            }
            if (param == new string(new[] { (char)127 }))
            {
                throw new ArgumentOutOfRangeException();
            }
            
            char[] myChar;
            int[] myInt = new int[param.Length];
            myChar = param.ToCharArray(0, param.Length);
            for (int i =0; i < myChar.Length; i++)
            {
                myInt[i] = (int) myChar[i];
            }
            for (int i = 0; i < myInt.Length; i++)
            {
                myInt[i] = PlusForChar(myInt[i], Offset);
            }
            for (int i = 0; i < myInt.Length; i++)
            {
                myChar[i] = (char) myInt[i];
            }
            string a = new string(myChar);

            return a;
        }

        public string Decrypt(string param)
        {
            if (param == new string(new[] { (char)127 }))
            {
                throw new ArgumentOutOfRangeException();
            }
            if (param == null)
            {
                throw new ArgumentNullException();
            }

            char[] myChar;
            int[] myInt = new int[param.Length];
            myChar = param.ToCharArray(0, param.Length);
            for (int i = 0; i < myChar.Length; i++)
            {
                myInt[i] = (int)myChar[i];
            }
            for (int i = 0; i < myInt.Length; i++)
            {
                myInt[i] = MinusForChar(myInt[i], Offset);
            }
            for (int i = 0; i < myInt.Length; i++)
            {
                myChar[i] = (char)myInt[i];
            }
            string a = new string(myChar);

            return a;
        }

        private int PlusForChar(int myChar, int offset)
        {
            for (int i = 0; i<offset; i++)
            {
                if (myChar == 126)
                {
                    myChar = 32;
                }
                else
                {
                    myChar++; 
                }
            }
            return myChar;
        }

        private int MinusForChar(int myChar, int offset)
        {
            for (int i = 0; i < offset; i++)
            {
                if (myChar == 32)
                {
                    myChar = 126;
                }
                else
                {
                    myChar--;
                }
            }
            return myChar;
            
        }


    }
}
