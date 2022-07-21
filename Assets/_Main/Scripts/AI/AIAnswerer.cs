using System.Collections;
using _Main.Scripts.Core;
using _Main.Scripts.MemoryButton._3D;
using UnityEngine;

namespace _Main.Scripts.AI
{
    public class AIAnswerer
    {
        private AIDifficultyGetter aiDifficultyGetter;
        private MemoryButtonInGameWindowManager[] buttonsArray;
        private float answeringDuration;

        public AIAnswerer(MemoryButtonInGameWindowManager[] buttonsArray, AIDifficultyGetter aiDifficultyGetter)
        {
            this.buttonsArray = buttonsArray;
            this.aiDifficultyGetter = aiDifficultyGetter;
            answeringDuration = (GameManager.Instance.RoundManager.AnsweringPhaseDuration - 1) / 2f;
            answeringDuration = Random.Range(0f, answeringDuration);
            answeringDuration /= buttonsArray.Length;
        }

        public void StartAnswering()
        {
            GameManager.Instance.StartCoroutine(StartAnsweringRoutine());
        }

        public void ResetMyAnswers()
        {
            foreach (var _button in buttonsArray) {
                _button.AssignGuessOnButton(0);
            }
        }

        private IEnumerator StartAnsweringRoutine()
        {
            for (int i = 0; i < buttonsArray.Length; i++) {
                if (Random.Range(0f, 1f) < aiDifficultyGetter.Preciseness)
                    buttonsArray[i].AssignGuessOnButton(GameManager.Instance.RoundManager.RoundAnswer.AnswersArray[i]);
                else
                    buttonsArray[i].AssignGuessOnButton(GameManager.Instance.RoundManager.RoundAnswer.AnswersArray[i] == 0 ? 1 : 0);
                yield return new WaitForSeconds(answeringDuration);
            }
        }
    }
}
