using _Main.Scripts.Answer;
using _Main.Scripts.CharacterSeat;
using _Main.Scripts.Symbol;
using _Main.Scripts.Timer;
using DG.Tweening;

namespace _Main.Scripts.Round
{
    public class RoundManager
    {
        private SymbolScOb roundAnswer;

        private float showAnswerPhaseDuration;
        private float answeringPhaseDuration;

        #region Props

        public float AnsweringPhaseDuration => answeringPhaseDuration;
        public SymbolScOb RoundAnswer => roundAnswer;

        #endregion

        public RoundManager(float showAnswerPhaseDuration, float answeringPhaseDuration)
        {
            this.showAnswerPhaseDuration = showAnswerPhaseDuration;
            this.answeringPhaseDuration = answeringPhaseDuration;
        }

        public void StartRoundWithDelay(float delay)
        {
            DOVirtual.DelayedCall(delay, StartRound);
        }
        private void StartRound()
        {
            roundAnswer = RandomAnswerGetter.GetRandomAnswer();
            ShowAnswerPhase.StartShowAnswerPhase();
            TimerManager.Instance.SetActivenessOfTimer(true);
            TimerManager.Instance.SetTimer(showAnswerPhaseDuration,
                () => AnsweringPhase.StartAnsweringPhase(answeringPhaseDuration, EndRoundPhase.EndRound));
        }
    }
}
