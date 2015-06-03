using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void Deal(string playerName, int numberPlayers)
        {
            SetUpDeck(); // create deck and shuffle
            GetHand(numberPlayers);
            SortCards();
            DisplayCards(playerName);
            EvaluateHands(playerName);

            _allComputerHands.Clear();
            _allSortedComputerHands.Clear();
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
        }

        public void DisplayCards(string playerName)
        {
            Console.Clear();

            // display player hand
            Console.WriteLine(playerName + "'S HAND");
            for (var i = 0; i < 5; i++)
            {
                Poker.DisplayCards.DisplayCardSuitValue(_sortedPlayerHand[i]);
            }

            var d = 1;
            foreach (var x in _allSortedComputerHands)
            {
                Console.WriteLine("\n\n" + "COMPUTER " + d + "'S HAND");
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
            var winner = " ";

            foreach (var x in _allSortedComputerHands)
            {
                var computerHandEvaluator = new HandEvaluator(x);
                var computerhands = computerHandEvaluator.EvaluateHand();
                Console.WriteLine("COMPUTER " + a + " has " + computerhands);
                a++;
            }

            Console.WriteLine("\n" + winner + " WINS!");
        }
    }
}
