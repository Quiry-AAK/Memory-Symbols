using System;
using DG.Tweening;
using UnityEngine;

namespace _Main.Scripts.StartScene
{
    public class CharacterAndBoatAnimation : MonoBehaviour
    {
        [SerializeField] private Transform tr;

        private void Start()
        {
            tr.DOLocalMoveY(tr.position.y + .3f, 5f).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Yoyo);
        }
    }
}
