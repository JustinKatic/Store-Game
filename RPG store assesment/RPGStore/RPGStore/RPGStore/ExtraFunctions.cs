using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGStore
{
    class ExtraFunctions
    {
 
        public void PrintColour(string content, ConsoleColor colour)
        {
            Console.ForegroundColor = colour;
            Console.WriteLine(content);
            Console.ResetColor();
        }

        public void DisplayOptions()
        {
            PrintColour("select which option you would like to buy using the numbers", ConsoleColor.Green);
            string[] displayOptions = new string[6]
            {"Buy", "Sell","Inspect shop items","Inspect inventory items" ,"Inventory","Leave"};
            for (int i = 0; i < displayOptions.Length; i++)
            {
                Console.WriteLine($"[{i}] - {displayOptions[i]}");
            }
        }
    }
}
