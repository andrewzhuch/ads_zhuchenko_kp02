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
           int.TryParse(inputOfN, out N); //checking is N int number
           WriteLine("Input M");
           string inputOfM = ReadLine(); //reading the M
           int M = 0;  
           int.TryParse(inputOfM, out M); //checking is M int number
           double k;
           WriteLine("Input K");
           string inputOfk = ReadLine(); //reading the k
           bool checkingInputOfk = double.TryParse(inputOfk, out k); //checking is k double
           if(checkingInputOfk == false)
           {
               WriteLine("Wrong input of k");
           }
           else if(M < 1 || N < 1) //checking are N and M satisfie the conditions
           {
               WriteLine("Wrong input of N and/or M");
           }
           else if(N % 2 != 0)
           {
               WriteLine("Wrong input of N");
           }
           else //main part
           {
               traversalMatrix(N, M, k);
           }
        }
        static void traversalMatrix(int N, int M, double k)
        {
            WriteLine("input 1 if you want to traverse a random matrix, input 2 if you want to choose the test case");
            int determinantOfChoice = int.Parse(ReadLine()); // determing what kind of matrix user chose
            int[,] matrix = new int[N, M];
            if(determinantOfChoice == 1)
            {
                Random rand = new Random(); //variable for random matrix numbers
                for(int i = 0; i < N; i++) //hereinafter "i" - row index, "j" - column index
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
                int newNumber = 0; //new number addited to matrix
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
            WriteLine("Indexes of elements greater than k:");
            int counter = 0;
            for(int i = 0; i < N; i++)
            {
                for(int j = 0; j < M; j++)
                {
                    if(matrix[i, j] > k)
                    {
                        counter++;
                        Write("{0},{1}; ", i, j);
                    }
                }

            }
            if(counter != 0)
            {
                WriteLine(); //to make an orderly output
            }
            else
            {
                WriteLine("There are no elements greater than k");
            }
            int[] traverseOfMatrix = new int[N * M]; //array of numbers from matrix in correct order
            int rawIndex = 0; // index of the current cell
            int columnIndex = M - 1; //index of the current cell
            int currentCell = 0; //number of current cell
            while(currentCell < (N * M) / 2)
            {
                if(columnIndex == M - 1 && rawIndex != N / 2 - 1)// for right border
                {
                    traverseOfMatrix[currentCell] = matrix[rawIndex, columnIndex];
                    currentCell++;
                    rawIndex++;
                    traverseOfMatrix[currentCell] = matrix[rawIndex, columnIndex];
                    currentCell++;
                    rawIndex--;
                    columnIndex--;
                    while(rawIndex > 0)
                    {
                        if(columnIndex == 0)
                        {
                            break;
                        }
                        traverseOfMatrix[currentCell] = matrix[rawIndex, columnIndex];
                        rawIndex--;
                        columnIndex--;
                        currentCell++;
                    }
                }
                else if(rawIndex == 0 && columnIndex != M - 1 && columnIndex != 0) // for top border
                {
                    traverseOfMatrix[currentCell] = matrix[rawIndex, columnIndex];
                    currentCell++;
                    columnIndex--;
                    traverseOfMatrix[currentCell] = matrix[rawIndex, columnIndex];
                    currentCell++;
                    columnIndex++;
                    rawIndex++;
                    while (rawIndex < N / 2 - 1)
                    {
                        if(columnIndex == M - 1)
                        {
                            break;
                        }
                        traverseOfMatrix[currentCell] = matrix[rawIndex, columnIndex];
                        currentCell++;
                        rawIndex++;
                        columnIndex++;
                    }
                }
                else if(rawIndex == N / 2 - 1 && columnIndex != 0) // for bottom border
                {
                    traverseOfMatrix[currentCell] = matrix[rawIndex, columnIndex];
                    currentCell++;
                    if(currentCell == (N * M) / 2)
                    {
                        break;
                    }
                    columnIndex--;
                    traverseOfMatrix[currentCell] = matrix[rawIndex, columnIndex];
                    currentCell++;
                    if(currentCell == (N * M) / 2)
                    {
                        break;
                    }
                    columnIndex--;
                    rawIndex--;
                    while(rawIndex > 0)
                    {
                        if (columnIndex == 0)
                        {
                            break;
                        }
                        traverseOfMatrix[currentCell] = matrix[rawIndex, columnIndex];
                        currentCell++;
                        if(currentCell == N * M / 2)
                        {
                            break;
                        }
                        columnIndex--;
                        rawIndex--;
                    }
                }
                else if(columnIndex == 0) // for left border
                {
                    traverseOfMatrix[currentCell] = matrix[rawIndex, columnIndex];
                    currentCell++;
                    if(currentCell == (N * M) / 2)
                    {
                        break;
                    }
                    rawIndex++;
                    traverseOfMatrix[currentCell] = matrix[rawIndex, columnIndex];
                    currentCell++;
                    if(currentCell == (N * M) / 2)
                    {
                        break;
                    }
                    rawIndex++;
                    columnIndex++;
                    while(rawIndex < N / 2 - 1)
                    {
                        if(columnIndex == M - 1)
                        {
                            break;
                        }
                        traverseOfMatrix[currentCell] = matrix[rawIndex, columnIndex];
                        currentCell++;
                        if(currentCell == N * M / 2)
                        {
                            break;
                        }
                        rawIndex++;
                        columnIndex++;
                    }

                }
            }
            int counter1 = 2; //helps to determine do we need to go down or to go up in "snake" traverse
            int indexForTraverseOfMatrix = (N * M) / 2; //index of number added to traverseOfMatrix
            for(int j = 0; j < M; j++)
            {
                if(counter1 % 2 == 0) //if we need to go up
                {
                    for(int i = N / 2; i < N; i ++)
                    {
                        traverseOfMatrix[indexForTraverseOfMatrix] = matrix[i, j];
                        indexForTraverseOfMatrix++;
                    }
                    counter1 += 1;
                }
                else // if we need to go down
                {
                    for(int i = N - 1; i >= N / 2; i--)
                    {
                        traverseOfMatrix[indexForTraverseOfMatrix] = matrix[i, j];
                        indexForTraverseOfMatrix++;

                    }
                    counter1 += 1;
                }

            }
            for(int i = 0; i < traverseOfMatrix.Length; i++) //printing array in orderly way
            {
                Write("{0} ", traverseOfMatrix[i]);
            }
        }
    }
}
