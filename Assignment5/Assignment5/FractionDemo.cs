//Shervin Khosravi
//0667443
//Description: Program that computes fractions, adds them toegther, multiplies them together, and determines if they are greater or less than 1/2
using System;
using static System.Console;
using static System.FormattableString;

namespace FractionTest
{
    static class FractionDemo
    {
        static void Main(string[] args)

        {
            //Decalre the variables
            //input: what the user enters for numerator or denominator
            int numerator = 0;
            int denominator = 1;
            string input;

            //make the 5 fraction array
            Fraction[] testFractions = new Fraction[5];

            //First fraction with a numerator if 1 and a denominator of 2
            testFractions[0] = new Fraction(1, 2);

            //Second Fraction: prompts the user to enter the variables
            testFractions[1] = new Fraction();

            //prompts the user to enter the numerator
            Console.Write("Enter the numerator: ");
            input = Console.ReadLine();

            //make sure the input is a valid integer
            while (!int.TryParse(input, out numerator))
            {
                Console.WriteLine("Please enter a valid number");
                input = Console.ReadLine();
            }


            Console.Write("Enter the denominator: ");
            //make sure that the denominator is not 0
            do
            {
                input = Console.ReadLine();
                //make sure the input is a valid integer
                while (!int.TryParse(input, out denominator))
                {
                    Console.WriteLine("Please enter a valid numerator");
                    input = Console.ReadLine();
                }
                //inform user if denominator is 0 and ask to re enter
                if (denominator == 0)
                {
                    Console.WriteLine("Please enter a denominator thats greater than 0");
                }

            } while (denominator == 0);

            //Take the user's values and make the numerator and denominator
            testFractions[1].Numerator = numerator;
            testFractions[1].Denominator = denominator;



            //Outputs fraction0 and fraction1
            Console.WriteLine("testFractions[0] is {0}", testFractions[0]);
            Console.WriteLine("testFractions[1] is {0}", testFractions[1]);

            //Creates testFractions[2] by adding testfraction0 and testfraction1
            testFractions[2] = testFractions[0] + testFractions[1];

            //Creates testFractions[3] by multiplying testfraction0 and testfraction1
            testFractions[3] = testFractions[0] * testFractions[1];

            //Creates testFractions[4] by adding testfraction2 and 3 and multplies it by testfraction0
            testFractions[4] = (testFractions[2] + testFractions[3]) * testFractions[0];



            //outputs the fractions
            Console.WriteLine("testFractions[2] is {0}", testFractions[2]);
            Console.WriteLine("testFractions[3] is {0}", testFractions[3]);
            Console.WriteLine("testFractions[4] is {0}", testFractions[4]);

            Console.WriteLine($"{testFractions[0]} >= {testFractions[1]} is {testFractions[0] >= testFractions[1]}");
            Console.WriteLine($"{testFractions[0]} <= {testFractions[1]} is {testFractions[0] <= testFractions[1]}");

            Console.ReadLine();
        }
    }
}