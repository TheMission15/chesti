using chesti.Model;
using System.Text.Json;

namespace chesti.Utils
{
    public static class DataManager
    {
        public static string folder = "C:\\Users\\raulc\\source\\repos\\chesti\\Data";
        public static Player PlayerSaves(string username)
        {
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string filePath = Path.Combine(folder, $"{username}.json");
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                Player player = JsonSerializer.Deserialize<Player>(json);
                return player;
            }
            else
            {
                Player newPlayer = new Player(username, 3, 30);
                string json = JsonSerializer.Serialize(newPlayer, new JsonSerializerOptions { WriteIndented = true });
                return newPlayer;
            }
        } // End of PlayerSaves

        public static void SavePlayer(Player player)
        {
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string filePath = Path.Combine(folder, $"{player.Name}.json");
            string json = JsonSerializer.Serialize(player, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
    }
}
