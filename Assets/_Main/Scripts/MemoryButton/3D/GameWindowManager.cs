using System;
using _Main.Scripts.Characters;
using _Main.Scripts.MemoryButton.Common;
using UnityEngine;

namespace _Main.Scripts.MemoryButton._3D
{
    public class GameWindowManager : MonoBehaviour
    {
        [SerializeField] private MemoryButtonArrayGetter memoryButtonArrayGetter;

        #region Props

        public MemoryButtonArrayGetter MemoryButtonArrayGetter => memoryButtonArrayGetter;

        #endregion
        
    }
}
