using Chesti.Core.Result;

namespace Chesti.Core.Model
{
    public class Wallet
    {
        public int KeyCount { get; set; }
        public int GoldCount { get; set; }
        public int ScrollCount { get; set; }
        public int Fragments { get; set; }
        public int Essence { get; set; }
        public Wallet(int keyCount, int goldCount, int scrollCount)
        {
            KeyCount = keyCount;
            GoldCount = goldCount;
            ScrollCount = scrollCount;
            Fragments = 0;
            Essence = 0;
        }
        public StringResult BuyKeys(int price, int amount)
        {
            if (GoldCount >= price)
            {
                GoldCount -= price;
                KeyCount += amount;
                return new(true, $"\n Keys:{KeyCount}\n Gold:{GoldCount}");
            }
            else
            {
                return new(false, "You dont have enough gold");
            }
        } // end of BuyKeys

        public StringResult BuyScrolls(int price, int amount)
        {
            if (GoldCount >= price)
            {
                GoldCount -= price;
                ScrollCount += amount;
                return new(true, $"\n Scrolls:{ScrollCount}\n Gold:{GoldCount}");
            }
            else
            {
                return new(false, "You dont have enough gold");

            }
        } // end of BuyKeys
    }
}
