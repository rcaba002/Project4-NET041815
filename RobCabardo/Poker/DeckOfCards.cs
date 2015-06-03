using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class DeckOfCards : Card
    {
        const int NumOfCards = 52; // total number of cards
        private readonly Card[] _deck; // array of all cards

        public DeckOfCards()
        {
            _deck = new Card[NumOfCards];
        }

        public Card[] GetDeck { get { return _deck; } } // get current deck

        // create deck of 52 cards: 4 suits, 13 Values each
        public void SetUpDeck()
        {
            var i = 0;

            foreach (Suit s in Enum.GetValues(typeof(Suit)))
            {
                foreach (Value v in Enum.GetValues(typeof(Value)))
                {
                    _deck[i] = new Card { MySuit = s, MyValue = v };
                    i++;
                }
            }

            ShuffleCards();
        }

        // shuffle deck
        public void ShuffleCards()
        {
            var rand = new Random();

            // run shuffle one thousand times
            for (var shuffleTimes = 0; shuffleTimes < 1000; shuffleTimes++)
            {
                for (var i = 0; i < NumOfCards; i++)
                {
                    // swap cards
                    var secondCardIndex = rand.Next(13);
                    var temp = _deck[i];
                    _deck[i] = _deck[secondCardIndex];
                    _deck[secondCardIndex] = temp;
                }
            }
        }
    }
}
