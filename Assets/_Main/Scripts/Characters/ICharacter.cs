using _Main.Scripts.MemoryButton.Common;
using UnityEngine;

namespace _Main.Scripts.Characters
{
    public interface ICharacter
    {
        public GameObject EndPrefab { get; }
        public MemoryButtonScoreCalculator MemoryButtonScoreCalculator { get; }

        void EliminateMe();
        void ResetMyGuesses();
    }
}
