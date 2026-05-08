using Chesti.Core.Result;

namespace Chesti.Core.Model
{
    public class Wallet
    {
        public int[] Scales { get; set; }
        public int Fragments { get; set; }
        public Wallet(int scales)
        {
            Scales = new int[7];
            Scales[0] = scales;
            Fragments = 0;
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
