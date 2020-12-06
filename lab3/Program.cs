using System;
using static System.Console;
using static System.Math;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)//main fucntion
        {
            WriteLine("Hello! Plese, enter number n:");
            int n;
            bool isNCorrect = ProcessingNumber(out n);
            if(isNCorrect == false)//checking input of N
            {
                WriteLine("Sorry, somethig went wrong. Check your input of n");
            }
            else
            {
                WriteLine("Plese, enter number m:");
                int m;
                bool isMcorrect = ProcessingNumber(out m);
                if(isMcorrect == false)//checking input of M
                {
                    WriteLine("Sorry, somethig went wrong. Check your input of m");
                }
                else
                {
                    WriteLine("Plese, enter number k:");
                    double k;
                    bool isKcorrect = double.TryParse(ReadLine(), out k);
                    if(isKcorrect == false || k == 0)//k is a denominator, because of that k cannot be equal to zero
                    {
                        WriteLine("Sorry, somethig went wrong. Check your input of k");
                    }
                    else
                    {
                        WriteLine("Plese, enter number l:");
                        double l;
                        bool isLCorrect = double.TryParse(ReadLine(), out l);
                        if(isLCorrect == false)//checking input of l
                        {
                            WriteLine("Sorry, somethig went wrong. Check your input of l");
                        }
                        else
                        {
                            int[,] matrix = CreatingNewMatrix(n, m);//creating matrix
                            PrintingMatrix(matrix, k, l);//printing unsorted matrix
                            WriteLine();
                            int[,] sortedMatrix = SortingMatrix(matrix, k, l);
                            PrintingMatrix(sortedMatrix, k, l);
                        }
                    }
                }
            }
        }
        /*
        I decided to make function ProcessingNumber because my program should check two numbers and it's a good idea to create a function for code
        which is used twice
        */
        static bool ProcessingNumber(out int n)//function order of which is to check are dementions of martix correct
        {
            int number;
            bool isNUmberNCorrect = int.TryParse(ReadLine(), out number);
            if(isNUmberNCorrect == true)//checking is inputed number int
            {
                if(number > 0)//checking is inputed number bigger than zero
                {
                    n = number;
                    return true;
                }
                else
                {
                    n = 0;
                    return false;
                }
            }
            else
            {
                n = 0;
                return false;
            }

        }
        /*
        function for creating array, I thought that it's a good idea to create it in order make main fucnion simple and short as possible
        and make my code more readable
        */
        static int[,] CreatingNewMatrix(int n, int m)
        {
            int[,] array = new int[n, m];//matrix itself
            Random rnd = new Random();//variable for random numbers in my matrix
            for(int i = 0; i < n; i++)//hereinafter i - raw index, j - column index
            {
                for(int j = 0; j < m; j++)
                {
                    array[i, j] = rnd.Next(10, 100);
                }
            }
            return array;
        }
        /*
        function for printing matrix in a proper way, as well as the previous function making code more readable
        */
        static void PrintingMatrix(int[,] matrix, double k, double l)
        {
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    if((int)(matrix[i, j]) / k < l)
                    {
                        BackgroundColor = ConsoleColor.Blue;//one of the conditions from task
                        Write("{0} ", matrix[i, j]);
                        ResetColor();
                    }
                    else
                    {
                        Write("{0} ", matrix[i, j]);
                    }
                }
                WriteLine();//making orderly output
            }
        }
        /*
        function for Shell sorting
        original Shell sequence was chosen for sorting
        general idea: sort every column separatly, looking for the soughtable numbers
        and making two new arrays, first one with indexes of these numbers, second one with numbers
        than sorting array of soughtable numbers and inserting them in column array and inserting column array in matrix
        making two additional arrays is essentiall, because if my program sort whole сolumn array sometimes not all elements are sorted
        */
        static int[,] SortingMatrix(int[,] matrix, double k, double l)
        {
            for(int j = 0; j < matrix.GetLength(1); j++)
            {
                int[] currentColumn = new int[matrix.GetLength(0)];//variable for each column
                int counter = 0;//requierd because helps to create an array of soughtable numbers
                for(int i = 0; i < currentColumn.Length; i++)//filling array of numbers from column
                {
                    currentColumn[i] = matrix[i, j];
                    if((int)(currentColumn[i] / k) < l )
                    {
                        counter++;
                    }
                }
                int[] soughtNumbers = new int[counter];//array for soughtable numbers
                int[] indexesOfSoughtNumbers = new int[counter];//array for indexes of soughtable numbers
                int counter2 = 0;
                for(int i = 0; i < currentColumn.Length; i++)
                {
                    if((int)(currentColumn[i] / k) < l )
                    {
                        soughtNumbers[counter2] = currentColumn[i];
                        indexesOfSoughtNumbers[counter2] = i;
                        counter2++;
                    }
                }
                int gap = soughtNumbers.Length / 2;//gap in sorting
                int o = 1;// variable that is using in calculating of gap
                int current;
                int variable;//variable for changing elements
                while(gap >= 1)//main process of sorting
                {
                    for(int c = gap; c < soughtNumbers.Length; c++)
                    {
                        current = soughtNumbers[c];
                        for(int p = c; p >= gap;)
                        {
                            if(soughtNumbers[p - gap] > current)
                            {
                                variable = soughtNumbers[p];
                                soughtNumbers[p] = soughtNumbers[p - gap];
                                soughtNumbers[p - gap] = variable;
                            }
                            else
                            {
                                break;
                            }
                            p = p - gap;
                        }
                    }
                    o++;
                    gap = (int)(soughtNumbers.Length / Pow(2, o));//calculating next gap
                    for(int i = 0; i < soughtNumbers.Length; i++)
                    {
                        currentColumn[indexesOfSoughtNumbers[i]] = soughtNumbers[i];
                    }
                    for(int y = 0; y < matrix.GetLength(0); y++)//inserting column in matrix
                    {
                        matrix[y, j] = currentColumn[y];
                    }
                } 
            }
            return matrix;
        }
    }
}
