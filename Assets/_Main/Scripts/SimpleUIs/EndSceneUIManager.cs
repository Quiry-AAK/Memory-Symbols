using System;
using DG.Tweening;
using EMA.Scripts.PatternClasses;
using UnityEngine;
using UnityEngine.UI;

namespace _Main.Scripts.SimpleUIs
{
    public class EndSceneUIManager : MonoSingleton<EndSceneUIManager>
    {
        [SerializeField] private Text panelTxt;
        [SerializeField] private RectTransform rectTransform;

        public void MakeActivePanel(bool playerWon)
        {
            var _panelTxtText = playerWon ? "WELL DONE!" : "FAILED!";
            panelTxt.text = _panelTxtText;

            var _localScale = rectTransform.localScale;
            rectTransform.localScale = Vector3.zero;
            rectTransform.gameObject.SetActive(true);
            rectTransform.DOScale(_localScale, 1f).SetEase(Ease.OutBack);
        }
        
        
    }
}
