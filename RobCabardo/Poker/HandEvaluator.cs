using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public enum Hand
    {
        Nothing,
        OnePair,
        TwoPairs,
        ThreeKind,
        Straight,
        Flush,
        FullHouse,
        FourKind
    }

    public struct HandValue
    {
        public int Total { get; set; }
        public int HighCard { get; set; }
    }

    class HandEvaluator : Card
    {
        private int _heartsSum;
        private int _diamondSum;
        private int _clubSum;
        private int _spadesSum;
        private readonly Card[] _cards;
        private HandValue _handValue;

        public HandEvaluator(Card[] sortedHand)
        {
            _heartsSum = 0;
            _diamondSum = 0;
            _clubSum = 0;
            _spadesSum = 0;
            _cards = new Card[5];
            Cards = sortedHand;
            _handValue = new HandValue();
        }

        public HandValue HandValues
        {
            get { return _handValue; }
            set { _handValue = value; }
        }

        public Card [] Cards
        {
            get { return _cards; }
            set
            {
                _cards[0] = value[0];
                _cards[1] = value[1];
                _cards[2] = value[2];
                _cards[3] = value[3];
                _cards[4] = value[4];
            }
        }

        public Hand EvaluateHand()
        {
            // get the number of each suit on hand
            GetNumberOfSuit();

            if (FourOfKind())
                return Hand.FourKind;
            if (FullHouse())
                return Hand.FullHouse;
            if (Flush())
                return Hand.Flush;
            if (Straight())
                return Hand.Straight;
            if (ThreeOfKind())
                return Hand.ThreeKind;
            if (TwoPairs())
                return Hand.TwoPairs;
            if (OnePair())
                return Hand.OnePair;

            // if hand is nothing, than player with highest card wins
            _handValue.HighCard = (int)_cards[4].MyValue;
            return Hand.Nothing;
        }

        private void GetNumberOfSuit()
        {
            foreach (var element in Cards)
            {
                switch (element.MySuit)
                {
                    case Card.Suit.Hearts:
                        _heartsSum++;
                        break;
                    case Card.Suit.Diamonds:
                        _diamondSum++;
                        break;
                    case Card.Suit.Clubs:
                        _clubSum++;
                        break;
                    case Card.Suit.Spades:
                        _spadesSum++;
                        break;
                }
            }
        }

        private bool FourOfKind()
        {
            // if first 4 cards, add values of four cards and last card is highest
            if(_cards[0].MyValue == _cards[1].MyValue && _cards[0].MyValue == _cards[2].MyValue && _cards[0].MyValue == _cards[3].MyValue)
            {
                _handValue.Total = (int)_cards[1].MyValue * 4;
                _handValue.HighCard = (int)_cards[4].MyValue;
                return true;
            }
            if (_cards[1].MyValue == _cards[2].MyValue && _cards[1].MyValue == _cards[3].MyValue && _cards[1].MyValue == _cards[4].MyValue)
            {
                _handValue.Total = (int)_cards[1].MyValue * 4;
                _handValue.HighCard = (int)_cards[0].MyValue;
                return true;
            }

            return false;
        }

        private bool FullHouse()
        {
            // first three cars and last two cards are same value
            // first two cards, and last three cards are same value
            if ((_cards[0].MyValue == _cards[1].MyValue && _cards[0].MyValue == _cards[2].MyValue && _cards[3].MyValue == _cards[4].MyValue) ||
                (_cards[0].MyValue == _cards[1].MyValue && _cards[2].MyValue == _cards[3].MyValue && _cards[2].MyValue == _cards[4].MyValue))
            {
                _handValue.Total = (int)(_cards[0].MyValue) + (int)(_cards[1].MyValue) + (int)(_cards[2].MyValue) +
                    (int)(_cards[3].MyValue) + (int)(_cards[4].MyValue);
                return true;
            }

            return false;
        }

        private bool Flush()
        {
            // if all suits are same
            if (_heartsSum == 5 || _diamondSum == 5 || _clubSum == 5 || _spadesSum == 5)
            {
                // if flush, player with higher cards win
                // whoever has highest last card automatically has all cards total higher
                _handValue.Total = (int)_cards[4].MyValue;
                return true;
            }

            return false;
        }

        private bool Straight()
        {
            // if 5 consecutive values
            if (_cards[0].MyValue + 1 == _cards[1].MyValue &&
                _cards[1].MyValue + 1 == _cards[2].MyValue &&
                _cards[2].MyValue + 1 == _cards[3].MyValue &&
                _cards[3].MyValue + 1 == _cards[4].MyValue)
            {
                //player with the highest value of the last card wins
                _handValue.Total = (int)_cards[4].MyValue;
                return true;
            }

            return false;
        }

        private bool ThreeOfKind()
        {
            // if the 1,2,3 cards are the same OR
            // 2,3,4 cards are the same OR
            // 3,4,5 cards are the same
            // 3rd card will always be part of Three of A Kind
            if ((_cards[0].MyValue == _cards[1].MyValue && _cards[0].MyValue == _cards[2].MyValue) ||
            (_cards[1].MyValue == _cards[2].MyValue && _cards[1].MyValue == _cards[3].MyValue))
            {
                _handValue.Total = (int)_cards[2].MyValue * 3;
                _handValue.HighCard = (int)_cards[4].MyValue;
                return true;
            }
            if (_cards[2].MyValue == _cards[3].MyValue && _cards[2].MyValue == _cards[4].MyValue)
            {
                _handValue.Total = (int)_cards[2].MyValue * 3;
                _handValue.HighCard = (int)_cards[1].MyValue;
                return true;
            }
            return false;
        }

        private bool TwoPairs()
        {
            // if 1,2 and 3,4
            // if 1,2 and 4,5
            // if 2,3 and 4,5
            //with two pairs, 2nd card will always be part of one pair 
            // and 4th card will always be part of second pair
            if (_cards[0].MyValue == _cards[1].MyValue && _cards[2].MyValue == _cards[3].MyValue)
            {
                _handValue.Total = ((int)_cards[1].MyValue * 2) + ((int)_cards[3].MyValue * 2);
                _handValue.HighCard = (int)_cards[4].MyValue;
                return true;
            }
            if (_cards[0].MyValue == _cards[1].MyValue && _cards[3].MyValue == _cards[4].MyValue)
            {
                _handValue.Total = ((int)_cards[1].MyValue * 2) + ((int)_cards[3].MyValue * 2);
                _handValue.HighCard = (int)_cards[2].MyValue;
                return true;
            }
            if (_cards[1].MyValue == _cards[2].MyValue && _cards[3].MyValue == _cards[4].MyValue)
            {
                _handValue.Total = ((int)_cards[1].MyValue * 2) + ((int)_cards[3].MyValue * 2);
                _handValue.HighCard = (int)_cards[0].MyValue;
                return true;
            }

            return false;
        }

        private bool OnePair()
        {
            // if 1,2 -> 5th card has highest value
            // 2,3
            // 3,4
            // 4,5 -> card #3 has highest value
            if (_cards[0].MyValue == _cards[1].MyValue)
            {
                _handValue.Total = (int)_cards[0].MyValue * 2;
                _handValue.HighCard = (int)_cards[4].MyValue;
                return true;
            }
            if (_cards[1].MyValue == _cards[2].MyValue)
            {
                _handValue.Total = (int)_cards[1].MyValue * 2;
                _handValue.HighCard = (int)_cards[4].MyValue;
                return true;
            }
            if (_cards[2].MyValue == _cards[3].MyValue)
            {
                _handValue.Total = (int)_cards[2].MyValue * 2;
                _handValue.HighCard = (int)_cards[4].MyValue;
                return true;
            }
            if (_cards[3].MyValue == _cards[4].MyValue)
            {
                _handValue.Total = (int)_cards[3].MyValue * 2;
                _handValue.HighCard = (int)_cards[2].MyValue;
                return true;
            }

            return false;
        }

    }
}
