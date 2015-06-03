using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(65, 25);
            Console.BufferWidth = 65;
            Console.BufferHeight = 25;

            Console.Title = "Claim Poker";

            DealCards newhand = new DealCards();

            bool quit = false;
            string userInput = " ";

            while (!quit)
            {
                while (!userInput.Equals("S") && !userInput.Equals("X"))
                {
                    Console.WriteLine("S - Start Poker Game");
                    Console.WriteLine("X - Exit Program");
                    userInput = Console.ReadLine().ToUpper();

                    if (userInput.Equals("S"))
                    {
                        Console.Write("Player Name: ");
                        string playerName = Console.ReadLine().ToUpper();

                        while (!quit)
                        {
                            Console.Write("Number of Players (2-5): ");
                            int numberPlayers = Convert.ToInt32(Console.ReadLine());
                            newhand.Deal(playerName, numberPlayers);

                            string selection = " ";
                            while (!selection.Equals("Y") && !selection.Equals("N"))
                            {
                                Console.Write("\nPlay again? Y-N ");
                                selection = Console.ReadLine().ToUpper();
                                
                                Console.Clear();

                                if (selection.Equals("Y"))
                                {
                                    quit = false;
                                }
                                else if (selection.Equals("N"))
                                    quit = true;
                                else
                                    Console.WriteLine("Enter a valid response.");
                            }
                        }
                    }
                    else if (userInput.Equals("X"))
                        quit = true;
                    else
                        Console.WriteLine("Enter a valid response.");
                }
            }  
        }
    }
}