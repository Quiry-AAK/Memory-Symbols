using System.Collections;
using _Main.Scripts.Core;
using _Main.Scripts.MemoryButton._2D;
using _Main.Scripts.Sound;
using UnityEngine;

namespace _Main.Scripts.MemoryButton.Common
{
    public static class MemoryButtonAnswerShower
    {
        public static void ShowAnswers(MemoryButtonManager[] memoryButtonManagers, MonoBehaviour mono)
        {
            mono.StartCoroutine(ShowAnswerNumerator(memoryButtonManagers));
        }

        private static IEnumerator ShowAnswerNumerator(MemoryButtonManager[] memoryButtonManagers)
        {
            foreach (var _memoryButtonManager in memoryButtonManagers) {
                _memoryButtonManager.Interactable = false;
            }
            
            for (int i = 0; i < memoryButtonManagers.Length; i++) {
                memoryButtonManagers[i].Img.sprite = 
                    AllMemoryButtonsManager.Instance.MemoryButtonsSpriteHolder.GetButtonImage
                        (GameManager.Instance.RoundManager.RoundAnswer.AnswersArray[i]);
                if (GameManager.Instance.RoundManager.RoundAnswer.AnswersArray[i] == 1) {
                    SoundManager.Instance.PlayPopSound();
                }
                
                yield return new WaitForSeconds(.03f);
            }
        }
    }
}
