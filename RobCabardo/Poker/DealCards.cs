using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class DealCards : DeckOfCards
    {
        private Card[] playerHand;
        private Card[] computerHand;
        private Card[] sortedPlayerHand;
        private Card[] sortedComputerHand;
        private List<Card[]> allComputerHands;
        public List<Card[]> allSortedComputerHands; 

        public DealCards()
        {
            playerHand = new Card[5];
            sortedPlayerHand = new Card[5];

            allComputerHands = new List<Card[]>();
            allSortedComputerHands = new List<Card[]>();
        }

        public void Deal(string playerName, int numberPlayers)
        {
            setUpDeck(); //create the deck of cards and shuffle them
            getHand(numberPlayers);
            sortCards(numberPlayers);
            displayCards(playerName);
            evaluateHands(playerName);
            allComputerHands.Clear();
            allSortedComputerHands.Clear();
        }

        public void getHand(int numComputerHands)
        {
            //5 cards for the player
            for (int i = 0; i < 5; i++)
                playerHand[i] = getDeck[i];

            int p = 5;

            for (int j = 1; j < numComputerHands; j++)
            {
                computerHand = new Card[5];

                int i = 0;
                //5 cards for the computer
                while (i < 5)
                {
                    computerHand[i] = getDeck[p];
                    p++;
                    i++;
                }

                allComputerHands.Add(computerHand);
            }
        }

        public void sortCards(int numComputerHands)
        {
            var queryPlayer = from hand in playerHand
                              orderby hand.MyValue
                              select hand;

            var index = 0;
            foreach (var element in queryPlayer.ToList())
            {
                sortedPlayerHand[index] = element;
                index++;
            }

            int m = 0;

            foreach (Card[] x in allComputerHands)
            {
                sortedComputerHand = new Card[5];

                var queryComputer = from hand in x
                                    orderby hand.MyValue
                                    select hand;

                index = 0;
                foreach (var element in queryComputer.ToList())
                {
                    sortedComputerHand[index] = element;
                    index++;
                }

                allSortedComputerHands.Insert(m, sortedComputerHand);
                m++;
            }
        }

        public void displayCards(string playerName)
        {
            Console.Clear();

            //display player hand
            Console.WriteLine(playerName + "'S HAND");
            for (int i = 0; i < 5; i++)
            {
                DisplayCards.DisplayCardSuitValue(sortedPlayerHand[i]);
            }

            int d = 1;
            foreach (Card[] x in allSortedComputerHands)
            {
                Console.WriteLine("\n\n" + "COMPUTER " + d + "'S HAND");
                foreach (Card p in x)
                {
                    DisplayCards.DisplayCardSuitValue(p);
                }
                d++;
            }
        }

        public void evaluateHands(string playerName)
        {
            //create player's evaluation objects (passing SORTED hand to constructor)
            HandEvaluator playerHandEvaluator = new HandEvaluator(sortedPlayerHand);
            
            //get the player's hand
            Hand playerHand = playerHandEvaluator.EvaluateHand();

            //display user hand
            Console.WriteLine("\n\n" + playerName + " has " + playerHand);

            int a = 1;

            Hand computerHand;
            string winner = " ";

            foreach (Card[] x in allSortedComputerHands)
            {
                HandEvaluator computerHandEvaluator = new HandEvaluator(x);
                computerHand = computerHandEvaluator.EvaluateHand();
                Console.WriteLine("COMPUTER " + a + " has " + computerHand);

                //evaluate hands
                if (playerHand > computerHand)
                {
                    winner = playerName;
                }
                else if (playerHand < computerHand)
                {
                    winner = "COMPUTER " + a;
                }
                else //if the hands are the same, evaluate the values
                {
                    //first evaluate who has higher value of poker hand
                    if (playerHandEvaluator.HandValues.Total > computerHandEvaluator.HandValues.Total)
                        winner = playerName;
                    else if (playerHandEvaluator.HandValues.Total < computerHandEvaluator.HandValues.Total)
                        winner = "COMPUTER " + a;
                    //if both hanve the same poker hand (for example, both have a pair of queens), 
                    //than the player with the next higher card wins
                    else if (playerHandEvaluator.HandValues.HighCard > computerHandEvaluator.HandValues.HighCard)
                        winner = playerName;
                    else if (playerHandEvaluator.HandValues.HighCard < computerHandEvaluator.HandValues.HighCard)
                        winner = "COMPUTER " + a;
                    else
                        winner = " ";
                }

                a++;
            }

            Console.WriteLine("\n" + winner + " WINS!");
        }
    }
}
