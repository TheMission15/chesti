using Chesti.Core.Result;
namespace Chesti.Core.Model
{
    public class Player
    {
        public string Name { get; set; }
        public Wallet Wallet { get; set; }
        public int SelectedTool { get; set; }
        public int[] ActiveCharms { get; set; }
        public List<Charm> Charms { get; set; }
        public List<Tool> Tools { get; set; }
        //public List<Chest> ChestStorage { get; set; }

        public Player(string name, Wallet wallet)
        {
            Name = name; Wallet = wallet;
            SelectedTool = -1;
            ActiveCharms = [-1, -1, -1];
            Charms = [];
            Tools = [];
            //ChestStorage = [Catalogue.GiveChest((Rarity)0)];
        }
        public void dealDamage(int damage)
        {
            Tools[SelectedTool].Durability -= damage;
            Wallet.Fragments += Methods.randInt(3, damage / 2);
        }
        public void DeleteItem()
        {
            Tools.RemoveAt(SelectedTool);
            SelectedTool = -1;
        }
        public bool SetSkill(int i, ConsoleKey k)
        {
            bool runAgain = true;
            if (k >= ConsoleKey.D1 && k <= ConsoleKey.D3)
            {
                int index = k - ConsoleKey.D0 - 1;
                for (int p = 0; p < 3; p++)
                {
                    if (ActiveCharms[p] == i)
                    {
                        ActiveCharms[p] = i;
                    }
                }
                ActiveCharms[index] = i;
                runAgain = false;
            }
            else if (k == ConsoleKey.Escape)
            {
                runAgain = false;
            }
            return runAgain;
        }
        public bool CheckBreak()
        { 
            if (Tools[SelectedTool].Durability < 0)
            {
                DeleteItem();
                return true;
            }
            return false;
        }
        public bool PassNullCheck()
        {
            if (SelectedTool == -1 || ActiveCharms.All(x => x == -1))
            {
                return false;
            }
            else { return true; }
        }
    }
}
