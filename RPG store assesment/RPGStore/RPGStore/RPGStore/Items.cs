using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGStore
{
    public class Items
    {
        public string itemName;
        public string itemDescription;
        public int itemCost;
        public int itemModifier;
        

        public virtual void StatsOfCreation()
        {
            Console.WriteLine();
            Console.WriteLine($"Name: {itemName}");
            Console.WriteLine($"Cost: ${itemCost}");
        }
    }
}

    
