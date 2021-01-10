//Shervin khosravi
//0667443
//Description: Runs all the math to determine the values for testfraction[0-4]
using System;

namespace FractionTest
{
    public class Fraction
    {
        //Decalare variables
        private int numerator;
        private int denominator;

        //Constructor 1: no parameters
        public Fraction()
        {
            //Numerator set to 0
            numerator = 0;
            //Denominator set to 1
            denominator = 1;
        }

        //Constructor 2: two paramters
        public Fraction(int num, int den)
        {
            //Tells the numerator that it must always be 0
            this.Numerator = num;
            //Tells the denominator that it must always be 1
            this.Denominator = den;
            //Reduces the fraction
            this.Reduce();
        }

        //Description: numerator property to make sure the numerator is greater than or equal to 0
        public int Numerator
        {
            //gets the entered numerator
            get
            {
                return numerator;
            }
            set
            {
                //if the value is less than 0, make the denominator 1 so the answer is will be 0
                if (value < 0)
                {
                    denominator = 1;
                }
                else
                {
                    numerator = value;
                }
                this.Reduce();
            }
        }

        //Description: Denominator property that makes sure the denominator is greater than 0
        public int Denominator
        {
            //gets the entered denominator
            get
            {
                return denominator;
            }
            set
            {
                //if the value is less than 0, make it 1
                if (value < 0)
                {
                    denominator = 1;
                }
                else
                {
                    denominator = value;
                }
                //reduce the denominator
                this.Reduce();
            }
        }

        //Description: Reduce method used to reduce the fraction into it's simpliest form
        private void Reduce()
        {
            //gcf: greatest common factor
            int gcf;

            //if the denominator is negative
            if (denominator < 0)
            {
                //takes the numerator and uses the absolute value of it
                numerator = Math.Abs(numerator);
                
                //takes the denominator and uses the absolute value of it 
                denominator = Math.Abs(numerator);
            }

            //Calls upon the method that finds the highest common factor
            gcf = GCF(numerator, denominator);
            
            //takes the numerator and divides it by the highest common factor to reduce it
            numerator = numerator / gcf;
            
            //takes the numerator and divides it by the highest common factor to reduce it
            denominator = denominator / gcf;
        }

        //Description: Returns a string that represents the fraction
        public override string ToString()
        {
            //retuns the fraction in a string format
            return String.Format("{0}/{1}", this.numerator, this.denominator);
        }

        //Description: Multiplies two fractions to make one fraction
        public static Fraction operator *(Fraction fract1, Fraction fract2)
        {
            //take the numerator of fraction1 and multiply it by the numerator of fraction2
            int numerator = fract1.Numerator * fract2.Numerator;
            
            //take the denominator of fraction1 and multiply it by the denominator of fraction2
            int denominator = fract1.Denominator * fract2.Denominator;
            
            //returns the new fraction
            return new Fraction(numerator, denominator);
        }

        // Add operator
        public static Fraction operator +(Fraction fract1, Fraction fract2)
        {
            //take the numerator of fraction1 and multiply it by the denominator of fraction2 then take
            //the denominator of fraction1 and multiply it ny the numerator of fraction2 then add
            int numerator = (fract1.Numerator * fract2.Denominator) + (fract1.Denominator * fract2.Numerator);
            
            //multiply the denominator of fraction1 by the denominator of fraction2
            int denominator = fract1.Denominator * fract2.Denominator;
            
            //return the new fraction
            return new Fraction(numerator, denominator);
        }

        // Description: compares two fraction and returns a true or false value if fraction1 is greater
        // than or equal to fraction2
        public static bool operator >=(Fraction fract1, Fraction fract2)
        {
            //Computes fraction1
            double fractionValue1 = (double)fract1.Numerator / (double)fract1.Denominator;
            
            //Computes fraction2
            double fractionValue2 = (double)fract2.Numerator / (double)fract2.Denominator;
            
            //returns either true or false if the value for fraction1 is greater than fraction2
            return fractionValue1 >= fractionValue2;
        }

        //Description: compares two fraction and returns a true or false value if fraction1 is less
        // than or equal to fraction2
        public static bool operator <=(Fraction fract1, Fraction fract2)
        {
            //computes fraction1
            double fractionValue1 = (double)fract1.Numerator / (double)fract1.Denominator;
            
            //computes fraction2
            double fractionValue2 = (double)fract2.Numerator / (double)fract2.Denominator;
            
            //returns either true or false if the value for fraction1 is less than fraction2
            return fractionValue1 <= fractionValue2;
        }


        // Description: Finds the greatest common factor to reduce the fractions
        private int GCF(int num, int den)
        {
            //Decalre variables
            int i, i2, gcf = 1;

            //if num1 is less than num2, then i2 equals num1
            if (num < den)
            {
                i2 = num;
            }
            //if num1 is greater than num2, then i2 equals num2
            else
            {
                i2 = den;
            }

            //for loop to get the remainder of the fractions and come up with the greatest common factor
            for (i = 1; i <= i2; i++)
            {
                //if the remainder of num1/i and num2/i is 0, make the highest common factor be i
                if (num % i == 0 && den % i == 0)
                {
                    gcf = i;
                }
            }
            return gcf;
        }
    }
}