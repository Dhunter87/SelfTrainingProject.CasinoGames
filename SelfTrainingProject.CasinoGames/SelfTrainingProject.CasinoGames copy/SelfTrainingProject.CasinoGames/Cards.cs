using System;
using System.Linq;
using System.Collections.Generic;
namespace SelfTrainingProject.CasinoGames
{
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

        public int ResetDeck()
        {
            SelectedCards.Clear();
            DealersCards.Clear();
            PlayersCards.Clear();
            return RemainingCardsInDeck = 52;
        }

        Random random = new Random();

        public string DrawSingleCard()
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
