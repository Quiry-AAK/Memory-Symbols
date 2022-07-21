using _Main.Scripts.Characters;
using _Main.Scripts.Core;
using _Main.Scripts.Eliminate;
using _Main.Scripts.MemoryButton._3D;
using _Main.Scripts.Ranking;
using DG.Tweening;
using UnityEngine;

namespace _Main.Scripts.CharacterSeat
{
    public class Seat : MonoBehaviour
    {
        [SerializeField] private Transform trapDoor;
        [SerializeField]private Transform seatPosTr;
        [SerializeField] private EliminateButton eliminateButton;
        [SerializeField] private GameWindowManager gameWindowManager;
        
        private ICharacter character;

        [HideInInspector] public bool hasCharacter = false;
        [HideInInspector] public bool eliminated = false;

        public ICharacter Character {
            get {
                if (character != null) return character;
                Debug.LogError("Assign character!!!!");
                return null;
            }
            set => character = value;
        }

        #region Props

        public Transform SeatPosTr => seatPosTr;

        public GameWindowManager GameWindowManager => gameWindowManager;

        #endregion

        public void Eliminate()
        {
            AllSeatsManager.Instance.ActiveSeats.Remove(this);
            RankingHolder.RankingList.Add(character.EndPrefab);
            eliminateButton.PressEliminateButton();
            eliminated = true;
            trapDoor.DOLocalRotate(new Vector3(90, 0, 0), .5f).SetEase(Ease.OutBounce).SetDelay(.5f);
            character.EliminateMe();
        }
    }
}
