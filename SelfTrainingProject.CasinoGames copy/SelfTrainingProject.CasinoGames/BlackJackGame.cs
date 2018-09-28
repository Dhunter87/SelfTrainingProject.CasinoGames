using System;
namespace SelfTrainingProject.CasinoGames
{
    public class BlackJackGame
    {
        // instantiate relevant classes, variables and methods etc.
        public static int UserTwistLoop = 0;

        BlackJack blackJack = new BlackJack();
        UserProfile user = new UserProfile();
        Cards cards = new Cards();

        //run game
        public void RunBlackJackGame()
        {
            // issue credits to user
            blackJack.InitializeCredits();
            for (int loopIndex2 = 0; loopIndex2 < cards.RemainingCardsInDeck;)
            {
                // game loop, while there are cards available check user credits...
                if (blackJack.UserCredits <= 0)
                {
                    Console.WriteLine("Credits : " + blackJack.UserCredits + " Game Over!");
                    Console.ReadLine();
                    loopIndex2 = int.MaxValue;
                    break;
                }
                else
                {
                    // game loop, while user has credits...
                    while (blackJack.UserCredits  > 0)
                    {
                        // if there are cards available, run new game method in blackjack.cs. else reset deck
                        if (cards.RemainingCardsInDeck < 1)
                        {
                            cards.ResetDeck();
                        }
                        blackJack.NewGame();
                        for (int loopIndex3 = 0; loopIndex3 <= 1; loopIndex3++)
                        {
                            // loop runs twice - select users card then select dealers card.
                            for (int p = 0; p < 1; p++)
                            {
                                blackJack.AddPoints(blackJack.GetValue(blackJack.DrawCard(), blackJack.UserPoints));
                            }
                            for (int r = 0; r < 1; r++)
                            {
                                blackJack.AddDealerPoints(blackJack.GetValue(blackJack.DrawDealersCard(), blackJack.DealerPoints));
                            }
                        }
                        // display points
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\n\nPoints : " + blackJack.UserPoints);
                        Console.ResetColor();
                        // if user won payout, reset loop(restart game)
                        if (blackJack.HasBlackJackWin(blackJack.UserPoints) == true)
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
                        //if points less than 21, prompt user for "user response loop"
                        for (int loopIndex4 = 0; loopIndex4 < 1;)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Enter 1 to stick or 2 to twist : ");
                            Console.ResetColor();
                            string entry = Console.ReadLine();
                            Console.WriteLine("");
                            // continue unitl valid response given by user
                            if (!(entry == "1" || entry == "2"))
                            {
                                continue;
                            }
                            // if user sticks - run dealer algorithm
                            if (entry == "1")
                            {
                                blackJack.DealerResponse();
                                loopIndex4 = 1;
                            }
                            //else - draw another card & evaluate points an re-run the loop. 
                            else if (entry == "2")
                            {
                                /*

                                string card = blackJack.DrawCard();
                                int cardValue = blackJack.GetValue(card, blackJack.UserPoints);
                                blackJack.AddPoints(cardValue);

                                The above is the longhand of the below function/s - tested with both ways and both work the same.
                                note below how all three functions are called on one line.

                                */
                                blackJack.AddPoints(blackJack.GetValue(blackJack.DrawCard(), blackJack.UserPoints));
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("\n\nPoints : " + blackJack.UserPoints);
                                Console.ResetColor();

                                // if user won - payout - jump out of loop
                                if (blackJack.HasBlackJackWin(blackJack.UserPoints) == true)
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
                                // if user lost reset game - jump out of loop
                                if (blackJack.HasLost(blackJack.UserPoints) == true)
                                {
                                    loopIndex4 = 2;
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Game Over!");
                                    Console.ResetColor();
                                    Console.WriteLine("");
                                    Console.ReadLine();
                                    break;
                                }
                                // if user has not won or lost re-prompt user - "stick or twist"
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
