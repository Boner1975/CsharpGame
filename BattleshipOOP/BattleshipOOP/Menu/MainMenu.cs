using System;
using System.Collections.Generic;

namespace BattleshipOOP
{
    public class MainMenu : Menu
    {
        public MainMenu() : base()
        {
            GameLogo = logo;
            string NewGameOption = "Start New Game";
            FirstLine = "Main menu:\n";
            CurrentOptions = new[] {NewGameOption, "Instruction", "High scores", "Quit"};
            OptionsList.Add(CurrentOptions);
            DropableOptions = new List<string>() {NewGameOption};
        }


        protected override bool ManageMenuInput()
        {
            bool finishGame = false;
            
            switch (ArrowIndex)
            {
                case 0:
                    ModeMenu menu = new ModeMenu();
                    menu.RunMenu();
                    
                    if (!menu.goBack)
                    {
                        Game game = new Game();
                        List<bool> PlayersMode = new List<bool>() {menu.IsPlayer1Human, menu.IsPlayer2Human};
                        game.RunGame(PlayersMode, GameLevel);
                    }
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
        
        


        protected override bool DropsDown(string option)
        {
            return DropableOptions.Contains(option);
        }


        protected override bool AcceptableInput(ConsoleKey key)
        {
            return key != ConsoleKey.Enter && key != ConsoleKey.RightArrow;
        }


        protected string logo = @"
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