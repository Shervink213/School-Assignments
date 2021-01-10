// COIS 2020 A1; Kai Brucker: 0664706. Connor Corso: 0671950. Shervin Khosravi: 0667443
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2
{
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
                for(int i = 0; i < this.count; i++)
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
            Node<Term> qCurr = q.front;
            Polynomial r = p;

            for (int i = 0; i < q.count; i++)
            {
                r.AddTerm(qCurr.Item); //Add every term from q to p
                qCurr = qCurr.Next;
            }
            
            return r;
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
            for(int i = 0; i < count; i++)
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
}
