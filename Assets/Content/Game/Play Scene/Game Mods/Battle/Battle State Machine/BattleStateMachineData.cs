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

        private int _yellowHeal = 3;
        private int _blueHeal = 3;

        public BattleStateMachineData(DefaultBall defaultBall)
            => DefaultBall = defaultBall;

        public int YellowHeal
        {
            get => _yellowHeal;
            set
            {
                if (value < 0 || value > 3)
                    throw new ArgumentOutOfRangeException(nameof(value));

                _yellowHeal = value;
            }
        }

        public int BlueHeal
        {
            get => _blueHeal;
            set
            {
                if (value < 0 || value > 3)
                    throw new ArgumentOutOfRangeException(nameof(value));

                _blueHeal = value;
            }
        }
    }
}