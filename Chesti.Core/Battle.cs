using Chesti.Core.Model;
using Chesti.Core.Result;
using static Chesti.Core.DataManager;

namespace Chesti.Core
{
    public class Battle
    {
        public Player Player1 { get; set; }
        public Fighter Fighter1 { get; set; }
        public Player Player2 { get; set; }
        public Fighter Fighter2 { get; set; }
        public RoundResult Result { get; set; }
        public int Turn { get; set; }
        public int BestOf { get; set; } // 
        public int Wincon { get; set; } // 1600, 3400, 7200, 15000, 30000
        public int Durability { get; set; } // 300 - 500 400, 700 - 1000 850, 1400 - 1800 1600, 2400 - 2900 2650, 10,000
        public Battle(Player player1, Player player2, int bestOf, int durability)
        {
            Player1 = player1; Player2 = player2;
            Player1.Selected ??= Catalogue.Items[0][0].Copy(); Player2.Selected ??= Catalogue.Items[0][0].Copy();
            Turn = 0; BestOf = bestOf; Wincon = BestOf % 2 != 0 ? (BestOf / 2) + 1 : BestOf / 2; Durability = durability;
            Fighter1 = new Fighter(Durability, Player1.Selected, false); Fighter2 = new Fighter(Durability, Player2.Selected, true);

            Result = new(true, false, false, false, false, false, false, false);
        }

        public void RoundWinner()
        {
            if (Fighter2.Durability <= 0 && Fighter1.Durability > 0)
            {
                Fighter1.Win();
            }
            else if (Fighter1.Durability <= 0 && Fighter2.Durability > 0)
            {
                Fighter2.Win();
            }
            else if (Fighter1.Tool.Weight < Fighter2.Tool.Weight)
            {
                Fighter1.Win();
            }
            else
            {
                Fighter2.Win();
            }
            Result.Active = false;
        } // end of RoundWinner()
        public string MatchWinner()
        {
            if (Fighter1.RoundsWon == Wincon)
            {
                Result.Player1Won = true;
                return "Player 1 Wins";
            }
            else
            {
                Result.Player1Won = false;
                return "Player 2 Wins";
            }
        }
        public string NewRound()
        {
            if (Player1.Selected != null && Player2.Selected != null)
            {
                Fighter1.Reset(Durability, Player1.Selected);
                Fighter2.Reset(Durability, Player2.Selected);
                Result.Active = true;
                return "New Round";
            }
            return "error?";
        }
        public bool RoundCondition() { return (Fighter1.Durability > 0 && Fighter2.Durability > 0); } // condition for while loop
        public void CheckBreak()
        {
            Result.Player1Break = Player1.CheckBreak();
            Result.Player2Break = Player2.CheckBreak();
        }
        public void PlayTurn(ConsoleKey k)
        {
            Result.Player1Valid = Fighter1.PassTurn(Turn, Player1, Player2, Fighter2, k, Result.Player1Valid);
            Result.Player2Valid = Fighter2.PassTurn(Turn, Player2, Player1, Fighter1, k, Result.Player2Valid);
            if (Result.Player1Valid && Result.Player2Valid)
            {
                Turn++;
                Result.Player1Valid = false; Result.Player2Valid = false;
            }
        } // end of PlayTurn()
        public string StartOfRound()
        {
            if (Fighter1.RoundsWon == Wincon || Fighter2.RoundsWon == Wincon)
            {
                Result.WinconReached = true;
                return "Match Over";
            }
            else if (!Player1.PassNullCheck() || !Player2.PassNullCheck())
            {
                Result.PassedNullCheck = false;
                return "Failed Null Check";
            }
            else
            {
                return NewRound();
            }
        }
        public string EndOfRound()
        {
            string message = "";
            RoundWinner();
            CheckBreak();
            SavePlayer(Player1);
            if (Fighter1.RoundWinner) { message += "Player 1 Won round\n\n"; }
            else { message += "Player 2 Won round\n\n"; }
            if (Result.Player1Break) { message += "Player 1 Broke tool\n\n"; }
            if (Result.Player2Break) { message += "Player 2 Broke tool\n\n"; }
            return message + "Saved Player";

        }
    }
}
