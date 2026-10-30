using System;

namespace ConsoleApp1
{
    internal class Program
    {
        private Thread _childThread;
        static void Main(string[] args)
        {
            // ThreadStart delThread = new ThreadStart(ChildThreadMethod);
            // Thread childThread = new Thread(delThread);
            // Thread.CurrentThread.Name = "Main Thread";
            // Console.WriteLine(Thread.CurrentThread.Name);
            // childThread.Start();

            while (true)
            {
               Menu();
               Console.Write("\nEnter choice (1-9, or 0 to exit): ");

               if (int.TryParse(Console.ReadLine(), out int userChoice))
               {
                   if (userChoice == 0)
                   {
                       Console.WriteLine("Exiting program...");
                       break;
                   }

                   Console.WriteLine("\n-------------------------------------------");
                   Choice(userChoice);
                   Console.WriteLine("-------------------------------------------\n");
               }
               else
               {
                   Console.WriteLine("Invalid input! Please enter a valid number.\n");
               }

               Console.WriteLine("Press Enter to continue...");
               Console.ReadLine();
               Console.Clear();
            }
        }
        public static void ChildThreadMethod()
        {
            Console.WriteLine("Calling child thread");
        }

        private static void Menu()
        {
            Console.WriteLine("=========== MENU ===========");
            Console.WriteLine("[1] System.Exception");
            Console.WriteLine("[2] System.ArithmeticException");
            Console.WriteLine("[3] System.OverflowException");
            Console.WriteLine("[4] System.ArgumentException");
            Console.WriteLine("[5] System.ArgumentNullException");
            Console.WriteLine("[6] System.IndexOutOfRangeException");
            Console.WriteLine("[7] System.OutOfMemoryException");
            Console.WriteLine("[8] System.StackOverflowException");
            Console.WriteLine("[9] System.FormatException");
            Console.WriteLine("[0] Exit");
        }

        private static void Choice(int choice)
        {
            switch (choice)
            {
                case 1:
                    try
                    {
                        Console.WriteLine("Triggering generic System.Exception...");
                        throw new Exception("Happy Birthday");
                    }
                    catch (Exception ex)
                    {
                        PrintException(ex);
                    }
                    break;

                case 2:
                    try
                    {
                        Console.WriteLine("Triggering ArithmeticException (Divide by Zero)...");
                        int zero = 0;
                        int result = 10 / zero;
                    }
                    catch (ArithmeticException ex)
                    {
                        PrintException(ex);
                    }
                    break;

                case 3:
                    try
                    {
                        Console.WriteLine("Triggering OverflowException...");
                        checked
                        {
                            int max = int.MaxValue;
                            int overflow = max + 1;
                        }
                    }
                    catch (OverflowException ex)
                    {
                        PrintException(ex);
                    }
                    break;

                case 4:
                    try
                    {
                        Console.WriteLine("Triggering ArgumentException...");
                        SetAge(-5);
                    }
                    catch (ArgumentException ex)
                    {
                        PrintException(ex);
                    }
                    break;

                case 5:
                    try
                    {
                        Console.WriteLine("Triggering ArgumentNullException...");
                        PrintName(null);
                    }
                    catch (ArgumentNullException ex)
                    {
                        PrintException(ex);
                    }
                    break;

                case 6:
                    try
                    {
                        Console.WriteLine("Triggering IndexOutOfRangeException...");
                        int[] numbers = { 1, 2, 3 };
                        int invalidElement = numbers[10];
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        PrintException(ex);
                    }
                    break;

                case 7:
                    try
                    {
                        Console.WriteLine("Triggering OutOfMemoryException...");
                        int[] hugeArray = new int[int.MaxValue];
                    }
                    catch (OutOfMemoryException ex)
                    {
                        PrintException(ex);
                    }
                    break;

                case 8:
                    try
                    {
                        Console.WriteLine("Triggering StackOverflowException (simulated via throw)...");
                        throw new StackOverflowException("Stack memory exhausted due to uncontrolled recursion.");
                    }
                    catch (StackOverflowException ex)
                    {
                        PrintException(ex);
                    }
                    break;

                case 9:
                    try
                    {
                        Console.WriteLine("Triggering FormatException...");
                        int number = int.Parse("NotANumber");
                    }
                    catch (FormatException ex)
                    {
                        PrintException(ex);
                    }
                    break;

                default:
                    Console.WriteLine("Option not recognized. Please choose from 1 to 9.");
                    break;
            }
        }

        private static void SetAge(int age)
        {
            if (age < 0)
                throw new ArgumentException("Age cannot be negative.", nameof(age));
        }

        private static void PrintName(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name), "Name cannot be null.");
        }

        private static void PrintException(Exception ex)
        {
            Console.WriteLine($"Caught Type : {ex.GetType().FullName}");
            Console.WriteLine($"Message     : {ex.Message}");
        }

    }
}