using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Text;

namespace BattleshipOOP
{
    class Battleship
    {
        private Display display = new Display();
        private Input input = new Input();
        private bool finishGame = false;

        public void StartApp()
        {
            MainMenu mainMenu = new MainMenu();

            do
            {
                finishGame = mainMenu.RunMenu();
                mainMenu.ResetArrowIndex();
                Console.ReadKey();
                
            } while (!finishGame);
        }
    }
}
