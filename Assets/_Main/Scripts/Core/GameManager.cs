using System.Collections.Generic;
using _Main.Scripts.Characters;
using _Main.Scripts.Round;
using EMA.Scripts.PatternClasses;

namespace _Main.Scripts.Core
{
    public class GameManager : MonoSingleton<GameManager>
    {
        private RoundManager roundManager;
        

        #region Props
        public RoundManager RoundManager => roundManager;


        #endregion
        

        private void Start()
        {
            roundManager = new RoundManager(5f, 15f);
            roundManager.StartRoundWithDelay(3f);
        }

    }
}
