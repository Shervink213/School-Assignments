//Task 5
// COIS 2020 A1; Kai Brucker: 0664706. Connor Corso: 0671950. Shervin Khosravi: 0667443
using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;
using Task4;
using Task3;
using Task1;


/*namespace Task5
{
    class Task5
    {
        public static void Main(string[] args)
        {
            try
            {


                //Creates a new list, S, of Polynomials 
                Polynomials S = new Polynomials();

                //Data members
                double coef;
                int count = 0;

                //Data members for deciding what the program will do the make sure it's a number
                int pick;
                int exp;

                //Will continue the program until the user inputs "6"
                do
                {
                    //Detailing all the options the user has
                    Console.WriteLine("Welcome to the Polynomial program, please read all the options before entering an input");
                    Console.WriteLine("Here is the list of polynomials");
                    S.Print(); // prints the list so the user knows what is already in the list
                    Console.WriteLine("Press 1 if you would like to insert a polynomial into the list printed above");
                    Console.WriteLine("Press 2 if you would like to add two polynomials together and insert them into the list");
                    Console.WriteLine("Press 3 if you would like to multiply two polynomials together and insert it into the list");
                    Console.WriteLine("Press 4 if you would like to delete any polynomials from the list above");
                    Console.WriteLine("Press 5 if you would like to evaluate a polynomial from the list, provided that you enter x");
                    Console.WriteLine("Press 6 if you would like to close this console");
                    pick = Convert.ToInt32(Console.ReadLine());

                    //If the user tries to enter a letter instead of a number, it gets an error
                    if (pick < 1 || pick > 6)
                    {
                        Console.WriteLine("Sorry, you must pick an option between 1 and 6");
                        Console.WriteLine("");
                    }


                    //If the  user picks the 1st option, it does this
                    if (pick == 1)
                    {

                        //creates a new list to keep track of what the user has entered
                        Polynomial b = new Polynomial();

                        int hMany;
                        int i = 0;

                        //asks the user how many terms they want to enter
                        Console.WriteLine("How many terms do you want to add to?");
                        hMany = Convert.ToInt32(Console.ReadLine());

                        //Asks the user what they want the coefficient and exponent to be until i reaches hMany
                        while (i < hMany)
                        {
                            Console.WriteLine("Please enter the coefficient");
                            coef = Convert.ToDouble(Console.ReadLine());

                            Console.WriteLine("Please enther the exponent");
                            exp = Convert.ToInt32(Console.ReadLine());

                            //takes the coefficient and exponents, adds them to the term
                            Term t = new Term(coef, exp);
                            b.AddTerm(t);

                            i++;
                            count++;
                        }
                        //Inserts the newly added polynomials into S
                        S.Insert(b);

                    }
                    //Tells the program what to do if the user enters 2
                    else if (pick == 2)
                    {
                        //Checks to see if there are any polynomials to add together in the first place
                        if (count < 2)
                        {
                            Console.WriteLine("There are no polynomials in the list");
                            Console.WriteLine("");
                        }
                        //Asks the user which polynomails he wants to use, then it adds them together and inserts it in to the list
                        else
                        {
                            Console.WriteLine("Here is the list of Polynomials");
                            S.Print();

                            int Ret1, Ret2;


                            Console.WriteLine("Please enter the index of the first polynomial you would like to use ");
                            Ret1 = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Please enter the index of the second polynomial you would like to use");
                            Ret2 = Convert.ToInt32(Console.ReadLine());


                            Polynomial answer = S.Retrieve(Ret1) + S.Retrieve(Ret2);


                            Console.WriteLine("Your new polynomial is:");
                            answer.Print();
                            Console.WriteLine("");


                            S.Insert(answer);
                        }


                    }
                    //Tells the program what to do if the user wants to multiply
                    else if (pick == 3)
                    {
                        //Checks to see if there are polynomials to multiply together 
                        if (count < 2)
                        {
                            Console.WriteLine("There are no polynomials in the list");
                            Console.WriteLine("");
                        }
                        //Asks the user for which polynomials it wants to multiply together and then inserts it
                        else
                        {
                            Console.WriteLine("Here is the list of Polynomials");
                            S.Print();

                            int Mul1, Mul2;

                            Console.WriteLine("Please enter the index of the first polynomial you would like to use ");
                            Mul1 = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Please enter the index of the second polynomial you would like to use");
                            Mul2 = Convert.ToInt32(Console.ReadLine());


                            //inserts the newly multiplied together polynomial 
                            Polynomial result = S.Retrieve(Mul1) * S.Retrieve(Mul2);
                            Console.WriteLine("Your new polynomial is:");
                            result.Print();
                            Console.WriteLine("");
                            S.Insert(result);

                        }
                    }
                    //Tells the program what to do if the user wants to delete polynomials 
                    else if (pick == 4)
                    {
                        //checks to see there are any polynomials to add together
                        if (count == 0)
                        {
                            Console.WriteLine("There are no polynomials in the list");
                            Console.WriteLine("");
                        }
                        //Asks the user which polynomial they want to delete and then deletes it  
                        else
                        {
                            int del;

                            Console.WriteLine("Here is the list of Polynomials");
                            S.Print();

                            Console.WriteLine("Please enter the index of the polynomial you would like to delete");
                            del = Convert.ToInt32(Console.ReadLine());

                            S.Delete(del);

                            Console.WriteLine("Deleted");
                            Console.WriteLine("");
                        }
                    }
                    //Tells the program what to do if the user wants to evaluate a term
                    else if (pick == 5)
                    {
                        //Checks to see if there are any polynomials to evaluate
                        if (count == 0)
                        {
                            Console.WriteLine("There are no polynomials in the list");
                            Console.WriteLine();
                        }
                        //Asks the user which polynomial they want to evaluate, what value for x and then answers them
                        else
                        {
                            int Ret;
                            double x;

                            Console.WriteLine("Please enter the index of the polynomial you would like to evaluate");
                            Ret = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Please enter the x value you would like to use");
                            x = Convert.ToInt32(Console.ReadLine());

                            double answer;
                            answer = S.Retrieve(Ret).Evaluate(x);

                            Console.WriteLine("Your answer is:");
                            Console.WriteLine(answer);
                            Console.WriteLine("");

                        }
                    }
                } while (pick != 6);
            }
            catch (ArgumentException e) { Console.WriteLine(e.Message); }
        }
    }
}*/