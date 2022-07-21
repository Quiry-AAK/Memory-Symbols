using System;
using EMA.Scripts.MyShortcuts;
using UnityEngine;

namespace _Main.Scripts.AI
{
    public class AIDifficultyGetter
    {
         private AIDifficulty aiDifficulty;
         
         public AIDifficultyGetter()
         {
             aiDifficulty = MyShortcuts.RandomEnumValue<AIDifficulty>();
         }


         public float Preciseness {
            get {
                switch (aiDifficulty) {

                    case AIDifficulty.Easy:
                        return .75f;
                    case AIDifficulty.Medium:
                        return .85f;
                    case AIDifficulty.Hard:
                        return .95f;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
