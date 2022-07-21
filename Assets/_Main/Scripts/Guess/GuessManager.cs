using EMA.Scripts.PatternClasses;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Main.Scripts.Guess
{
    public class GuessManager : MonoSingleton<GuessManager>
    {
        private int selectedGuess;

        private bool dragging = false;

        public void OnPointerDown(ref int currentGuess)
        {
            dragging = true;
            
            currentGuess = currentGuess switch
            {
                0 => 1,
                1 => 0,
                _ => currentGuess
            };
            selectedGuess = currentGuess;
        }

        public void OnPointerEnter(ref int currentGuess)
        {
            if (!dragging) {
                return;
            }

            currentGuess = selectedGuess;
        }

        public void OnPointerUp(ref int currentGuess)
        {
            if(!dragging) return;

            currentGuess = selectedGuess;
            dragging = false;
        }
    }
}
