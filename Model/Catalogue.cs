
namespace chesti.Model
{
    public static class Catalogue
    {
        public static List<Skill> Skills = new List<Skill>()
        {
            new Skill("Punch", 10,4),
            new Skill("Slash", 15, 5)
        };
        public static List<Item> Items = new List<Item>()
        {
            new Item("Gloves", 60, 5, Group.Gloves, Rarity.Standard, Element.Neutral),
            new Item("Sword", 150, 9, Group.Sword, Rarity.Standard, Element.Neutral),
            new Item("Heavy Sword", 85, 17, Group.Sword, Rarity.Standard, Element.Neutral),
            new Item("Bow", 53, 3, Group.Bow, Rarity.Standard, Element.Neutral),
            new Item("Axe", 59, 11, Group.Axe, Rarity.Standard, Element.Neutral),
            new Item("Light Axe", 38, 7, Group.Axe, Rarity.Standard, Element.Neutral),
            new Item("Hammer", 73, 15, Group.Hammer, Rarity.Standard, Element.Neutral),
            new Item("Heavy Hammer", 98, 19, Group.Hammer, Rarity.Standard, Element.Neutral),
            new Item("Better Sword", 130, 10, Group.Sword, Rarity.New, Element.Neutral),
            new Item("Better Bow", 150, 4, Group.Bow, Rarity.New, Element.Neutral),

            new Item("Gloves", 60, 5, Group.Gloves, Rarity.Standard, Element.Neutral),
            new Item("Sword", 60, 9, Group.Sword, Rarity.Standard, Element.Neutral),
            new Item("Heavy Sword", 85, 17, Group.Sword, Rarity.Standard, Element.Neutral),
            new Item("Bow", 53, 3, Group.Bow, Rarity.Standard, Element.Neutral),
            new Item("Axe", 59, 11, Group.Axe, Rarity.Standard, Element.Neutral),
            new Item("Light Axe", 38, 7, Group.Axe, Rarity.Standard, Element.Neutral),
            new Item("Hammer", 73, 15, Group.Hammer, Rarity.Standard, Element.Neutral),
            new Item("Heavy Hammer", 98, 19, Group.Hammer, Rarity.Standard, Element.Neutral),
            new Item("Better Sword", 130, 10, Group.Sword, Rarity.New, Element.Neutral),
            new Item("Better Bow", 150, 4, Group.Bow, Rarity.New, Element.Neutral),
        };
    }
}
