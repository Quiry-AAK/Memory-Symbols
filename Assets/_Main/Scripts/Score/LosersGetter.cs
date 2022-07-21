using System;
using System.Collections.Generic;
using _Main.Scripts.CharacterSeat;

namespace _Main.Scripts.Score
{
    public static class LosersGetter
    {
        public static List<Seat> GetLosers()
        {
            var _seats = AllSeatsManager.Instance.ActiveSeats;
            var _highestScore = 0f;
            var _lowestScore = 101f;
            foreach (var _seat in _seats) {
                if (_lowestScore > _seat.Character.MemoryButtonScoreCalculator.Score) {
                    _lowestScore = _seat.Character.MemoryButtonScoreCalculator.Score;
                }
                if (_highestScore < _seat.Character.MemoryButtonScoreCalculator.Score) {
                    _highestScore = _seat.Character.MemoryButtonScoreCalculator.Score;
                }
            }
            
            var _losers = new List<Seat>();
            
            if(Math.Abs(_highestScore - _lowestScore) < .5f)
                return _losers;
                
            foreach (var _seat in _seats) {
                if (Math.Abs(_seat.Character.MemoryButtonScoreCalculator.Score - _lowestScore) < .5f) {
                    _losers.Add(_seat);
                }
            }

            return _losers;
        }
    }
}
