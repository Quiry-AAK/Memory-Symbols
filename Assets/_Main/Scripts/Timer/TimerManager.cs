using DG.Tweening;
using EMA.Scripts.PatternClasses;
using UnityEngine;
using UnityEngine.UI;

namespace _Main.Scripts.Timer
{
    public class TimerManager : MonoSingleton<TimerManager>
    {
        [SerializeField] private Slider timerSlider;

        public delegate void TimerOnComplete();

        public void SetActivenessOfTimer(bool value)
        {
            timerSlider.gameObject.SetActive(value);    
        }
        
        public void SetTimer(float duration, TimerOnComplete timerOnComplete)
        {
            timerSlider.value = 1f;
            timerSlider.DOValue(0f, duration).SetEase(Ease.Linear).OnComplete(() => TimerCompleteMethod(timerOnComplete));
        }

        private void TimerCompleteMethod(TimerOnComplete timerOnComplete)
        {
            timerOnComplete?.Invoke();
        }
    }
}
