using System.Runtime.CompilerServices;
using static chesti.Python;
namespace chesti.Blueprints
{
    public class Chest
    {
        public required string Name { get; set; }
        public required Rarity Rarity { get; set; }

        public int chest(ref int keys, Random r, Item[] equipment, ref Item[] inventory)
        {
            int length = equipment.Length;
            bool finding = true;
            bool counting = false;
            keys--;

            int roll = r.Next(1, 10);
            Rarity chosen = Rarity.Common;
            int count = 0;

            if (roll >= 10)
            {
                chosen = Rarity.Uncommon;
            }

            while (finding)
            {
                if (counting)
                {
                    finding = false;
                }
                for (int i = 0; i < length; i++)
                {

                    if (equipment[i].Rarity == chosen)
                    {
                        if (counting)
                        {
                            if (roll == 0)
                            {
                                inventory = inventory.Append(equipment[i]).ToArray();
                                return i;
                            }
                            roll--;
                        }
                        else
                        {
                            count++;
                        }
                    }
                }
                roll = r.Next(1, count);
                counting = true;
            }
            return -1;
        }

    }
}
