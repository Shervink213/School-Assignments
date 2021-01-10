// Name: Shervin Khosravi
// Student number: 0667443
// Description: A program that takes salaries of univeristy, college, and high school graduates and displays the average salary for the respective education

using System;
public static class Assingment2
{
    public static void Main()
    {
        //stating all variables 
        //numUni = number of university graduates, numCol = numUni = number of college graduates, numHigh = numUni = number of high school graduates
        // salaryData = the salary that was inputted by the user, uData = salary of university graduates inputted by the user
        // cData = salary of college graduates inputted by the user, hData = salary of high school graduates inputted by the user
        // uniAvg = average salary of university graduates gathered by the users, colAvg = average salary of university college gathered by the users
        //highAvg = average salary of high school graduates gathered by the users, edType: type of education inputted by the user
        int numUni = 0, numCol = 0, numHigh = 0;
        double salaryData = 0, uData = 0, cData = 0, hData = 0, uniAvg = 0, colAvg = 0, highAvg =0;
        char edType;

        do
        {
            //prompt the user to enter their education tyepe
            Console.WriteLine("Please enter education type (U or u for university, C or c for college, H or h for high school, Q or q to end): ");
            edType = Convert.ToChar(Console.ReadLine());

            //tells the program what to do if the user entered U,C,H,u,c, or h
            if (edType == 'U' || edType == 'u' || edType == 'C' || edType == 'c' || edType == 'H' || edType == 'h')
            {
                do
                {
                    //prompt the user to enter their salary
                    Console.WriteLine("Please enter your salary (>0): ");
                    salaryData = Convert.ToDouble(Console.ReadLine());

                    //tells the program what to say if the user enters a number less then 0 for their salary
                    if (salaryData < 0)
                    {
                        Console.WriteLine("Sorry, that is an invalid number. Try again");
                    }

                } while (salaryData < 0);
                
                //Calculations to determine the average univeristy graduate's salary if the user entered U or u for education type
                if (char.ToUpper(edType) == 'U')
                {
                    uData += salaryData;
                    numUni++;
                    uniAvg = uData / (double)numUni;

                }
                //Calculations to determine the average college graduate's salary if the user entered C or c for education type
                else if (char.ToUpper(edType) == 'C')
                {
                    cData += salaryData;
                    numCol++;
                    colAvg = cData / (double)numCol;

                }
                //Calculations to determine the average high school graduate's salary if the user entered H or h for education type
                else if (char.ToUpper(edType) == 'H')
                {
                    hData += salaryData;
                    numHigh++;
                    highAvg = hData / (double)numHigh;

                }

            }
            //tells the program what to say if the user enters an invalid education type
            else if (char.ToUpper(edType) != 'U' && char.ToUpper(edType) != 'C' && char.ToUpper(edType) != 'C' && char.ToUpper(edType) != 'Q')
            {
                Console.WriteLine("Sorry, that is an invalid education type. Please try again");

            }
        //displays the output when the user enters Q or q when they want to the program to end
        } while (char.ToUpper(edType) != 'Q');
        Console.WriteLine("The average salary for university graduates with the given data is: {0:C}", uniAvg);
        Console.WriteLine("The average salary for college graduates with the given data is: {0:C}", colAvg);
        Console.WriteLine("The average salary for high school graduates with the given data is: {0:C}", highAvg);
    }

} 