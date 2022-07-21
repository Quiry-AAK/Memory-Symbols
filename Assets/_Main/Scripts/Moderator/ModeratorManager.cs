using _Main.Scripts.Core;
using _Main.Scripts.MemoryButton._3D;
using EMA.Scripts.PatternClasses;
using UnityEngine;

namespace _Main.Scripts.Moderator
{
    public class ModeratorManager : MonoSingleton<ModeratorManager>
    {
        [SerializeField] private Animator moderatorAnimator;
        [SerializeField] private GameWindowManager gameWindowManager;

        private GameObject gameWindowManagerGameObject;

        private void Start()
        {
            gameWindowManagerGameObject = gameWindowManager.gameObject;
        }
        
        public void BeginShowAnswer()
        {
            moderatorAnimator.SetTrigger("ShowAnswer");
            gameWindowManagerGameObject.SetActive(true);
            for (int i = 0; i < gameWindowManager.MemoryButtonArrayGetter.MemoryButtonInGameWindowManager.Length; i++) {
                gameWindowManager.MemoryButtonArrayGetter.MemoryButtonInGameWindowManager[i].AssignGuessOnButton
                    (GameManager.Instance.RoundManager.RoundAnswer.AnswersArray[i]);
            }
        }
        
        public void EndShowAnswer()
        {
            gameWindowManagerGameObject.SetActive(false);
        }
    }
}
