using System;
namespace SelfTrainingProject.CasinoGames
{
    public class BlackJackGame
    {

        public static int UserTwistLoop = 0;

        BlackJack blackJack = new BlackJack();
        UserProfile user = new UserProfile();
        Cards cards = new Cards();

        public void RunBlackJackGame()
        {
            blackJack.InitializeCredits();
            for (int loopIndex2 = 0; loopIndex2 < cards.RemainingCardsInDeck; loopIndex2++)
            {
                if (blackJack.UserCredits <= 0)
                {
                    Console.WriteLine("Credits : " + blackJack.UserCredits + " Game Over!");
                    Console.ReadLine();
                    loopIndex2 = int.MaxValue;
                    break;
                }
                else
                {
                    while (blackJack.UserCredits  > 0)
                    {
                        blackJack.NewGame();
                        for (int loopIndex3 = 0; loopIndex3 <= 1; loopIndex3++)
                        {
                            if (cards.RemainingCardsInDeck < 4)
                            {
                                cards.ResetDeck();
                            }
                            for (int p = 0; p < 1; p++)
                            {
                                blackJack.AddPoints(blackJack.GetValue(blackJack.DrawCard(), blackJack.Points));
                            }
                            for (int r = 0; r < 1; r++)
                            {
                                blackJack.AddDealerPoints(blackJack.GetValue(blackJack.DrawDealersCard(), blackJack.DealerPoints));
                            }
                        }

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\n\nPoints : " + blackJack.Points);
                        Console.ResetColor();

                        if (blackJack.HasBlackJackWin(blackJack.Points) == true)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("BLACKJACK!!!");
                            Console.WriteLine("Congratulations, You Win!");
                            Console.ResetColor();
                            blackJack.PayOut(blackJack.playerWin = true);
                            Console.ReadLine();
                            Console.WriteLine("");
                            loopIndex2 = 1;
                            break;
                        }

                        for (int loopIndex4 = 0; loopIndex4 < 1;)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Enter 1 to stick or 2 to twist : ");
                            Console.ResetColor();
                            string entry = Console.ReadLine();
                            Console.WriteLine("");
                            if (!(entry == "1" || entry == "2"))
                            {
                                continue;
                            }
                            if (entry == "1")
                            {
                                blackJack.DealerResponse();
                                loopIndex4 = 1;
                            }
                            else if (entry == "2")
                            {
                                blackJack.AddPoints(blackJack.GetValue(blackJack.DrawCard(), blackJack.Points));
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("\n\nPoints : " + blackJack.Points);
                                Console.ResetColor();

                                if (blackJack.HasBlackJackWin(blackJack.Points) == true)
                                {
                                    blackJack.ViewDealersCards();
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\nCongratulations, You Win!");
                                    Console.ResetColor();
                                    Console.ReadLine();
                                    Console.WriteLine("");
                                    loopIndex4 = 1;
                                    blackJack.PayOut(blackJack.playerWin = true);
                                    break;
                                }

                                if (blackJack.HasLost(blackJack.Points) == true)
                                {
                                    loopIndex4 = 2;
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Game Over!");
                                    Console.ResetColor();
                                    Console.WriteLine("");
                                    Console.ReadLine();
                                    break;
                                }
                                continue;
                            }
                        }
                        break;
                    }
                }

            }
        }
    }
}
