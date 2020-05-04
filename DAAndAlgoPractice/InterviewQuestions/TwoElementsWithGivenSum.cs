using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DAAndAlgoPractice.DALogic
{
    //The two sum problem is a common interview question, and it is a variation of the subset sum problem. 
    //There is a popular dynamic programming solution for the subset sum problem, but for the two sum problem we can actually write an algorithm that runs in O(n) time. 
    //The challenge is to find all the pairs of two integers in an unsorted array that sum up to a given S. 

    //For example, if the array is [3, 5, 2, -4, 8, 11] and the sum is 7, 
    //             your program should return [[11, -4], [2, 5]] because 11 + -4 = 7 and 2 + 5 = 7.

    public class TwoElementsWithGivenSum
    {

        public void Processor()
        {
            int[] inputArray = new int[] { 3, 5, 2, -4, 8, 11 };
            int expectedSum = 7;

            var returnValue = NaiveSolution(inputArray, expectedSum);
            var returnValueFaster = FasterSolution(inputArray, expectedSum);
        }

        // our two sum function which will return
        // all pairs in the array that sum up to S
        private IDictionary<int, int> NaiveSolution(int[] inputArray, int expectedSum)
        {
            IDictionary<int, int> returnValue = new Dictionary<int, int>();

            // check each element in array
            for (var i = 0; i < inputArray.Count(); i++)
            {
                // check each other element in the array
                for (var j = i + 1; j < inputArray.Count(); j++)
                {
                    // determine if these two elements sum to S
                    if (inputArray[i] + inputArray[j] == expectedSum)
                    {
                        //    sums.push([arr[i], arr[j]]);
                        returnValue.Add(inputArray[i], inputArray[j]);
                    }
                }
            }

            return returnValue;
        }

        // faster solution
        private IDictionary<int, int> FasterSolution(int[] inputArray, int expectedSum)
        {
            IDictionary<int, int> returnValue = new Dictionary<int, int>();
            var hashTable = new Hashtable();

            for (int i = 0; i < inputArray.Count(); i++)
            {
                var sumMinusElement = expectedSum - inputArray[i];

                if (hashTable.ContainsKey(sumMinusElement))
                {
                    returnValue.Add(inputArray[i], sumMinusElement);
                }

                //  add the running number to the array
                hashTable.Add(inputArray[i], inputArray[i]);
            }

            return returnValue;
        }
    }
}
