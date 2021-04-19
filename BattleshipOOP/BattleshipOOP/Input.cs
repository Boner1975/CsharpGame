﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipOOP
{
    public class Input
    {
        string userInput = "";
        public bool isQuit = false;
        private Display display = new Display();

        //Board size
        public int GetBoardSize(Display display)
        {
            bool isValidSize = false;
            while (!isValidSize)
            {
                display.PrintMessageInLine("Please choose board size from 10 to 20: ");
                userInput = Console.ReadLine();
                bool successfullyParsed = int.TryParse(userInput, out _);
                if (!successfullyParsed)
                {
                    display.PrintMessage($"\"{userInput}\" is not a digit");
                }
                else if (successfullyParsed && (int.Parse(userInput) < 10 || int.Parse(userInput) > 20))
                {
                    display.PrintMessage($"\"{userInput}\" is outside of range");
                }
                else
                {
                    isValidSize = !isValidSize;
                }
            }
            return int.Parse(userInput);
        }

        //Player names
        public string GetPlayerName(Display display)
        {
            bool isValidName = false;
            //string name = "";
            while (!isValidName)
            {
                display.PrintMessage("Please provide your nickname: ");
                userInput = Console.ReadLine();
                if (userInput.Length == 0)
                {
                    display.PrintMessage("Please provide at least one character.");
                }
                else
                {
                    isValidName = !isValidName;
                }
            }
            return userInput;
        }

        //Ship type

        //Ship location on placement
        public List<int> GetLocation(Display display, Utility utility, Board board)
        {
            bool isValidEntry = false;
            //string location;
            var list = new List<int>();
            while (!isValidEntry)
            {
                display.PrintMessageInLine("Provide coordinate in a1/A1 format: ");
                userInput = Console.ReadLine();
                if (userInput.Length == 2 && int.TryParse(userInput[1].ToString(), out _) && Char.IsLetter(userInput[0]))
                {
                    list = utility.StringToIntTransformation(userInput);
                    if (list[0] > (int.Parse(board.size.ToString())) - 1 || list[1] > (int.Parse(board.size.ToString())) - 1)
                    {
                        display.PrintMessage("Location out of range");
                        continue;
                    }
                    isValidEntry = true;
                }
                else if (userInput.Length == 3 && int.TryParse((userInput[1].ToString() + userInput[2].ToString()), out _) && Char.IsLetter(userInput[0]))
                {
                    list = utility.StringToIntTransformation(userInput);
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
                //string location = Console.ReadLine();
                userInput = Console.ReadLine();

                table = userInput.Split(" ", StringSplitOptions.RemoveEmptyEntries);
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
        //Ship location on fireing
    }
}
