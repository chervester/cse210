using System;

namespace Learning03
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test case 1: 1/1
            Fraction fraction1 = new Fraction(); // 1/1
            Console.WriteLine(fraction1.GetFractionString()); // Output: 1/1
            Console.WriteLine(fraction1.GetDecimalValue());   // Output: 1

            // Test case 2: 5/1
            Fraction fraction2 = new Fraction(5); // 5/1
            Console.WriteLine(fraction2.GetFractionString()); // Output: 5/1
            Console.WriteLine(fraction2.GetDecimalValue());   // Output: 5

            // Test case 3: 3/4
            Fraction fraction3 = new Fraction(3, 4); // 3/4
            Console.WriteLine(fraction3.GetFractionString()); // Output: 3/4
            Console.WriteLine(fraction3.GetDecimalValue());   // Output: 0.75

            // Test case 4: 1/3
            Fraction fraction4 = new Fraction(1, 3); // 1/3
            Console.WriteLine(fraction4.GetFractionString()); // Output: 1/3
            Console.WriteLine(fraction4.GetDecimalValue());   // Output: 0.3333333333333333

            // Pause the program to view output
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }
    }
}

