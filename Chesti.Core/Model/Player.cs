using Chesti.Core.Result;
using static Chesti.Core.DataManager;
namespace Chesti.Core.Model
{
    public class Player
    {
        public string Name { get; set; }
        public Wallet Wallet { get; set; }
        public Item? Selected { get; set; }
        public int? SelectedIndex { get; set; }
        public Skill?[] Skills { get; set; }
        public List<Item> Inventory { get; set; }
        public List<Chest> ChestStorage { get; set; }

        public Player(string name, Wallet wallet)
        {
            Name = name; Wallet = wallet;
            Skills = new Skill?[3];
            Inventory = [];
            ChestStorage = [Catalogue.GiveChest((Rarity)0)];
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
                int rarity = (int)Selected.Rarity + 2;
                Wallet.Fragments += Methods.randInt(rarity * 2, rarity * rarity);
                Selected = null;
                SelectedIndex = null;

            }
        }
        public bool SetSkill(AcquireSkillResult result, ConsoleKey k)
        {
            bool runAgain = true;
            if (k >= ConsoleKey.D1 && k <= ConsoleKey.D3)
            {
                int index = k - ConsoleKey.D0 - 1;
                Skills[index] = result.Skill;
                runAgain = false;
            }
            else if (result.Droppable == true)
            {
                runAgain = false;
            }
            return runAgain;
        }
        public bool CheckBreak()
        { 
            if (Selected == null || Selected.Durability < 0)
            {
                DeleteItem();
                return true;
            }
            return false;
        }
        public bool PassNullCheck()
        {
            if (Selected == null || Skills.All(x => x == null))
            {
                return false;
            }
            else { return true; }
        }
    }
}
