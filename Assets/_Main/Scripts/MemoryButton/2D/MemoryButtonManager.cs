using _Main.Scripts.Characters;
using _Main.Scripts.Guess;
using _Main.Scripts.MemoryButton.Common;
using _Main.Scripts.Player;
using _Main.Scripts.Sound;
using UnityEngine;
using UnityEngine.EventSystems;
using Image = UnityEngine.UI.Image;

namespace _Main.Scripts.MemoryButton._2D
{
    public class MemoryButtonManager : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerUpHandler, IMemoryButton
    {
        [SerializeField] private Image img;

        public bool interactable = true;

        #region Props

        public bool Interactable {
            get => interactable;
            set => interactable = value;
        }

        public Image Img => img;

        #endregion
        
        
        private int memoryButtonGuess;

        private void Start()
        {
            memoryButtonGuess = 0;
        }

        public int MemoryButtonGuess {
            get => memoryButtonGuess;
            set => memoryButtonGuess = value;
        }

        public void SetButtonProperties()
        {
            img.sprite = AllMemoryButtonsManager.Instance.MemoryButtonsSpriteHolder.GetButtonImage(memoryButtonGuess);
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            if(!interactable)
                return;
            var _oldValue = memoryButtonGuess;
            GuessManager.Instance.OnPointerDown(ref memoryButtonGuess);
            if(CheckMemoryButtonIsChanged(_oldValue))
                SoundManager.Instance.PlayPopSound();
            PlayerManager.Instance.CalculatePlayerScore();
            SetButtonProperties();
        }
        public void OnPointerEnter(PointerEventData eventData)
        {
            if(!interactable)
                return;

            var _oldValue = memoryButtonGuess;
            GuessManager.Instance.OnPointerEnter(ref memoryButtonGuess);
            if(CheckMemoryButtonIsChanged(_oldValue))
                SoundManager.Instance.PlayPopSound();
            PlayerManager.Instance.CalculatePlayerScore();
            SetButtonProperties();
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            if(!interactable)
                return;

            var _oldValue = memoryButtonGuess;
            GuessManager.Instance.OnPointerUp(ref memoryButtonGuess);
            if(CheckMemoryButtonIsChanged(_oldValue))
                SoundManager.Instance.PlayPopSound();
            PlayerManager.Instance.CalculatePlayerScore();
            SetButtonProperties();
        }

        public void ResetMe()
        {
            memoryButtonGuess = 0;
            SetButtonProperties();
        }

        private bool CheckMemoryButtonIsChanged(int oldMemoryButtonGuess)
        {
            return oldMemoryButtonGuess != memoryButtonGuess;
        }
    }
}
