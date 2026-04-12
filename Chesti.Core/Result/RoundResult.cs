using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;

namespace Chesti.Core.Result
{
    public class RoundResult
    {
        public bool PassedNullCheck { get; set; }
        public bool WinconReached { get; set; }
        public bool Active { get; set; }
        public bool Player1Break { get; set; }
        public bool Player2Break { get; set; }
        public bool Player1Won { get; set; }
        public bool Player1Valid { get; set; }
        public bool Player2Valid { get; set; }
        public RoundResult(bool passedNullCheck, bool winconReached, bool active, bool player1Break, bool player2Break, bool player1Won, bool player1Valid, bool player2Valid)
        {
            PassedNullCheck = passedNullCheck; WinconReached = winconReached; Active = active;
            Player1Break = player1Break; Player1Valid = player1Valid;
            Player2Break = player2Break; Player2Valid = player2Valid;
            Player1Won = player1Won;
        }
    }
}
