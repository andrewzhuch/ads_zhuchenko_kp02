using System;
using static System.Console;
using System.Collections.Generic;

namespace lab7
{
    class Program
    {
        static void Main()
        {
            WriteLine("Hello!");
            while (true)
            {
                WriteLine("0 - see example");
                WriteLine("1 - work with your own values");
                WriteLine("9 - exit");
                WriteLine("Input your command:");
                string command = ReadLine();
                if(command == "0")
                {
                    ProcessingExample();
                }
                else if(command == "9")
                {
                    break;
                }
                else if(command == "1")
                {
                    Hashtable table = new Hashtable();
                    DoctorsPatiensHashTable doctorsTable = new DoctorsPatiensHashTable();
                    int ID = 35900;
                    while(true)
                    {
                        WriteLine("0 - add new patient");
                        WriteLine("1 - find patient");
                        WriteLine("2 - remove patient");
                        WriteLine("3 - print table");
                        WriteLine("4 - find doctor's patiens");
                        WriteLine("5 - exit");
                        WriteLine("Input your command:");
                        string command1 = ReadLine();
                        if(command1 == "5")
                        {
                            break;
                        }
                        else if(command1 == "0")
                        {
                            ProcessingCommandAdd(table, doctorsTable, ID);
                            ID++;
                        }
                        else if(command1 == "1")
                        {
                            ProcessingCommandFindPatient(table);
                        }
                        else if(command1 == "3")
                        {
                            table.PrintTable();
                        }
                        else if(command1 == "4")
                        {
                            PrcoessingCommandFindDoctrosPatients(doctorsTable);
                        }
                        else if(command1 == "2")
                        {
                            ProcessingCommandRemove(table, doctorsTable);
                        }
                        else
                        {
                            WriteLine("Wrong command");
                        }
                    }
                }
                else
                {
                    WriteLine("Wrong command!");
                }
            }
        }
        static void ProcessingCommandAdd(Hashtable table, DoctorsPatiensHashTable doctorsTable, int ID)
        {
            WriteLine("Firstname:");
            Key key = new Key();
            key.firstName = ReadLine();
            WriteLine("Lastname:");
            key.lastName = ReadLine();
            Value value = new Value();
            WriteLine("Doctor:");
            string doctor = ReadLine();
            List<Entry> list = doctorsTable.FindPatiens(doctor);
            while(list != null && list.Count == 5)
            {
                WriteLine("This doctor doesnt have free places.Input another.");
                doctor = ReadLine();
                list = doctorsTable.FindPatiens(doctor);
            }
            value.familyDoctor = doctor;
            WriteLine("Address:");
            value.patientID = ID;
            value.address = ReadLine();
            Entry entry = new Entry(key,value);
            table.InsertEntry(entry);
            doctorsTable.Addpatient(entry);
        }
        static void ProcessingCommandRemove(Hashtable table, DoctorsPatiensHashTable doctorsTable)
        {
            WriteLine("Firstname:");
            Key key = new Key();
            key.firstName = ReadLine();
            WriteLine("Lastname:");
            key.lastName = ReadLine();
            Entry entry = table.FindEntry(key);
            if(entry == null)
            {
                WriteLine("There is no such entry");
                return;
            }
            doctorsTable.RemovePatient(entry);
            table.RemoveEntry(key);
        }
        static void ProcessingCommandFindPatient(Hashtable table)
        {
            WriteLine("Firstname:");
            Key key = new Key();
            key.firstName = ReadLine();
            WriteLine("Lastname:");
            key.lastName = ReadLine();
            if(table.FindEntry(key) == null)
            {
                WriteLine("There is no such patient");
            }
            else
            {
                WriteLine(table.FindEntry(key));
            }
        }
        static void PrcoessingCommandFindDoctrosPatients(DoctorsPatiensHashTable doctorsTable)
        {
            WriteLine("Doctor:");
            List<Entry> list = doctorsTable.FindPatiens(ReadLine());
            if(list == null)
            {
                WriteLine("There is no such docotr");
                return;
            }
            else
            {
                for(int i = 0; i < list.Count; i++)
                {
                    WriteLine(list[i]);
                }
            }
        }
        static void ProcessingExample()
        {
            int IDcounter = 35900;
            Hashtable table = new Hashtable();
            DoctorsPatiensHashTable doctorsTable = new DoctorsPatiensHashTable();
            WriteLine("Adding some new values.");
            WriteLine("First value: <firstName-Igor; lastName-Romanenko; Doctor-Anton Kuznetcov; address-Lenina street>");
            Key key0 = new Key();
            key0.firstName = "Igor";
            key0.lastName = "Romanenko";
            Value value0 = new Value();
            value0.patientID = IDcounter;
            IDcounter++;
            value0.address = "Lenina street";
            value0.familyDoctor = "Anton Kuznetcov";
            Entry entry0 = new Entry(key0, value0);
            table.InsertEntry(entry0);
            doctorsTable.Addpatient(entry0);
            WriteLine("Second value: <firstName-Petr; lastName-Ivanov; Doctor-Anton Kuznetcov; address-Nizhniy val street>");
            Key key1 = new Key();
            key1.firstName = "Petr";
            key1.lastName = "Ivanov";
            Value value1 = new Value();
            value1.patientID = IDcounter;
            IDcounter++;
            value1.address = "Nizhniy val street";
            value1.familyDoctor = "Anton Kuznetcov";
            Entry entry1 = new Entry(key1, value1);
            table.InsertEntry(entry1);
            doctorsTable.Addpatient(entry1);
            WriteLine("Here is the table:");
            table.PrintTable();
            WriteLine("And here is a table of Anton Kuznetcov's patiens:");
            List<Entry> list = doctorsTable.FindPatiens("Anton Kuznetcov");
            for(int i = 0; i < list.Count; i++)
            {
                WriteLine(list[i]);
            }
            WriteLine("Now remove first patient");
            table.RemoveEntry(key0);
            doctorsTable.RemovePatient(entry0);
            WriteLine("Here is new table:");
            table.PrintTable();
            WriteLine("And here is new table of Anton Kuznetcov's patiens:");
            List<Entry> list1 = doctorsTable.FindPatiens("Anton Kuznetcov");
            for(int i = 0; i < list1.Count; i++)
            {
                WriteLine(list1[i]);
            }
            WriteLine("Finally, lets find a value using key:");
            WriteLine(table.FindEntry(key1));
        }
    }
}
