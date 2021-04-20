using System;

namespace BattleshipOOP
{
    public class YesNoMenu : Menu
    {
        public YesNoMenu() : base()
        {
            FirstLine = "Do you want to place ships manually?\n";
            CurrentOptions = new[] {"Yes", "No"};
            OptionsList.Add(CurrentOptions);
        }
        
        protected override bool ManageMenuInput()
        {
            switch (ArrowIndex)
            {
                case 0:
                    return true;
                default:
                    return false;
            }
        }

        protected override bool DropsDown(string option)
        {
            return false;
        }

        protected override bool AcceptableInput(ConsoleKey key)
        {
            return key != ConsoleKey.Enter && key != ConsoleKey.RightArrow;
        }

    }
}