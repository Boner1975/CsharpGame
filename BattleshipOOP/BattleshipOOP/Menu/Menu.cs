using System;
using System.Collections.Generic;
using System.Linq;
using BattleshipOOP;

public abstract class Menu
{
    protected string FirstLine;
    protected List<string[]> OptionsList = new List<string[]>();
    protected List<string> DropableOptions { get; set; }
    protected int ArrowIndex = 0;
    protected string[] CurrentOptions;
    protected string GameLogo = String.Empty;
    protected Display display = new Display();
    public bool goBack { get; set; } 
    public bool IsPlayer1Human { get; set; }
    public bool IsPlayer2Human { get; set; }
    public int GameLevel { get; set; }

    public Menu()
    {
        goBack = false;
        IsPlayer1Human = true;
        IsPlayer2Human = true;
        GameLevel = 1;
    }

    public void ResetArrowIndex()
    {
        ArrowIndex = 0;
    }

    internal string ManageOptions(int optionIndex, string option, string tabulation)
    {
        return ArrowIndex == optionIndex && CurrentOptions.Contains(option)
            ? $"{tabulation} –> {option}"
            : $"{tabulation}    {option}";
    }

    protected void ManagePressedKey(ConsoleKey key)
    {
        int lastIndex = CurrentOptions.Length - 1;
        switch (key)
        {
            case ConsoleKey.UpArrow:
                ArrowIndex = ArrowIndex > 0 ? ArrowIndex - 1 : lastIndex;
                break;
            case ConsoleKey.DownArrow:
                ArrowIndex = ArrowIndex < lastIndex ? ArrowIndex + 1 : 0;
                break;
        }
    }
    
    protected abstract bool ManageMenuInput();


    protected void PrintMenu()
    {
        Console.Clear();
        display.PrintMessage(GameLogo);
        display.PrintMessage(FirstLine);
        PrintOptions(0);
    }
    
    
    protected void PrintOptions(int index)
    {
        int optionIndex = 0;
        string tabulation = String.Concat(Enumerable.Repeat("    ", index)); 

        foreach (string option in OptionsList[index])
        {
            display.PrintMessage(ManageOptions(optionIndex, option, tabulation));
            
            if (DropsDown(option) && index + 1 < OptionsList.Count)
                PrintOptions(index + 1);
            
            optionIndex++;
        }
    }

    protected abstract bool DropsDown(string option);
    
    
    public bool RunMenu()
    {
        GetMenuInput();
        return ManageMenuInput();
    }

    protected ConsoleKey GetMenuInput()
    {
        ConsoleKey key;
        do
        {
            PrintMenu();
            key = Console.ReadKey().Key;
            ManagePressedKey(key);
        } while (AcceptableInput(key));

        return key;
    }

    protected abstract bool AcceptableInput(ConsoleKey key);
}