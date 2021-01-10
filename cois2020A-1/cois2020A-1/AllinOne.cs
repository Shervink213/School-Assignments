// COIS 2020 A1; Kai Brucker: 0664706. Connor Corso: 0671950. Shervin Khosravi: 0667443
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Transactions;

//=================================================Task 1========================================

public class Term : IComparable
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

    public Object Clone()
    {
        Term t = new Term(this.coefficient, this.exponent);
        return t;
    }


    //=============================================================Task 2============================================

    /*public class Node<T>
    {
        public T Item { get; set; }
        public Node<T> Next { get; set; }

        public Node(T item, Node<T> next) //constructor with 0 parameters
        {
            Item = item;
            Next = next;
        }
        public override string ToString() //From Brian's code: safety net
        {
            return Item.ToString();
        }

    }

    public class Polynomial
    {
        // A reference to the first node of a singly linked list
        private Node<Term> front;
        private int count;             // Number of items in the list

        // Creates the polynomial 0
        public Polynomial()
        {
            front = null;
            count = 0;
        }

        // Inserts term t into the current polynomial in its proper order
        // If a term with the same exponent already exists then the two terms are added together
        public void AddTerm(Term t)
        {
            Node<Term> curr = this.front; //for moving along the polynomial
            Node<Term> leftNode = new Node<Term>(null, null); //For marking the left boundary when adding a term in between two others
            Boolean inserted = false; //To know if a term has been added yet
            if (count == 0) //if no terms have been added yet
            {
                Node<Term> A = new Node<Term>(t, null);
                this.front = A; //replace the empty front with the first term given
                count++;
            }
            else if (t.CompareTo(this.front.Item) > 0) //Necessary if t's exponent is larger than front's and only front is present
            {
                Node<Term> A = new Node<Term>(t, null);
                front = A;
                front.Next = curr;
                count++;
            }

            else if (t.CompareTo(front.Item) == 0) //same as above - necessary if exponents are equal and only front is present
            {
                curr.Item.Coefficient += t.Coefficient;
            }

            else
            {
                for (int i = 0; i < this.count; i++)
                {
                    if (inserted == true) break;
                    if (i != 0) curr = curr.Next; //move to the next term, only if this isn't the first loop (can't be placed at end)
                    if (t.CompareTo(curr.Item) == 0) //same exponent
                    {
                        curr.Item.Coefficient += t.Coefficient; //add coefficients
                        inserted = true;
                        //no count++, as it's the same number of terms now, but one has a larger coefficient
                    }
                    else if (t.CompareTo(curr.Item) < 0) //current term has a larger exponent than t, move to the next term and save this spot as leftNode
                    {
                        leftNode = curr;
                    }
                    else if (t.CompareTo(curr.Item) > 0) //current term has a smaller exponent than t, move to the left and place the term in
                    {
                        Node<Term> newSpot = new Node<Term>(t, null); //create a new node with t as its item
                        leftNode.Next = newSpot; //the Node to the left of curr now points to the new node
                        newSpot.Next = curr; //the new node points to curr - the new node is in between previous node and current node
                        inserted = true;
                        count++; //increase count
                    }
                }
                if (inserted == false) //check that the term hasn't already been inserted
                {
                    curr.Next = new Node<Term>(t, null); //in this case, t has a smaller exponent than all present terms
                    count++;
                }
            }
        }

        // Adds polynomials p and q to yield a new polynomial
        public static Polynomial operator +(Polynomial p, Polynomial q)
        {
            Polynomial f = new Polynomial();
            List<Term> t = new List<Term>(); //create a temp list of terms

            if (p == null && q != null)
                return q;
            else if (p != null && q == null)
                return p;
            Node<Term> p1 = p.front;
            Node<Term> q1 = q.front;
            while (p1 != null)
            {
                Term s = p1.Item;
                t.Add(s); //add every term from p to a list
                p1 = p1.Next;
            }

            while (q1 != null)
            {
                Term s = q1.Item;
                t.Add(s); //add every term from q to the same list
                q1 = q1.Next;
            }

            foreach (Term item in t)
            {
                f.AddTerm(item); //add all the terms to a new Polynomial, which puts them in order
            }

            return f;
        }

        // Multiplies polynomials p and q to yield a new polynomial
        public static Polynomial operator *(Polynomial p, Polynomial q)
        {
            Polynomial f = new Polynomial();
            List<Term> t = new List<Term>(); //create a temp list of terms

            if (p == null || q == null) //check that the parameter polynomials are not null
            {
                return null;
            }

            Node<Term> p1 = p.front;

            while (p1 != null)
            {
                Node<Term> q1 = q.front; //set q1 to the front term of q every time the while loop is repeated
                while (q1 != null)
                {
                    Term s = new Term(p1.Item.Coefficient * q1.Item.Coefficient, p1.Item.Exponent + q1.Item.Exponent); //coefficient is the product of p and q's coefficients, exponent is the sum of their exponents.
                    t.Add(s); //add the term to the list
                    q1 = q1.Next; //move to the next term in q
                }
                p1 = p1.Next; //move to the next term in p (beginning of while loop sets q back to the front term)
            }
            foreach (Term item in t)
            {
                f.AddTerm(item); //add all the terms to a Polynomial, which puts them in order
            }

            return f;
        }

        // Evaluates the current polynomial at x
        public double Evaluate(double x)
        {
            Node<Term> curr = front;
            double final = 0; //number to be sent back
            for (int i = 0; i < count; i++)
            {
                if (curr.Item == null) //can't calculate a null
                    throw new ArgumentNullException("Cannot evaluate polynomial with a null term");
                else
                    final += curr.Item.Evaluate(x); //evaluate the term and add it to final
                curr = curr.Next; //move to next term
            }
            return final;
        }

        // Prints the current polynomial
        public void Print()
        {
            Node<Term> curr = front;
            String poly = "";
            Boolean first = true;
            for (int i = 0; i < count; i++)
            {
                if (first == false && curr.Item.Coefficient >= 0)
                    poly = poly + " + " + curr.Item.ToString(); //place a plus sign in between terms if it is not the first term and coefficient is positive
                else
                {
                    poly = poly + curr.Item.ToString();
                    first = false;
                }
                curr = curr.Next;
            }
            Console.WriteLine(poly);
        }
    }*/

    //======================================Task 3==============================================
    public class Polynomial : ICloneable
    {
        //P is a linear array of Terms
        private Term[] P;  //max items
        private int count;      //number of items

        //constructor if size is given
        public Polynomial(int size)
        {
            count = 0;
            P = new Term[size]; //Creates a new polynomial, P
        }

        //Default Constructor if no parameter is given
        public Polynomial() : this(100) { }//invokes Polynomial(100)


        //clone the polynomial
        public Object Clone()
        {
            int i = 0;
            Polynomial c = new Polynomial();
            Term t;
            //Polynomial c = (Polynomial)this.MemberwiseClone();//makes a copy of all of the references and sets it up to be copied properly

            //goes through all of the elements in the array to clone each term induvidually, making a deep copy
            while (i <= count - 1)
            {
                t = (Term)P[i].Clone();//takes the term at position i in the current polynomial and 
                c.AddTerm(t);//adds said term to the new polynomial
                i++;
            }

            return c; //spits out the cloned Polynomial
        }



        //Inserts item at the correct position in the list
        public void AddTerm(Term item)
        {
            bool inserted = false;
            int l = 0;
            if (count == 0)//if there are no elements in the array then it adds it to the first spot
            {
                P[0] = item;
                count++;
            }
            else//if there are elements this figures out where to put it
            {
                while (!inserted)
                {

                    int test = P[l].CompareTo(item); //compares the one to 
                    switch (test)
                    {
                        case -1:
                            {
                                //the term that we are adding is greater than the current term
                                // if the exponent of the term you are adding is smaller than the term you are comparing it to, 
                                //then you must add the term to the place in the array one place before that term
                                int a;
                                //we need to move every boy up a spot to make room to place pal at the top
                                for (a = count - 1; a >= l; a--)
                                {
                                    P[a + 1] = P[a]; //moves each term up one position in the list
                                }
                                P[a + 1] = item;
                                count++;
                                inserted = true;


                                break;
                            }

                        case 0:
                            {
                                double tCoeff = item.Coefficient;   //sets tCoeff as a placeholder of the coeff of the item being added
                                double rCoeff = P[l].Coefficient;   //sets rCoeff as a placeholder of the coeff we are adding the item to
                                double totCoeff = rCoeff + tCoeff;
                                P[l].Coefficient = totCoeff;        //sets the coeff of the coeff we added the item to
                                inserted = true;                    //lets the while loop know we inserted the item succsessfully
                                break;
                            }

                        case 1:
                            {
                                //if the item's coefficient is smaller than the current coefficient, check to see if it is the last term or if not move on to the next term
                                if (l == count - 1)//if this is the last term in the polynomial, add the item on to the end of the polynomial
                                {
                                    P[l + 1] = item;
                                    count++;
                                    inserted = true;
                                }
                                else//if it isnt, go to the next term in the polynomial
                                {
                                    l++;
                                }
                                break;
                            }
                    }
                }
            }
        }

        public static Polynomial operator +(Polynomial p, Polynomial q)
        {
            Polynomial tempP, tempQ; //create two temporary copies of p and q
            tempP = (Polynomial)p.Clone();//clone p
            tempQ = (Polynomial)q.Clone();//clone q

            Polynomial r = new Polynomial(); //make the new resultant polynomial

            int i = 0, j = 0;


            //makes sure that both of the chosen polynomials are valid polynomials with terms in them
            if (tempP.count == 0 || tempQ.count == 0)
            {
                return null;
            }

            //loops through all of tempP to add each of its elements to r
            while (i <= (tempP.count - 1))
            {
                r.AddTerm(tempP.P[i]);//adds each term at place i to r
                i++;
            }
            //loops through all of tempQ to add each of its elements to r
            while (j <= (tempQ.count - 1))
            {
                r.AddTerm(tempQ.P[j]);//adds each term at place i to r
                j++;
            }
            return r;
        }




        //Multiplies polynomials p and q together to produce a new polynomial
        public static Polynomial operator *(Polynomial p, Polynomial q)
        {

            Polynomial r = new Polynomial(); //makes the new resultant polynomial
            Term h;
            Polynomial tempP, tempQ; //used to make copies of p and q
            tempP = (Polynomial)p.Clone(); //clones p
            tempQ = (Polynomial)q.Clone(); //clones q
            double tempCoeff;
            int tempExpo;
            int i = 0, j = 0;

            //makes sure that both of the chosen polynomials are valid polynomials with terms in them
            if (tempP.count == 0 || tempQ.count == 0)
            {
                return null;
            }

            //loops through all of the terms in both polynomials being multiplied, first starting with the first term in polynomial p and multiplying it with each 
            while (i <= (tempP.count - 1))
            {
                while (j <= (tempQ.count - 1))
                {
                    tempCoeff = (tempP.P[i].Coefficient) * (tempQ.P[j].Coefficient);
                    tempExpo = (tempP.P[i].Exponent) + (tempQ.P[j].Exponent);
                    h = new Term(tempCoeff, tempExpo);// creates a new term h that is the product of of two terms of the polynomial multiplied together
                    r.AddTerm(h); //adds the term to the resultant polynomial
                    j++;  //goes to the next term in Q
                }
                j = 0; //restarts to the start of Q so that each of P's terms are multiplied by each of Q's terms
                i++;   //moves to the next term in P
            }


            return r;
        }

        //Evaluates the current polynomial at x
        public double Evaluate(double x)
        {
            double result = 0;
            int i = 0;
            while (i <= count - 1)//loops through all the terms
            {
                result += P[i].Evaluate(x);//runs the induvidual evaluate for each term and adds it to a running total for the whole polynomial
                i++;
            }
            return result;
        }

        //Prints the polynomial
        public void Print()
        {
            string output = "";
            int i = 0;
            while (i < count)//runs through the whole polynomial
            {
                if (i == count - 1)
                {
                    output += P[i].ToString(); //uses the term's ToString method
                }
                else//
                {
                    output += P[i].ToString() + " + "; //uses the term's ToString method

                }
                i++;
            }
            Console.WriteLine(output);
        }
        public override string ToString()
        {
            string output = "";
            int i = 0;
            while (i < count)//if the current element is the last one in the polynomial it does this so that there isnt a trailing "+"
            {
                if (i == count - 1)
                {
                    output += P[i].ToString();//uses the term's ToString method
                }
                else
                {
                    output += P[i].ToString() + " + ";//uses the term's ToString method

                }
                i++;
            }
            return output;
        }



    }




    //=========================================Task 4==========================================
    class Polynomials
    {
        private List<Polynomial> L;
        private int capacity;          // Maximum number of items in a list
        private int count;             // Number of items in the list


        //Creates an empty list L of polynomials
        public Polynomials()
        {
            //Makes an empty list
            L = new List<Polynomial>();
            count = 0;
        }

        //Retrieves the polynomial stored at position i in L
        public Polynomial Retrieve(int i)
        {
            //Returns the polynomial the user asks for. 
            //It's (i-1) because the user doesn't know that the element count starts at 0
            return L[i];
        }

        //Inserts polynomial p into L
        public void Insert(Polynomial p)
        {
            //increaes the count and adds the new polynomial into the list
            count++;
            L.Add(p);
        }

        //Deletes the polynomial at index i
        public void Delete(int i)
        {
            L.RemoveAt(i);
            count--;
        }

        //Returns the number of polynomials in L
        public int Size()
        {
            return count;
        }

        //Prints out the list of polynomials
        public void Print()
        {

            Console.WriteLine("The Polynomials in S are:");
            int i = 0;
            while (i < count)
            {

                Console.WriteLine(i + ": " + L[i]);
                i++;
            }

        }
    }

    //=======================================Task 5===============================================
    class Program
    {
        static void Main(string[] args)
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
}












