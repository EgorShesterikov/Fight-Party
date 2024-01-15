using System;
using UnityEngine;

namespace FightParty.Game.PlayScene.Battle
{
    public class BattleStateMachineData
    {
        public DefaultBall DefaultBall;

        public Character SelectCharacterPlayer;
        public Character SelectCharacterEnemy;

        public Action<Vector2> _playerInput;

        private int _firstHeal = 3;
        private int _secondHeal = 3;

        public BattleStateMachineData(DefaultBall defaultBall)
            => DefaultBall = defaultBall;

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