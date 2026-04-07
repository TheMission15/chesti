
namespace chesti.Model
{
    public static class Catalogue
    {
        public static List<Skill> Skills = new List<Skill>()
        {
            new Skill("Punch", 10,8),
            new Skill("Slash", 13, 9),
            new Skill("Swing", 16, 6),
            new Skill("Squash", 20, 3),
            new Skill("Shoot", 7, 11),
            new Skill("Bash", 18, 6),
            new Skill("Crank", 17, 7),
        };
        public static List<Item> Items = new List<Item>()
        {
            new Item("Gloves", 320, 5, Group.Gloves, Rarity.Standard, Element.Neutral),
            new Item("Weights", 2200, 8, Group.Gloves, Rarity.Standard, Element.Neutral),
            new Item("Sword", 2650, 9, Group.Sword, Rarity.Standard, Element.Neutral),
            new Item("Heavy Sword", 3025, 17, Group.Sword, Rarity.Standard, Element.Neutral),
            new Item("Bow", 2600, 3, Group.Bow, Rarity.Standard, Element.Neutral),
            new Item("Axe", 2725, 11, Group.Axe, Rarity.Standard, Element.Neutral),
            new Item("Light Axe", 2375, 7, Group.Axe, Rarity.Standard, Element.Neutral),
            new Item("Hammer", 2850, 15, Group.Hammer, Rarity.Standard, Element.Neutral),
            new Item("Heavy Hammer", 3335, 19, Group.Hammer, Rarity.Standard, Element.Neutral),
            new Item("Better Sword", 10550, 10, Group.Sword, Rarity.New, Element.Neutral),
            new Item("Better Bow", 9525, 4, Group.Bow, Rarity.New, Element.Neutral),
            new Item("BROKEN HAMMER", 999999999, 30, Group.Hammer, Rarity.Elite, Element.Neutral),

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
        };
    }
}
