using _Main.Scripts.CharacterSeat;
using DG.Tweening;
using UnityEngine;

namespace _Main.Scripts.Eliminate
{
    public class EliminateButton : MonoBehaviour
    {
        [SerializeField] private Transform eliminateBtn;


        public void PressEliminateButton()
        {
            eliminateBtn.GetComponent<MeshRenderer>().material = AllSeatsManager.Instance.PressedBtnMat;
            eliminateBtn.DOLocalMoveY(-0.8f, .5f).SetEase(Ease.Linear);
        }
    }
}
