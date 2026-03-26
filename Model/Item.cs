namespace chesti.Model
{
    public class Item
    {
        public required string Name { get; set; }
        public required Rarity Rarity { get; set; }
        public Element Element { get; set; }
        public Group Group { get; set; }
    }
}