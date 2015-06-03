using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class Card
    {
        public enum Suit
        {
            Hearts,
            Spades,
            Diamonds,
            Clubs
        }

        public enum Value
        {
            TWO = 2, THREE, FOUR, FIVE, SIX, SEVEN,
            EIGHT, NINE, TEN, JACK, QUEEN, KING, ACE
        }

        //properties
        public Suit MySuit { get; set; }
        public Value MyValue { get; set; }
    }
}
