using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class Player
    {
        public Player()
        {
            _hand = new List<Card>();
        }

        public void PutInHand(Card cardToHold)
        {
            _hand.Add(cardToHold);
        }

        public override string ToString()
        {
            return string.Join(", ", _hand);
        }

        public bool HasGoneOver21()
        {
            return TotalOfHand() > 21;
        }

        public List<Card> ClearYourHand()
        {
            List<Card> oldHand = _hand;
            _hand = new List<Card>();
            return oldHand;
        }

        public bool HasNotGoneOver21()
        {
            return TotalOfHand() <= 21;
        }

        public bool WantsAnotherCard()
        {
            Console.WriteLine("Would you like another card? (y/n) ");
            string input = Console.ReadLine().ToLower();
            while (input != "y" && input != "n")
            {
                Console.WriteLine("Please enter 'y' or 'n': ");
                input = Console.ReadLine().ToLower();
            }
            return input == "y";
        }

        public int TotalOfHand()
        {
            int totalInHand = 0;
            foreach (Card card in _hand)
            {
                totalInHand += card.GetValue();
            }
            return totalInHand;
        }

        private List<Card> _hand;
    }
}