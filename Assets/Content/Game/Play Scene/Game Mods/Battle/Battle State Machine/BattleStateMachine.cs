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

        private Character _firstCharacter;
        private Character _secondCharacter;

        public BattleStateMachine(BattleRaundIndication raundIndication, PlayerIndication playerIndication,
            BattleReadyButton readyButton, BattleResultMenu battleResult, 
            Character firstCharacter, Character secondCharacter, 
            DefaultBall defaultBall)
        {
            _data = new BattleStateMachineData(defaultBall);

            _raundIndication = raundIndication;

            _playerIndication = playerIndication;

            _readyButton = readyButton;

            _resultMenu = battleResult;

            _firstCharacter = firstCharacter;
            _secondCharacter = secondCharacter;

            Init();
        }

        protected override List<IState> CreateStates()
            => new List<IState>()
            {
                new BattleSelection(this, _data, _raundIndication, _playerIndication, _playerIndication.View, _firstCharacter, _secondCharacter),
                new BattlePreparation(this, _data, _raundIndication, _readyButton),
                new BattleFight(this, _data, _raundIndication, _playerIndication.View),
                new BattleResults(this, _data, _raundIndication, _resultMenu)
            };
    }
}