namespace DAAndAlgoPractice.Array
{
    // REF: https://www.youtube.com/watch?v=bgx1eAgBgaQ
    public class ZigZagArray
    {

        public static void Processor()
        {
            int[] inputArray =  {3,4,6,2,1,8,9 };

            var output = NaivSolution(inputArray);
        }

        private static int[] NaivSolution(int[] input)
        {
            int i = 0, n = input.Length;
            bool flag = false; // 0=> False || 1=> True

            while (i < n - 1) // last element will be as it is
            {
                if (flag)
                {
                    // EVEN: check if input[i] < input[i+1]
                    if (input[i] < input[i + 1])
                    {
                        // swap the elements
                        input[i] = input[i + 1] + input[i];
                        input[i + 1] = input[i] - input[i + 1];
                        input[i] = input[i] - input[i + 1];
                    }
                }
                else
                {
                    // ODD: check if input[i] < input[i+1]
                    if (input[i] >= input[i + 1])
                    {
                        // swap the elements
                        input[i] = input[i + 1] + input[i];
                        input[i + 1] = input[i] - input[i + 1];
                        input[i] = input[i] - input[i + 1];
                    }
                }

                // Ok now increment i and flip the flag
                flag = !flag;
                i++;
            }

            return input;
        }
    }
}
