using System.Collections.Generic;
using System.Linq;
using _Main.Scripts.Characters;
using _Main.Scripts.MemoryButton._3D;
using EMA.Scripts.PatternClasses;
using UnityEngine;

namespace _Main.Scripts.CharacterSeat
{
    public class AllSeatsManager : MonoSingleton<AllSeatsManager>
    {
        [SerializeField] private RandomSeatArranger randomSeatArranger;
        [SerializeField] private Seat[] seats;

        private List<Seat> activeSeats;

        [SerializeField] private Material pressedBtnMat;
        
        #region Props

        public List<Seat> ActiveSeats => activeSeats;

        public Material PressedBtnMat => pressedBtnMat;

        public Seat[] Seats => seats;

        #endregion
        
        
        public GameWindowManager GetMyGameWindowManager(ICharacter character)
        {
            foreach (var _seat in seats) {
                if (_seat.Character == character)
                    return _seat.GameWindowManager;
            }

            Debug.LogError("Invalid character!!!");
            return null;
        }
        public ICharacter GetMyCharacter(GameWindowManager gameWindowManager)
        {
            foreach (var _platform in seats) {
                if (_platform.GameWindowManager == gameWindowManager)
                    return _platform.Character;
            }

            Debug.LogError("Invalid GameWindowManager!!!");
            return null;
        }


        private void Start()
        {
            randomSeatArranger.ArrangeCharacters(seats);
            activeSeats = seats.ToList();
        }
        
    }
}
