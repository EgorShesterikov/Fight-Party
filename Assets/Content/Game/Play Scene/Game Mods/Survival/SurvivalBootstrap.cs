using FightParty.Audio;
using FightParty.Game.PlayScene.Battle;
using UnityEngine;
using Zenject;

namespace FightParty.Game.PlayScene.Survival
{
    public class SurvivalBootstrap : GameBootstrap
    {
        [SerializeField] private SurvivalTimeIndicationView _timeIndicationView;
        [SerializeField] private PlayerIndicationView _playerIndicationView;
        [SerializeField] private SurvivalResultMenuView _resultMenuView;

        private SurvivalResultUIMediator _resultUIMediator;

        private BallSpawner _ballSpawner;

        [Inject]
        public void Construct(SurvivalResultUIMediator resultUIMediator, BallSpawner ballSpanwer)
        {
            _resultUIMediator = resultUIMediator;

            _ballSpawner = ballSpanwer;
        }

        protected override void Binding()
        {
            Character firstCharacter = Characters.Find((character) => character.Type == CharacterTypes.First);
            Character secondCharacter = Characters.Find((character) => character.Type == CharacterTypes.Second);

            SurvivalTimeIndication timeIndication = new SurvivalTimeIndication(_timeIndicationView);

            PlayerIndication playerIndication = new PlayerIndication(_playerIndicationView, firstCharacter, secondCharacter);

            SurvivalResultMenu resultMenu = new SurvivalResultMenu(_resultMenuView, GlobalSFXSource, ProgressManager);

            _resultUIMediator.Initialize(resultMenu);

            foreach (Character character in Characters)
                character.Initialized(playerIndication);

            SurvivalStateMachine survivalStateMachine = new SurvivalStateMachine(timeIndication, playerIndication, resultMenu,
                firstCharacter, secondCharacter, _ballSpawner);

            GameMode.BindStateMachine(survivalStateMachine);
        }

        private void Start()
            => MusicSource.PlayMusic(MusicSource.TypesMusic.Survival);
    }
}