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
        public override string ToString()
        {
            return $" Scales: {Scales[0]} \n Fragments: {Fragments}";
        }
    }
}
