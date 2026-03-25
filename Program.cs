using chesti.Blueprints;
using System.ComponentModel;
using static chesti.Python;
using Random = System.Random;

Random r = new Random();
int keys = 10;
int gold = 0;
int i;
ConsoleKeyInfo key;
ConsoleKeyInfo shopInput;

// i want togive rarities different weights. then if a rarity is picked itll pick a rndom item from that rarity.

Chest comomn = new Chest { Name = "Common Chest", Rarity = Rarity.Common };
Item[] inventory = new Item[] { };
Item[] equipment = new Item[]
{
    new Item {Name = "woodSword", Rarity = Rarity.Common},
    new Item {Name = "budSword", Rarity = Rarity.Common},
    new Item {Name = "Bow", Rarity = Rarity.Common},
    new Item {Name = "Sword", Rarity = Rarity.Common},
    new Item {Name = "Beter Sword", Rarity = Rarity.Uncommon},
    new Item {Name = "Beter Bow", Rarity = Rarity.Uncommon},
    new Item {Name = "bingBow", Rarity = Rarity.Uncommon},
};


while (true)
{
    gold += 15;
    clear();    print("B for leave \n E for chest \n F for menu \n S for shop ");

    key = Console.ReadKey();
    if (key.Key == ConsoleKey.E)
    {
        if (keys > 0)
        {
            clear();
            print("You got a");
            sleep(450);
            i = comomn.chest(ref keys, r, equipment, ref inventory);
            print(equipment[i].Name);
            readKey();
        }
        else
        {
            clear();
            print("You dont have any keys");
            readKey();
        }

    }
    if (key.Key == ConsoleKey.S)
    {
        while (true)
        {
            clear();
            print("    Welcome Shop    \n B for back \n 1. 10 coins = 3 keys");
            shopInput = readKey();
            if (shopInput.Key == ConsoleKey.B)
            {
                break;
            }
            if (shopInput.Key == ConsoleKey.D1) 
            {
                if (gold > 10)
                {
                    clear();
                    print("You got 3 Keys");
                    gold-=10;
                    keys += 3;
                    readKey();
                }
            }
        }
    }
    if (key.Key == ConsoleKey.B)
    {
        break;
    }
    if (key.Key == ConsoleKey.F)
    {
        while (true)
        {
            clear();
            print("    MENU    \n K for keys \n I for inventory \n B for back");
            key = readKey();
            if (key.Key == ConsoleKey.K)
            {
                clear();
                print($"You have {keys} keys");
                readKey();
            }
            if (key.Key == ConsoleKey.I)
            {
                clear();
                print("Inventory:");
                    foreach (Item item in inventory)
                    {
                        print($"{item.Name}, {item.Rarity}");
                    }
                readKey();
            }
            if (key.Key == ConsoleKey.B)
            {
                break;
            }
        }
    }
}
clear();
print("Cya");