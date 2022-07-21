using _Main.Scripts.CharacterSeat;

namespace _Main.Scripts.Answer
{
    public static class SeatAnswerResetter
    {
        public static void ResetAllAnswers()
        {
            var _activeSeats = AllSeatsManager.Instance.ActiveSeats;
            foreach (var _activeSeat in _activeSeats) {
                _activeSeat.Character.ResetMyGuesses();
            }
        }
    }
}
