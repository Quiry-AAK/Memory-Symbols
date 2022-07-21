using _Main.Scripts.MemoryButton.Common;
using UnityEngine;

namespace _Main.Scripts.MemoryButton._3D
{
    public class MemoryButtonInGameWindowManager : MonoBehaviour, IMemoryButton
    {
        [SerializeField] private MeshRenderer buttonMeshRenderer;

        private int memoryButtonGuess = 0;

        #region Props

        public int MemoryButtonGuess {
            get => memoryButtonGuess;
            set => memoryButtonGuess = value;
        }

        #endregion

        public void AssignGuessOnButton(int guess)
        {
            memoryButtonGuess = guess;
            buttonMeshRenderer.material = AllGameWindowsManager.Instance.MemoryButtonInGameWindowMaterialHolder.GetButtonMaterial(memoryButtonGuess);
        }
    }
}
