namespace Chesti.Core.Model
{
    public static class Catalogue
    {

        public static void SkillList(int i)
        {
            Skills[i] = DataManager.LoadSkills(0);
        }
        public static void LoadItems()
        {
            Items.Clear();
            Items.AddRange(DataManager.LoadItems());
        }
        public static void LoadSkills()
        {
            for (int i = 0; i < Skills.Count(); i++)
            {
                SkillList(i);
            }
        }

        public static List<Skill>[] Skills { get; } = [];
        public static Group?[] groups = new Group?[2];
        public static List<Item> Items { get; } = [];
    }
}
