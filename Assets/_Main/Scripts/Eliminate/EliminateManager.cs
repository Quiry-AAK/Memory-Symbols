using System.Collections.Generic;
using _Main.Scripts.CharacterSeat;

namespace _Main.Scripts.Eliminate
{
    public static class EliminateManager
    {
        public static void EliminateCharacter(List<Seat> losers)
        {
            if(losers.Count <=0) return;
            foreach (var _loser in losers) {
                _loser.Eliminate();
            }
        }
    }
}
