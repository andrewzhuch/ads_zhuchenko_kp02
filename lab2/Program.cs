using System;
using static System.Console;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
           WriteLine("Input N");
           string inputOfN = ReadLine(); //reading the N
           int N = 0;
           bool checkingTheInputOfN = int.TryParse(inputOfN, out N); //checking is N an int number
           WriteLine("Input M");
           string inputOfM = ReadLine(); //reading the M
           int M = 0;
           bool checkingTheInputOfM = int.TryParse(inputOfM, out M); //checking is M an int number
           if(M < 1 || N < 1) // checking are N and M satisfie the condotions
           {
               WriteLine("Wrong input of N and/or M");
           }
           else if(N % 2 != 0)
           {
               WriteLine("Wrong input of N");
           }
           else // main part
           {
               traversalMatrix(N,M);
           }
        }
        static void traversalMatrix(int N, int M)
        {
            WriteLine("input 1 if you want to traverse a random matrix, input 2 if you want to choose the test case");
            int determinantOfChoice = int.Parse(ReadLine()); // determing what kind of matrix user chose
            int[,] matrix = new int[N, M];
            if(determinantOfChoice == 1)
            {
                Random rand = new Random(); // variable for random matrix numbers
                for(int i = 0; i < N; i++) // hereinafter "i" - row index, "j" - column index
                {
                    for(int j = 0; j < M; j++)
                    {
                        matrix[i, j] = rand.Next();
                        Write("{0} ", matrix[i, j]);
                    }
                    WriteLine();
                }
            }
            else
            {   
                int newNumber = 0; // new number addited to matrix
                for(int i = 0; i < N; i++)
                {
                    for(int j = 0; j < M; j++)
                    {   
                        matrix[i, j] = newNumber;
                        newNumber += 1;
                        Write("{0} ", matrix[i, j]);
                    }
                    WriteLine();
                }
            }
        }
    }
}
