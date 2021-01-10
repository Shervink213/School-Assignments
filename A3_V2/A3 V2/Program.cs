
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class Program
    {
        class Node
        {
            public string Directory { get; set; }
            public List<string> File { get; set; }
            public Node LeftMostChild { get; set; }
            public Node RightSibling { get; set; }

            public Node(List<string> file, string directory, Node leftMostChild, Node rightSibling)
            {
                this.File = file;
                this.Directory = directory;
                this.LeftMostChild = leftMostChild;
                this.RightSibling = rightSibling;
            }
            public Node(string directory)
            {
                //Sets everything to null, a default node
                this.File = new List<string>();
                this.Directory = directory;
                this.LeftMostChild = null;
                this.RightSibling = null;
            }
        }

        class FileSystem
        {
            //reference to the root node or root directory
            private Node root;

            // Creates a file system with a root directory
            public FileSystem()
            {
                //Creates the file system and names it "/" because that typically is what the root is named
                root = new Node("/");
            }




            // Adds a directory at the given address
            // Returns false if the directory already exists or the path is undefined; true otherwise
            public bool AddDirectory(string address)
            {
                //Asks the user to name the directory and stores that name
                Console.WriteLine("Name the new directory");
                string dirName = Console.ReadLine();
                return AddDirectory(address, root, dirName);
            }

            // I did this recursively because its neat
            private bool AddDirectory(string address, Node curr, string name)
            {
                bool found = false;
                if (curr.Directory == address)
                {

                    if (curr.LeftMostChild == null)//since there are no children already it doesnt need to check if the folder already exists
                    {
                        curr.LeftMostChild = new Node(address + name + "/");  //create the child node
                        Console.WriteLine("The folder was added");
                        return true;
                    }

                    curr = curr.LeftMostChild;//moves down to the left child in preparation to shuffle through the right siblings

                    if (curr.Directory == (address + name + "/"))
                    {
                        Console.WriteLine("That directory already exists");
                        return false;
                    }


                    if (curr.RightSibling == null) //if there are no siblings then move over
                    {
                        curr.RightSibling = new Node(address + name + "/"); //set the right sibling to the new directory
                    }
                    else
                    {
                        while (curr.RightSibling != null) //loop through all of the right siblings untill you hit the end or hit one that is named the same as the one that youre trying to add
                        {
                            if (curr.Directory == (address + name + "/"))  //the folder that you were trying to add already exists
                            {
                                Console.WriteLine("That directory already exists");
                                return false;
                            }

                            curr = curr.RightSibling; //moves over to the next sibling

                        }
                        curr.RightSibling = new Node(address + name + "/"); //sets the null sibling to the new directory

                    }


                }
                // This part runs recursively up until you find the node that has the address that you want to add the directory under


                if (curr.LeftMostChild != null)//makes sure that there is a left child so that it doesnt loop forever or error out
                {
                    found = AddDirectory(address, curr.LeftMostChild, name); //runs AddDirectory recursively
                }
                if (curr.RightSibling != null)//makes sure that there is a right child so that it doesnt loop forever or error out
                {
                    found = AddDirectory(address, curr.RightSibling, name); //runs AddDirectory recursively
                }

                return found;
            }


            // Prints the directories in a pre-order fashion along with their files
            public void PrintFileSystem()
            {
                PrintFileSystem(root);//runs Print starting at the root node
            }
            private void PrintFileSystem(Node curr)
            {

                //If the current node is null return nothing (only when the root is null)
                if (curr == null)
                    return;

                int i = 0;
                //Prints the directory that it is in
                Console.WriteLine(curr.Directory);

                //This cycles through all the files in the current directory and prints them with the path to get to them
                while (i < curr.File.Count)
                {
                    Console.WriteLine(curr.Directory + curr.File[i]); 
                    i++;
                }

                //A recursive function that goes through in an inorder fashion, running PrintFileSystem eventually for every node in the tree
                if (curr.LeftMostChild != null) //if theres a left node, go there
                    PrintFileSystem(curr.LeftMostChild);
                if (curr.RightSibling != null)//if theres a right node go thre
                    PrintFileSystem(curr.RightSibling);

            }


            //Returns the number of files in the file system by going through each node and adding up the number of files that there are total
            public int NumberFiles()
            {
                return NumberFiles(root);
            }
            private int NumberFiles(Node curr)
            {
                //create a variable that stores the amount of files
                int amt = 0;

                //add the number of files stored in the node and add them to the running sum
                amt += curr.File.Count;

                //A recursive function that goes through every node, until it reaches the last one
                //each time it runs it returns the amount of files in that node so it adds to the running sum, the variable amt
                if (curr.LeftMostChild != null)
                    amt += NumberFiles(curr.LeftMostChild);
                if (curr.RightSibling != null)
                    amt += NumberFiles(curr.RightSibling);

                //returns the amount.
                return amt;
            }

            

            // Adds a file at the given address
            // Returns false if the file already exists or the path is undefined; true otherwise

            public bool AddFile(string address)
            {
                Console.WriteLine("What is the name of the file that you would like to add?");
                string fileName = Console.ReadLine();
                return AddFile(address, root, fileName);  //runs the recursive method AddFile
            }
            private bool AddFile(string address, Node curr, string fileName)
            {
                bool addSucc = false; //a bool, to see if it was added succesfully
                if (curr.Directory == address) //if you are in the node that matches up with the address you wanted to go to then...
                {
                    foreach (string fl in curr.File) //goes through every file in curr.File
                    {
                        if (fl==fileName) //if curr.File contains the file that you are trying to add then it tells the user and returns false
                        {
                            Console.WriteLine("That file already exists");
                            return false;
                        }
                    }
                    curr.File.Add(fileName);//if the file doesnt already exist then it adds it
                }
                //the recursion part
                //if there is a left child move to the left
                //if there is a right child move to the right
                if (curr.LeftMostChild != null)
                    addSucc = AddFile(address, curr.LeftMostChild, fileName);
                if (curr.RightSibling != null)
                    addSucc = AddFile(address, curr.RightSibling, fileName);

                return addSucc;
            }

            public bool RemoveFile(string address)
            {
                //if RemoveFile returns 1, then you know that the operation was successfull, so return true. Otherwise it was unsuccessfull
                if (RemoveFile(address, root,0) == 1)
                    return true;
                else
                    return false;
            }
            private int RemoveFile(string address, Node curr,int delSucc)
            {
                
                if (curr.Directory == address) //if youre in the node you want to be in then...
                {
                    int i = 0;
                    Console.WriteLine("These are the files in the current directory");
                    foreach (string fl in curr.File)      //goes through and lists all of the files to make it easy to choose one to remove
                        Console.WriteLine(fl);
                    Console.WriteLine("Which file would you like to delete?");//asks the user which file they would like to delete
                    string toDelete = Console.ReadLine();
                    while (i < curr.File.Count)   //goes through File
                    {
                        if (curr.File[i] == toDelete)   //if a file matches the one that you want to delete then it does
                        {
                            curr.File.RemoveAt(i);      //uses the RemoveAt method
                            Console.WriteLine("The file was deleted successfully");    //tells the user the operation was a success
                            return 1;
                        }
                        i++;
                    }
                    Console.WriteLine("That file could not be found");
                    return 0;
                }


                //the recursion part
                //if there is a left child move to the left
                //if there is a right child move to the right
                if (curr.LeftMostChild != null)
                    delSucc = RemoveFile(address, curr.LeftMostChild, 0);
                if (curr.RightSibling != null)
                    delSucc = RemoveFile(address, curr.RightSibling, 0);


                return delSucc;
            }
            
            // Removes the directory (and its subdirectories) at the given address
            // Returns false if the directory is not found or the path is undefined; true otherwise
            public bool RemoveDirectory(string address)
            {
                //Asks the user to name the directory and stores that name
                Console.WriteLine("Which Directory would you like to remove?");
                string dirName = Console.ReadLine();
                return RemoveDirectory(address, root, dirName);

            }
            private bool RemoveDirectory(string address, Node curr, string dirName)
            {
                bool deleted = false;
                if (curr.LeftMostChild != null)//makes sure that the node you want to look in isnt null, otherwise you break things
                {
                    if (curr.LeftMostChild.Directory == (address + dirName + "/"))//if the directory that you are looking to remove is below you then...
                    {
                        Node temp = curr; //make a new temp node, I couldve probably avoided using this but it just made things a bit simpler without as many .LeftMostChild
                        temp = temp.LeftMostChild; //move to the left child
                        if (temp.RightSibling != null) //if there is a sibling to the right then set the parent's to the child's first sibling. effectively deleting it
                        {
                            curr.LeftMostChild = temp.RightSibling;
                            Console.WriteLine("The folder was removed");
                            return true;
                        }
                        else //otherwise you can just set the child to null
                        {
                            curr.LeftMostChild = null;
                            Console.WriteLine("The folder was removed");
                            return true;
                        }
                    }
                }
                //make sure that the node youre looking at exists to avoid breaking everthing
                if (curr.RightSibling != null)
                {
                    if (curr.RightSibling.Directory == (address + dirName + "/")) //if the next sibling over is the one that you want to remove then...
                    {
                        Node temp = curr.RightSibling;// same as with the leftsibling temp up above, i was lazy
                        if (temp.RightSibling == null) //if there are no more siblings, aka that is the last folder in the parent then set the leftsibling's reference to the node you want to delete to null
                        {
                            curr.RightSibling = null;
                            Console.WriteLine("The folder was removed");
                            return true;
                        }
                        else //otherwise you need to bypass that sibling to effectively remove it
                        {
                            curr.RightSibling = temp.RightSibling;
                            Console.WriteLine("The folder was removed");
                            return true;
                        }
                    }
                }


                //the recursive part that effectively searches for the node you want to delete by moving through all of the nodes in the tree
                if (curr.LeftMostChild != null)
                    deleted = RemoveDirectory(address, curr.LeftMostChild, dirName);
                if (curr.RightSibling != null)
                    deleted = RemoveDirectory(address, curr.RightSibling, dirName);

                return deleted;
            }


        }
                          
        static void Main()
        {
            //Creates the file system
            FileSystem fs = new FileSystem();
            int choice;

            try
            {
                do
                {
                    //Prints the file system so the user can see it
                    Console.WriteLine("Here is what the file system looks like so far");
                    fs.PrintFileSystem();

                    //asks the user what they want to do
                    Console.WriteLine("\nPress 1 to add a directory \nPress 2 to add a file \nPress 3 to remove a directory \nPress 4 to remove a file \nPress 5 to return the number of files in the system \nPress 6 to print the file system \nPress 7 to quit");
                    choice = Convert.ToInt32(Console.ReadLine());

                    if (choice == 1)
                    {
                        //Asks the user which directory they wish to add to and then goes through the process of trying to add
                        Console.WriteLine("Which directory would you like to add a directory to?");
                        fs.AddDirectory(Console.ReadLine());
                    }
                    else if (choice == 2)
                    {
                        //Asks the user which directory they wish to add a file to and then goes through the process of trying to add a file
                        Console.WriteLine("Which directory would you like to add a file to?");
                        fs.AddFile(Console.ReadLine());
                    }
                    else if (choice == 3)
                    {
                        //Asks the user which directory they wish to remove and then goes through the process of trying to remove it
                        Console.WriteLine("What is the directory that holds the directory you would like removed called?");
                        fs.RemoveDirectory(Console.ReadLine());
                    }
                    else if (choice == 4)
                    {
                        //Asks the user which directory they wish to remove a file from and then goes through the process of trying to remove it
                        Console.WriteLine("What is the directory of the file that you would like to remove?");
                        string remFile = Console.ReadLine();
                        fs.RemoveFile(remFile);
                    }
                    else if (choice == 5)
                    {
                        //Prints the number of files
                        int count = fs.NumberFiles();
                        Console.WriteLine("The file system has: " + count + " files");
                    }
                    else if (choice == 6)
                    {
                        //prints the file system, should probably have a friendly message next to it... nah
                        fs.PrintFileSystem();
                    }
                    else if (choice < 1 || choice > 7)
                    {
                        //if the user didn't hit the right option, then give them error
                        Console.WriteLine("\nPlease enter a valid option\n");
                    }

                    //if the user wants to quit, they hit 7 and BAM! gone
                } while (choice != 7);
            }
            catch
            {
                //if anything happens that we didn't see happening, we got ourselves covered. 
                throw new ArgumentException("An error occured");
            }



        }
    }
}

