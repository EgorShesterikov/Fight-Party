using FightParty.UI;
using UnityEngine;
using Zenject;

namespace FightParty.Installers
{
    public class SettingsInstaller : MonoInstaller
    {
        [SerializeField] private SettingsMenuView _settingsMenuView;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SettingsMenu>().FromNew().AsSingle();

            Container.BindInstances(_settingsMenuView);
        }
    }
}
