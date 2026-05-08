using Chesti.Core.Result;
using static Chesti.Core.DataManager;
using static Chesti.Core.Methods;

namespace Chesti.Core.Model
{
    public class Chest
    {
        public string Name { get; set; }
        public Rarity Rarity { get; set; }
        //public Tier Tier { get; set; }
        public int Odds { get; set; }
        public Element Element { get; set; }
        public Chest(Rarity starting, Element element = Element.Neutral)
        {
            Rarity = starting;
            //Tier = tier;

            Name = $"{Rarity}";
            //for (int i = 1; i <= (int)Tier; i++) { name += "+"; }
            
            Odds = 5;
            Element = element;
        }
        public Chest Copy(Element element)
        {
            return new(Rarity, element);
        }
        public StringResult OpenChest(Player player)
        {;
            Catalogue.LoadItems();
            int roll = randInt(1,100);

            if (player.Wallet.KeyCount <= 0)
            {
                player.Wallet.KeyCount = 0;
                return new(false, "You dont have any keys");
            }
            //if (roll <= Odds && Rarity != Rarity.Elite) { Rarity++; }

            if (Catalogue.Items[(int)Rarity].Count > 0)
            {
                roll = randInt(1, Catalogue.Items[(int)Rarity].Count);
                Item item = Catalogue.Items[(int)Rarity][roll - 1];
                player.Inventory.Add(item);
                player.Wallet.KeyCount--;
                SavePlayer(player);
                return new(true, $"{item.Name}, {item.Durability}, {item.Rarity}");
            }
            else { return new(false, "error"); }

        } // end of OpenChest
    }
}
