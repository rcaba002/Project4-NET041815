using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class DisplayCards
    {
        //displays suit and value of the card
        public static void DisplayCardSuitValue(Card card)
        {
            char cardSuit = ' ';

            switch (card.MySuit)
            {
                case Card.SUIT.HEARTS:
                    cardSuit = '♥';
                    break;
                case Card.SUIT.DIAMONDS:
                    cardSuit = '♦';
                    break;
                case Card.SUIT.CLUBS:
                    cardSuit = '♣';
                    break;
                case Card.SUIT.SPADES:
                    cardSuit = '♠';
                    break;
            }

            //display the suit and value of the card
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
