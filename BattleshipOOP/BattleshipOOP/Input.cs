using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipOOP
{
    class Input
    {
        /*
        Display display = new Display();
        Utility utility = new Utility();
        Board board = new Board(10);
        */
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

        //Ship location on fireing
    }
}
