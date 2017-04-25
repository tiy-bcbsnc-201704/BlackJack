using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class BlackJackGame
    {
        public void Play()
        {
            _discardPile = new List<Card>();

            // create a player
            _player = new Player();

            // create a dealer
            _dealer = new Dealer();

            // create some cards in a deck of cards
            _deck = new DeckOfCards();
            _deck.Shuffle();

            while (true)
            {
                List<Card> discards;
                discards = _player.ClearYourHand();
                _discardPile.AddRange(discards);
                discards = _dealer.ClearYourHand();
                _discardPile.AddRange(discards);

                // deal the cards
                Card cardToDeal;
                cardToDeal = GetTopCardFromDeck();
                _player.PutInHand(cardToDeal);

                cardToDeal = GetTopCardFromDeck();
                _dealer.PutInHand(cardToDeal);

                cardToDeal = GetTopCardFromDeck();
                _player.PutInHand(cardToDeal);

                cardToDeal = GetTopCardFromDeck();
                _dealer.PutInHand(cardToDeal);

                // print the state of the game for the user
                PrintTheGame();

                // hit the player until they don't wanna be hit no more
                while (_player.HasNotGoneOver21() && _player.WantsAnotherCard())
                {
                    cardToDeal = GetTopCardFromDeck();
                    _player.PutInHand(cardToDeal);
                    PrintTheGame();
                }

                // stop if the player busts
                if (_player.HasGoneOver21())
                {
                    Console.WriteLine("You have lost, human.");
                    Console.WriteLine("It is a sad day for your species.");
                }
                else
                {
                    _dealer.ShowAllOfYourCards();
                    // hit the dealer until the computer is over 17
                    while (_dealer.HasNotGoneOver21() && _dealer.WantsAnotherCard())
                    {
                        cardToDeal = GetTopCardFromDeck();
                        _dealer.PutInHand(cardToDeal);
                    }
                    PrintTheGame();

                    // figure out the winner
                    if (_dealer.HasGoneOver21())
                    {
                        Console.WriteLine("You win, this time, human.");
                    }
                    else if (_player.TotalOfHand() >= _dealer.TotalOfHand())
                    {
                        Console.WriteLine("You win, this time, human.");
                    }
                    else
                    {
                        Console.WriteLine("You have lost, puny human.");
                        Console.WriteLine("Your species will never win.");
                    }
                }

                // see if the player wants to go another hand
                Console.WriteLine("Press any key but N and Enter to play another hand.");
                string input = Console.ReadLine().ToLower();
                if (input == "n")
                {
                    break;
                }
            }
        }

        private Card GetTopCardFromDeck()
        {
            if (_deck.AreYouEmpty())
            {
                _deck.Restock(_discardPile);
                _discardPile.Clear();
                _deck.Shuffle();
            }
            return _deck.GiveMeTopCard();
        }

        private void PrintTheGame()
        {
            Console.Clear();
            Console.WriteLine(_dealer);
            Console.WriteLine(_player);
        }

        private Player _player;
        private Dealer _dealer;
        private DeckOfCards _deck;
        private List<Card> _discardPile;
    } // class BlackJackGame
} // namespace BlackJack