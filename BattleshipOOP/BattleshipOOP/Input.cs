using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipOOP
{
    public class Input
    {
        string size = "";

        //Board size
        public int GetBoardSize(Display display)
        {
            bool isValidSize = false;
            ;
            while (!isValidSize)
            {
                display.PrintMessageInLine("Please choose board size from 10 to 20: ");
                size = Console.ReadLine();
                bool successfullyParsed = int.TryParse(size, out _);
                if (!successfullyParsed)
                {
                    display.PrintMessage($"\"{size}\" is not a digit");
                }
                else if(successfullyParsed && (int.Parse(size) < 10 || int.Parse(size) > 20))
                {
                    display.PrintMessage($"\"{size}\" is outside of range");
                }
                else
                {
                    isValidSize = !isValidSize;
                }
            }
            return int.Parse(size);
        }

        //Player names
        public string GetPlayerName(Display display)
        {
            bool isValidName = false;
            string name = "";
            while (!isValidName)
            {
                display.PrintMessage("Please provide your nickname: ");
                name = Console.ReadLine();
                if (name.Length == 0)
                {
                    display.PrintMessage("Please provide at least one character.");
                }
                else
                {
                    isValidName = !isValidName;
                }
            }
            return name;
        }

        //Ship type

        //Ship location on placement
        public List<int> GetLocation(Display display, Utility utility, Board board)
        {
            bool isValidEntry = false;
            string location;
            var list = new List<int>();
            while (!isValidEntry)
            {
                display.PrintMessageInLine("Provide coordinates to place a ship in a1/A1 format: ");
                location = Console.ReadLine();
                if (location.Length == 2 && int.TryParse(location[1].ToString(), out _) && Char.IsLetter(location[0]))
                {
                    list = utility.StringToIntTransformation(location);
                    if (list[0] > (int.Parse(board.size.ToString())) - 1 || list[1] > (int.Parse(board.size.ToString())) - 1)
                    {
                        display.PrintMessage("Location out of range");
                        continue;
                    }
                    isValidEntry = true;
                }
                else if (location.Length == 3 && int.TryParse((location[1].ToString() + location[2].ToString()), out _) && Char.IsLetter(location[0]))
                {
                    list = utility.StringToIntTransformation(location);
                    if (list[0] > (int.Parse(board.size.ToString())) - 1 || list[1] > (int.Parse(board.size.ToString())) - 1)
                    {
                        display.PrintMessage("Location out of range");
                        continue;
                    }
                    isValidEntry = true;
                }
                else
                {
                    display.PrintMessage("Wrong format, try again.");
                }
            }
            return list;
        }
        public (int, int,int,int) GetLocations(Display display, Utility utility, int boardSize)
        {
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();

            string[] table;
            do
            {
                string location = Console.ReadLine();
                table = location.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (table.Length != 2)
                {
                    display.PrintMessage("Wrong format, try again.");
                    continue;
                }

            } while (table.Length != 2 || (!CheckLocation(table[0], ref list1, utility, display, boardSize) || !CheckLocation(table[1], ref list2, utility, display, boardSize)));

            return (list1[0], list1[1], list2[0], list2[1]);
        }
        private bool CheckLocation(string location, ref List<int> list, Utility utility, Display display, int boardSize)
        {

            if (Char.IsLetter(location[0]) && 
                ((location.Length == 2 && int.TryParse(location[1].ToString(), out _)) || 
                 (location.Length == 3 && int.TryParse((location[1].ToString() + location[2].ToString()), out _))))
            {
                list = utility.StringToIntTransformation(location);
                if (list[0] > boardSize - 1 || list[1] > boardSize - 1)
                {
                    display.PrintMessage("Location out of range");
                    return false;
                }
            }
            else
            {
                display.PrintMessage("Wrong format, try again.");
                return false;
            }

            return true;
        }

        public bool ManageMenuInput(int menuChoice)
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

        //Ship location on fireing
    }
}
