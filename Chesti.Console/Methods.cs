using Chesti.Core;
using Chesti.Core.Model;
using Chesti.Core.Result;
using static Chesti.Console.Python;
using static Chesti.Core.DataManager;
using static Chesti.Core.Methods;

namespace Chesti.Console
{
    public class Methods
    {
        public static void ShowCharmPage(Page<Charm> page, Player player)
        {
            for (int i = 0; i < page.InPage; i++) { print($"{i + 1}. {page.Items[i]}"); }
        } // end of ShowCharmPage
        public static void ShowToolPage(Page<Tool> page, Player player)
        {
            for (int i = 0; i < page.InPage; i++) { print($"{i + 1}. {page.Items[i]}"); }
        } // end of ShowItemPage

        public static void CreateItem()
        {
            ConsoleKeyInfo k;
            while (true)
            {
                clear(); print(" 1. for Items\n 2. for Skills\n 3. to return");
                k = readKey();
                if (k.Key == ConsoleKey.D1)
                {
                    string? name = input("Name of tool: ");
                    int.TryParse(input("Weight: "), out int weight);
                    string? group = input("First group: ");
                    Group group1 = !int.TryParse(group, out int opt) ? 0 : (Group)opt;
                    group = input("Second group: ");
                    Group group2 = !int.TryParse(group, out opt) ? 0 : (Group)opt;
                    Group[] groups = { group1, group2 };
                    Item newItem = new((name == null) ? "" : name, weight, groups);
                    print($"Add: {newItem.ToString()}\n y/n");
                    k = readKey();
                    if (k.Key == ConsoleKey.Y)
                        AddItem(newItem);
                }
                else if (k.Key == ConsoleKey.D2)
                {
                    string? name = input("Name of Skill: ");
                    int.TryParse(input("Power: "), out int power);
                    int.TryParse(input("Speed: "), out int speed);
                    List<Group> groups = [];
                    int opt;
                    while (true)
                    {
                        string? group = input("New group: ");
                        if (int.TryParse(group, out opt))
                            groups.Add((Group)opt);
                        else
                            break;
                    }
                    string? extra = input("Element: ");
                    Element element = !int.TryParse(extra, out opt) ? 0 : (Element)opt;
                    extra = input("Rarity: ");
                    Rarity rarity = !int.TryParse(extra, out opt) ? 0 : (Rarity)opt;
                    Skill newSkill = new((name == null) ? "" : name, rarity, power, speed, groups, element);
                    print($"Add: {newSkill.ToString()}\n y/n");
                    k = readKey();
                    if (k.Key == ConsoleKey.Y)
                        AddSkill(newSkill);
                }
                else if (k.Key == ConsoleKey.D3)
                    break;
            }
        }

