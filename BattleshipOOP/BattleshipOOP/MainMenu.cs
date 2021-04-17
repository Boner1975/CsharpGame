using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Xml;

namespace BattleshipOOP
{
    public class MainMenu
    {
        internal string mainMenu = "Main menu:\n";
        internal string modeSelectionText = "Choose one of the following modes:\n";
        internal string[] MenuOptionsList = new[] {"Start New Game", "Instruction", "High scores", "Quit"};
        internal string[] ModeOptionsList = new[] {"HUMAN vs HUMAN", "HUMAN vs COMPUTER", "COMPUTER vs COMPUTER"};
        internal int selectedOptionIndex;
        internal int lastOptionIndex;
        private Display display = new Display();


        public int RunMenu(string menuType = "mainMenu")
        {
            ConsoleKey key;
            selectedOptionIndex = 0;
            bool isMainMenu = menuType == "mainMenu";
            
            do
            {
                display.PrintMainMenu(selectedOptionIndex, menuType);
                key = Console.ReadKey().Key;
                ManageKeys(key, isMainMenu ? MenuOptionsList : ModeOptionsList);
            } while (key != ConsoleKey.Enter);

            return selectedOptionIndex;
        }


        internal string ManageOptions(int selectedOptionIndex, string[] optionsList,  int optionIndex)
        {
            return selectedOptionIndex == optionIndex ? $" –> {optionsList[optionIndex]}" : $"    {optionsList[optionIndex]}";
        }

        internal void ManageKeys(ConsoleKey key, string[] optionsList)
        {
            lastOptionIndex = optionsList.Length - 1;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    selectedOptionIndex = selectedOptionIndex > 0 ? selectedOptionIndex - 1 : lastOptionIndex;
                    break;
                case ConsoleKey.DownArrow:
                    selectedOptionIndex = selectedOptionIndex < lastOptionIndex ? selectedOptionIndex + 1 : 0;
                    break;
            }
        }


        internal string gameLogo = @"
                                     |__
                                     |\/
                                     ---
                                     / | [
                              !      | |||
                            _/|     _/|-++'
                        +  +--|    |--|--|_ |-
                     { /|__|  |/\__|  |--- |||__/
                    +---------------___[}-_===_.'____                 /\
                ____`-' ||___-{]_| _[}-  |     |_[___\==--            \/   _
 __..._____--==/___]_|__|_____________________________[___\==--____,------' .7
|                                                                     BB-61/
 \_________________________________________________________________________|

88                                     88                      88          88  
88                       ,d      ,d    88                      88          ''  
88                       88      88    88                      88              
88,dPPYba,  ,adPPYYba, MM88MMM MM88MMM 88  ,adPPYba, ,adPPYba, 88,dPPYba,  88  8b,dPPYba,
88P'    '8a ''     `Y8   88      88    88 a8P_____88 I8[    `` 88P'    `8a 88  88P'    88a
88       d8 ,adPPPPP88   88      88    88 8PP8888888  `8Y8ba,  88       88 88  88       d8 
88b,   ,a8' 88,    ,88   88,     88,   88 `8b,   ,aa aa    ]8I 88       88 88  88b,   ,a88
8Y`Ybbd88'  ``8bbdP8Y8   8Y888   8Y888 88  `8Ybbd88' `8YbbdP8' 88       88 88  88`YbbdP8'
                                                                               88
                                                                               88
";

    }
}