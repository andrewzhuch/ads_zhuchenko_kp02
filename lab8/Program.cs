using System;
using static System.Console;

namespace lab8
{
    class Program
    {
        static void Main()
        {
            while(true)
            {
                WriteLine("Avaliable commands: example, userTree, exit");
                WriteLine("Command:");
                string command = ReadLine();
                if(command == "exit")
                {
                    break;
                }
                else if(command == "example")
                {
                    BinaryTree tree = new BinaryTree();
                    WriteLine("Now tree is empty:");
                    BinaryTree.Print(tree);
                    WriteLine("Add 15, 30, 10 and 8");
                    tree.InsertValue(15);
                    tree.InsertValue(30);
                    tree.InsertValue(10);
                    tree.InsertValue(8);
                    WriteLine("Here is a result");
                    BinaryTree.Print(tree);
                }
                else if(command == "userTree")
                {
                    BinaryTree tree = new BinaryTree();
                    while(true)
                    {
                        WriteLine("Avaliable commands: add {value}, print, exit");
                        string command1 = ReadLine();
                        if(command1 == "exit")
                        {
                            break;
                        }
                        else if(command1 == "print")
                        {
                            BinaryTree.Print(tree);
                        }
                        else if(command1.StartsWith("add "))
                        {
                            string[] array = command1.Split(' ');
                            if(array.Length != 2)
                            {
                                WriteLine("Wrong command");
                            }
                            else
                            {
                                int value;
                                bool checkValue = int.TryParse(array[1], out value);
                                if(checkValue == false)
                                {
                                    WriteLine("Wrong value");
                                }  
                                else
                                {
                                    tree.InsertValue(value);
                                }
                            }
                        }
                        else
                        {
                            WriteLine("Wrong command");
                        }
                    }
                }
                else
                {
                    WriteLine("Wrong command");
                }
            }
        }
    }
}
