using Chesti.Core.Model;
using System.Numerics;
using System.Text.Json;

namespace Chesti.Core
{
    public static class DataManager
    {
        public static string BasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Chesti");
        public static Player PlayerSaves(string username)
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
                Player player = JsonSerializer.Deserialize<Player>(json) ?? new Player(username, new(0, 0, 0));
                return player;
            }
            else
            {
                Player newPlayer = new Player(username, new(3, 30, 1));
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
        }
        public static List<Item> LoadItem(Rarity rarity)
        {
            string path = Path.Combine(BasePath, "Data");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path = Path.Combine(path, $"{rarity}.json");
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                List<Item> item = JsonSerializer.Deserialize<List<Item>>(json) ?? new();
                return item;
            }
            else
            {
                List<Item> item = [];
                string json = JsonSerializer.Serialize(item, new JsonSerializerOptions { WriteIndented = true });
                return item;
            }
        }
        public static void AddItem(Item item)
        {
            string path = Path.Combine(BasePath, "Catalouge");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            List<Item> items = LoadItem(item.Rarity);
            items.Add(item);
            path = Path.Combine(path, $"{item.Rarity}.json");
            string jsonData = JsonSerializer.Serialize(items, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, jsonData);
        }
    }
}
