// COIS 2020 A1; Kai Brucker: 0664706. Connor Corso: 0671950. Shervin Khosravi: 0667443
using System;
using System.Collections.Generic;

namespace Task1
{
    /*public class Term : IComparable, ICloneable
    {
        //Most of this code was taken from Dr.Patrick's code

        //data member: coefficient of the term
        private double coefficient;
        //read and write propertise
        public double Coefficient
        {
            get { return coefficient; }
            set { coefficient = value; }
        }

        //data member: exponent of the term
        private int exponent;
        //read and write propertise
        public int Exponent
        {
            get { return exponent; }
            set { exponent = value; }
        }

        //Constructors
        //No parameters
        public Term()   //makes a default term wehere exponent=0 and coefficient = 0
        {
            Init(0, 0);
        }
        //one parameter
        public Term(double coeff)  //makes a term where exponent 0 and coefficient the value the user enters
        {
            Init(coeff, 0);
        }

        //two parameters
        public Term(double coeff, int expo)  //makes a term where the exponent and coefficient are whatever user does
        {
            Init(coeff, expo);
        }

        //Initializer used by the constructors
        private void Init(double coeff, int expo)
        {
            //makes sure the exponent is between 0 and 99
            if (expo >= 0 && expo <= 99)
            {
                Coefficient = coeff;
                Exponent = expo;
            }
            else
                throw new ArgumentException("Exponent is not in-between 0 and 99");
        }



        //evaluates the term at value x
        public double Evaluate(double x)
        {
            //gets the result of the term depending on what x is and returns it
            double result = (Math.Pow(x, (Convert.ToDouble(Exponent)))) * Coefficient;
            return result;
        }

        // Returns -1, 0, or 1 if the exponent of the current term
        // is less than, equal to, or greater than the exponent of obj
        public int CompareTo(Object obj)
        {
            //if the exponent is empty, it'll tell you
            if (obj == null) throw new ArgumentException("Object is null");

            //Converts obj to term type
            Term B = obj as Term;

            //compares the exponents and returns either -1, 0, or 1
            if (this.Exponent < B.Exponent)
            {
                return -1;
            }
            else if (this.Exponent == B.Exponent)
            {
                return 0;
            }
            else return 1;
        }

        //Override ToString
        public override string ToString()
        {
            //Writes out the terms in it's actual form
            return (this.Coefficient + "x^" + this.Exponent);
        }

        //used for task 3
        public Object Clone()
        {
            Term t = new Term(this.coefficient, this.exponent);
            return t;
        }
    }*/



}