using System;
using static System.Console;
using static System.Math;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Input day 1");
            int d1 = int.Parse(ReadLine());
            WriteLine("Input day 2");
            int d2 = int.Parse(ReadLine());
            WriteLine("Input month 1");
            int m1 = int.Parse(ReadLine());
            WriteLine("Input month 2");
            int m2 = int.Parse(ReadLine());
            WriteLine("Input year 1");
            int y1 = int.Parse(ReadLine());
            WriteLine("Input year 2");
            int y2 = int.Parse(ReadLine());
            int maxYear = 0;
            int minYear = 0;
            int numberOfDaysInFirstDate = 0;
            int numberOfDaysInSecondDate = 0;
            int numberOfDaysBetweenDates = 0;
            int numberOfYearsBetweenDates = 0;
            // checking the input data
            if (d1 <= 0 || d1 > 31 || d2 <=0 || d2 > 31 || m1 <= 0 || m1 > 12 || m2 <=0 || m2 > 12 || y1 <= 0 || y2 <= 0)
            {
                WriteLine("Wrong date");
            }
            else if ((m1 == 4 || m1 == 6 || m1 == 9 || m1 == 11) && d1 == 31)
            {
                WriteLine("Wrong date");
            }
            else if ((m2 == 4 || m2 == 6 || m2 == 9 || m2 == 11) && d2 == 31)
            {
                WriteLine("Wrong date");
            }
            else if ((m1 == 2 && d1 > 29) || (m2 == 2 && d2 > 29))
            {
                WriteLine("Wrong date");
            }
            else if (((y1 % 4 != 0) || ((y1 % 4 == 0) && (y1 % 100 == 0) && (y1 % 400 != 0))) && ((m1 == 2) && (d1 == 29)))
            {
                WriteLine("Wrong date");
            }
            else if (((y2 % 4 != 0) || ((y2 % 4 == 0) && (y2 % 100 == 0) && (y2 % 400 != 0))) && ((m2 == 2) && (d2 == 29)))
            {
                WriteLine("Wrong date");
            }
            //main part
            else  
            //finding min and max year 
            { 
                if (y2 > y1)
                {
                    maxYear = y2;
                    minYear = y1;
                }
                else if (y2 == y1)
                {
                    maxYear = 0;
                    minYear = 0;
                    numberOfYearsBetweenDates = 0;
                }
                else
                {
                    maxYear = y1;
                    minYear = y2;
                }
                //calculating amount of days in first date(year)
                int counter = 1;
                while (counter < y1)
                {
                    numberOfDaysInFirstDate += 365;
                    if (((counter % 4 == 0) && (counter % 100 != 0)) || (counter % 400 == 0))
                    {
                        numberOfDaysInFirstDate += 1;
                    }
                    counter += 1;
                }
                //calculating amount of days in second date(year)
                int counter1 = 1;
                while (counter1 < y2)
                {
                    numberOfDaysInSecondDate += 365;
                    if (((counter1 % 4 == 0) && (counter1 % 100 != 0)) || (counter1 % 400 == 0))
                    {
                        numberOfDaysInSecondDate += 1;
                    }
                    counter1 += 1;
                }
                //calculating amount of days in first date(month and day)
                int[] daysInMonth = new int[] {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
                int counter2 = 0;
                while (counter2 < m1 - 1)
                {
                    numberOfDaysInFirstDate += daysInMonth[counter2];
                    counter2 = counter2 + 1;
                }
                numberOfDaysInFirstDate += d1;
                if ((((y1 % 4 == 0) && (y1 % 100 != 0)) || (y1 % 400 == 0)) &&  (m1 > 2))
                {
                    numberOfDaysInFirstDate += 1;
                }
                //calculating amount of days in second date(month and day)
                int counter3 = 0;
                while (counter3 < m2 - 1)
                {
                    numberOfDaysInSecondDate += daysInMonth[counter3];
                    counter3 = counter3 + 1;
                }
                numberOfDaysInSecondDate += d2;
                if ((((y2 % 4 == 0) && (y2 % 100 != 0)) || (y2 % 400 == 0)) &&  (m2 > 2))
                {
                    numberOfDaysInSecondDate += 1;
                }
                numberOfDaysBetweenDates =  Abs(numberOfDaysInSecondDate - numberOfDaysInFirstDate);
                //counting number of years between dates
                if (maxYear == 0)
                {
                    WriteLine(numberOfDaysBetweenDates);
                    WriteLine(numberOfYearsBetweenDates);
                }
                else
                {
                    int counter4 = numberOfDaysBetweenDates;
                    while (counter4 >= 365)
                    {
                        if (((minYear % 4 == 0) && (minYear % 100 != 0)) || (minYear % 400 == 0))
                        {
                            counter4 -= 366;
                            minYear += 1;
                            numberOfYearsBetweenDates += 1;
                        }
                        else
                        {
                            counter4 -= 365;
                            minYear += 1;
                            numberOfYearsBetweenDates += 1;
                        }
                    }
                    WriteLine(numberOfDaysBetweenDates);
                    WriteLine(numberOfYearsBetweenDates);
                }
            }
        }    
    }
}
