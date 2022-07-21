using System;
using DG.Tweening;
using EMA.Scripts.PatternClasses;
using UnityEngine;

namespace _Main.Scripts.SimpleUIs
{
    public class FailManager : MonoSingleton<FailManager>
    {
        [SerializeField] private RectTransform rectTransform;

        public void MakeActiveFailPanel()
        {
            var _localScale = rectTransform.localScale;
            rectTransform.localScale = Vector3.zero;
            rectTransform.gameObject.SetActive(true);
            rectTransform.DOScale(_localScale, 1f).SetEase(Ease.OutBack);
        }
    }
}
