using _Main.Scripts.Characters;
using _Main.Scripts.CharacterSeat;
using _Main.Scripts.MemoryButton._2D;
using _Main.Scripts.MemoryButton.Common;
using _Main.Scripts.SimpleUIs;
using DG.Tweening;
using EMA.Scripts.PatternClasses;
using UnityEngine;

namespace _Main.Scripts.Player
{
    public class PlayerManager : MonoSingleton<PlayerManager>, ICharacter
    {
        [SerializeField] private Animator playerAnimator;
        [SerializeField] private GameObject endPrefab;

        private MemoryButtonScoreCalculator memoryButtonScoreCalculator;

        public bool playerEliminated = false;

        #region Props

        public GameObject EndPrefab => endPrefab;

        public MemoryButtonScoreCalculator MemoryButtonScoreCalculator => memoryButtonScoreCalculator;


        #endregion
        public void EliminateMe()
        {
            transform.DOLocalMoveY(transform.localPosition.y - 2f, 1f).SetEase(Ease.InBack);
            playerAnimator.SetBool("Eliminated", true);
            playerEliminated = true;
            
            if(AllSeatsManager.Instance.ActiveSeats.Count == 1) return;
            
            DOVirtual.DelayedCall(3f, FailManager.Instance.MakeActiveFailPanel);
        }
        public void ResetMyGuesses()
        {
            AllMemoryButtonsManager.Instance.ResetButtons();
        }

        private void Start()
        {
            memoryButtonScoreCalculator = new MemoryButtonScoreCalculator( 
                AllMemoryButtonsManager.Instance.MemoryButtonArrayGetter.GetArrayAsInterface());
        }

        public void CalculatePlayerScore()
        {
            memoryButtonScoreCalculator.CalculateScore();
            if (memoryButtonScoreCalculator.Score >= 100f) {
                AllMemoryButtonsManager.Instance.SetActivenessOfCanvas(false);
                ShowPlayersAnswersOnGameWindow();
                AllMemoryButtonsManager.Instance.MakeActiveConfetti();
            }
        }

        public void ShowPlayersAnswersOnGameWindow()
        {
            var _myGameWindowManager = AllSeatsManager.Instance.GetMyGameWindowManager(this);
            var _buttons2D = AllMemoryButtonsManager.Instance.MemoryButtonArrayGetter.MemoryButtonManagers;
            var _buttons3D = _myGameWindowManager.MemoryButtonArrayGetter.MemoryButtonInGameWindowManager;
            for (int i = 0; i < _buttons2D.Length; i++) {
                _buttons3D[i].AssignGuessOnButton(_buttons2D[i].MemoryButtonGuess);
            }
        }

    }
}
