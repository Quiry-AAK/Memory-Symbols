using System;
using System.Collections.Generic;
using _Main.Scripts.Characters;
using _Main.Scripts.CharacterSeat;
using _Main.Scripts.Eliminate;
using DG.Tweening;
using EMA.Scripts.PatternClasses;
using UnityEngine;
using UnityEngine.UI;

namespace _Main.Scripts.Score
{
    public class ScoreTextsManager : MonoSingleton<ScoreTextsManager>
    {
        private Camera cam;
        [SerializeField] private Text[] scoreTexts;

        private void Start()
        {
            cam = Camera.main;
        }

        public void WriteScores(List<Seat> losers)
        {
            var _seats = AllSeatsManager.Instance.ActiveSeats;
            
            
            for (int i = 0; i < _seats.Count; i++) {
                var _characterPos = ((MonoBehaviour)_seats[i].Character).transform.position;
                var _startPos = cam.WorldToScreenPoint(_characterPos);

                scoreTexts[i].gameObject.SetActive(true);
                scoreTexts[i].DOFade(1f, 1f);
                scoreTexts[i].rectTransform.position = _startPos;
                var _i = i;
                scoreTexts[i].transform.DOLocalMoveY(_characterPos.y, 1.5f).SetEase(Ease.OutBack).OnComplete(() =>
                    scoreTexts[_i].gameObject.SetActive(false));
                var _score = (int)_seats[i].Character.MemoryButtonScoreCalculator.Score;
                scoreTexts[i].text = _score.ToString();

                scoreTexts[i].color = losers.Contains(_seats[i]) ? Color.red : Color.green;
            }
            
        }
    }
}
