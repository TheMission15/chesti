namespace Chesti.Core.Model
{
    public class Wallet
    {
        public int Scales { get; set; }
        public int Fragments { get; set; }
        public Wallet() { }
        public Wallet(int scales)
        {
            Scales = scales;
            Fragments = 0;
        }
        public override string ToString()
        {
            return $" Scales: {Scales} \n Fragments: {Fragments}";
        }
    }
}
