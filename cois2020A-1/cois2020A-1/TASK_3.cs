// COIS 2020 A1; Kai Brucker: 0664706. Connor Corso: 0671950. Shervin Khosravi: 0667443
using System;
using Task1;
using Task4;


namespace Task3
{
    /*public class Polynomial : ICloneable
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



    }*/
}