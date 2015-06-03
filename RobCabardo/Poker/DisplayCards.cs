using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class DisplayCards
    {
        // displays suit and value of card
        public static void DisplayCardSuitValue(Card card)
        {
            var cardSuit = ' ';

            switch (card.MySuit)
            {
                case Card.Suit.Hearts:
                    cardSuit = '♥';
                    break;
                case Card.Suit.Diamonds:
                    cardSuit = '♦';
                    break;
                case Card.Suit.Clubs:
                    cardSuit = '♣';
                    break;
                case Card.Suit.Spades:
                    cardSuit = '♠';
                    break;
            }

            // display suit and value of card
            if (cardSuit == '♦' || cardSuit == '♥')
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.BackgroundColor = ConsoleColor.White;
            Console.Write(card.MyValue);
            Console.Write(cardSuit);
            Console.ResetColor();
            Console.Write(" ");                
        }
    }
}
