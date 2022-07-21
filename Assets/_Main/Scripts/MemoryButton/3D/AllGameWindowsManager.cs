using EMA.Scripts.PatternClasses;
using UnityEngine;

namespace _Main.Scripts.MemoryButton._3D
{
    public class AllGameWindowsManager : MonoSingleton<AllGameWindowsManager>
    {
        [SerializeField] private MemoryButtonInGameWindowMaterialHolder memoryButtonInGameWindowMaterialHolder;

        #region Props
        public MemoryButtonInGameWindowMaterialHolder MemoryButtonInGameWindowMaterialHolder => memoryButtonInGameWindowMaterialHolder;

        #endregion
        
        
    }
}
