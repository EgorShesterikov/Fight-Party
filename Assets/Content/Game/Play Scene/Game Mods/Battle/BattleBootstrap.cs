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

        private BattleResultUIMediator _resultUIMediator;

        private DefaultBall _ball;

        [Inject]
        public void Construct(IGameMode gameMode, MusicSource musicSource, GlobalSFXSource globalSFXSource, 
            BattleResultUIMediator resultUIMediator, ProgressManager progressManager,
            List<Character> characters, DefaultBall defaultBall)
        {
            _resultUIMediator = resultUIMediator;

            _ball = defaultBall;
        }

        protected override void Binding()
        {
            Character firstCharacter = Characters.Find((character) => character.Type == CharacterTypes.First);
            Character secondCharacter = Characters.Find((character) => character.Type == CharacterTypes.Second);

            BattleRaundIndication raundIndication = new BattleRaundIndication(_raundIndicationView);

            PlayerIndication playerIndication = new PlayerIndication(_playerIndicationView, firstCharacter, secondCharacter);

            BattleReadyButton readyButton = new BattleReadyButton(_readyButtonView, GlobalSFXSource);

            BattleResultMenu resultMenu = new BattleResultMenu(_resultMenuView, GlobalSFXSource, ProgressManager);

            _resultUIMediator.Initialize(resultMenu);

            foreach (Character character in Characters)
                character.Initialized(playerIndication);

            BattleStateMachine battleStateMachine = new BattleStateMachine
                (raundIndication, playerIndication, readyButton, resultMenu, firstCharacter, secondCharacter, _ball);

            GameMode.BindStateMachine(battleStateMachine);
        }

        private void Start()
            => MusicSource.PlayMusic(MusicSource.TypesMusic.Battle);
    }
}