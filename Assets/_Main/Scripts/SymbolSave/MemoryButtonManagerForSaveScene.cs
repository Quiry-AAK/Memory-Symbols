using _Main.Scripts.Guess;
using _Main.Scripts.MemoryButton._2D;
using _Main.Scripts.MemoryButton.Common;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Main.Scripts.SymbolSave
{
    public class MemoryButtonManagerForSaveScene : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerUpHandler, IMemoryButton
    {
        private Image img;

        private bool interactable = true;

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
            img = GetComponent<Image>();
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
            GuessManager.Instance.OnPointerDown(ref memoryButtonGuess);
            SetButtonProperties();
        }
        public void OnPointerEnter(PointerEventData eventData)
        {
            if(!interactable)
                return;

            GuessManager.Instance.OnPointerEnter(ref memoryButtonGuess);
            SetButtonProperties();
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            if(!interactable)
                return;
            
            GuessManager.Instance.OnPointerUp(ref memoryButtonGuess);
            SetButtonProperties();
        }
    }
}
