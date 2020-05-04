using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAAndAlgoPractice
{
    //Write a program to calculate pow(x,n)
  public  class ModularExponent
    {
        public static void Processor()
        {
            var pow = PowerOfX(2, 3);

            pow = PowerOfX(2, 5);

            pow = PowerOfX(2, 10);
            pow = PowerOfX(2, 11);
        }

        private static int PowerOfX(int x, int y)
        {
            int tempPow = 0, squareOfTemp = 0;
            if (y == 0)
            {
                return 1;
            }
            else
            {
                tempPow = PowerOfX(x, y / 2);
                squareOfTemp = tempPow * tempPow;
                if ((y % 2) == 0)
                {
                    // if even
                    return squareOfTemp;
                }
                else
                {
                    return x * squareOfTemp;
                }
            }

        }
    }
}
