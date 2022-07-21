using System;
using _Main.Scripts.Characters;
using _Main.Scripts.Player;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace _Main.Scripts.CharacterSeat
{
    [Serializable]
    public class RandomSeatArranger
    {
        [SerializeField] private GameObject[] aiPrefabs;

        public void ArrangeCharacters(Seat[] seats)
        {
            SitCharacter(PlayerManager.Instance.transform, seats[Random.Range(0, seats.Length)], PlayerManager.Instance);
            
            for (int i = 0; i < seats.Length - 1; i++) {
                var _index = Random.Range(0, seats.Length);
                while (seats[_index].hasCharacter) {
                    _index = Random.Range(0, seats.Length);
                }
                var _ai = Object.Instantiate(aiPrefabs[i]);
                SitCharacter(_ai.transform, seats[_index], _ai.GetComponent<ICharacter>());
            }
        }

        private void SitCharacter(Transform tr, Seat seat, ICharacter character)
        {
            tr.position = seat.SeatPosTr.position;
            seat.hasCharacter = true;
            seat.Character = character;
        }

    }
}
