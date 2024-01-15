using System;
using UnityEngine;

namespace FightParty.Game.PlayScene.Survival
{
    public class SurvivalStateMachineData
    {
        public Character SelectCharacterPlayer;

        public Action<Vector2> _playerInput;

        private int _firstHeal = 3;
        private int _secondHeal = 3;

        public int FirstHeal
        {
            get => _firstHeal;
            set
            {
                if (value < 0 || value > 3)
                    throw new ArgumentOutOfRangeException(nameof(value));

                _firstHeal = value;
            }
        }

        public int SecondHeal
        {
            get => _secondHeal;
            set
            {
                if (value < 0 || value > 3)
                    throw new ArgumentOutOfRangeException(nameof(value));

                _secondHeal = value;
            }
        }
    }
}