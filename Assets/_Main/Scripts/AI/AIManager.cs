using System;
using _Main.Scripts.Characters;
using _Main.Scripts.CharacterSeat;
using _Main.Scripts.MemoryButton.Common;
using DG.Tweening;
using UnityEngine;

namespace _Main.Scripts.AI
{
    public class AIManager : MonoBehaviour, ICharacter
    {
        [SerializeField] private GameObject endPrefab;
        [SerializeField] private Animator aiAnimator;
        
        private MemoryButtonScoreCalculator memoryButtonScoreCalculator;
        private AIAnswerer aiAnswerer;
        private AIDifficultyGetter aiDifficultyGetter;
        
        #region Props

        public GameObject EndPrefab => endPrefab;

        public MemoryButtonScoreCalculator MemoryButtonScoreCalculator => memoryButtonScoreCalculator;


        public AIAnswerer AIAnswerer => aiAnswerer;

        #endregion
        public void EliminateMe()
        {
            transform.DOLocalMoveY(transform.localPosition.y - 2f, 1f).SetEase(Ease.InBack);
            aiAnimator.SetBool("Eliminated", true);
        }
        public void ResetMyGuesses()
        {
            aiAnswerer.ResetMyAnswers();
        }

        private void Start()
        {
            aiDifficultyGetter = new AIDifficultyGetter();
            aiAnswerer = new AIAnswerer(AllSeatsManager.Instance.GetMyGameWindowManager(this).MemoryButtonArrayGetter.MemoryButtonInGameWindowManager, aiDifficultyGetter);

            memoryButtonScoreCalculator = new MemoryButtonScoreCalculator(AllSeatsManager.Instance
                .GetMyGameWindowManager(this).MemoryButtonArrayGetter.GetArrayAsInterface());

        }

    }
}
