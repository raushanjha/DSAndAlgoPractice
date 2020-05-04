using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAAndAlgoPractice
{
    public class TestClass
    {
        public static void HashSetTest()
        {
            HashSet<int> set = new HashSet<int>();

            int[] input = { 1, 2, 3, 3, 3, 4, 5 };

            for (int i = 0; i < input.Length; i++)
            {
                set.Add(input[i]);
            }

            // print all
            //for (int i = 0; i < input.Length; i++)
            foreach(var forSet in set)
            {
                Console.WriteLine($"{forSet} ");
            }
        }
    }
}
