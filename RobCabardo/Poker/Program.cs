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
            var theDealer = 0;
            Console.SetWindowSize(65, 25);
            Console.BufferWidth = 65;
            Console.BufferHeight = 25;

            Console.Title = "Claim Poker";

            var newhand = new DealCards();

            var quit = false;
            var userInput = " ";

            while (!quit)
            {
                while (!userInput.Equals("S") && !userInput.Equals("X"))
                {
                    Console.WriteLine("S - Start Poker Game");
                    Console.WriteLine("X - Exit Program");
                    userInput = Console.ReadLine().ToUpper();

                    Console.Clear();

                    if (userInput.Equals("S"))
                    {
                        Console.Write("Player Name: ");
                        string playerName = Console.ReadLine();
                        playerName = playerName.Remove(1).ToUpper() + playerName.Remove(0, 1).ToLower();

                        Console.Write("Number of Players (2-5): ");
                        var numberPlayers = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Ante size: $");
                        var anteSize = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Wallet size: $");
                        var walletSize = Convert.ToDouble(Console.ReadLine());

                        while (!quit)
                        {
                            if (theDealer == numberPlayers)
                                theDealer = 0;

                            theDealer++;

                            var selection = " ";
                            while (!selection.Equals("Y") && !selection.Equals("N"))
                            {
                                walletSize = newhand.Deal(playerName, numberPlayers, theDealer, walletSize, anteSize);

                                if (walletSize <= 0)
                                {
                                    Console.WriteLine("\nYou have no more money.");
                                    Console.ReadKey();
                                    System.Environment.Exit(1);
                                }
                                else
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