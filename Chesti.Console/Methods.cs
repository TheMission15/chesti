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
        public static void Test(Player player)
        {
            player.Selected = Catalogue.Items[0][0].Copy();
            print($"{player.Selected}");
            player.SetSelected(2);
            print($"{player.Selected}");readKey();
                }
        public static void BuyItem(Player player, int price, int amount, ShopType x)
        {
            if (x == ShopType.Keys)
            {
                var result = player.Wallet.BuyKeys(price, amount);
                popUp(result.Message);
            }
            else if (x == ShopType.Scrolls)
            {
                var result = player.Wallet.BuyScrolls(price, amount);
                popUp(result.Message);
            }
        } // end of BuyItem
        public static void GiveSkill(Player player)
        {
            var result = AcquireSkill(player);
            print(result.Message);
            while (result.Result)
            {
                ConsoleKeyInfo key = readKey();
                result.Result = player.SetSkill(result, key.Key);
            }
            popUp("updated skills: \n" + ListSkills(player), true);
        } // end of GiveSkill
        public static void OpenChest(Player player)
        {
            StringResult result = Catalogue.Chests[0].OpenChest(player);
            if (!result.Result) { popUp(result.Message); }
            else
            {
                popUp($"You opened a {result.Message}");
            }
        }
        public static void Wallet(Player player)
        {
            print($"You have \n\n Keys:{player.Wallet.KeyCount} \n Gold:{player.Wallet.GoldCount} \n Scrolls:{player.Wallet.ScrollCount}\n");
            print(ListSkills(player));
            readKey();
        } // end of Wallet
        public static void ShowItemPage(Page<Item> page, Player player)
        {
            for (int i = 0; i < page.InPage; i++) { print($"{i + 1}. {page.Items[i]}"); }
        } // end of ShowItemPage
        public static bool ViewItems(Book<Item> book, Player player, bool selecting = false)
        {
            if (player.Inventory.Count == 0)
            {
                popUp("no items amigo");
                return false;
            }
            ConsoleKeyInfo k;
            IntResult result = new(true, -1);
            while (result.Result)
            {
                clear(); print($"Page {book.Page} of {book.Pages.Count}    ESC to leave    arrow keys to change pages");
                ShowItemPage(book.Pages[book.Page-1], player);
                k = readKey(); result = book.BookNav(player, k.Key, selecting);

            }
            if (result.Number > -1) { player.SetSelected(result.Number); }
            popUp($"\nItem Selected: {player.Selected}", true);
            return true;
        } // end of ViewItems
        public static Book<Item> Write(Player player){ return new(player.Inventory); }
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
            if (player.Selected == null || player.SelectedIndex == null)
            {
                return new(false, " Esc for back \n S for selecting item");
            }
            else
            {
                return new(true, " Esc for back \n S for selecting item \n B for random battle");
            }
        } // end of BattleLock
        public static void RoundUI(Battle battle)
        {
            clear();
            print($"turn {battle.Turn}        Space to advance \n\n");
            print($"You     {battle.Player1.Selected!.Name}, {battle.Player1.Selected!.Weight}KG\n\n");
            print($" durability {battle.Fighter1.Durability}\n {battle.Fighter1.Damage} Damage \n on turn {battle.Fighter1.Wait}\n\n");
            print($"Opp     {battle.Player2.Selected!.Name}, {battle.Player2.Selected!.Weight}KG\n\n");
            print($" durability {battle.Fighter2.Durability}\n {battle.Fighter2.Damage} Damage \n on turn {battle.Fighter2.Wait}\n\n");
        }
        public static void VerifyBattle(Player player, bool itemLock)
        {
            bool skillLock = false;
            if (player.Skills.All(x => x == null)) { skillLock = true; }
            if (skillLock || !itemLock)
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
            Book<Item> book;
            Battle battle = new(player, npc, 3, 500);
            ConsoleKey key;

            for (int i = 0; i < battle.BestOf; i++)
            {
                book = Write(player);
                while (battle.Result.Player1Break) { ViewItems(book, player, true); battle.Result.Player1Break = false; }
                print(battle.StartOfRound()+"\n");
                if (battle.Result.PassedNullCheck && !battle.Result.WinconReached && battle.Result.Active)
                {
                    print($"Fight Until: {battle.Durability}\n\nYou     {battle.Player1.Selected!.Name}, {battle.Player1.Selected!.Weight}KG\n\n" +
                        $"        VS \n\nOpp     {battle.Player2.Selected!.Name}, {battle.Player2.Selected!.Weight}KG\n\n");
                    readKey();
                    while (battle.RoundCondition())
                    {
                        RoundUI(battle);
                        if (battle.Fighter1.SkillUsed == null) { print(ListSkills(player)); }
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
