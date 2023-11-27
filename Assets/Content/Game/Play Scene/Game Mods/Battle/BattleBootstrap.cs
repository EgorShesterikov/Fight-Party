using FightParty.Audio;
using FightParty.Save;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace FightParty.Game.PlayScene.Battle
{
    public partial class BattleBootstrap : GameBootstrap
    {
        [SerializeField] private BattleRaundIndicationView _raundIndicationView;
        [SerializeField] private PlayerIndicationView _playerIndicationView;
        [SerializeField] private BattleReadyButtonView _readyButtonView;
        [SerializeField] private BattleResultMenuView _resultMenuView;

        private IGameMode<GameModeConfig> _gameMode;

        private MusicSource _musicSource;

        private GlobalSFXSource _globalSFXSource;

        private BattleResultUIMediator _resultUIMediator;

        private ProgressManager _progressManager;

        private List<Character> _characters;

        private DefaultBall _ball;

        [Inject]
        public void Construct(IGameMode<GameModeConfig> gameMode, MusicSource musicSource, GlobalSFXSource globalSFXSource, 
            BattleResultUIMediator resultUIMediator, ProgressManager progressManager,
            List<Character> characters, DefaultBall defaultBall)
        {
            _gameMode = gameMode;

            _musicSource = musicSource;

            _globalSFXSource = globalSFXSource;

            _resultUIMediator = resultUIMediator;

            _progressManager = progressManager;

            _characters = characters;

            _ball = defaultBall;
        }

        protected override void Binding()
        {
            Character yellowCharacter = _characters.Find((character) => character.Type == CharacterTypes.Yellow);
            Character blueCharacter = _characters.Find((character) => character.Type == CharacterTypes.Blue);

            BattleRaundIndication raundIndication = new BattleRaundIndication(_raundIndicationView);

            PlayerIndication playerIndication = new PlayerIndication(_playerIndicationView, yellowCharacter, blueCharacter);

            BattleReadyButton readyButton = new BattleReadyButton(_readyButtonView, _globalSFXSource);

            BattleResultMenu resultMenu = new BattleResultMenu(_resultMenuView, _globalSFXSource, _progressManager);

            _resultUIMediator.Initialize(resultMenu);

            foreach (Character character in _characters)
                character.Initialized(playerIndication);

            BattleStateMachine battleStateMachine = new BattleStateMachine
                (raundIndication, playerIndication, readyButton, resultMenu, yellowCharacter, blueCharacter, _ball);

            _gameMode.BindStateMachine(battleStateMachine);
        }

        private void Start()
            => _musicSource.PlayMusic(MusicSource.TypesMusic.Battle);

        private void Update()
            => _gameMode.StateMachine.Tick();
    }
}