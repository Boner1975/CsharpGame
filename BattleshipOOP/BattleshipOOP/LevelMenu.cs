using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipOOP
{
    class LevelMenu : Menu
    {
        public LevelMenu():base()
        {
            FirstLine ="Choose level of difficulty";
            Options =new[] { "Easy", "Normal","Hard"};
            GameLogo = "";
        }

        public new int RunMenu()
        {
            ConsoleKey key;
            do
            {
                PrintMenu();
                key = Console.ReadKey().Key;
                ManageKeys(key);
            } while (key != ConsoleKey.Enter);

            return selectedOptionIndex + 1;

        }
    }
}
