using System.Collections.Generic;
using UnityEngine;

namespace _Main.Scripts.Symbol
{
    public class SymbolScOb : ScriptableObject
    {
        [SerializeField]private int[] answersArray;

        public int[] AnswersArray {
            get => answersArray;
            set => answersArray = value;
        }

        public void GetAnswers()
        {
            foreach (var _answer in answersArray) {
                Debug.Log(_answer);
            }
        }
    }
}
