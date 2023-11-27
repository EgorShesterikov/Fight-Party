using FightParty.Audio;
using FightParty.Game.PlayScene.Battle;
using FightParty.Save;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace FightParty.Game.PlayScene.Survival
{
    public class SurvivalBootstrap : GameBootstrap
    {
        [SerializeField] private SurvivalTimeIndicationView _timeIndicationView;
        [SerializeField] private PlayerIndicationView _playerIndicationView;
        [SerializeField] private SurvivalResultMenuView _resultMenuView;

        private IGameMode<GameModeConfig> _gameMode;

        private MusicSource _musicSource;

        private GlobalSFXSource _globalSFXSource;

        private SurvivalResultUIMediator _resultUIMediator;

        private ProgressManager _progressManager;

        private List<Character> _characters;

        private BallSpawner _ballSpawner;

        [Inject]
        public void Construct(IGameMode<GameModeConfig> gameMode, MusicSource musicSource, GlobalSFXSource globalSFXSource, SurvivalResultUIMediator resultUIMediator, ProgressManager progressManager,
            List<Character> characters, BallSpawner ballSpanwer)
        {
            _gameMode = gameMode;

            _musicSource = musicSource;

            _globalSFXSource = globalSFXSource;

            _resultUIMediator = resultUIMediator;

            _progressManager = progressManager;

            _characters = characters;

            _ballSpawner = ballSpanwer;
        }

        protected override void Binding()
        {
            Character yellowCharacter = _characters.Find((character) => character.Type == CharacterTypes.Yellow);
            Character blueCharacter = _characters.Find((character) => character.Type == CharacterTypes.Blue);

            SurvivalTimeIndication timeIndication = new SurvivalTimeIndication(_timeIndicationView);

            PlayerIndication playerIndication = new PlayerIndication(_playerIndicationView, yellowCharacter, blueCharacter);

            SurvivalResultMenu resultMenu = new SurvivalResultMenu(_resultMenuView, _globalSFXSource, _progressManager);

            _resultUIMediator.Initialize(resultMenu);

            foreach (Character character in _characters)
                character.Initialized(playerIndication);

            SurvivalStateMachine survivalStateMachine = new SurvivalStateMachine(timeIndication, playerIndication, resultMenu,
                yellowCharacter, blueCharacter, _ballSpawner);

            _gameMode.BindStateMachine(survivalStateMachine);
        }

        private void Start()
            => _musicSource.PlayMusic(MusicSource.TypesMusic.Survival);

        private void Update()
            => _gameMode.StateMachine.Tick();
    }
}