using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipOOP
{
    class LevelMenu : ModeMenu
    {
        public LevelMenu(string dropableOption = ""):base()
        {
            FirstLine ="Choose level of difficulty";
            CurrentOptions = new[] {"Easy", "Normal", "Hard"};
            OptionsList.Add(CurrentOptions);
            DropableOptions.Add(dropableOption);
        }

        public new void RunMenu()
        {
            ConsoleKey key;
            do
            {
                PrintMenu();
                key = Console.ReadKey().Key;
                ManagePressedKey(key);
            } while (AcceptableInput(key));
            
            goBack = key == ConsoleKey.LeftArrow;

            GameLevel = ArrowIndex + 1;
        }
        
        protected override bool AcceptableInput(ConsoleKey key)
        {
            return key != ConsoleKey.Enter && key != ConsoleKey.LeftArrow && key != ConsoleKey.RightArrow;
        }
    }
}
