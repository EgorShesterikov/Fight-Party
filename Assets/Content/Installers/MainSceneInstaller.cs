using FightParty.UI.MainScene;
using FightParty.UI;
using UnityEngine;
using Zenject;

namespace FightParty.Installers
{
    public class MainSceneInstaller : MonoInstaller
    {
        [SerializeField] private MainMenuView _mainMenuView;
        [SerializeField] private PlayMenuView _playMenuView;
        [SerializeField] private CollectionMenuView _collectionMenuView;
        [SerializeField] private SettingsMenuView _settingsMenuView;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MainMenu>().FromNew().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayMenu>().FromNew().AsSingle();
            Container.BindInterfacesAndSelfTo<CollectionMenu>().FromNew().AsSingle();
            Container.BindInterfacesAndSelfTo<SettingsMenu>().FromNew().AsSingle();

            Container.BindInstance(_mainMenuView).AsSingle();
            Container.BindInstance(_playMenuView).AsSingle();
            Container.BindInstance(_collectionMenuView).AsSingle();
            Container.BindInstance(_settingsMenuView).AsSingle();

            Container.BindInterfacesAndSelfTo<MainSceneMediator>().FromNew().AsSingle();
        }
    }
}
