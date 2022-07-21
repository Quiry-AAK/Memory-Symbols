using System.Collections.Generic;
using DG.Tweening;
using EMA.Scripts.PatternClasses;
using UnityEngine;
using UnityEngine.UI;

namespace EMA.Scripts.UI
{
    public class UICoinGoToIcon : MonoBehaviour
    {
        [SerializeField] private RectTransform mainCanvas;

        [SerializeField] private ObjectPool coinUIObjectPool;
        [SerializeField] private Transform coinObjectPoolParent;
        [SerializeField] private Transform icon;
        [SerializeField] private Text coinTxt;
        
        private Queue<GameObject> coinUIQueue = new Queue<GameObject>();

        private void Start()
        {
            coinUIObjectPool.CreatePool();
        }

        public void GenerateCoinUIAndMoveIt(Vector3 pos)
        {
            var _camera = Camera.main;

            var _viewportPosition=_camera.WorldToViewportPoint(pos);
            var _worldObjectScreenPosition=new Vector2(
                ((_viewportPosition.x*mainCanvas.sizeDelta.x)-(mainCanvas.sizeDelta.x*0.5f)),
                ((_viewportPosition.y*mainCanvas.sizeDelta.y)-(mainCanvas.sizeDelta.y*0.5f)));
            

            var _obj = coinUIObjectPool.GetPooledObject();
            _obj.transform.SetParent(coinObjectPoolParent);
            _obj.GetComponent<RectTransform>().anchoredPosition = _worldObjectScreenPosition;
            _obj.transform.SetParent(icon);
            _obj.GetComponent<RectTransform>().DOLocalMove(Vector3.zero, .5f).OnComplete(TakeCoinUI);
            coinUIQueue.Enqueue(_obj);
        }
        
        private void TakeCoinUI()
        {
            coinUIObjectPool.SendObjectToPool(coinUIQueue.Dequeue()); 
            DOTween.Complete("coinUI");
            icon.DOScale(icon.localScale * 1.3f, .2f).SetLoops(2, LoopType.Yoyo)
                .SetEase(Ease.InOutQuad).SetId("coinUI");
            UIEma.CoinAmount++;
            coinTxt.text = UIEma.CoinAmount.ToString();
        }
    }
}
