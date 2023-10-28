using FightParty.UI.PlayScene;
using UnityEngine;
using Zenject;

namespace FightParty.Installers
{
    public class PlaySceneInstaller : MonoInstaller
    {
        [SerializeField] private GamePlayMenuView _gamePlayMenu;
        [SerializeField] private ExitMenuView _exitMenuView;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GamePlayMenu>().FromNew().AsSingle();
            Container.BindInterfacesAndSelfTo<ExitMenu>().FromNew().AsSingle();

            Container.BindInstance(_gamePlayMenu).AsSingle();
            Container.BindInstance(_exitMenuView).AsSingle();

            Container.BindInterfacesAndSelfTo<PlaySceneUIMediator>().FromNew().AsSingle();
        }
    }
}
