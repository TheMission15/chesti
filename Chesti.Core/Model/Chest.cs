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
        public StringResult OpenChest(Player player, Element element = Element.Neutral)
        {;
            Catalogue.LoadItems();
            int roll = randInt(1,100);

            //if (roll <= Odds && Rarity != Rarity.Elite) { Rarity++; }

            if (Catalogue.Items[(int)Rarity].Count > 0)
            {
                roll = randInt(1, Catalogue.Items[(int)Rarity].Count);
                Item item = Catalogue.Items[(int)Rarity][roll - 1];
                player.Tools.Add(new(item, element));
                SavePlayer(player);
                return new(true, $"{item.Name}, {player.Tools[^1].Durability}, {item.Rarity}");
            }
            else { return new(false, "error"); }

        } // end of OpenChest
    }
}
