using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGStore
{
    public class Potions : Items  //potion class
    {
        public Potions(string _itemName, string _itemDescription, int _itemCost, int _itemModifier)
        {
            itemName = _itemName;
            itemDescription = _itemDescription;
            itemCost = _itemCost;
            itemModifier = _itemModifier;
        }

        public override void StatsOfCreation()
        {
            base.StatsOfCreation();
            Console.WriteLine($"Potion strength: {itemModifier}.");
            Console.WriteLine(itemDescription);
            Console.WriteLine();
        }
    }   
}
