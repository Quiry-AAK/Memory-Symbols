using System;
using UnityEngine;

namespace _Main.Scripts.MemoryButton._3D
{
    [Serializable]
    public class MemoryButtonInGameWindowMaterialHolder
    {
        [SerializeField] private Material notPressedMaterial;
        [SerializeField] private Material pressedMaterial;
        public Material GetButtonMaterial(int guess)
        {
            return guess == 0 ? notPressedMaterial : pressedMaterial;
        }
    }
}
