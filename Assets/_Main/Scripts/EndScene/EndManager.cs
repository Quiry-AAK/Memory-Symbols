using System.Collections.Generic;
using _Main.Scripts.Characters;
using _Main.Scripts.Ranking;
using _Main.Scripts.SimpleUIs;
using DG.Tweening;
using UnityEngine;

namespace _Main.Scripts.EndScene
{
    public class EndManager : MonoBehaviour
    {
        [SerializeField] private List<Transform> rankingSeats;

        private void Start()
        {
            SitCharacters();
            DOVirtual.DelayedCall(3f, () => EndSceneUIManager.Instance.MakeActivePanel(RankingHolder.RankingList[0].GetComponent<CharacterEndController>().AmIPlayer));
        }
        private void SitCharacters()
        {
            RankingHolder.RankingList.Reverse();
            for (int i = 0; i < rankingSeats.Count; i++) {
                var _go = Instantiate(RankingHolder.RankingList[i]);
                _go.transform.position = rankingSeats[i].position;

                if (i == 0) {
                    _go.GetComponent<CharacterEndController>().Won();
                }
            }
        }
    }
}
