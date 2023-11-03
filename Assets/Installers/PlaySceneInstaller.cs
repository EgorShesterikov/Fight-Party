using FightParty.Game;
using FightParty.Game.PlayScene;
using FightParty.Game.SceneLoader;
using UnityEngine;
using Zenject;

namespace FightParty.Installers
{
    public class PlaySceneInstaller : MonoInstaller
    {
        [SerializeField] private BallsConfig _ballsConfig;
        [SerializeField] private CharacterConfig _characterConfig;

        [Space]
        [SerializeField] private GamePlayMenuView _gamePlayMenu;
        [SerializeField] private ExitMenuView _exitMenuView;

        private LoadingData _levelLoadingData;

        [Inject]
        public void Construct(LoadingData levelLoadingData)
            => _levelLoadingData = levelLoadingData;

        public override void InstallBindings()
        {
            BindUIInterfaces();

            BindBallFactroy();

            BindCharacterFactory();

            BindGameMode();
        }

        private void BindUIInterfaces()
        {
            Container.BindInterfacesAndSelfTo<GamePlayMenu>().FromNew().AsSingle();
            Container.BindInterfacesAndSelfTo<ExitMenu>().FromNew().AsSingle();

            Container.BindInstance(_gamePlayMenu).AsSingle();
            Container.BindInstance(_exitMenuView).AsSingle();

            Container.BindInterfacesAndSelfTo<PlaySceneUIMediator>().FromNew().AsSingle();
        }

        private void BindBallFactroy()
        {
            Container.BindInstance(_ballsConfig).AsSingle();

            Container.Bind<BallFactory>().FromNew().AsSingle();
            Container.Bind<BallSpawner>().FromNew().AsSingle();  
        }

        private void BindCharacterFactory()
        {
            Container.BindInstance(_characterConfig).AsSingle();

            Container.Bind<CharacterFactory>().FromNew().AsSingle();
            Container.Bind<CharacterSpawner>().FromNew().AsSingle();
        }

        private void BindGameMode()
        {
            Container.BindInstance(_levelLoadingData.GameMode).AsSingle();

            Container.Bind<PlayWindowFactory>().FromNew().AsSingle();
            Container.Bind<PlayWindowGenerator>().FromNew().AsSingle();

            Container.BindInterfacesAndSelfTo<GameController>().FromNew().AsSingle().NonLazy();
        }
    }
}
