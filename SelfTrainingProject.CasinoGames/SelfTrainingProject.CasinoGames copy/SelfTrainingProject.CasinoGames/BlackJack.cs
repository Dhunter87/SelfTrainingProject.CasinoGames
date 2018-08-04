using System;
namespace SelfTrainingProject.CasinoGames
{
    public class BlackJack
    {
        Cards cards = new Cards();
        UserProfile user = new UserProfile();
        TitleScreen title = new TitleScreen();

        public int Points { get; private set; } = 0;
        public int DealerPoints { get; private set; } = 0;
        public int result { get; private set; } = 0;
        public bool playerWin { get; set; } = false;
        public bool dealerWin { get; private set; } = false;
        public bool Win { get; private set; } = false;
        public bool Bet { get; private set; } = false;
        public double Stake { get; set; } = 0.0;
        public double Winnings(double stake) => Stake *= 2;
        public double UserCredits { get; set; }
        public double DecreaseCredits(double value) => UserCredits -= value;
        public double AddCredits(double value) => UserCredits += value;
        public double InitializeCredits()
        {
            return UserCredits = user.Credits;        
        }
        public string ViewDealersCards()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Dealer has : " + DealerPoints + "\n");
            cards.ViewDealersCards();

            return null;
        }
        public void ResetStake()
        {
            Stake = 0.0;
        }

        public double PayOut(bool playerWin)
        {
            if (playerWin == true)
            {
                return AddCredits(Winnings(Stake));
            }
            return  0.0;
        }

        public void ResetGame()
        {
            cards.DealersCards.Clear();
            cards.PlayersCards.Clear();
            Bet = false;
            ResetStake();
            ResetPoints();
            dealerWin = false;
            playerWin = false;
            Win = false;
            result = 0;
            Console.Clear();
        }

        public void NewGame()
        {
            ResetGame();
            title.RunTitleScreen();
            while(Bet == false)
            {
                TakeBet();
                DecreaseCredits(Stake);
                Console.WriteLine("");
            }
        }
        public bool TakeBet()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Welcome to BlackJack!");
            Console.WriteLine("Credits : " + UserCredits);
            Console.WriteLine("Please make a bet and press enter to deal cards : ");
            Console.ResetColor();
            try
            {
                Stake = double.Parse(Console.ReadLine());
                if (Stake <= 0)
                {
                    Console.Beep();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Unable to make a bet of 0 or less!");
                    Console.ResetColor();
                    Stake = 0;
                    return false;
                    throw new System.Exception();
                }
                else if (Stake > UserCredits)
                {
                    Console.Beep();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Insufficient Credits!");
                    Console.ResetColor();
                    Stake = 0;
                    return false;
                    throw new System.Exception();
                }
                return Bet = true;
            }
            catch (Exception)
            {
                Console.Beep();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Input!");
                Console.ResetColor();
                return Bet = false;
            }
        }

        public void ResetPoints()
        {
            Points = 0;
            this.Points = 0;

            DealerPoints = 0;
            this.DealerPoints = 0;
        }

        public int AddPoints(int value) => Points += value;

        public int AddDealerPoints(int value) => DealerPoints += value;

        public string DrawDealersCard() => cards.DrawSingleDealersCard();

        public string DrawCard() => cards.DrawSingleCard();

        public bool HasBlackJackWin(int value)
        {
            if (value == 21)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HasLost(int value)
        {
            if (value > 21)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DealerHasWon(int playerPoints, int dealerPoints)
        {
            if (dealerPoints > playerPoints && dealerPoints <= 21)
            {
                return true;
            }
            return false;
        }

        public bool DealerTwist(int playerPoints, int dealerPoints)
        {
            if (this.DealerPoints < playerPoints && this.DealerPoints < 21)
            {
                return true;
            }
            return false;
        }

        public bool PointsEqual(int playerPoints, int dealerPoints)
        {
            if (this.DealerPoints == playerPoints)
            {
                return true;
            }
            return false;
        }

        public bool DealerBust(int playerPoints, int dealerPoints)
        {
            if (this.DealerPoints > 21)
            {
                return true;
            }
            return false;
        }

        public void DealerResponse()
        {
            while(Win == false)
            {
                if (DealerHasWon(Points, DealerPoints) == true)
                {
                    ViewDealersCards();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nSorry, You Loose!");
                    Console.ResetColor();
                    BlackJackGame.UserTwistLoop = 1;
                    Console.ReadLine();
                    dealerWin = true;
                    Win = true;
                }
                else if (DealerTwist(Points, DealerPoints) == true)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Dealer drew card...");
                    Console.ResetColor();
                    AddDealerPoints(GetValue(DrawDealersCard(), DealerPoints));
                }
                else if (PointsEqual(Points, DealerPoints) == true)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Dealer drew card...");
                    Console.ResetColor();
                    AddDealerPoints(GetValue(DrawDealersCard(), DealerPoints));
                }
                else if (DealerBust(Points, DealerPoints) == true)
                {
                    ViewDealersCards();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nCongratulations, You Win!");
                    Console.ResetColor();
                    Console.ReadLine();
                    BlackJackGame.UserTwistLoop = 1;
                    PayOut(playerWin = true);
                    Win = true;

                }
            }
        }

        public int GetValue(string card, int points)
        {
            if (card == "Ace/Hearts" || card == "Ace/Diamonds" || card == "Ace/Spades" || card == "Ace/Clubs")
            {
                if ((points += 11) > 21)
                {
                    return 1;
                }
                else
                {
                    return 11;
                }
            }
            else if (card == "Ten/Hearts" || card == "Jack/Hearts" || card == "Queen/Hearts" || card == "King/Hearts" ||
                    card == "Ten/Diamonds" || card == "Jack/Diamonds" || card == "Queen/Diamonds" || card == "King/Diamonds" ||
                    card == "Ten/Spades" || card == "Jack/Spades" || card == "Queen/Spades" || card == "King/Spades" ||
                    card == "Ten/Clubs" || card == "Jack/Clubs" || card == "Queen/Clubs" || card == "King/Clubs")
            {
                return 10;
            }
            else if (card == "Nine/Hearts" || card == "Nine/Diamonds" || card == "Nine/Spades" || card == "Nine/Clubs")
            {
                return 9;
            }
            else if (card == "Eight/Hearts" || card == "Eight/Diamonds" || card == "Eight/Spades" || card == "Eight/Clubs")
            {
                return 8;
            }
            else if (card == "Seven/Hearts" || card == "Seven/Diamonds" || card == "Seven/Spades" || card == "Seven/Clubs")
            {
                return 7;
            }
            else if (card == "Six/Hearts" || card == "Six/Diamonds" || card == "Six/Spades" || card == "Six/Clubs")
            {
                return 6;
            }
            else if (card == "Five/Hearts" || card == "Five/Diamonds" || card == "Five/Spades" || card == "Five/Clubs")
            {
                return 5;
            }
            else if (card == "Four/Hearts" || card == "Four/Diamonds" || card == "Four/Spades" || card == "Four/Clubs")
            {
                return 4;
            }
            else if (card == "Three/Hearts" || card == "Three/Diamonds" || card == "Three/Spades" || card == "Three/Clubs")
            {
                return 3;
            }
            else if (card == "Two/Hearts" || card == "Two/Diamonds" || card == "Two/Spades" || card == "Two/Clubs")
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }
    }
}
