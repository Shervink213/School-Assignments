// name: Shervin Khosravi
// Student #: 0667443
// Description: A program made, using arrays, to manage 10 seats 
using System;

namespace Assignment4
{
    public static class Assignment4
    {
        public static void Main()
        {
            //SeatAssign[] = array of all the seats
            //SeatType = action the user wants to do when managing their seat
            string[] SeatAssign = new string[10] {null, null, null, null, null, null, null, null, null, null};
            char SeatType;

            do
            {
                //prompt the user to enter what they would like to do
                Console.WriteLine("\nPlease enter what you want to do");
                Console.WriteLine(" ‘b’ or ‘B’ to book a seat, ‘c’ or ‘C’ to cancel a seat, ‘p’ or ‘P’ to print the seating assignments, and ‘q’ or ‘Q’ to quit");
                SeatType = Convert.ToChar(Console.ReadLine());

                //what to do if the user enters a valid character
                if ((SeatType == 'B' || SeatType == 'b' || SeatType == 'C' || SeatType == 'c' || SeatType == 'p' || SeatType == 'P'))
                {
                    //cases telling the program what to do depending on what the user input
                    switch (char.ToUpper(SeatType))
                    {
                        //Tells the program what to do if the user wants to book a seat
                        case 'B':
                            Booking(SeatAssign);
                            break;
                        //Tells the program what to do if the user wants to cancel their seat
                        case 'C':
                            Cancel(SeatAssign);
                            break;
                        //Tells the program what to do if the user wants to see all assigned seats that aren't empty
                        case 'P':
                            PrintSeat(SeatAssign);
                            break;
                    }
                }
                //Writes an error message if the user enters an invalid character
                else if (char.ToUpper(SeatType) != 'B' && char.ToUpper(SeatType) != 'C' && char.ToUpper(SeatType) != 'P' && char.ToUpper(SeatType) != 'Q')
                {
                    Console.WriteLine("Sorry, that is invalid");
                }
            //Quits the program if the user enters "q"
            } while (char.ToUpper(SeatType) != 'Q');
        }

        //Description: A method used to find the first empty seat in the array
        public static int FindEmptySeat(string[] SeatAssign)
        {
            //location = location of the seat in the array
            //found = a boolean to tell if an empty seat has been found
            //searchItem = the object the program is supposed to find in the array
            int location = 0;
            bool found = false;
            string searchItem = null;
            
            //for loop to search for an empty seat
            for (int i =0; (i < SeatAssign.Length && !found); ++i)
            {
               //Tells the program what to do if the object has been found
                if (searchItem == SeatAssign[i])
                {
                    //Tells the program that the object has been found and to make the location equal the array number
                    found = true;
                    location = i;
                }
                //Tells the program what to do if the object wasn't found
                else
                {
                    //Tells the program that the object wasn't found and to make the location equal negative one
                    found = false;
                    location = -1;
                }
            }
            //returns the location of an empty seat or -1 if non were found
            return location;
        }

        //Description: Find the assigned seat the customer has already booked
        public static int FindCustomerSeat(string[] SeatAssign, ref string cName)
        {
            //location = location of the assigned seat
            //found = a boolean to tell if the assigned seat has been found
            //searchItem = the object the program is trying to find
            int location = 0;
            bool found = false;
            string searchItem = cName;

            //for loop to search the array for the object
            for (int i = 0;( i < SeatAssign.Length && !found); ++i)
            {
                //tells the program what to do if the assigned seat was found
                if (searchItem == SeatAssign[i])
                {
                    //Tells the program that the object has been found and to make the location equal the array number
                    found = true;
                    location = i;
                }
                //Tells the program what to do if the object wasn't found
                else
                {
                    //Tells the program that the object wasn't found and to make the location equal negative one
                    found = false;
                    location = -1;
                }
            }
            //returns the location of an empty seat or -1 if non were found
            return location;
        }

        public static void Booking(string[] SeatAssign)
        {
            //seat = the returned value of FindCustomerSeat(), empty = the returned value of FindEmptySeat()
            //cName = name of the user
            int seat, empty;
            string cName;

            //prompts the user to enter their name
            Console.Write("Please enter your name:");
            cName = Convert.ToString(Console.ReadLine());

            //run the method FindCustomerSeat()
            seat = FindCustomerSeat(SeatAssign, ref cName);

            //Tells the program what to do if the customer hasn't already booked a seat
            if(seat == -1)
            {
                //runs the method FindEmptySeat()
                empty = FindEmptySeat(SeatAssign);
                
                //Tells the program what to do if there are no seats left
                if (empty == -1)
                {
                    //Tells the user that there are no seats left
                    Console.WriteLine("\nSorry, there are no seats available");
                }
                //Tells the program what to do if there are seats avaiable
                else
                {
                    //Changes the array element to the name of the user and tells them which seat they have
                    SeatAssign[empty] = cName;
                    Console.WriteLine("\nSeat # {1} assigned to {0}", cName, empty);
                }
            }
            //Tells the program what to do if the customer has already booked a seat
            else
            {
                Console.WriteLine("\nSorry, you already have a seat assigned");
            }
        }

        //Description: Cancels the assigned seat 
        public static void Cancel(string[] SeatAssign)
        {
            //seat = the seat the user is trying to cancel
            //cName = the user's name
            int seat;
            string cName;

            //prompts the user to enter their name
            Console.Write("Please enter your name:");
            cName = Convert.ToString(Console.ReadLine());

            //runs the method FindCustomerSeat()
            seat = FindCustomerSeat(SeatAssign, ref cName);

            //Tells the program what to do if there are no seats under the name
            if(seat == -1)
            {
                //Tells the user that there are no seats with that name
                Console.WriteLine("\nSorry, there are no seats assigned to that name");
            }
            //Tells the program what to do if there is a seat under that name
            else
            {
                //changes the array element to "null" and tells the user the seat has been cancelled
                SeatAssign[seat] = null;
                Console.WriteLine("\nYour assigned seat has been cancelled");
            }
        }


        //Description: Prints the seating assignments
        public static void PrintSeat(string[] SeatAssign)
        {
            //for loop to go through the array
            for (int i = 0; i < SeatAssign.Length; ++i)
            {
                //tells the program what to do if the array element is null
                if (SeatAssign[i] != null)
                {
                    //print the names and the seat number of all assigned seats, leaves out the empty seats because of the "if" statement
                    Console.WriteLine("\n Seat #: {1} assigned to: {0}" ,SeatAssign[i],i);
                }
            }
        }

    }
}
