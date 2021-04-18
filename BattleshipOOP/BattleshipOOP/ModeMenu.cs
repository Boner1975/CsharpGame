using System;

namespace BattleshipOOP
{
    public class ModeMenu : Menu
    {
        public ModeMenu() : base()
        {
            this.FirstLine = "Choose one of the following modes:\n";
            this.Options = new[] {"HUMAN vs HUMAN", "HUMAN vs COMPUTER", "COMPUTER vs COMPUTER"};
            this.GameLogo = "";
        }
        
        public bool[] ManageModeInput(int modeChoice)
        {
            bool player1 = true;
            bool player2 = true;

            switch (modeChoice)
            {
                case 1:
                    player2 = false;
                    break;
                case 2:
                    player1 = false;
                    player2 = false;
                    break;
            }

            return new bool[] { player1, player2 };
        }

        public bool[] RunMenu()
        {
            ConsoleKey key;
            do
            {
                PrintMenu();
                key = Console.ReadKey().Key;
                ManageKeys(key);
            } while (key != ConsoleKey.Enter);
        
            return ManageModeInput(selectedOptionIndex);
                
        }
    }
}