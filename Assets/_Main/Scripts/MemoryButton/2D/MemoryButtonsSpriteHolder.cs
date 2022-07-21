using UnityEngine;

namespace _Main.Scripts.MemoryButton._2D
{
    [System.Serializable]
    public class MemoryButtonsSpriteHolder
    {
        [SerializeField] private Sprite notPressedSprite;
        [SerializeField] private Sprite pressedSprite;
        public Sprite GetButtonImage(int guess)
        {
            return guess == 0 ? notPressedSprite : pressedSprite;
        }
    }
}
