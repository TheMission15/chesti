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
            ConsoleKey key;

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
                        if (battle.Fighter1.SkillUsed == null) { print(ListCharms(player)); }
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
