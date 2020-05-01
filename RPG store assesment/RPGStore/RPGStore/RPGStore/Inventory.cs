using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGStore
{
    class Inventory 
    {
        public Items[] inventory;  //creates array of type items 

        public Inventory(int capacity)  //allows to capacity of inventory to be set in params 
        {
            inventory = new Items[capacity]; //changed inventory array var to be = to a new array which holds a capacity parameter
        }

        //AddItem adds items of type item into an array using params loops through for the amount of items passed into the paremeter finding a free spot and if free spot is found adding inventory[spot] = the item in the paramter
        public bool AddItem(params Items[] itemsToAdd)
        {
            for (int i = 0; i < itemsToAdd.Length; i++)
            {
                int spot = FindFreeSpot();

                if (spot >= 0)
                {
                    inventory[spot] = itemsToAdd[i];
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        //RemoveItem takes a number in its paremeter checks if slot is != null if != chnage slot to = null
        public bool RemoveItem(int itemNumber)
        {
            if (inventory[itemNumber] != null)
            {
                inventory[itemNumber] = null;
                return true;
            }
            return false;
        }
        //GetItem takes a number in its parameter checks if its not a null slot in the inventory and if not null reuturns the values inside of inventory [number in parameter]
        public Items GetItem(int itemNumber)
        {
            if (inventory[itemNumber] != null)
            {
                return inventory[itemNumber];
            }

            return null;
        }
        //FindFreeSpot loops through inventory if slot is == null return the value at which the slot is null in i
        public int FindFreeSpot()
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] == null)
                {
                    return i;
                }
            }
            return -1;
        }
        
        //Checks if the slot is empty. looping through inventory length and if slot is !null keep looping till slot is == null then returns true
        public bool IsEmpty()
        {

            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] != null)
                {
                    return false;
                }
            }
            return true;
        }

        //DisplayInventory loops though length of inventory printing the name and cost to the inventory of each item
        public void DisplayInventory()
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] != null)
                {
                    Console.WriteLine($"[{i}] - {inventory[i].itemName} - ${inventory[i].itemCost}");
                }
            }
        }
    }
}


