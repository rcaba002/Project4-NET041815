using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Poker
{
    class DealCards : DeckOfCards
    {
        private readonly Card[] _playerHand;
        private Card[] _computerHand;
        private readonly Card[] _sortedPlayerHand;
        private Card[] _sortedComputerHand;
        private readonly List<Card[]> _allComputerHands;
        private readonly List<Card[]> _allSortedComputerHands; 

        public DealCards()
        {
            _playerHand = new Card[5];
            _sortedPlayerHand = new Card[5];

            _allComputerHands = new List<Card[]>();
            _allSortedComputerHands = new List<Card[]>();
        }

        public double Deal(string playerName, int numberPlayers, int theDealer, double walletSize, int antesize)
        {
            SetUpDeck(); // create deck and shuffle
            GetHand(numberPlayers);
            SortCards();
            var newWallet = DisplayCardsFaceDown(playerName, theDealer, walletSize, antesize);
            newWallet = PlaceBets(theDealer, newWallet);
            DisplayCards(playerName, numberPlayers, theDealer, newWallet);
            EvaluateHands(playerName);
            _allComputerHands.Clear();
            _allSortedComputerHands.Clear();

            return newWallet;
        }

        public void GetHand(int numComputerHands)
        {
            // 5 cards for player
            for (int i = 0; i < 5; i++)
                _playerHand[i] = GetDeck[i];

            var p = 5;

            for (var j = 1; j < numComputerHands; j++)
            {
                _computerHand = new Card[5];

                var i = 0;
                // 5 cards for computer
                while (i < 5)
                {
                    _computerHand[i] = GetDeck[p];
                    p++;
                    i++;
                }

                _allComputerHands.Add(_computerHand);
            }
        }

        public void SortCards()
        {
            var queryPlayer = from hand in _playerHand
                              orderby hand.MyValue
                              select hand;

            var index = 0;
            foreach (var element in queryPlayer.ToList())
            {
                _sortedPlayerHand[index] = element;
                index++;
            }

            foreach (var x in _allComputerHands)
            {
                _sortedComputerHand = new Card[5];

                var queryComputer = from hand in x
                                    orderby hand.MyValue
                                    select hand;

                index = 0;
                foreach (var element in queryComputer.ToList())
                {
                    _sortedComputerHand[index] = element;
                    index++;
                }

                _allSortedComputerHands.Add(_sortedComputerHand);
            }

            Console.Clear();
        }

        public double DisplayCardsFaceDown(string playerName, int theDealer, double walletSize, int antesize)
        {
            var newWallet = walletSize - antesize;

            if (theDealer == 1)
            {
                Console.Write(playerName + "'s Hand");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" (DEALER)");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(" {0:C0}", newWallet);
                Console.ResetColor();
            }
            else
            {
                Console.Write(playerName + "'s Hand");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(" {0:C0}", newWallet);
                Console.ResetColor();
            }

            for (var i = 0; i < 5; i++)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("  ?  ");
                Console.ResetColor();
                Console.Write(" ");
            }

            var d = 1;
            foreach (var x in _allSortedComputerHands)
            {
                if (theDealer == d + 1)
                {
                    Console.Write("\n\n" + "Computer " + d + "'s Hand");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" (DEALER)");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(" {0:C0}", newWallet);
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("\n\n" + "Computer " + d + "'s Hand");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(" {0:C0}", newWallet);
                    Console.ResetColor();
                }

                foreach (var p in x)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("  ?  ");
                    Console.ResetColor();
                    Console.Write(" ");
                }

                d++;
            }

            return newWallet;
        }

        public double PlaceBets(int theDealer, double walletSize)
        {
            double bet = 0;

            if (walletSize <= 0)
            {
                Console.WriteLine("\n\nYou have no money to bet.");
            }
            else
            {
                if (theDealer == 1)
                {
                    Console.Write("\n\nHow much do you want to bet? ");
                    bet = Convert.ToDouble(Console.ReadLine());
                }
            }

            var newWallet = walletSize - bet;

            Console.ReadKey();
            return newWallet;
        }

        public void DisplayCards(string playerName, int numberPlayers, int theDealer, double newWallet)
        {
            Console.Clear();

            if (theDealer == 1)
            {
                Console.Write(playerName + "'s Hand");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" (DEALER)");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(" {0:C0}", newWallet);
                Console.ResetColor();
            }
            else
            {
                Console.Write(playerName + "'s Hand");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(" {0:C0}", newWallet);
                Console.ResetColor();
            }

            for (var i = 0; i < 5; i++)
            {
                Poker.DisplayCards.DisplayCardSuitValue(_sortedPlayerHand[i]);
            }

            var d = 1;
            foreach (var x in _allSortedComputerHands)
            {
                if (theDealer == d + 1)
                {
                    Console.Write("\n\n" + "Computer " + d + "'s Hand");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" (DEALER)");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(" {0:C0}", newWallet);
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("\n\n" + "Computer " + d + "'s Hand");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(" {0:C0}", newWallet);
                    Console.ResetColor();
                }

                foreach (var p in x)
                {
                    Poker.DisplayCards.DisplayCardSuitValue(p);
                }

                d++;
            }
        }

        public void EvaluateHands(string playerName)
        {
            // create player evaluation objects (passing SORTED hand to constructor)
            HandEvaluator playerHandEvaluator = new HandEvaluator(_sortedPlayerHand);
            
            // get player hand
            var playerhand = playerHandEvaluator.EvaluateHand();

            // display player hand
            Console.WriteLine("\n\n" + playerName + " has " + playerhand);

            var a = 1;

            var compHand = Hand.Nothing;
            var compTotal = 0;
            var compHighCard = 0;

            var compWinner = " ";
            var winner = " ";

            foreach (var x in _allSortedComputerHands)
            {
                var computerHandEvaluator = new HandEvaluator(x);
                var computerhand = computerHandEvaluator.EvaluateHand();
                Console.WriteLine("Computer " + a + " has " + computerhand);

                if (computerhand > compHand)
                {
                    compHand = computerhand;
                    compTotal = computerHandEvaluator.HandValues.Total;
                    compHighCard = computerHandEvaluator.HandValues.HighCard;
                    compWinner = string.Format("Computer {0} Wins!", a);
                }
                else if (compHand > computerhand)
                {
                    compHand = compHand;
                    compTotal = compTotal;
                    compHighCard = compHighCard;
                }
                else
                {
                    if (computerHandEvaluator.HandValues.Total > compTotal)
                    {
                        compHand = computerhand;
                        compTotal = computerHandEvaluator.HandValues.Total;
                        compHighCard = computerHandEvaluator.HandValues.HighCard;
                        compWinner = string.Format("Computer {0} Wins!", a);
                    }
                    else if (compTotal > computerHandEvaluator.HandValues.Total)
                    {
                        compHand = compHand;
                        compTotal = compTotal;
                        compHighCard = compHighCard;
                    }
                    else
                    {
                        if (computerHandEvaluator.HandValues.HighCard > compHighCard)
                        {
                            compHand = computerhand;
                            compTotal = computerHandEvaluator.HandValues.Total;
                            compHighCard = computerHandEvaluator.HandValues.HighCard;
                            compWinner = string.Format("Computer {0} Wins!", a);
                        }
                        else if (compHighCard > computerHandEvaluator.HandValues.HighCard)
                        {
                            compHand = compHand;
                            compTotal = compTotal;
                            compHighCard = compHighCard;
                        }
                        else // v2.0 will check 2nd highest card
                        {
                            compHand = compHand;
                            compTotal = compTotal;
                            compHighCard = compHighCard;
                            compWinner = string.Format("It's a Draw!");
                        }
                    }
                }

                a++;
            }

            if (playerhand > compHand)
            {
                winner = string.Format("{0} Wins!", playerName);
            }
            else if (compHand > playerhand)
            {
                winner = compWinner;
            }
            else
            {
                if (playerHandEvaluator.HandValues.Total > compTotal)
                {
                    winner = string.Format("{0} Wins!", playerName);
                }
                else if (compTotal > playerHandEvaluator.HandValues.Total)
                {
                    winner = compWinner;
                }
                else
                {
                    if (playerHandEvaluator.HandValues.HighCard > compHighCard)
                    {
                        winner = string.Format("{0} Wins!", playerName);
                    }
                    else if (compHighCard > playerHandEvaluator.HandValues.HighCard)
                    {
                        winner = compWinner;
                    }
                    else // v2.0 will check 2nd highest card
                    {
                        winner = string.Format("It's a Draw!");
                    }
                }
            }

            Console.WriteLine("\n" + winner);
        }
    }
}
