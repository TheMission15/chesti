using static Chesti.Core.Methods;
using static Chesti.Core.DataManager;

namespace Chesti.Core.Model
{
    public static class Catalogue
    {

        public static void LoadItems()
        {
            Items[0] = [];
            Items[1] = [];
            Items[2] = [];
            Items[3] = [];
            Items[0] = DataManager.LoadItems(0);
            Items[1] = DataManager.LoadItems((Rarity)1);
            Items[2] = DataManager.LoadItems((Rarity)2);
            Items[3] = DataManager.LoadItems((Rarity)3);
        }
        public static void LoadSkills()
        { 
            Skills.Clear();
            Skills.AddRange(DataManager.LoadSkills());
        }

        public static Skill RandomSkill()
        {
            if (Skills.Count != 0 )
            {
            int r = randInt(0, Skills.Count - 1);
            return Skills[r];
            }
            else return new("", 0, 0, Group.Freestyle, [], Element.Neutral);
        }
        public static Item RandomItem()
        {
            int r = randInt(0, Items[0].Count - 1);
            return Items[0][r];
        }

        public static List<Skill> Skills { get; } =
        [
        ];
        public static Group?[] groups = new Group?[2];
        public static List<Item>[] Items { get; } =
        [
            new List<Item> { },

            new List<Item> { },

            new List<Item> { },

            new List<Item> { }
            //new("Gloves", 2000, 5, Group.Gloves, Rarity.Standard),
            //new("Weights", 2200, 8, Group.Gloves, Rarity.Standard),
            //new("Sword", 2650, 9, Group.Sword, Rarity.Standard),
            //new("Heavy Sword", 3025, 17, Group.Sword, Rarity.Standard),
            //new("Bow", 2600, 3, Group.Bow, Rarity.Standard),
            //new("Axe", 2725, 11, Group.Axe, Rarity.Standard),
            //new("Light Axe", 2375, 7, Group.Axe, Rarity.Standard),
            //new("Hammer", 2850, 15, Group.Hammer, Rarity.Standard),
            //new("Heavy Hammer", 3335, 19, Group.Hammer, Rarity.Standard),
            //new("Catapult", 3335, 16, Group.Cannon, Rarity.Standard),
            //new("Better Sword", 10550, 10, Group.Sword, Rarity.New),
            //new("Better Bow", 9525, 4, Group.Bow, Rarity.New),
            //new("Wrench", 1100, 7, Group.Bow, Rarity.New),
            //new("BROKEN HAMMER", 999999999, 30, Group.Hammer, Rarity.Elite),
            //new("Cannon", 999999999, 24, Group.Cannon, Rarity.Elite),
            //new("Gun", 999999999, 6, Group.Bow, Rarity.Elite),
            //new("Queen", 999999999, 17, Group.Cannon, Rarity.Elite),
            //new("Launcher", 53000, 18, Group.Cannon, Rarity.Improved),
            //new("Gauntlets", 49950, 18, Group.Gloves, Rarity.Improved),


            //new Item("Gloves", 30, 5, Group.Gloves, Rarity.Standard, Element.Neutral),
            //new Item("Sword", 60, 9, Group.Sword, Rarity.Standard, Element.Neutral),
            //new Item("Heavy Sword", 85, 17, Group.Sword, Rarity.Standard, Element.Neutral),
            //new Item("Bow", 53, 3, Group.Bow, Rarity.Standard, Element.Neutral),
            //new Item("Axe", 59, 11, Group.Axe, Rarity.Standard, Element.Neutral),
            //new Item("Light Axe", 38, 7, Group.Axe, Rarity.Standard, Element.Neutral),
            //new Item("Hammer", 73, 15, Group.Hammer, Rarity.Standard, Element.Neutral),
            //new Item("Heavy Hammer", 98, 19, Group.Hammer, Rarity.Standard, Element.Neutral),
            //new Item("Better Sword", 130, 10, Group.Sword, Rarity.New, Element.Neutral),
            //new Item("Better Bow", 150, 4, Group.Bow, Rarity.New, Element.Neutral),
        ];
    }
}