        public static bool ViewCharms(Book<Charm> book, Player player, bool selecting = false)
        {
            if (player.Charms.Count == 0)
            {
                popUp("no can do without any experience");
                return false;
            }
            ConsoleKeyInfo k;
            IntResult result = new(true, -1);
            while (result.Result)
            {
                clear(); print($"Page {book.Page} of {book.Pages.Count}    ESC to leave    arrow keys to change pages");
                ShowCharmPage(book.Pages[book.Page - 1], player);
                k = readKey(); result = book.BookNav(player, k.Key, selecting);

            }
            if (result.Number > -1)
            {
                bool loop = true;
                while (loop)
                {
                    clear(); print(ListCharms(player));
                    k = readKey();
                    loop = player.SetSkill(result.Number, k.Key);
                }
            }
            popUp($"\nItem Selected: ", true);
            return true;
        } // end of ViewCharms
        public static bool ViewTools(Book<Tool> book, Player player, bool selecting = false)
        {
            if (player.Tools.Count == 0)
            {
                popUp("no items amigo");
                return false;
            }
            ConsoleKeyInfo k;
            IntResult result = new(true, -1);
            while (result.Result)
            {
                clear(); print($"Page {book.Page} of {book.Pages.Count}    ESC to leave    arrow keys to change pages");
                ShowToolPage(book.Pages[book.Page-1], player);
                k = readKey(); result = book.BookNav(player, k.Key, selecting);

            }
            if (result.Number > -1) { player.SelectedTool = result.Number; }
            popUp($"\nItem Selected: {player.Tools[player.SelectedTool]}", true);
            return true;
        } // end of ViewItems
        public static Book<Tool> WriteT(Player player) { return new(player.Tools); }
        public static Book<Charm> WriteC(Player player) { return new(player.Charms); }
        public static Player JoinGame()
        {
            string? username = null;
            while (username == null)
            {
                clear();
                username = input("Username: ");
            }
            return PlayerSaves(username);
        } // end of JoinGame
        public static StringResult BattleLock(Player player)
        {
            string baseMessage = " S.Change build \n F. Info Desk";
            if (player.SelectedTool == -1 && player.ActiveCharms.All(x => x == -1))
            {
                return new(false, $"{baseMessage} \n Make sure you have equiped a Tool and a Charm");
            }
            else
            {
                return new(true, $"{baseMessage} \n C. Random Battle \n Q. Online \n E. Expedisions");
            }
        } // end of BattleLock
        public static void RoundUI(Battle battle)
        {
            clear();
            print($"turn {battle.Turn}        Space to advance \n\n");
            print($"You     {battle.Player1.Tools[battle.Player1.SelectedTool].Name}, {battle.Player1.Tools[battle.Player1.SelectedTool].Weight}KG\n\n");
            print($" durability {battle.Fighter1.Durability}\n {battle.Fighter1.Damage} Damage \n on turn {battle.Fighter1.Wait}\n\n");
            print($"Opp     {battle.Player2.Tools[battle.Player2.SelectedTool].Name}, {battle.Player2.Tools[battle.Player2.SelectedTool].Weight}KG\n\n");
            print($" durability {battle.Fighter2.Durability}\n {battle.Fighter2.Damage} Damage \n on turn {battle.Fighter2.Wait}\n\n");
        }
        public static void VerifyBattle(Player player, bool unLock)
        {
            if (!unLock)
            {
                popUp("You need at least one skill and some durability on ur tool");
            }
            else
            {
                StartBattle(player);
            }
        } // end of VerifyBattle
        public static void StartBattle(Player player)
        {
            clear();
            Player npc = PlayerSaves("npc"); NPC(npc);
            Book<Tool> book;
            Battle battle = new(player, npc, 3, 500, false);
            ConsoleKey key = ConsoleKey.Z;

            for (int i = 0; i < battle.BestOf; i++)
            {
                book = WriteT(player);
                while (battle.Result.Player1Break) { ViewTools(book, player, true); battle.Result.Player1Break = false; }
                print(battle.StartOfRound()+"\n");
                if (battle.Result.PassedNullCheck && !battle.Result.WinconReached && battle.Result.Active)
                {
                    print($"Fight Until: {battle.Durability}\n\nYou     {battle.Player1.Tools[battle.Player1.SelectedTool].Name}, {battle.Player1.Tools[battle.Player1.SelectedTool].Weight}KG\n\n" +
                        $"        VS \n\nOpp     {battle.Player2.Tools[battle.Player2.SelectedTool].Name}, {battle.Player2.Tools[battle.Player2.SelectedTool].Weight}KG\n\n");
                    readKey();
                    while (battle.RoundCondition())
                    {
                        RoundUI(battle);
                        if (battle.Fighter1.SkillUsed == null) 
                        {
                            print(ListCharms(player));
                            key = readKey().Key;
                        }
                        else if (battle.Fighter2.SkillUsed == null)
                            key = readKey().Key;
                        battle.PlayTurn(key);
                    }   
                    popUp(battle.EndOfRound());    
                }
            }
            popUp(battle.MatchWinner(), true);
        } // end of StartBattle
    }
}
