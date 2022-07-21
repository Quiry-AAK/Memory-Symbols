using _Main.Scripts.AI;
using _Main.Scripts.Answer;
using _Main.Scripts.CharacterSeat;
using _Main.Scripts.Timer;
using UnityEngine;

namespace _Main.Scripts.Round
{
    public static class AnsweringPhase
    {
        public static void StartAnsweringPhase(float answeringPhaseDuration, TimerManager.TimerOnComplete timerOnComplete)
        {
            SeatAnswerResetter.ResetAllAnswers();
            TimerManager.Instance.SetTimer(answeringPhaseDuration, timerOnComplete);

            foreach (var _seat in AllSeatsManager.Instance.Seats) {
                var _seatMono = _seat.Character as MonoBehaviour;
                if (_seatMono != null && _seatMono.TryGetComponent(out AIManager _aiManager) && !_seat.eliminated) {
                    _aiManager.AIAnswerer.StartAnswering();
                }
            }
        }
    }
}
