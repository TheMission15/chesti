using chesti.Model;
using static chesti.Utils.Python;
using static chesti.Utils.Methods;

namespace chesti.Utils
{
    public static class Battle
    {        
        public static void Fight(Player p1, Player p2, int rounds = 3, int durability = 500)
        {
            if (p1.Selected == null) { p1.Selected = Catalogue.Items[0].Copy(); }
            if (p2.Selected == null) { p2.Selected = Catalogue.Items[0].Copy(); }
            Fighter player1 = new Fighter(durability, p1.Selected);
            Fighter player2 = new Fighter(durability, p2.Selected);
            player1.RoundsWon = 0; player2.RoundsWon = 0;
            int wincon = (rounds % 2 != 0) ? (rounds / 2) + 1 : (rounds / 2);
            int turn = -1;

            clear();
            print($"Fight Until: {durability}\n\nYou     {p1.Selected.Name}, {p1.Selected.Weight}KG\n\n        VS \n\n{p2.Name}     {p2.Selected.Name}, {p2.Selected.Weight}KG\n\n");
            readKey();
            for (int i = 1; i <= rounds; i++)
            {
                if (p1.Selected == null || p1.Skills.All(x => x == null) || p2.Selected == null || p2.Skills.All(x => x == null))
                {
                    return;
                }

                if (player1.RoundsWon == wincon || player2.RoundsWon == wincon)
                {
                    break;
                }

                while (true)
                {
                    if (player1.Durability <= 0 || player2.Durability <= 0)
                    {
                        break;
                    }

                    if (player1.Select)
                    {
                        player1.SkillUsed = SelectSkill(p1); player1.calculateTurn(turn);
                        player1.calculateDamage();
                        player1.Select = false;
                    }
                    else if (turn == player1.Wait)
                    {
                        p2.dealDamage(player1.Damage);
                        player2.Durability -= player1.Damage;
                        player1.Select = true;
                    }


                    if (player2.Select)
                    {
                        player2.SkillUsed = SelectSkill(p2, true); player2.calculateTurn(turn);
                        player2.calculateDamage();
                        player2.Select = false;
                    }
                    else if (turn == player2.Wait)
                    {
                        p1.dealDamage(player2.Damage);
                        player1.Durability -= player2.Damage;
                        player2.Select = true;
                    }
                    turn++;
                    clear();
                    print($"turn {turn}\n\n");
                    print($"You     {p1.Selected.Name}, {p1.Selected.Weight}KG\n\n");
                    print($" durability {player1.Durability}\n {player1.Damage} Damage \n on turn {player1.Wait}\n\n");
                    print($"{p2.Name}     {p2.Selected.Name}, {p2.Selected.Weight}KG\n\n");
                    print($" durability {player2.Durability}\n {player2.Damage} Damage \n on turn {player2.Wait}\n\n");
                    readKey();
                }


                if (player2.Durability <= 0 && player1.Durability > 0)
                {
                    popUp("player 1 wins", false, 500);
                    player1.RoundsWon++;
                    p1.GoldCount += 5;
                }
                else if (player1.Durability <= 0 && player2.Durability > 0)
                {
                    popUp("player 2 won", false, 500);
                    player2.RoundsWon++;
                }
                else if (p1.Selected.Weight < p2.Selected.Weight)
                {
                    popUp("player 1 wins", false, 500);
                    player1.RoundsWon++;
                    p1.GoldCount += 5;
                }
                else
                {
                    popUp("player 2 won", false, 500);
                    player2.RoundsWon++;
                }

                if (p1.Selected.Durability < 0)
                {
                    p1.DeleteItem();
                    popUp("     YOUR TOOL BROKE!!!!!\n\n you need a new one", false, 1000);
                    SelectItem(p1);
                    if (p1.Selected == null)
                    {
                        popUp("... you aint got a new one", false, 800);
                    }
                }
            }


            if (player1.RoundsWon == wincon)
            {
                popUp("player 1 won the match", false, 500);
                p1.GoldCount += 25;
            }
            else
            {
                popUp("player 2 won the round", false, 500);
            }

        }
        public static Skill SelectSkill(Player player, bool npc = false)
        {
            Skill? skill = null;
            if (npc)
            {
                while (skill == null)
                {
                    int randint = randInt(0, 2);
                    skill = player.Skills[randint];
                }
            }
            print("Choose Skill to use\n");
            ListSkills(player); print("\n");
            while (skill == null)
            {
                ConsoleKeyInfo key = readKey();
                if (key.Key == ConsoleKey.D1 || key.Key == ConsoleKey.D2 || key.Key == ConsoleKey.D3)
                {
                    int dif = key.Key - ConsoleKey.D0;
                    skill = player.Skills[dif - 1];
                }
            }
            return skill;
        }
    }
}
