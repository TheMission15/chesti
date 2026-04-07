using static chesti.Utils.Python;

namespace chesti.Model
{
    public class Player
    {
        public string Name { get; set; }
        public int KeyCount { get; set; }
        public int GoldCount { get; set; }
        public int ScrollCount { get; set; }
        public Item? Selected { get; set; }
        public int? SelectedIndex { get; set; }
        public Skill?[] Skills { get; set; }
        public List<Item> Inventory { get; set; }

        public Player(string name, int keyCount, int goldCount, int scrollCount)
        {
            Name = name; KeyCount = keyCount; GoldCount = goldCount; ScrollCount = scrollCount;
            Skills = new Skill?[3];
            Inventory = new List<Item>() { };
        }
        public void dealDamage(int damage)
        {
            if (Selected != null)
            {
                Selected.Durability -= damage;
                Inventory[Convert.ToInt32(SelectedIndex)].Durability -= damage;
            }
        }
        public void SetSelected(int index)
        {
            Selected = Inventory[index];
            SelectedIndex = index;
        }
        public void DeleteItem()
        {
            if (Selected != null)
            {
                Inventory.Remove(Selected);
                Selected = null;
                SelectedIndex = null;
            }
        }
    }
}
