namespace Chesti.Core.Model
{
    public class Item
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public Group[] Groups { get; set; } = new Group[2];
        public Item(string name, int weight, Group[] groups)
        {
            Name = name;
            Weight = weight;
            Groups = groups;
        }
    }
}