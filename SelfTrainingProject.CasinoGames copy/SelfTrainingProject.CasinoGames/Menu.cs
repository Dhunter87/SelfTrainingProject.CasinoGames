using System;
namespace SelfTrainingProject.CasinoGames
{
    public class Menu
    {

        // only blackjack game available at the moment
        public void RunMenu()
        {
            BlackJackGame game = new BlackJackGame();
            // run blackjack game
            game.RunBlackJackGame();
        }
    }
}
