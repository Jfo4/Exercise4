﻿using System;
using System.Collections.Generic;
using System.Text;

// 1. Stack: som en hög med pannkakor, sist in - först ut
//    Det kan vara variabler som endast existerar när metod körs, men inte är åtkomlig efteråt.
//    Heap: kan vara variabler som är åtkomstbara "globalt". Objekt som är public.
// 2. Value Types är variabler av "enkel" typ: int, bool, char etc.
//    Reference Types är objekt: string, class, interface.
//    Reference Type lagras i Heap, medan Value Types kan lagras både på Stack eller Heap.
// 3. y.MyValue = 4 ändrar även x.MyValue till 4, då y = x gör att x och y "pekar" på samma objekt.

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()[0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParenthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method until the user inputs something to exit to main menu.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            // 2. Listan ser ut att öka från 0 till 4 vid första addering.
            // 3. Listan verkar öka med fyra när gränsen nåtts, 4 -> 8.
            // 4. "Det är gjort så". Förmodligen för att ökningen i sig tar resurser,
            //    bättre att lägga till fyra i taget.
            // 5. Nej.
            // 6. En egen array kan inte ökas (eller minskas).

            Console.Clear();
            bool exit = false;

            List<string> theList = new List<string>();
            do
            {
                Console.WriteLine("\nEnter some text.");
                Console.WriteLine("'+' -> add to the list, e.g. +abc");
                Console.WriteLine("'-' -> removes from the list, e.g. -abc");
                Console.WriteLine("'.' -> print list + stats.");
                Console.WriteLine("'q' to quit.");
                string input = Console.ReadLine();
                char nav = input[0]; // Prefix: used in switch
                string value = input.Substring(1); // Removes prefix: remaining text for adding or deleting in list.
                // Check if value == ""?

                switch (nav)
                {
                    case '+':
                        theList.Add(value);
                        break;
                    case '-':
                        // No check if "value" is in the list
                        theList.Remove(value);
                        break;
                    case '.': // Just to se if the list is populated.
                        foreach (var item in theList)
                        {
                            Console.WriteLine(item);
                        }
                        Console.WriteLine($"Objekt: {theList.Count}\nKapacitet: {theList.Capacity}\n");
                        break;
                    case 'q':
                    case 'Q':
                        exit = true; // Return to main menu.
                        break;
                    default:
                        Console.WriteLine("Invalid prefix!");
                        break;
                }
            } while (!exit);
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method until the user inputs something to exit to main menu.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
            Console.Clear();
            bool exit = false;

            Queue<string> myQ = new Queue<string>();
            do
            {
                Console.WriteLine("\nSvenskar älskar köer!");
                Console.WriteLine("'+' -> Namnge en person som ställer sig i kön, t ex +Kalle");
                Console.WriteLine("'-' -> Du behåller din plats i kön, men nu går den framåt!");
                Console.WriteLine("'.' -> Uppgifter om kön.");
                Console.WriteLine("'a' för att avsluta.");
                string input = Console.ReadLine();
                char nav = input[0]; // Prefix: used in switch
                string value = input.Substring(1); // Removes prefix: remaining text for adding or deleting in list.
                // Check if value == ""?

                switch (nav)
                {
                    case '+':
                        myQ.Enqueue(value);
                        break;
                    case '-':
                        string leave = myQ.Dequeue();
                        Console.WriteLine($"{leave} har lämnat kön");
                        break;
                    case '.':
                        Console.WriteLine($"Antal i kö: {myQ.Count}");
                        foreach (object o in myQ)
                            Console.WriteLine($"{o}");
                        break;
                    case 'a':
                    case 'A':
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val.");
                        break;
                }
            } while (!exit);
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            // 2. Det blir ju precis som vid bussen... Den som kommer sist går på först!

            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
            Console.Clear();
            Stack<string> pile = new Stack<string>();
            Console.WriteLine("Mata in en text så vänder jag på den:");
            string myInputString = Console.ReadLine();
            int myInputLength = myInputString.Length;
            for (int i = 0; i < myInputLength; i++)
            {
                pile.Push(myInputString[i].ToString());
            }
            for (int j = 0; j < myInputLength; j++)
            {
                Console.Write(pile.Pop());
            }
            Console.ReadLine();
        }

        static void CheckParenthesis()
        {
            /*
             * Use this method to check if the parenthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})], List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}], List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            var parenthesisOpen = "({[<";
            var parenthesisClose = ")}]>";

            var parenthesisStack = new Stack<char>();

            Console.Clear();
            Console.WriteLine("Parenthesis check. Please input a string with (), [], {}, and/or <>:");
            String parenthesisCheck = Console.ReadLine();

            StringBuilder sb = new StringBuilder(); // Parenthesis check: fails/passes

            for (int i = 0; i < parenthesisCheck.Length; i++)
            {
                char testChar = parenthesisCheck[i]; // One char at a time
                if (parenthesisOpen.IndexOf(testChar) >= 0) // Opening parenthesis?
                    parenthesisStack.Push(testChar); // Put on stack
                else if (parenthesisClose.IndexOf(testChar) >= 0)
                {
                    if (parenthesisStack.Count == 0)
                    {
                        // Closing parenthesis, but stack is empty.
                        sb.Append($"fails, position {i+1}.\nClosing parenthesis before opening");
                        break;
                    }
                    // Matching opening/closing parenthesis?
                    else if (parenthesisOpen.IndexOf(parenthesisStack.Peek()) ==
                        parenthesisClose.IndexOf(testChar))
                    {
                        // ...yes, remove from stack
                        parenthesisStack.Pop();
                    }
                    else
                    {
                        // Closing parenthesis didn't match opening parenthesis
                        sb.Append($"fails, position {i + 1}.\nMismatching parenthesis");
                        break;
                    }
                }
                // End of text, but stack not empty? Closing parenthesis missing.
                if (parenthesisCheck.Length - 1 == i && parenthesisStack.Count > 0)
                {
                    sb.Append($"fails, position {i + 1}.\nMissing closing parenthesis");
                    break;
                }
            }
            Console.WriteLine($"Parenthesis check {(sb.Length > 0 ? sb.ToString() : "passes")}.");
            Console.ReadKey();
        }
    }
}
