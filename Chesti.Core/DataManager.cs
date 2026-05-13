using Chesti.Core.Model;
using System.Text.Json;

namespace Chesti.Core
{
    public static class DataManager
    {
        public static string BasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Chesti");
        public static string Folder = "C:\\Users\\raulc\\source\\repos\\Chesti\\Chesti.Core\\Catalogue";
        public static Player PlayerSaves(string username)  // --- Player Data ---
        {
            string path = Path.Combine(BasePath, "Data");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path = Path.Combine(path, $"{username}.json");
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                Player player = JsonSerializer.Deserialize<Player>(json) ?? new Player(username, new(0));
                return player;
            }
            else
            {
                Player newPlayer = new Player(username, new(100));
                string json = JsonSerializer.Serialize(newPlayer, new JsonSerializerOptions { WriteIndented = true });
                return newPlayer;
            }
        } // End of PlayerSaves

        public static void SavePlayer(Player player)
        {
            string path = Path.Combine(BasePath, "Data");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path = Path.Combine(path, $"{player.Name}.json");
            string jsonData = JsonSerializer.Serialize(player, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, jsonData);
        }
        public static void DeletePlayer(Player player)
        {
            string path = Path.Combine(BasePath, "Data");
            path = Path.Combine(path, $"{player.Name}.json");
            if (!Directory.Exists(path))
            {
                Directory.Delete(path);
            }
        }                       //      --- Player Data ---


        public static List<Item> LoadItems() // --- Item Data ---
        {
            string path = Folder;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path = Path.Combine(path, $"Items.json");
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                List<Item> items = JsonSerializer.Deserialize<List<Item>>(json) ?? [];
                return items;
            }
            else
            {
                List<Item> items = [];
                string json = JsonSerializer.Serialize(items, new JsonSerializerOptions { WriteIndented = true });
                return items;
            }
        }
        public static void AddItem(Item item)
        {
            string path = Folder;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            List<Item> items = LoadItems();
            items.Add(item);
            path = Path.Combine(path, $"Items.json");
            string jsonData = JsonSerializer.Serialize(items, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, jsonData);
        }                   //              --- Item Data ---


        public static List<Skill> LoadSkills(Rarity rarity) // --- Skill Data ---
        {
            string path = Folder;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path = Path.Combine(path, $"{rarity}.json");
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                List<Skill> skills = JsonSerializer.Deserialize<List<Skill>>(json) ?? [];
                return skills;
            }
            else
            {
                List<Skill> skills = [];
                string json = JsonSerializer.Serialize(skills, new JsonSerializerOptions { WriteIndented = true });
                return skills;
            }
        }
        public static void AddSkill(Skill skill)
        {
            string path = Folder;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            List<Skill> skills = LoadSkills(skill.Rarity);
            skills.Add(skill);
            path = Path.Combine(path, $"{skill.Rarity}.json");
            string jsonData = JsonSerializer.Serialize(skills, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, jsonData);
        }                   //              --- Skill Data ---
    }
}
