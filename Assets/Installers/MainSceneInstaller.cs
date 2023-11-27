using FightParty.Game;
using FightParty.Game.MainScene;
using UnityEngine;
using Zenject;

namespace FightParty.Installers
{
    public class MainSceneInstaller : MonoInstaller
    {
        [SerializeField] private MainMenuView _mainMenuView;
        [SerializeField] private PlayMenuView _playMenuView;
        [SerializeField] private CollectionMenuView _collectionMenuView;

        [Space]
        [SerializeField] private SkinChangerConfig _skinChangerConfig;

        public override void InstallBindings()
        {
            BindUIInterfaces();

            BindGameModeFactory();

            BindSkinChager();
        }

        private void BindUIInterfaces()
        {
            Container.BindInterfacesAndSelfTo<MainMenu>().FromNew().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayMenu>().FromNew().AsSingle();
            Container.BindInterfacesAndSelfTo<CollectionMenu>().FromNew().AsSingle();

            Container.BindInstance(_mainMenuView).AsSingle();
            Container.BindInstance(_playMenuView).AsSingle();
            Container.BindInstance(_collectionMenuView).AsSingle();

            Container.BindInterfacesAndSelfTo<MainSceneUIMediator>().FromNew().AsSingle();
        }

        private void BindGameModeFactory()
            => Container.Bind<GameModeFactory>().FromNew().AsSingle();

        private void BindSkinChager()
        {
            Container.BindInstance(_skinChangerConfig).AsSingle();

            Container.BindInterfacesAndSelfTo<SkinChanger>().FromNew().AsSingle();
        }
    }
}
