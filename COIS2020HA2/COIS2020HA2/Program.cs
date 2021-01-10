using System;
using System.Collections.Generic;
using PriorityQueue;

// Made by Connor Corso 0671950 and Shervin Khosravi 0667443

namespace COIS2020HA2
{
    class Program
    {
        class Node : IComparable
        {
            public char Character { get; set; }
            public int Frequency { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public Node(char character, int frequency, Node left, Node right)
            {
                //So this is the basis for the nodes and what they include
                //the characters, the frequency, the left and right references, this is for inserting data into the nodes later on
                this.Character = character;
                this.Frequency = frequency;
                this.Left = left;
                this.Right = right;
            }


            // 5 marks
            public int CompareTo(Object obj)
            {
                
                //Took this from Dr.Patrick's PQ.cs, said I should so I did. 
                //Switched around the return because lower frequency = higher priority, other way around and we get massive numbers 
                if (obj != null)
                {
                    Node other = (Node)obj;   // Explicit cast
                    if (other != null)
                        return other.Frequency - Frequency;
                    else
                        return 1;
                }
                else
                    return 1;
                
            }

        }


        class Huffman
        {
            private Node HT; // Huffman tree to create codes and decode text
            private Dictionary<char, string> D = new Dictionary<char, string>(); // Dictionary to encode text


            // Constructor
            public Huffman(string S)
            {
                //Invokes the methods below, dont know why the Console.WriteLine works there but it does
                AnalyzeText(S);
                Build(AnalyzeText(S));
                Console.WriteLine("\nThis is what the tree looks like: \n '//' is a parent node \n 'x/y' is a node where x is the character and y is the frequency \n");
                CreateCodes(S);
                Printing();
            }

            // Return the frequency of each character in the given text (invoked by Huffman)
            private int[] AnalyzeText(string S)
            {

                //Creates an array so that we can store the frequiences of the characters, made it 500 because it seemed like a good size
                int[] FreqChar = new int[500];

                

                //A foreach loop that goes through each character in the String, S, and counts the amount of times they are there
                //Got this from this website: https://www.dotnetperls.com/count-letter-frequencies
                foreach (char s in S)
                {

                    //creates inex, then takes the characters from the string, casts them as integers because it grabs their ascii value
                    //adds it to the array and then increments it
                    //Got this version from: https://stackoverflow.com/questions/14716615/what-is-mapintxwhat-it-does
                    int index;
                    index = (int)s;
                    FreqChar[index]++;

                }

                return FreqChar;
            }

            // Build a Huffman tree based on the character frequencies greater than 0 (invoked by Huffman)
            private void Build(int[] F)
            {
                //References to a Priotity Queue and then creates one with a size of the array
                PriorityQueue<Node> PQ;
                PQ = new PriorityQueue<Node>(F.Length);

                int k = 0;

                //This goes through the array, F[], and adds a node for each letter. Could've made it a for loop but I like while loops
                while (k < F.Length)
                {
                    //Makes sure that the letters entering the Queue have a frequency of 1 or more, ie: the letter is used
                    if (F[k] > 0)
                    {
                        //Copied this from the AnalyzeText so it takes the letters, casts it as a character, then it properly stores it.
                        char index;
                        index = (char)k;

                        //Adds the character, the frequency of the chracter, and then sets the left and right to null so it becomes a leaf node
                        PQ.Add(new Node(index, F[k], null, null));
                    }
                    k++;
                }

                //This sees if there's only one node in the PQ. If so, just make the tree that one node
                if (PQ.Size() == 1)
                {
                    HT = PQ.Front();
                }
                //Goes through this if there is more than one node in the tree
                else
                {
                    //goes through this while there is more than one node
                    do
                    {
                        //So this sets the left node in the Huffman Tree to the front of PQ and then removes it
                        Node Left = PQ.Front();
                        PQ.Remove();

                        //Then it sets the right node in the Huffman Tree to the front of the PQ and then removes it
                        //A cycle where it adds nodes from left to right, removes them, adds again, and so on until there is only one node left in the PQ
                        Node Right = PQ.Front();
                        PQ.Remove();

                        //So this adds a node with that '/' for printing because it was in Brian's code, the frequency of the letters in the left and right node
                        //which is the number in the parent nodes in the Huffman tree, and then just the left and right
                        PQ.Add(new Node('/', Left.Frequency + Right.Frequency, Left, Right));

                    } while (PQ.Size() != 1);

                    //Then it msets the top of the tree to the front of the PQ
                    HT = PQ.Front();
                }



            }

