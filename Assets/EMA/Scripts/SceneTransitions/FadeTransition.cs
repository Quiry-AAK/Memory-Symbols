using DG.Tweening;
using UnityEngine;

namespace EMA.Scripts.SceneTransitions
{
    [RequireComponent(typeof(CanvasGroup))]
    public class FadeTransition : MonoBehaviour
    {
        [SerializeField] private GameObject canvas;
        [SerializeField] private CanvasGroup cg;
        private void Start()
        {
            cg.alpha = 1f;
            cg.DOFade(0f, 1f).SetEase(Ease.Linear).OnComplete(() => canvas.SetActive(false));
        }
    }
}
