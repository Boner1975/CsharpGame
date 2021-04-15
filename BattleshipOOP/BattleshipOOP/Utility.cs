using System;
using System.Collections.Generic;
using System.Text;

namespace BattleshipOOP
{
    public class Utility
    {
        public List<int> StringToIntTransformation(string location)
        {
            var list = new List<int>();
            if (location.Length == 2)
            {
                list.Add(int.Parse(location[1].ToString()) - 1);
            }
            else if (location.Length == 3)
            {
                list.Add(int.Parse(location[1].ToString() + location[2].ToString()));
            }
            list.Add(((int)char.Parse(location[0].ToString().ToUpper())) - 65);
            return list;
        }
        public string CoordinatesTransformation(int x, int y)
        {
            string stringRow = ((char)(y + 65)).ToString().ToUpper();
            string stringCol = (x + 1).ToString();
            return (stringRow + stringCol);
        }
    }
}
