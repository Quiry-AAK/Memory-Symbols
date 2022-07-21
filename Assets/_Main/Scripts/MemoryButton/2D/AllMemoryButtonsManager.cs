using System;
using _Main.Scripts.MemoryButton.Common;
using DG.Tweening;
using EMA.Scripts.PatternClasses;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace _Main.Scripts.MemoryButton._2D
{
    public class AllMemoryButtonsManager : MonoSingleton<AllMemoryButtonsManager>
    {
        [SerializeField] private GameObject confetti;
        [SerializeField] private GameObject canvas;

        [SerializeField] private MemoryButtonArrayGetter memoryButtonArrayGetter;
        [SerializeField] private MemoryButtonsSpriteHolder memoryButtonsSpriteHolder;

        private Vector3 canvasDefaultScale;


        #region Props

        public MemoryButtonArrayGetter MemoryButtonArrayGetter => memoryButtonArrayGetter;

        public MemoryButtonsSpriteHolder MemoryButtonsSpriteHolder => memoryButtonsSpriteHolder;

        #endregion

        private void Start()
        {
            canvasDefaultScale = canvas.transform.localScale;
        }


        public void SetActivenessOfCanvas(bool value)
        {
            if (value) {
                canvas.transform.localScale = Vector3.zero;
                DOTween.Kill("CanvasScaler");
                canvas.transform.DOScale(canvasDefaultScale, .5f).SetEase(Ease.OutBack).SetId("CanvasScaler");
                canvas.SetActive(true);
            }
            else {
                DOTween.Kill("CanvasScaler");
                canvas.transform.DOScale(0f, .5f).SetEase(Ease.OutBack).SetId("CanvasScaler").OnComplete(() => canvas.SetActive(false));
            }
        }

        public void ShowAnswerOnCanvas()
        {
            MemoryButtonAnswerShower.ShowAnswers(memoryButtonArrayGetter.MemoryButtonManagers, this);
        }

        public void ResetButtons()
        {
            foreach (var _memoryButtonManager in memoryButtonArrayGetter.MemoryButtonManagers) {
                _memoryButtonManager.Interactable = true;
                _memoryButtonManager.ResetMe();
            }
        }

        public void MakeActiveConfetti()
        {
            confetti.SetActive(true);
            DOVirtual.DelayedCall(1f, MakePassiveConfetti);
        }

        private void MakePassiveConfetti()
        {
            confetti.SetActive(false);
        }
    }
}
