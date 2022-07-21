using _Main.Scripts.Characters;
using _Main.Scripts.Core;

namespace _Main.Scripts.MemoryButton.Common
{
    public class MemoryButtonScoreCalculator
    {
        private const float scoreForEachButton = 2.78f; // --> 100 / 36
        private IMemoryButton[] memoryButtons;
        private float score;

        public float Score => score;

        public MemoryButtonScoreCalculator(IMemoryButton[] memoryButtons)
        {
            this.memoryButtons = memoryButtons;
        }

        public void CalculateScore()
        {
            score = 0f;
            for (int i = 0; i < memoryButtons.Length; i++) {
                if (memoryButtons[i].MemoryButtonGuess == GameManager.Instance.RoundManager.RoundAnswer.AnswersArray[i])
                    score += scoreForEachButton;
            }
        }
    }
}
