namespace BattleshipOOP
{
    public class YesNoMenu : MainMenu
    {
        public YesNoMenu() : base()
        {
            this.FirstLine = "Do you want to place ships manually?\n";
            this.Options = new[] {"Yes", "No"};
            this.GameLogo = "";
        }
        
        public override bool ManageMenuInput(int modeChoice)
        {
            switch (modeChoice)
            {
                case 0:
                    return true;
                default:
                    return false;
            }
        }
        
    }
}