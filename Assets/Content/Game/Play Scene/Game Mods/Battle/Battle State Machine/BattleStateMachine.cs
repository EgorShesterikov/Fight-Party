using System.Collections.Generic;

namespace FightParty.Game.PlayScene.Battle
{
    public class BattleStateMachine : StateMachine
    {
        private BattleStateMachineData _data;

        private BattleRaundIndication _raundIndication;
        private PlayerIndication _playerIndication;
        private BattleReadyButton _readyButton;
        private BattleResultMenu _resultMenu;

        private Character _yellowCharacter;
        private Character _blueCharacter;

        public BattleStateMachine(BattleRaundIndication raundIndication, PlayerIndication playerIndication,
            BattleReadyButton readyButton, BattleResultMenu battleResult, 
            Character yellowCharacter, Character blueCharacter, 
            DefaultBall defaultBall)
        {
            _data = new BattleStateMachineData(defaultBall);

            _raundIndication = raundIndication;

            _playerIndication = playerIndication;

            _readyButton = readyButton;

            _resultMenu = battleResult;

            _yellowCharacter = yellowCharacter;
            _blueCharacter = blueCharacter;

            Init();
        }

        protected override List<IState> CreateStates()
            => new List<IState>()
            {
                new BattleSelection(this, _data, _raundIndication, _playerIndication, _playerIndication.View, _yellowCharacter, _blueCharacter),
                new BattlePreparation(this, _data, _raundIndication, _readyButton),
                new BattleFight(this, _data, _raundIndication, _playerIndication.View),
                new BattleResults(this, _data, _raundIndication, _resultMenu)
            };
    }
}