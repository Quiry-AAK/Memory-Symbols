using UnityEngine;

namespace EMA.Scripts.UI
{
    public abstract class TapToPlay : MonoBehaviour
    {
        private void OnEnable()
        {
            UIEma.IsGamePaused = true;
        }

        private void OnDisable()
        {
            UIEma.IsGamePaused = false;
        } 

        public void StartTheGame()
        {
            gameObject.SetActive(false);
        }
    }
}
