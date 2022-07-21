using _Main.Scripts.Symbol;
using _Main.Scripts.SymbolSave;
using EMA.Scripts.MyShortcuts;
using UnityEngine;

namespace _Main.Scripts.Answer
{
    public static class RandomAnswerGetter
    {
        private static SymbolScOb[] allAnswers = Resources.LoadAll<SymbolScOb>("Answers/");

        public static SymbolScOb GetRandomAnswer()
        {
            return MyShortcuts.GetRandomObjectOfList(allAnswers);
        }
    }
}
