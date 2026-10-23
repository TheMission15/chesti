namespace Chesti.Core.Model
{
    public static class Catalogue
    {

        public static void SkillList(int i)
        {
            Skills[i] = DataManager.LoadSkills((Rarity)i);
        }
        public static void LoadItems()
        {
            Items.Clear();
            Items.AddRange(DataManager.LoadItems());
        }
        public static void LoadSkills()
        {
            for (int i = 0; i < 4; i++)
            {
                SkillList(i);
            }
        }

        public static List<Skill>[] Skills { get; } = { [], [], [], [] };
        //public static Group?[] groups = new Group?[2];
        public static List<Item> Items { get; } = [];
    }
}
