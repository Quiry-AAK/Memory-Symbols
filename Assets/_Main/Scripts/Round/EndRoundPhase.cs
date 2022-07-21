using System.Linq;
using _Main.Scripts.CharacterSeat;
using _Main.Scripts.Core;
using _Main.Scripts.Eliminate;
using _Main.Scripts.MemoryButton._2D;
using _Main.Scripts.Moderator;
using _Main.Scripts.Player;
using _Main.Scripts.Ranking;
using _Main.Scripts.Score;
using _Main.Scripts.Timer;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Main.Scripts.Round
{
    public static class EndRoundPhase
    {
        public static void EndRound()
        {
            PlayerManager.Instance.ShowPlayersAnswersOnGameWindow();
            CalculatorForAllScores.CalculateAllScores();
            TimerManager.Instance.SetActivenessOfTimer(false);
            AllMemoryButtonsManager.Instance.SetActivenessOfCanvas(false);
            ModeratorManager.Instance.BeginShowAnswer();
            var _losers = LosersGetter.GetLosers();
            ScoreTextsManager.Instance.WriteScores(_losers);
            EliminateManager.EliminateCharacter(_losers);
            if (AllSeatsManager.Instance.ActiveSeats.Count == 1) {
                RankingHolder.RankingList.Add(AllSeatsManager.Instance.ActiveSeats[0].Character.EndPrefab);
                DOVirtual.DelayedCall(3f, () => SceneManager.LoadScene("End"));
            }
            else if (!PlayerManager.Instance.playerEliminated) {
                GameManager.Instance.RoundManager.StartRoundWithDelay(3f);
            }
        }
    }
}
