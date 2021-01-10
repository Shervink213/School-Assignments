// name: Shervin Khosravi
// ID: 0667443
// Description: A program that helps the user balance their bank account by withdrawing, depositing, and printing your balance
using System;

namespace Assignment3
{
    public static class Assignment3
    {
        public static void Main()
        {
            // data dictionary
            // transType: the transaction type, either withdraw, deposit or print
            // balance: the balance of the bank account. amount: get the amount the user wants to deposit or withdraw
            char transType;
            double balance = 0, amount;
            do
            {
                //prompting the user to enter the transaction type
                Console.WriteLine("Please enter what type of transaction you want");
                Console.Write("(w or W for withdraw, d or D for deposit, p or P for print, q or Q for quit):  ");
                transType = Convert.ToChar(Console.ReadLine());


                //what the program to do when the user enters a valid transaction type
                if (transType == 'W' || transType == 'w' || transType == 'D' || transType == 'd' || transType == 'p' || transType == 'P')
                {
                    //switch case to what transaction type the user enters
                    switch (char.ToUpper(transType))
                    {
                        case 'W':
                            //invokes the program to get the amount withdrawed, then subtracting that from the account    
                            amount = GetAmount();
                            Withdrawal(amount,ref balance);
                            break;
                        case 'D':
                            //invokes the program to get the amount desposited, then adding that from the account
                            amount = GetAmount();
                            Deposit(amount, ref balance);
                            break;
                        case 'P':
                            //invokes the program to print the balance
                            Print(balance);
                            break;

                    }
                }
                //what the program does if the user enter an invalid transaction
                else if (char.ToUpper(transType) != 'W' && char.ToUpper(transType) != 'D' && char.ToUpper(transType) != 'P' && char.ToUpper(transType) != 'Q')
                {
                    Console.WriteLine("Sorry, that is an invalid trans action type");
                } 
            // to make sure the user enters a valid transaction type 
            } while (char.ToUpper(transType) != 'Q');
        }
        
        //description: to get the amount the user wants to deposit or withdraw
        public static double GetAmount()
        {
            double amount;
            do
            {
                // prompts the user to enter the amount
                Console.Write("Please enter amount:  ");
                amount = Convert.ToDouble(Console.ReadLine());
                
                //if the amount is less than or equal to 0, show an error message
                if (amount <= 0)
                {
                    Console.WriteLine("Sorry, you can't enter a zero or negative number ");
                }

            //make sure the amount is a positive number
            } while (amount < 0);

            // retuns the amount entered to be used in another method
            return amount;
        }
       


        //Description: compute the balance for a withdraw
        public static void Withdrawal(double amount, ref double balance)
        {

            // make the $1.50 service fee a constant
            const double fee = 1.50;

            //computes the balance when a withdraw happens
            balance = balance - (amount + fee);

            //if the balance is less than or equal to the service fee, show and error message and make sure the withdraw doesn't happen
            if (balance <= fee)
            {
                balance = balance + (amount + fee);
                Console.WriteLine("Sorry, you cannot withdraw enough to get a negative account");
            }
        }


        //Description: Compute the balance for a deposit
        public static void Deposit(double amount, ref double balance)
        {
            const double bonus = 0.01;

            //to check if the amount is less then or greater than 2000 to see if it can apply the 1% bonus
            if (amount >= 2000)
            {
                //computes the balance if the amount being deposited is greater than or equal to 2000
                balance = balance + (amount + (amount * bonus));
            }
            else if(amount < 2000)
            {
                //computes the balance if the amount being deposited is less than  2000
                balance = balance + amount;
            }
        }

        //Description: Method to print the balance
        public static void Print(double balance)
        {
           //prints the balance
            Console.WriteLine("Your balance is {0:C}", balance);
        }






    }
}
