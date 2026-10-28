namespace Chesti.Core.Model
{
    public enum Rarity // for items and quality of chests
    {
        Standard,
        New,
        Improved,
        Elite,
        //Myth
    }
    public enum Input
    {
        None,
        _1 = 1,
        _2 = 2,
        _3 = 3,
        Back,
        Buy,
        Select,

        
    }
    public enum Element // for future element specific skills
    {
        Neutral,
        Fire,
        Water,
        Lightning,
        Nature,
        Ice,
        Anti,
        Radiation,
    }
    public enum Group // for weapons and skill effectiveness
    {
        Freestyle,
        Power,
        Speed,
        Control,
        Range,
        Guile,
        //Flux,
        //Tactic,
        //Close,
        //Magic,
        //Modern,
        //Gloves,
        //Sword,
        //Bow,
        //Axe,
        //Hammer,
        //Cannon,
    }
    public enum ShopType
    {
        Keys,
        Scrolls,
        Chests,
    }
    public enum MoveType  // this is wrong but i might still use it later   -   it is later and im thinking of removing   -   i really dont need it anymore but this thread is becoming funnier by the message
    {

    }
    /*public enum Tier // calculsting the quality of the reward   -   IMPORTANT NOTICE, to be in V4
    {
        Base,
        Tier1,
        Tier2,
        Tier3,
    }
    public enum EnchantType   // further into development
    {

    }*/
}