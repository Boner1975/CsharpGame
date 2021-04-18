using System;
using BattleshipOOP;

public class Menu
    {
        protected string FirstLine;
        protected string[] Options;
        protected string GameLogo;
        protected int lastOptionIndex;
        protected int selectedOptionIndex;
        protected int FirstLineIndex = 0;
        protected int OptionsIndex = 1;


        public Menu()
        {
            this.GameLogo = logo;
        }

        public void ResetSelectedOptionIndex()
        {
            this.selectedOptionIndex = 0;
        }
        
        
        internal string ManageOptions(int optionIndex)
        {
            return selectedOptionIndex == optionIndex
                ? $" –> {Options[optionIndex]}"
                : $"    {Options[optionIndex]}";
        }
        

        internal void ManageKeys(ConsoleKey key)
        {
            lastOptionIndex = Options.Length - 1;
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
        
        public void PrintMenu()
        {
            Display display = new Display();
            Console.Clear();
            display.PrintMessage(GameLogo);
            display.PrintMessage(FirstLine);
            PrintOptions();
        }
        
        private void PrintOptions()
        {
            for (int i = 0; i < Options.Length; i++)
            {
                Console.Out.WriteLine(ManageOptions(i));
            }
        }

        public virtual bool ManageMenuInput(int menuChoice)
        {
            return false;
        }


        public bool RunMenu()
        {
            ConsoleKey key;
            do
            {
                PrintMenu();
                key = Console.ReadKey().Key;
                ManageKeys(key);
            } while (key != ConsoleKey.Enter);
        
            return ManageMenuInput(selectedOptionIndex);
                
        }


        internal string logo = @"
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