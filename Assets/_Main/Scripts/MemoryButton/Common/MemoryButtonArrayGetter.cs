using System;
using _Main.Scripts.MemoryButton._2D;
using _Main.Scripts.MemoryButton._3D;
using UnityEngine;

namespace _Main.Scripts.MemoryButton.Common
{
    [Serializable]
    public class MemoryButtonArrayGetter
    {
        [SerializeField] private MemoryButtonTypes type;
        [SerializeField] private Transform memoryButtonsParent;

        private MemoryButtonManager[] memoryButtonManagers;
        private MemoryButtonInGameWindowManager[] memoryButtonInGameWindowManagers;

        public MemoryButtonManager[] MemoryButtonManagers {
            get {
                if(type != MemoryButtonTypes.TwoD) Debug.LogError("This Array is for 2D memory buttons!!");
                if (memoryButtonManagers != null) return memoryButtonManagers;
                memoryButtonManagers = new MemoryButtonManager[memoryButtonsParent.childCount];
                for (int i = 0; i < memoryButtonsParent.childCount; i++) {
                    memoryButtonManagers[i] = memoryButtonsParent.GetChild(i).GetComponent<MemoryButtonManager>();
                }
                return memoryButtonManagers;
            }
        }
        public MemoryButtonInGameWindowManager[] MemoryButtonInGameWindowManager {
            get {
                if(type != MemoryButtonTypes.ThreeD) Debug.LogError("This Array is for 3D memory buttons!!");
                if (memoryButtonManagers != null) return memoryButtonInGameWindowManagers;
                memoryButtonInGameWindowManagers = new MemoryButtonInGameWindowManager[memoryButtonsParent.childCount];
                for (int i = 0; i < memoryButtonsParent.childCount; i++) {
                    memoryButtonInGameWindowManagers[i] = memoryButtonsParent.GetChild(i).GetComponent<MemoryButtonInGameWindowManager>();
                }
                return memoryButtonInGameWindowManagers;
            }
        }

        public IMemoryButton[] GetArrayAsInterface()
        {
            return type switch
            {
                MemoryButtonTypes.TwoD => MemoryButtonManagers as IMemoryButton[],
                MemoryButtonTypes.ThreeD => MemoryButtonInGameWindowManager as IMemoryButton[],
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}
