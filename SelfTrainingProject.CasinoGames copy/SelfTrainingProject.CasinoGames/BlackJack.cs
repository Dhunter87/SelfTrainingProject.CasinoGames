using System;
namespace SelfTrainingProject.CasinoGames
{
    // holds functionality for blackjack rules, betting algorithm and dealer response algorithm etc.
    public class BlackJack
    {
        //instantiate classes, variables and methods etc.
        Cards cards = new Cards();
        UserProfile user = new UserProfile();
        TitleScreen title = new TitleScreen();

        public int UserPoints { get; private set; } = 0;
        public int DealerPoints { get; private set; } = 0;
        public bool playerWin { get; set; } = false;
        public bool dealerWin { get; private set; } = false;
        public bool GameWon { get; private set; } = false;
        public bool BetTaken { get; private set; } = false;
        public double Stake { get; set; } = 0.0;

        public double GamblingOdds(double stake) => Stake *= 2;
        public double UserCredits { get; set; }
        public double DecreaseCredits(double value) => UserCredits -= value;
        public double AddCredits(double value) => UserCredits += value;
        public int AddPoints(int value) => UserPoints += value;
        public int AddDealerPoints(int value) => DealerPoints += value;
        public string DrawDealersCard() => cards.DrawSingleDealersCard();
        public string DrawCard() => cards.DrawSingleCard();

        public double InitializeCredits()
        {
            return UserCredits = user.Credits;        
        }
        public string ViewDealersCards()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Dealers cards : \n");
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
                return AddCredits(GamblingOdds(Stake));
            }
            return  0.0;
        }

        public void ResetGame()
        {
            cards.DealersCards.Clear();
            cards.PlayersCards.Clear();
            BetTaken = false;
            ResetStake();
            ResetPoints();
            dealerWin = false;
            playerWin = false;
            GameWon = false;
            Console.Clear();
        }

        public void NewGame()
        {
            // reset varibles, run titlescreen and call the "takebet" function.
            // decrease credits by stake taken & go back to game
            ResetGame();
            title.RunTitleScreen();
            while(BetTaken == false)
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
                return BetTaken = true;
            }
            catch (Exception)
            {
                Console.Beep();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Input!");
                Console.ResetColor();
                return BetTaken = false;
            }
        }

        public void ResetPoints()
        {
            UserPoints = 0;
            this.UserPoints = 0;

            DealerPoints = 0;
            this.DealerPoints = 0;
        }

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
            ViewDealersCards();
            while(GameWon == false)
            {
                if (DealerHasWon(UserPoints, DealerPoints) == true)
                {
                    //ViewDealersCards();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\nDealer has : " + DealerPoints);
                    Console.WriteLine("Sorry, You Loose!");
                    Console.ResetColor();
                    BlackJackGame.UserTwistLoop = 1;
                    Console.ReadLine();
                    dealerWin = true;
                    GameWon = true;
                }
                else if (DealerTwist(UserPoints, DealerPoints) == true)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\nDealer has : " + DealerPoints);
                    Console.WriteLine("Dealer drew card...\n");
                    Console.ResetColor();
                    AddDealerPoints(GetValue(DrawCard(), DealerPoints));
                    Console.WriteLine("");
                }
                else if (PointsEqual(UserPoints, DealerPoints) == true)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\nDealer has : " + DealerPoints);
                    Console.WriteLine("Dealer drew card...\n");
                    Console.ResetColor();
                    AddDealerPoints(GetValue(DrawCard(), DealerPoints));
                    Console.WriteLine("");
                }
                else if (DealerBust(UserPoints, DealerPoints) == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n\nDealer has : " + DealerPoints);
                    Console.WriteLine("Congratulations, You Win!");
                    Console.ResetColor();
                    Console.ReadLine();
                    BlackJackGame.UserTwistLoop = 1;
                    PayOut(playerWin = true);
                    GameWon = true;

                }
            }
        }

        public int GetValue(string card, int points)
        {
            if (card.Contains("Ace"))
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
            else if (card.Contains("King") || card.Contains("Queen") || card.Contains("Jack") || card.Contains("Ten"))
            {
                return 10;
            }
            else if (card.Contains("Nine"))
            {
                return 9;
            }
            else if (card.Contains("Eight"))
            {
                return 8;
            }
            else if (card.Contains("Seven"))
            {
                return 7;
            }
            else if (card.Contains("Six"))
            {
                return 6;
            }
            else if (card.Contains("Five"))
            {
                return 5;
            }
            else if (card.Contains("Four"))
            {
                return 4;
            }
            else if (card.Contains("Three"))
            {
                return 3;
            }
            else if (card.Contains("Two"))
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
