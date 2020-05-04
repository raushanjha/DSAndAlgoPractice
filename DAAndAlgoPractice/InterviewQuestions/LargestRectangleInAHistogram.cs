using System;
using System.Collections.Generic;

namespace DAAndAlgoPractice.DALogic
{
    //https://www.youtube.com/watch?v=VNbkzsnllsU

    public class LargestRectangleInAHistogram
    {

        public static void Processor()
        {
            int[] input = { 1, 2, 3, 4, 5, 3, 3, 2 };
            var maxArea = LargestSum(input);

            int[] input2 = { 1, 3, 2, 1, 2 };
            maxArea = LargestSum(input2);

            int[] input3 = { 9 };
            maxArea = LargestSum(input3);


            int[] input4 = { 9, 0, 1 };
            maxArea = LargestSum(input4);
        }

        private static int LargestSum(int[] input)
        {
            int maxArea = 0;
            Stack<int> positions = new Stack<int>();
            Stack<int> heights = new Stack<int>();
            int tempPos = 0, tempHeight = 0, tempSize = 0;

            void PopTheElement(int pos)
            {
                tempHeight = heights.Pop();
                tempPos = positions.Pop();

                int multiplier = 1;
                if( pos != tempPos) { multiplier = pos - tempPos; }
                tempSize = tempHeight * multiplier; // (pos - tempPos);
                maxArea = Math.Max(tempSize, maxArea);
            }


            for (int pos=0; pos < input.Length; pos++)
            {
                var currentHeight = input[pos];
                //
                // if current element's height is greater then push it to the Stack (means we're going to get another rectangle of new height)
                if (heights.Count == 0 || (currentHeight > heights.Peek()))
                {
                    heights.Push(input[pos]);
                    positions.Push(pos);
                    continue;
                }

                // if stack are not empty then. 
                if (currentHeight < heights.Peek())
                {
                    // Keeping removing the elements from the Stack (height, position) 
                    // unless it's top element's height is less than or equal to current element's height 
                    while (heights.Count > 0 && currentHeight < heights.Peek())
                    {
                        PopTheElement(pos);
                    }

                    // let's push the last element
                    heights.Push(input[pos]);
                    positions.Push(tempPos);
                }

                //Ok, now we have some elements in stacks. 
            }

            // we iterated through all the elements of the array, let's check the stacks
            // we've already covered all the elements of the stack so rectangle's width's (right-most point) is always Lenth of array
            while(heights.Count > 0)
            {
                PopTheElement(input.Length -1);
            }

            return maxArea;


        }
    }
}
