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
        {
            List<Item> items = [];
            int roll = randInt(1,100);

            if (player.Wallet.KeyCount <= 0)
            {
                player.Wallet.KeyCount = 0;
                return new(false, "You dont have any keys");
            }
            if (roll <= Odds && Rarity != Rarity.Elite) { Rarity++; }

            foreach (Item i in Catalogue.Items[(int)Rarity])
            {
                if (i.Rarity == Rarity)
                {
                    items.Add(i);
                }
            }
            if (items.Count != 0)
            {
                roll = randInt(1, items.Count);
                Item item = items[roll-1];
                player.Inventory.Add(item);
                SavePlayer(player);
                return new(true, $"{item.Name}, {item.Durability}, {item.Rarity}");
            }
            return new(false, "Error");
        } // end of OpenChest
    }
}
