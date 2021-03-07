using System;
using static System.Console;
using static System.Math;

namespace lab5
{
    class Program
    {
        static void Main()
        {
            WriteLine("Hello!");
            WriteLine("Attention! Wrong input stops running the program and you should restart it!");
            ConsoleKeyInfo keyInfo; // preparing for reading from keyboard
            do
            {
                WriteLine("If you want to work with example, press A. If you want to choose matrix size, press B. If you want to stop the program, press Escape.");
                keyInfo = ReadKey();
                if(keyInfo.Key == ConsoleKey.A) // part for sorting in example
                {
                    WriteLine(); // pretty output
                    WriteLine("Here is an unsorted example");
                    int[,] example = new int[8,8]{ // example matrix
                        {12,2,3,4,5,6,7,8},
                        {16,35,56,69,15,61,82,90},
                        {20,53,77,99,38,42,55,11},
                        {1000,600,700,800,200,350,400,500},
                        {-17,-21,-5,-6,-7,-8,-4,-2},
                        {44,667,129,599,699,899,0,18888},
                        {556,331,557,314,608,708,34,584},
                        {1111,1112,1113,-666666,66,-90,-40,-599}
                    };
                    PrintingMatrix(example);
                    int[] arrayForSorting = DetachArrayFromMatrix(example);
                    WriteLine();//
                    QuickSort(arrayForSorting, arrayForSorting.Length - 1);
                    for(int g = 0; g < arrayForSorting.Length; g++)//
                    {//
                            Write("{0} ", arrayForSorting[g]);//
                    }//
                    WriteLine();//
                    WriteLine("Here is sorted example");
                    int[,] sortedMatrix = PutArrayInMatrix(arrayForSorting, example);
                    PrintingMatrix(sortedMatrix);
                } 
                else if(keyInfo.Key == ConsoleKey.B) // part for user's matrix with random values in matrix
                {
                    WriteLine(); // pretty output
                    WriteLine("Input m");
                    string i = ReadLine();
                    int m;
                    WriteLine("Input n");
                    string j = ReadLine();
                    int n;
                    bool inputInfo = CheckingInput(i, j, out m, out n);
                    if(m == 1 || n == 1 || (m == 2 && n == 2))
                    {
                        WriteLine("Sorry, matrix is too small and there are no elements between two diagonals in right triangle.");
                        break;
                    }
                    else
                    {
                        int[,] matrix = CreatingMatrix(m, n);
                        WriteLine("Here is an unsorted matrix");
                        PrintingMatrix(matrix);
                        int[] arrayForSorting1 = DetachArrayFromMatrix(matrix);
                        QuickSort(arrayForSorting1, arrayForSorting1.Length - 1);
                        WriteLine();//
                        for(int g = 0; g < arrayForSorting1.Length; g++)//
                        {//
                            Write("{0} ", arrayForSorting1[g]);//
                        }//
                        WriteLine();//
                        PutArrayInMatrix(arrayForSorting1, matrix);
                        WriteLine("Here is the sorted matrix");
                        PrintingMatrix(matrix);
                    }
                }
                else if(keyInfo.Key != ConsoleKey.Escape)
                {
                    WriteLine("Wrong button!");
                }
            }
            while(keyInfo.Key != ConsoleKey.Escape); // Exit key.
            WriteLine("Thanks for using!");
        }
        static void PrintingMatrix(int[,] matrix) // Funcion that prints matrix in a pretty way.
        /* Here is the way how to find nedeed matrix elements.
        In this funcntion I use this idea in order to highlight sought elements in matrix.
        I use the same idea in detaching array from matrix, so here is the description of the method.
        I created two counters, each of them indicates where are the diagonals in current iteration.
        This counters indicates only the column index, but this is enough to see is the current element located in the right corner. 
        So, I just need to know is the column index of current element bigger than counter of each diagonal, because if it is,
        it means that current element is to the right for both diagonals, which means that current element is located in the right treangle.
        */
        {
            int counterForMainDiagonal = 0; // This index shows in what cells main diagonal is.
            int counterForSideDiagonal = matrix.GetLength(1) - 1; // This index shows in what cells side diagonal is.
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    if(j > counterForMainDiagonal && j > counterForSideDiagonal)
                    {
                        BackgroundColor = ConsoleColor.Blue;
                    }
                    Write("{0} ", matrix[i, j]);
                    ResetColor();
                }
                counterForMainDiagonal = counterForMainDiagonal + 1;
                counterForSideDiagonal = counterForSideDiagonal - 1;
                WriteLine(); // Pretty output.
            }
        }
        static int[,] CreatingMatrix(int i, int j) // Creates random matrix.
        {
            int[,] matrix = new int[i, j];
            Random rand = new Random();
            int a = 0;
            int b = 10;
            for(int k = 0; k < i; k++)
            {
                for(int o = 0; o < j; o++)
                {
                    matrix[k, o] = rand.Next(a, b);
                    a = a - 10;
                    b = b + 10;
                }
            }
            return matrix;
        }
        static bool CheckingInput(string i, string j, out int a, out int b) // function for cheking input.
        {
            int a1;
            bool isA1Integer = int.TryParse(i, out a1);
            int b1;
            bool isB1Integer = int.TryParse(j, out b1);
            if(isA1Integer == false || isB1Integer == false)
            {
                throw new Exception("Wrong input!");
            }
            else
            {
                a = a1;
                b = b1;
                if(a <= 0 || b <= 0)
                {
                    throw new Exception("Wrong input!"); 
                }
                else
                {
                    return true;
                }
            }
        }
        static int[] DetachArrayFromMatrix(int[,] matrix) // Detach sought elements of matrix in separate array.
        {
            /* In this part I count how many elements satisfy condition of the task
            in order to create an array that will be sorted.
            */
            int counterForMainDiagonal = 0;
            int counterForSideDiagonal = matrix.GetLength(1) - 1;
            int counter = 0;
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    if(j > counterForMainDiagonal && j > counterForSideDiagonal)  
                    {
                        counter++;
                    }
                }
                counterForMainDiagonal = counterForMainDiagonal + 1;
                counterForSideDiagonal = counterForSideDiagonal - 1;
            }
            int[] array = new int[counter]; // Creating an array that will be sorted.
            // In this part I fill the array that will be sorted with sought elements.
            int counterForMainDiagonal1 = 0;
            int counterForSideDiagonal1 = matrix.GetLength(1) - 1;
            int counter1 = 0;
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    if(j > counterForMainDiagonal1 && j > counterForSideDiagonal1)  
                    {
                        array[counter1] = matrix[i, j];
                        counter1++;
                    }
                }
                counterForMainDiagonal1 = counterForMainDiagonal1 + 1;
                counterForSideDiagonal1 = counterForSideDiagonal1 - 1;
            }
            return array;
        }
        static int[] QuickSort(int[] a, int lastIndex)  
        {
            int pivot = FindPivot(a, lastIndex);
            int index = FindIndexOfPivot(pivot, a);

            int buff = a[lastIndex];
            a[lastIndex] = pivot;
            a[index] = buff;
            int j = lastIndex - 1;
            int i = 0;
            while (true)
            {
                if (i > j)
                {
                    buff = a[i];
                    a[i] = pivot;
                    a[lastIndex] = buff;
                    lastIndex = i - 1;
                    break;
                }
                if (a[i] > pivot && a[j] < pivot)
                {
                    buff = a[i];
                    a[i] = a[j];
                    a[j] = buff;
                    i++;
                    j--;
                    continue;
                }
                if (a[i] < pivot)
                {
                    i++;
                }
                if (a[j] > pivot)
                {
                    j--;
                }
            }
            if (a.Length != 1)
            {
                int[] aRight = new int[a.Length - 1 - (lastIndex + 1)];
                for (i = 0; i < aRight.Length; i++)
                {
                    aRight[i] = a[lastIndex + 2 + i];
                }
                if (aRight.Length > 1)
                {
                    aRight = QuickSort(aRight, aRight.Length - 1);
                }

                int[] aLeft = new int[lastIndex + 1];
                for (i = 0; i < aLeft.Length; i++)
                {
                    aLeft[i] = a[i];
                }
                if (aLeft.Length > 1)
                {
                    aLeft = QuickSort(aLeft, aLeft.Length - 1);
                }

                j = 0;
                for (i = 0; i < a.Length; i++)
                {
                    if (i < aLeft.Length)
                    {
                        a[i] = aLeft[i];
                    }
                    else if (i > aLeft.Length)
                    {

                        a[i] = aRight[j];
                        j++;
                    }
                }
            }
            return a;
        }
        static int FindIndexOfPivot(int pivot, int[] a)
        {
            int index = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (pivot == a[i])
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        static int FindPivot(int[] a, int lastindex)
        {
            int first = a[0];
            int last = a[lastindex];
            int mid = a[(int)Round((decimal)(lastindex) / 2)];

            int pivot = Max(Min(first, mid), Min(Max(first, mid), last));
            return pivot;
        }
        static int[,] PutArrayInMatrix(int[] array, int[,] matrix)
        {
            int counter1 = array.Length - 1;
            int counter2 = 1;
            for(int j = matrix.GetLength(1) - 1; j >= 0; j--)
            {
                if(counter2 % 2 != 0)
                {
                    int counterForMainDiagonal1 = matrix.GetLength(1) - 1;
                    int counterForSideDiagonal1 = 0;
                    for(int i = matrix.GetLength(0) - 1; i >= 0; i--)
                    {
                        if(j > counterForMainDiagonal1 && j > counterForSideDiagonal1)  
                        {
                            matrix[i, j] = array[counter1];
                            counter1--;
                        }
                        counterForMainDiagonal1 = counterForMainDiagonal1 - 1;
                        counterForSideDiagonal1 = counterForSideDiagonal1 + 1;
                    }
                }
                else
                {
                    int counterForMainDiagonal1 = matrix.GetLength(1) - 1;
                    int counterForSideDiagonal1 = 0;  
                    for(int i = 0; i < matrix.GetLength(0); i++)
                    {
                        if(j > counterForMainDiagonal1 && j > counterForSideDiagonal1)  
                        {
                            matrix[i, j] = array[counter1];
                            counter1--;
                        }
                        counterForMainDiagonal1 = counterForMainDiagonal1 - 1;
                        counterForSideDiagonal1 = counterForSideDiagonal1 + 1;  
                    }
                }
                counter2++;
            }
            return matrix;
        }
    }
}
