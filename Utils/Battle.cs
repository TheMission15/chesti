using chesti.Model;
using static chesti.Utils.Python;

namespace chesti.Utils
{
    public static class Battle
    {
        public static void recieveDamage(Item reciever, Item dealer, Skill skill)
        {
            int random = randInt(2, 6);
            if (random > 5)
            {
                reciever.Durability -= dealer.Weight * skill.Damage;
            }
            else
            {
                reciever.Durability -= dealer.Weight * skill.Damage * (random / 10);
            }
        }
        public static int calculateTurn(Player player, Skill skill)
        {
            int wait = player.Selected.Weight / (skill.Speed );
            if (wait < 2)
            {
                wait++;
            }
            return wait;
        }
        public static void Fight(Player first, Player second)
        {
            int firstCounter = 1; int secondCounter = 1;
            int firstWait = calculateTurn(first, first.Skills[0]);
            int secondWait = calculateTurn(second, second.Skills[0]);
            if (firstCounter == secondCounter)
            {
                print("hi");
            }


        }
    }
}
