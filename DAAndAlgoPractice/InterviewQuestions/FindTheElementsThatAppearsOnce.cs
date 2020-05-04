using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAAndAlgoPractice.DALogic
{
    public class FindTheElementsThatAppearsOnce
    {
        public static void Processor()
        {
            //Find the element that appears once
            //Given an array where every element occurs three times, 
            // except one element which occurs only once. Find the element that occurs once. 
            // Expected time complexity is O(n) and O(1) extra space.


            int[] input1 = { 5, 5, 4, 8, 4, 5, 8, 9, 4, 8 };
            var result = GetSingleElement(input1);
        }

        private static int GetSingleElement(int[] input)
        {
            int x, result=0;
            int setBitArrayLenght = 32;
            int tempSum = 0;

            for(int i = 0; i < setBitArrayLenght; i++)
            {
                tempSum = 0;
                x = 1 << i; // set bit position to i(th) element.

                // now iterate through each and every element of input array
                for(int j = 0; j < input.Length; j++)
                {
                    // if set bit of this i(th) element is 0 then fine, otherwise we can consider it for the expected element 
                    if((input[j] & x) == 0)
                    {
                        tempSum = tempSum + 1;
                    }
                }

                // now check if sum if the multiple of 3 then we can ignore it otherwise it's the odd man out
                if ((tempSum % 3) == 0)
                {
                    result |= x;
                }
            }

            return result;
        }
    }
}
