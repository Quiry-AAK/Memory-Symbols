using _Main.Scripts.CharacterSeat;

namespace _Main.Scripts.Score
{
    public static class CalculatorForAllScores
    {
        public static void CalculateAllScores()
        {
            var _seats = AllSeatsManager.Instance.ActiveSeats;
            foreach (var _seat in _seats) {
                _seat.Character.MemoryButtonScoreCalculator.CalculateScore();
            }
        }
    }
}
