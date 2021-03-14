using System;
using static System.Console;

namespace lab6
{
    class Queue
    {
        private int[] _items;
        private int _size; 
        public Queue()
        {
            this._items = new int[16];
            this._size = 0;
        }
        public int GetHead()
        {
            if(this.IsEmpty() == true)
            {
                throw new Exception("Queue is empty!");
            }
            return this._items[0];
        }
        public int GetSize()
        {
            return this._size;
        }
        public int GetTail()
        {
            if(this.IsEmpty() == true)
            {
                throw new Exception("Queue is empty!");
            }
            return this._items[_size - 1];
        }
        public bool IsEmpty()
        {
            if(this._size != 0)
            {
                return false;
            }
            return true;
        }
        public void Enqueue(int newElement)
        {
            if(this.IsFull() == true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                WriteLine("Queue is full! All elements will be deleted!");
                Console.ResetColor(); 
                this.DestroyQueue();
            }
            this._items[_size] = newElement;
            this._size ++; 
        }
        public void Dequeue()
        {
            if(this.IsEmpty() == true)
            {
                throw new Exception("Queue is empty!");
            }
            for(int i = 0; i < this._size - 1; i ++)
            {
                this._items[i] = this._items[i + 1];
            }
            this._size --;
        }
        public void DestroyQueue()
        {
            for(int i = 0; i < this._size; i++)
            {
                this._items[i] = 0;
            }
            this._size = 0;
        }
        public int GetElement(int index)
        {
            if(index < 0 || index > this._size - 1)
            {
                throw new Exception("Wrong index!");
            }
            return this._items[index];
        }
        private bool IsFull()
        {
            if(this._size == this._items.Length)
            {
                return true;
            }
            return false;
        }
    }
    class Program
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            WriteLine("Welcome!");
            WriteLine("Queue can contain only integer elemets.");
            WriteLine("If you want to see an example, press A, if you want to input your own values, press B.");
            WriteLine("Capacity of the ARRAY is 16, so there can be only 16 elements in the queue!");
            WriteLine("If queue will be full and you will try to add new elements, all elements will be deleted!");
            Console.ResetColor();
            ConsoleKeyInfo keyInfo;
            while(true)
            {
                keyInfo = ReadKey();
                WriteLine();
                if(keyInfo.Key == ConsoleKey.A)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    WriteLine("Let's Create a new queue:");
                    Console.ResetColor();
                    Queue queue = new Queue();
                    PrintQueue(queue);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Write("Use method IsEmpy: ");
                    Console.ResetColor();
                    WriteLine(queue.IsEmpty());
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    WriteLine("As u can see, queue is empty. Now, let's add some elements: 1, 2 and 100:");
                    Console.ResetColor();
                    queue.Enqueue(1);
                    queue.Enqueue(2);
                    queue.Enqueue(100);
                    PrintQueue(queue);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Write("Use method IsEmpy: ");
                    Console.ResetColor();
                    WriteLine(queue.IsEmpty());
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    WriteLine("Now let's delete head element:");
                    Console.ResetColor();
                    queue.Dequeue();
                    PrintQueue(queue);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    WriteLine("Now let's use methods GetHead and GetTail:");
                    Write("Head: ");
                    Console.ResetColor();
                    WriteLine(queue.GetHead());
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Write("Tail: ");
                    Console.ResetColor();
                    WriteLine(queue.GetTail());
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    WriteLine("Now let's use method GetSize:");
                    Write("Size: ");
                    Console.ResetColor();
                    WriteLine(queue.GetSize());
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    WriteLine("Add 17 new elemets in the queue:");
                    for(int i = 0; i < 17; i++)
                    {
                        queue.Enqueue(i);
                    }
                    PrintQueue(queue);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    WriteLine("Now let's use method GetSize:");
                    Write("Size: ");
                    Console.ResetColor();
                    WriteLine(queue.GetSize());
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    WriteLine("Finally, let's destroy the queue:");
                    queue.DestroyQueue();
                    PrintQueue(queue);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Write("Use method IsEmpy: ");
                    Console.ResetColor();
                    WriteLine(queue.IsEmpty());
                    Console.ForegroundColor = ConsoleColor.Green;
                    WriteLine("Thanks for using! Bye!");
                    Console.ResetColor();
                    break;
                }
                else if(keyInfo.Key == ConsoleKey.B)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    WriteLine("Now u can input yout values.");
                    WriteLine("Be careful! If you input 0, programm will stop!");
                    Console.ResetColor();
                    Queue queue = new Queue();
                    while(true)
                    {
                       Console.ForegroundColor = ConsoleColor.Green;
                       WriteLine("Input new value:");
                       Console.ResetColor();
                       string n = ReadLine();
                       bool input = ProcessingInput(n);
                       if(input == false)
                       {
                           Console.ForegroundColor = ConsoleColor.Red;
                           WriteLine("Wrong input! Input another value!");
                           Console.ResetColor();
                       }
                       else
                       {
                           int newValue = int.Parse(n);
                           if(newValue == 0)
                           {
                               break;
                           }
                           else
                           {
                               queue.Enqueue(newValue);
                               PrintQueue(queue);
                           }
                       }
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    WriteLine("Thanks for using! Bye!");
                    Console.ResetColor();
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    WriteLine("Wrong button! Press A, if you want to input your own values, press B");
                    Console.ResetColor();
                }
            }
        }
        static void PrintQueue(Queue queue)
        {   
            Console.ForegroundColor = ConsoleColor.Blue;
            WriteLine("Here is a current queue:");
            for(int i = 0; i < queue.GetSize(); i++)
            {
                Write("{0} ", queue.GetElement(i));
            }
            Console.ResetColor();
            WriteLine();
        }
        static bool ProcessingInput(string a)
        {
            int newValue;
            bool isCorrect = int.TryParse(a, out newValue);
            if(isCorrect == false)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }
    }
}
