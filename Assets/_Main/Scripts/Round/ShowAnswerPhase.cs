using _Main.Scripts.MemoryButton;
using _Main.Scripts.MemoryButton._2D;
using _Main.Scripts.Player;
using UnityEngine;

namespace _Main.Scripts.Round
{
    public static class ShowAnswerPhase
    {
        public static void StartShowAnswerPhase()
        {
            PlayerManager.Instance.ResetMyGuesses();
            AllMemoryButtonsManager.Instance.SetActivenessOfCanvas(true);
            AllMemoryButtonsManager.Instance.ShowAnswerOnCanvas();
        }
    }
}