            //creates the code of 0s and 1s for each character by transversing the Huffman tree(invoked by Huffman)
            private void CreateCodes(String S)
            {
                
                Node top = HT; //sets the top node to the top of the Huffman tree
                string longNumbers ="";
              
                //This is what Dr.Patrick said we should do during his Thursday lecture about Recursive stuff
                //So this just calls the method from below
                MakeCode(top, longNumbers);
                
                
                //A Recursive method that'll keep cycling through itself so it makes the code
                void MakeCode(Node x, string longNumbers)
                {
                    //This is sort of what Dr.Patrick showed us during the lecture
                    //This checks if there is anything in the left and right nodes
                    //If there is, it'll run through it again but this time adding "0" or "1" based on whether it went to the left or to the right
                    if (x.Left != null)
                    {               
                        if (x.Right != null)
                        {
                            MakeCode(x.Right, longNumbers + "1");
                            MakeCode(x.Left, longNumbers + "0");
                        }    
                        
                    }
                    else
                    {
                        //This is for spotting a string thats just a repeat of one letter
                        //sets v to 1 and k to the length of the string
                        int v = 1, k = S.Length;

                        //This for loop goes through the string and compares the letters one by one
                        //Only v continues to increase while i stays the same
                        for (int i = 0; v < S.Length; v++)
                        {
                            //So this takes the first letter of the string, S[i], and compares it to every subsequent letter, S[v],
                            //If the letters are equal, that means that they're repeating letters
                            if (S[i] == S[v])
                            {
                                //So while going through this for loop, it will remove the letters that are repeats
                                //While decreasing k, since I'm using k to track how many repeats there are compared to the whole string 
                                S.Remove(v);
                                k--;
                            }
                        }
                        
                        //So, if every letter in the string is a repeat, that sets k to 1 because there's only one unique letter in the string
                        //Which then adds the character to the dictionary and a simple '0' for the encoded message
                        //Since thats the only letter, it has the highest frequency, so it just has to be 0
                        if (k == 1)
                        {
                            D.Add(x.Character, longNumbers + "0");
                        }
                        else
                        {
                            //Then this will put the character and the encoded message into the dictionary normally if the string isn't just repeats
                            D.Add(x.Character, longNumbers);  

                        }

                    }

                }

            }

        

            //This wasn't required, just found it cool to have the tree print out
            //Used Dr.Patrick's code
            private void Printing()
            {
                Node root = HT;
                Printt(root, 0);
                
                //it's named 'Printt' because 'Print' was taken in PriorityQueue.cs
                void Printt(Node root, int indent)
                {
                    //A recursive function, this goes through and draws the Huffman Tree, going through itself over and over again,
                    //Until the node finally becomes null
                    if (root != null)
                    {
                        Printt(root.Right, indent + 5);
                        Console.WriteLine(new String(' ', indent) + root.Character + '/' + root.Frequency);
                        Printt(root.Left, indent + 5);
                    }
                }
            }
            

            //encode the given text and return a string of 0s and 1s
            public string Encode(string S)
            {
                string enc = ""; //this is the encoded message, not creative with my names

                //Goes through each letter in the string and casts them as characters to x
                //Did the same for the AnalyzeText
                for(int i =0; i < S.Length; i++)
                {
                    char x;
                    x = (char) S[i];
                    
                    //Lookes through each Key and Value in the dictionary (characters and strings)
                    //if the character in the string is equal to the key in the dictionary
                    //take the encode message and add to it the value of that key (the string of 1s or 0s), from the dictionary. 
                    foreach (KeyValuePair<char, string> y in D)
                    {
                        if (x == y.Key)
                        {
                            enc += y.Value;
                        }
                    }
                }

                //return the encoded message
                return enc;

            }

            //Decode the given string of 0s and 1s and return original text
            public string Decode(string S)
            {

                Node top = HT; //Sets the top node to be the top of the Huffman tree
                string dec = ""; //The decoded message

                //A for loop that goes through each letter of the encoded message, getting through the tree, and then assigning letters to those 0s and 1s
                for (int i = 0; i < S.Length; i++)
                {
                    //Checks to see if you're at a leaf node
                    if (top.Left != null)
                    {
                        //There can only be 2 types of inputs, 0s and 1s. 
                        //So this is one of the only moments in history where a switch case can be useful 
                        switch (S[i])
                        {
                            //if the number is '1', then go to the right
                            case '1':
                                top = top.Right;
                                break;
                            //if the number is '0', then go to the left
                            case '0':
                                top = top.Left;
                                break;
                        }

                        //This checks if you reached a leaf node. If you have, then it adds the character of that node to the decoded message
                        //and sets the top node to the top of the Huffman Tree so it can go again in the for loop
                        if (top.Right == null)
                        {
                            dec += top.Character;
                            top = HT;
                        }
                    }
                    //This means that you have reach a leaf node
                    //It adds the character of that node to the decoded message
                    //and sets the top node to the top of the Huffman Tree so it can go again in the for loop
                    else
                    {
                        dec += top.Character; //add curr's character to the decoded string
                        top = HT; //set curr back to the top of the tree
                    }
                    
                }

                //returns the message
                return dec;
                
            }
        }


        public class Test
        {
            public static void Main(string[] args)
            {
                //data members for the string
                string S;
                int input;

                //makes sure the user enters an int
                try
                {
                    //do everything in the body until the user says it's time to quit
                    do
                    {
                        Console.WriteLine("\nWould you like to run the program or quit the program?");
                        Console.WriteLine("We did this because we found it annoying to keep running the program over and over again for testing");
                        Console.WriteLine("\n1: run program. \n2: quit program");
                        input = Convert.ToInt32(Console.ReadLine());

                        if (input < 1 || input > 2)
                        {
                            Console.WriteLine("\nPlease enter a valid input");
                        }

                        if (input == 1)
                        {
                            Console.WriteLine("\nPlease enter any sentence, word, or letters you want to be encoded and then decoded, plus a nice tree");
                            S = Convert.ToString(Console.ReadLine());

                            Huffman H = new Huffman(S);

                            Console.WriteLine("\nHere is the encoded message in 1s and 0s");
                            Console.WriteLine(H.Encode(S));
                            Console.WriteLine("\nHere is the decoded message from the encoded message above");
                            Console.WriteLine(H.Decode((H.Encode(S))));
                        }
                    } while (input != 2);
                }
                catch
                {
                    Console.WriteLine("\nNot a valid input");
                }    
                    
                
            }

        }
    }
}



        

