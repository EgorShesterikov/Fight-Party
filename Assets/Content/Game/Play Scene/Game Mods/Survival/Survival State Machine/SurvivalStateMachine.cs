using System.Collections.Generic;

namespace FightParty.Game.PlayScene.Survival
{
    public class SurvivalStateMachine : StateMachine
    {
        private SurvivalStateMachineData _data;

        private SurvivalTimeIndication _timeIndication;
        private PlayerIndication _playerIndication;
        private SurvivalResultMenu _resultMenu;

        private Character _firstСharacter;
        private Character _secondCharacter;

        private BallSpawner _ballSpawner;

        public SurvivalStateMachine(SurvivalTimeIndication timeIndication, PlayerIndication playerIndication, SurvivalResultMenu resultMenu,
            Character firstCharacter, Character secondCharacter, BallSpawner ballSpawner)
        {
            _data = new SurvivalStateMachineData();

            _timeIndication = timeIndication;

            _playerIndication = playerIndication;

            _resultMenu = resultMenu;

            _firstСharacter = firstCharacter;
            _secondCharacter = secondCharacter;

            _ballSpawner = ballSpawner;

            Init();
        }

        protected override List<IState> CreateStates()
            => new List<IState>()
            {
                new SurvivalSelection(this, _data, _playerIndication, _playerIndication.View, _firstСharacter, _secondCharacter),
                new SurvivalProcess(this, _data, _playerIndication, _timeIndication, _ballSpawner, _playerIndication.View),
                new SurvivalResults(this, _data, _timeIndication, _resultMenu)
            };
    }
}