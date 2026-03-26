using chesti.Model;
using static chesti.Utils.Python;
using static chesti.Utils.Shop;
using static chesti.Utils.Holdings;
using Random = System.Random;

Random r = new Random();
Player mission = new Player("Mission", 10, 50);
ConsoleKeyInfo menuInput;

bool lock1 = false; bool lock2 = false; bool lock3 = false;
Chest standardChest = new Chest { Name = "Standard Chest", Rarity = Rarity.Standard };
Item[] equipment = new Item[]
{
    new Item {Name = "woodSword", Rarity = Rarity.Standard},
    new Item {Name = "budSword", Rarity = Rarity.Standard},
    new Item {Name = "Bow", Rarity = Rarity.Standard},
    new Item {Name = "Sword", Rarity = Rarity.Standard},
    new Item {Name = "Beter Sword", Rarity = Rarity.New},
    new Item {Name = "Beter Bow", Rarity = Rarity.New},
    new Item {Name = "bingBow", Rarity = Rarity.New},
};


while (true)
{
    clear();    print("B for leave \n E for chest \n F for menu \n S for shop ");

    menuInput = readKey();

    //adim
    if (menuInput.Key == ConsoleKey.D0 || lock1 || lock2 || lock3)
    {
        lock1 = true;
        if (menuInput.Key == ConsoleKey.D8 || lock2 || lock3)
        {
            lock2 = true;
            if (menuInput.Key == ConsoleKey.D1 || lock3)
            {
                lock3 = true;
                if (menuInput.Key == ConsoleKey.D7)
                {
                    clear();
                    print("Welcome to admin panel");
                    sleep(100);
                    readKey();
                }
            }
        }
    }
    else
    {
        lock1=false; lock2 = false; lock3 = false;
    }


    //game loop

    if (menuInput.Key == ConsoleKey.E)  // open chests
    {
        standardChest.OpenChest(mission, equipment);
    }


    if (menuInput.Key == ConsoleKey.S)  // shop
    {
        ShopMenu(mission);
    }



    if (menuInput.Key == ConsoleKey.B)
    {
        break;
    }



    if (menuInput.Key == ConsoleKey.F)
    {
        HoldingsMenu(mission);
    }
}
clear();
print("Cya");