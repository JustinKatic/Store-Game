using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RPGStore
{

    class Program
    {
        public static Inventory playerInventory = new Inventory(5);   // sets length of Playerinventory
        public static Inventory StoreInventory = new Inventory(50);    // sets length of StoreInventory
        public static bool playing = true;                             //bool for checking if player is still playing or not used to exit main while loop
        public static int money = 4000;                                //sets starting money value
        public static bool correctInput = false;                       //bool for checking correct input has been used

        static void Main(string[] args)
        {
            int yesOrNo;        //sets yes or not to expect a int value
            ExtraFunctions extraFunctions = new ExtraFunctions();  //gives access to extraFunctions class
            StreamWriter writer;  //used so can just type writer instead of streamWriter each time
            StreamReader reader;  //used so can just type reader instead of streamReader each time



            extraFunctions.PrintColour("Would you like to start a new game? select which option you would like to buy using the numbers\n(0)New Game\n(1)Saved game", ConsoleColor.Green);


            //While loop to check if player is starting a new game or not if player is starting a new game add default items into the store else player is continueing then load files from text file
            while (correctInput != true)
            {
                while (!int.TryParse(Console.ReadLine(), out yesOrNo))
                {
                    extraFunctions.PrintColour("incorrect input please type one of the listed numbers", ConsoleColor.Red);
                    extraFunctions.PrintColour("Would you like to start a new game? select which option you would like to buy using the numbers\n(0)New Game\n(1)Saved game", ConsoleColor.Green);
                }
                {
                    if (yesOrNo == 0)
                    {
                        //Creating items in my game
                        Weapons weapon1 = new Weapons("Bronze Sword", "Crafted useing bronze bars at black smith.", 100, 7);
                        Weapons weapon2 = new Weapons("Iron Sword", "Crafted useing Iron bars at black smith.", 200, 7);
                        Weapons weapon3 = new Weapons("Steel Weapon", "Crafted useing Steel bars at black smith.", 400, 5);
                        Weapons weapon4 = new Weapons("Mithril Weapon", "Crafted useing Mithril bars at black smith.", 600, 5);
                        Weapons weapon5 = new Weapons("Abyssal Whip", "Found in the deep weilderness", 1000, 5);
                        Potions potion1 = new Potions("Small Health Potion", "Restores a small amount of health.", 20, 10);
                        Potions potion2 = new Potions("Medium Health Potion", "Restores a medium amount of health.", 40, 25);
                        Potions potion3 = new Potions("Large Health Potion", "Restores a large amount of health.", 80, 50);
                        Armour armour1 = new Armour("Bronze Chest Plate", "Crafted from bronze bars", 100, 20);
                        Armour armour2 = new Armour("Bronze Iron Plate", "Crafted from iron bars", 200, 30);
                        Armour armour3 = new Armour("Bronze Steel Plate", "Crafted from steel bars", 400, 40);
                        Armour armour4 = new Armour("Bronze Mithril Plate", "Crafted from mithril bars", 600, 60);
                        //Adding items to store
                        StoreInventory.AddItem(weapon1, weapon2, weapon3, weapon4, weapon5, potion1, potion2, potion3, armour1, armour2, armour3, armour4);
                        //exiting while loop
                        correctInput = true;
                    }



                    else if (yesOrNo == 1 && File.Exists("Money.txt") && File.Exists("StoreInventory.txt") && File.Exists("PlayerInventory.txt"))
                    {
                        //reading money text file
                        reader = new StreamReader("Money.txt");
                        string lineMoney = reader.ReadLine();
                        money = Convert.ToInt32(lineMoney);
                        reader.Close();

               

                        //READING ITEMS FROM STORE TEXT FILE
                        string Storeline;
                        reader = new StreamReader("StoreInventory.txt");  //textfile destination
                        while ((Storeline = reader.ReadLine()) != null)  //runs through textfile until all lines are read
                        {
                            string[] Item = Storeline.Split(',');        //creates array making a new element every time it reads a (',')

                            // checks the first element in array to check which class item belongs to
                            if (Item[0] == "RPGStore.Weapons")
                            {
                                StoreInventory.AddItem(new Weapons(Item[1], Item[2], Convert.ToInt32(Item[3]), Convert.ToInt32(Item[4])));
                            }
                            else if (Item[0] == "RPGStore.Potions")
                            {
                                StoreInventory.AddItem(new Potions(Item[1], Item[2], Convert.ToInt32(Item[3]), Convert.ToInt32(Item[4])));
                            }
                            else if (Item[0] == "RPGStore.Armour")
                            {
                                StoreInventory.AddItem(new Potions(Item[1], Item[2], Convert.ToInt32(Item[3]), Convert.ToInt32(Item[4])));
                            }
                        }
                        reader.Close();

                        //READING ITEMS FROM PLAYER INVENTORY
                        string Inventoryline;
                        reader = new StreamReader("PlayerInventory.txt");
                        while ((Inventoryline = reader.ReadLine()) != null)
                        {
                            string[] Item = Inventoryline.Split(',');
                            if (Item[0] == "RPGStore.Weapons")
                            {
                                playerInventory.AddItem(new Weapons(Item[1], Item[2], Convert.ToInt32(Item[3]), Convert.ToInt32(Item[4])));
                            }
                            else if (Item[0] == "RPGStore.Potions")
                            {
                                playerInventory.AddItem(new Potions(Item[1], Item[2], Convert.ToInt32(Item[3]), Convert.ToInt32(Item[4])));
                            }
                            else if (Item[0] == "RPGStore.Armour")
                            {
                                StoreInventory.AddItem(new Potions(Item[1], Item[2], Convert.ToInt32(Item[3]), Convert.ToInt32(Item[4])));
                            }
                        }
                        reader.Close();

                        correctInput = true; // exits while loop
                    }
                    else  // if incorrect input used prints following and repeats while loop
                    {
                        extraFunctions.PrintColour("incorrect input please type one of the listed numbers or you have no saved game files", ConsoleColor.Red);
                        extraFunctions.PrintColour("Would you like to start a new game? select which option you would like to buy using the numbers\n(0)New Game\n(1)Saved game", ConsoleColor.Green);
                    }
                }
            }
            extraFunctions.PrintColour("Welcome to the shop", ConsoleColor.Blue);
            Console.WriteLine("current money is $" + money); //displays players current money

            extraFunctions.DisplayOptions();


            //main while loop that gets the players options buy,sell,inspect etc and plays the playloop aslong as player bool is true
             // playeroption choice is a int          
            //Checking if playing is true
                int buyChoice;
                int sellChoice;
                int searchChoice;
                int playerOptionChoice;

            while (playing == true)
            {
                playerInventory.IsEmpty();
                while (!int.TryParse(Console.ReadLine(), out playerOptionChoice))  //if player doesnt enter a int throw error
                {
                    extraFunctions.PrintColour("incorrect input please type one of the listed numbers", ConsoleColor.Red);
                }

                //BUYING
                switch (playerOptionChoice)
                {
                    case 0:
                        if (playerInventory.FindFreeSpot() != -1 && money > 0)
                        {
                            extraFunctions.PrintColour("select which item you would like to buy using the numbers", ConsoleColor.Blue);
                            StoreInventory.DisplayInventory();

                            //error checking
                            while (!int.TryParse(Console.ReadLine(), out buyChoice) || buyChoice >= StoreInventory.inventory.Length || buyChoice <= -1 || StoreInventory.GetItem(buyChoice) == null)                            
                            {
                                extraFunctions.PrintColour("incorrect input please type one of the listed numbers", ConsoleColor.Red);
                                StoreInventory.DisplayInventory();
                            }         
                             if (StoreInventory.GetItem(buyChoice) != null)
                            {
                                Items tempItem = StoreInventory.GetItem(buyChoice);  //created a temp item and stores the selected item into it
                                extraFunctions.PrintColour(tempItem.itemName + " has been added to inventory for $" + tempItem.itemCost, ConsoleColor.Yellow);
                                money -= tempItem.itemCost;  //minus item cost from money
                                playerInventory.AddItem(tempItem);  //add the selected item to player
                                StoreInventory.RemoveItem(buyChoice); //remove item from store
                                Console.WriteLine("current money is $" + money); //display current money
                                extraFunctions.DisplayOptions();
                            }
                            //buy the item
                        }
                        else
                        {
                            extraFunctions.PrintColour("Inventory is full or out of money", ConsoleColor.Red);
                            extraFunctions.DisplayOptions();
                        }

                        break;
                       
                        //SELLING
                    case 1:
                        {
                            if (playerInventory.IsEmpty() == false)
                            {
                                extraFunctions.PrintColour("select which item you would like to sell using the numbers", ConsoleColor.Blue);
                                playerInventory.DisplayInventory();
                                while (!int.TryParse(Console.ReadLine(), out sellChoice) || sellChoice >= playerInventory.inventory.Length || sellChoice <= -1 || playerInventory.GetItem(sellChoice) == null)  //error checking to make sure int entered
                                {
                                    extraFunctions.PrintColour("incorrect input please type one of the listed numbers", ConsoleColor.Red);  
                                    playerInventory.DisplayInventory();
                                }
                            
                                 if (playerInventory.GetItem(sellChoice) != null)
                                {

                                    Items tempItem = playerInventory.GetItem(sellChoice);
                                    extraFunctions.PrintColour(tempItem.itemName + " has been sold to store for $" + tempItem.itemCost, ConsoleColor.Yellow);
                                    money += tempItem.itemCost;
                                    StoreInventory.AddItem(tempItem);
                                    playerInventory.RemoveItem(sellChoice);
                                    Console.WriteLine("current money is $" + money);
                                    extraFunctions.DisplayOptions();
                                }
                            }
                            else
                            {
                                extraFunctions.PrintColour("Player Inventory is empty", ConsoleColor.Red);
                                extraFunctions.DisplayOptions();
                            }
                        }
                        break;


                        //SEARCH STORE INVENTORY ITEMS
                    case 2:
                        {
                            StoreInventory.DisplayInventory();
                            extraFunctions.PrintColour("type item number you wish to search for", ConsoleColor.Blue);

                            while (!int.TryParse(Console.ReadLine(), out searchChoice) || searchChoice <= -1 || searchChoice > StoreInventory.inventory.Length || StoreInventory.inventory[searchChoice] == null)
                            {
                                extraFunctions.PrintColour("incorrect input please type one of the listed numbers", ConsoleColor.Red);
                                StoreInventory.DisplayInventory();
                            }
                            Items tempItem = StoreInventory.GetItem(searchChoice);
                            tempItem.StatsOfCreation();
                            extraFunctions.DisplayOptions();
                        }
                        break;


                        //SEARCH PLAYER INVENTORY
                    case 3:
                        {
                            if (playerInventory.IsEmpty() == false)
                            {
                                extraFunctions.PrintColour("type item number you wish to search for", ConsoleColor.Blue);
                                playerInventory.DisplayInventory();

                                while (!int.TryParse(Console.ReadLine(), out searchChoice) || searchChoice <= -1 || searchChoice > playerInventory.inventory.Length || playerInventory.inventory[searchChoice] == null)
                                {
                                    extraFunctions.PrintColour("incorrect input please type one of the listed numbers", ConsoleColor.Red);
                                    playerInventory.DisplayInventory();
                                }
                                Items tempItem = playerInventory.GetItem(searchChoice);
                                tempItem.StatsOfCreation();
                                extraFunctions.DisplayOptions();
                            }
                            else
                            {
                                extraFunctions.PrintColour("Player Inventory is empty", ConsoleColor.Red);
                                extraFunctions.DisplayOptions();
                            }
                        }
                        break;


                        //DISPLAY INVENTORY
                    case 4:
                        {
                            playerInventory.DisplayInventory();
                            extraFunctions.DisplayOptions();
                        }
                        break;


                        //LEAVE AND SAVE SHOP
                    case 5:

                        {
                            if (money > 0)
                            {
                                extraFunctions.PrintColour("thank you for shopping", ConsoleColor.Blue);
                                playing = false; //exits game loop

                                //saves money into text file
                                writer = new StreamWriter("Money.txt");
                                writer.WriteLine(money);
                                writer.Close();




                                //SAVES ITEMS IN STORE TEXT FILE
                                writer = new StreamWriter("StoreInventory.txt"); //file location
                                for (int i = 0; i < StoreInventory.inventory.Length; i++) //for each item in inventory
                                {
                                    if (StoreInventory.inventory[i] != null)  //loops through if position is != null
                                    {
                                        Items tempItem = StoreInventory.GetItem(i); //gets the item at position [i] storeing it inside of temp item
                                        string first = tempItem.itemName;           //getting the of the class at position [i]
                                        string second = tempItem.itemDescription;
                                        int third = tempItem.itemCost;
                                        int fourth = tempItem.itemModifier;
                                        string line = string.Format("{0},{1},{2},{3},{4}", StoreInventory.GetItem(i), first, second, third, fourth); //creates the format that is saved into text file [0] = weapon type [1] = first item name. [2] = second item description etc leaving a comma between each element
                                        writer.WriteLine(line);   //writes the whole formated line into console
                                        writer.Flush();           //clears values that had just been written to start fresh for next line in loop
                                    }
                                }
                                writer.Close();

                                //saves player inventory to textfile
                                writer = new StreamWriter("PlayerInventory.txt");
                                for (int i = 0; i < playerInventory.inventory.Length; i++)
                                {
                                    if (playerInventory.inventory[i] != null)
                                    {
                                        Items tempItem = playerInventory.GetItem(i);
                                        string first = tempItem.itemName;
                                        string second = tempItem.itemDescription;
                                        int third = tempItem.itemCost;
                                        int fourth = tempItem.itemModifier;
                                        string line = string.Format("{0},{1},{2},{3},{4}", playerInventory.GetItem(i), first, second, third, fourth);
                                        writer.WriteLine(line);
                                        writer.Flush();
                                    }
                                }
                                writer.Close();
                            }
                            else if (money<0)
                            {
                                extraFunctions.PrintColour("you have negative money please sell before saving and leave", ConsoleColor.Red);
                                extraFunctions.DisplayOptions();

                                break;
                            }
                        }
                        break;


                        //ADMIN FUNCTION
                    case 6:
                        {

                            int typeOfItem;
                            bool correctItemInput = false;

                            if (StoreInventory.FindFreeSpot() != -1)
                            {
                                extraFunctions.PrintColour("now creating your item", ConsoleColor.Green);

                                //getting stats of item to add
                                extraFunctions.PrintColour("Type your items name", ConsoleColor.Blue);
                                string a_itemName = Console.ReadLine();

                                extraFunctions.PrintColour("Type your items description", ConsoleColor.Blue);
                                string a_itemDescription = Console.ReadLine();

                                extraFunctions.PrintColour("Type your items cost", ConsoleColor.Blue);
                                int a_itemCost;
                                while (!int.TryParse(Console.ReadLine(), out a_itemCost)) // making sure only int inputed for cost
                                {
                                    extraFunctions.PrintColour("incorrect input please type cost amount as (int)", ConsoleColor.Red);
                                    extraFunctions.PrintColour("Type your items cost amount (int)", ConsoleColor.Blue);
                                }

                                extraFunctions.PrintColour("Type your items modifier  amount (int)", ConsoleColor.Blue);
                                int a_itemModifier;
                                while (!int.TryParse(Console.ReadLine(), out a_itemModifier)) // making sure only int inputed for modifier
                                {
                                    extraFunctions.PrintColour("incorrect input please type your modifier as (int)", ConsoleColor.Red);
                                    extraFunctions.PrintColour("Type your items modifier (int) amount", ConsoleColor.Blue);
                                }

                                while (correctItemInput != true)
                                {
                                    extraFunctions.PrintColour("is your item a weapon(0) or potion(1) or armour(2)", ConsoleColor.Green);
                                    while (!int.TryParse(Console.ReadLine(), out typeOfItem))
                                    {
                                        extraFunctions.PrintColour("incorrect input please type one of the listed numbers", ConsoleColor.Red);
                                        extraFunctions.PrintColour("is your item a weapon(0) or potion(1) or armour(2)", ConsoleColor.Green);
                                    }

                                    // checking what class the item created belongs to
                                    if (typeOfItem == 0)
                                    {
                                        Weapons createdItem = new Weapons(a_itemName, a_itemDescription, a_itemCost, a_itemModifier);
                                        StoreInventory.AddItem(createdItem);
                                        correctItemInput = true;
                                    }
                                    else if (typeOfItem == 1)
                                    {

                                        Potions createdItem = new Potions(a_itemName, a_itemDescription, a_itemCost, a_itemModifier);
                                        StoreInventory.AddItem(createdItem);
                                        correctItemInput = true;
                                    }
                                    else if (typeOfItem == 2)
                                    {

                                        Armour createdItem = new Armour(a_itemName, a_itemDescription, a_itemCost, a_itemModifier);
                                        StoreInventory.AddItem(createdItem);
                                        correctItemInput = true;
                                    }
                                    else
                                    {
                                        extraFunctions.PrintColour("incorrect input please type one of the listed numbers", ConsoleColor.Red);
                                    }
                                }
                                    extraFunctions.PrintColour("your item has been added to store", ConsoleColor.Yellow);
                                    extraFunctions.DisplayOptions();
                            }

                            else
                            {
                                extraFunctions.PrintColour("Store Inventory is full", ConsoleColor.Red);
                                extraFunctions.DisplayOptions();
                            }
                        }
                        break;

                    default:
                        extraFunctions.PrintColour("incorrect input please type one of the listed numbers", ConsoleColor.Red);

                        break;
                }
            }
        }
    }
}






