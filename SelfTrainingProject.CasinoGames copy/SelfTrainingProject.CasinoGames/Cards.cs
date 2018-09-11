using System;
using System.Linq;
using System.Collections.Generic;
namespace SelfTrainingProject.CasinoGames
{
    // contains attributes and behaviors for a single deck of cards
    public class Cards
    {
        public const int CardsInDeck = 52;
        public int RemainingCardsInDeck { get; private set; } = 52;
        public int DecreaseCardsRemaining(int value) => RemainingCardsInDeck -= value;
        
        public string SelectedCard { get; private set; }

        public List<string> PlayersCards = new List<string>();
        public List<string> DealersCards = new List<string>();
        public List<string> SelectedCards = new List<string>();
        public List<string> cards = new List<string>
        {
            "Ace/Hearts", "Two/Hearts", "Three/Hearts", "Four/Hearts",
            "Five/Hearts","Six/Hearts", "Seven/Hearts", "Eight/Hearts",
            "Nine/Hearts", "Ten/Hearts", "Jack/Hearts", "Queen/Hearts", "King/Hearts",

            "Ace/Diamonds", "Two/Diamonds", "Three/Diamonds", "Four/Diamonds", 
            "Five/Diamonds", "Six/Diamonds", "Seven/Diamonds", "Eight/Diamonds", 
            "Nine/Diamonds", "Ten/Diamonds", "Jack/Diamonds", "Queen/Diamonds", "King/Diamonds",

            "Ace/Spades", "Two/Spades", "Three/Spades", "Four/Spades", 
            "Five/Spades", "Six/Spades", "Seven/Spades", "Eight/Spades", 
            "Nine/Spades", "Ten/Spades", "Jack/Spades", "Queen/Spades", "King/Spades",

            "Ace/Clubs", "Two/Clubs", "Three/Clubs", "Four/Clubs",
            "Five/Clubs", "Six/Clubs", "Seven/Clubs", "Eight/Clubs",
            "Nine/Clubs", "Ten/Clubs", "Jack/Clubs", "Queen/Clubs", "King/Clubs"
        };
        // method to reset the deck - makes all cards available for selection again.
        public int ResetDeck()
        {
            SelectedCards.Clear();
            DealersCards.Clear();
            PlayersCards.Clear();
            return RemainingCardsInDeck = 52;
        }

        Random random = new Random();

        // method for drawing a single card from the deck, which has not been drawn out of the deck already.
        public string DrawSingleCard()
        {
            // if no cards remaining in deck - reset deck
            if (RemainingCardsInDeck == 0)
            {
                ResetDeck();
            }

            for (int i = 0; i < 1;)
            {
                int randomNumber = random.Next(0, 52);
                SelectedCard = cards[randomNumber];
            
                if (!(SelectedCards.Contains(SelectedCard)))
                {
                    if(SelectedCard.Contains("Hearts")|| SelectedCard.Contains("Diamonds"))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write("    ** " + SelectedCard + " **     ");
                    Console.ResetColor();
                    PlayersCards.Add(SelectedCard);
                    SelectedCards.Add(SelectedCard);
                    DecreaseCardsRemaining(1);
                    i = 1;
                    return SelectedCard;
                }
            }
            return null;
        }
        // select dealers card - same as selecting normal card but it is not displayed, without calling the display dealers card method.
        public string DrawSingleDealersCard()
        {
            if (RemainingCardsInDeck == 0)
            {
                ResetDeck();
            }
            for (int i = 0; i < 1;)
            {
                int randomNumber = random.Next(0, 52);
                SelectedCard = cards[randomNumber];

                if (!(SelectedCards.Contains(SelectedCard)))
                {
                    SelectedCards.Add(SelectedCard);
                    DealersCards.Add(SelectedCard);
                    DecreaseCardsRemaining(1);
                    i = 1;
                    return SelectedCard;
                }
            }
            return null;
        }
        // method to view dealers cards during the dealers response method.
        public void ViewDealersCards()
        {
            foreach (string card in DealersCards)
            {
                if (card.Contains("Hearts") || card.Contains("Diamonds"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ResetColor();
                }
                Console.WriteLine("    ** " + card + " **     ");
            }
        }

    }

}
