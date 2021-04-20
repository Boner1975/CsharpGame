using System;
using System.Runtime.CompilerServices;

namespace BattleshipOOP
{
    public class ModeMenu : MainMenu
    {
        string HCMode = "HUMAN vs COMPUTER";
        string CCMode = "COMPUTER vs COMPUTER";

        public ModeMenu() : base()
        {
            CurrentOptions = new[] {"HUMAN vs HUMAN", HCMode, CCMode};
            OptionsList.Add(CurrentOptions);
        }
        
        protected void ManageModeInput(int modeChoice, ConsoleKey key)
        {
            bool acceptableKey = key == ConsoleKey.RightArrow || key == ConsoleKey.Enter;
            switch (modeChoice)
            {
                case 1 when acceptableKey:
                    SetGameLevel(HCMode);
                    IsPlayer2Human = false;
                    break;
                case 2 when acceptableKey:
                    SetGameLevel(CCMode);
                    IsPlayer1Human = false;
                    IsPlayer2Human = false;
                    break;
            }
        }

        private void SetGameLevel(string mode)
        {
            LevelMenu menu = new LevelMenu(mode);
            menu.RunMenu();
            goBack = menu.goBack;

            if (!goBack)
            {
                GameLevel = menu.GameLevel;
            }
        }

        public void RunMenu()
        {
            ConsoleKey key;
            bool x;

            do
            {
                goBack = false;
                key = GetMenuInput();
                ManageModeInput(ArrowIndex, key);
            } while ((AcceptableInput(key) || goBack) && key != ConsoleKey.LeftArrow);
            
            goBack = key == ConsoleKey.LeftArrow;
        }

        protected override bool AcceptableInput(ConsoleKey key)
        {
            bool acceptableKey = key != ConsoleKey.Enter && key != ConsoleKey.LeftArrow && key != ConsoleKey.RightArrow;
            return (acceptableKey || goBack) && key != ConsoleKey.LeftArrow;
        }
    }
}