using System.Collections.Generic;
using _Main.Scripts.MemoryButton;
using _Main.Scripts.MemoryButton._2D;
using _Main.Scripts.Symbol;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace _Main.Scripts.SymbolSave
{
    public class CreateAnswerScOb : MonoBehaviour
    {
        [SerializeField] private Transform memoryButtonsParent;

        private MemoryButtonManagerForSaveScene[] memoryButtons;

        [SerializeField] private SymbolScOb scOb;


        private void Start()
        {
            if (scOb != null)
                scOb.GetAnswers();
            memoryButtons = new MemoryButtonManagerForSaveScene[memoryButtonsParent.childCount];
            for (int i = 0; i < memoryButtonsParent.childCount; i++) {
                memoryButtons[i] = memoryButtonsParent.GetChild(i).GetComponent<MemoryButtonManagerForSaveScene>();
            }
        }

        public void Save()
        {
            SymbolScOb _scOb = ScriptableObject.CreateInstance<SymbolScOb>();
            var _answersArray = new int[memoryButtons.Length];
            for (int i = 0; i < memoryButtons.Length; i++) {
                _answersArray[i] = memoryButtons[i].MemoryButtonGuess;
            }
            _scOb.AnswersArray = _answersArray;
            CreateScriptableObject(_scOb);
        }

        private void CreateScriptableObject(SymbolScOb scOb)
        {
            #if UNITY_EDITOR

            AssetDatabase.CreateAsset(scOb, PathGetter.GetPath());
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            #endif
            scOb.GetAnswers();
        }

    }
}
