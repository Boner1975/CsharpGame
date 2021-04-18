namespace BattleshipOOP
{
    public class MainMenu : Menu
    {

        public MainMenu() : base()
        {
            this.FirstLine = "Main menu:\n";
            this.Options = new[] {"Start New Game", "Instruction", "High scores", "Quit"};
        }
        
        
        public override bool ManageMenuInput(int menuChoice)
        {
            bool finishGame = false;
            
            switch (menuChoice)
            {
                case 0:
                    Game game = new Game();
                    game.RunGame();
                    finishGame = false;
                    break;
                case 1:
                    //Show instructions
                    finishGame = false;
                    break;
                case 2:
                    //show highscores
                    finishGame = false;
                    break;
                case 3:
                    finishGame = true;
                    break;
            }

            return finishGame;
        }
    }
}