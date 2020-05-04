using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAAndAlgoPractice
{
   public class LogicGates
    {
        public static void Processor()
        {
            // AND Gate
            // A   B = A & B
            // 0   0 = 0
            // 0   1 = 0
            // 1   0 = 0
            // 1   1 = 1

            int a = 3;
            int b = 4;

            Console.WriteLine(a & b);

            // OR Gate
            // A   B = A | B
            // 0   0 = 0
            // 0   1 = 1
            // 1   0 = 1
            // 1   1 = 1
            Console.WriteLine(a | b);

            // XOR Gate
            // A   B = A ^ B
            // 0   0 = 0
            // 0   1 = 1
            // 1   0 = 1
            // 1   1 = 0
            Console.WriteLine(a ^ b);
        }
    }
}
