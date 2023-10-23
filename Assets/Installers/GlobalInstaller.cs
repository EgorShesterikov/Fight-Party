using FightParty.Save;
using UnityEngine;
using Zenject;

namespace FightParty.Installers
{
    public class GlobalInstaller : MonoInstaller
    {
        [SerializeField] private SettingsManagerConfig _settingsManagerConfig;

        public override void InstallBindings()
        {
            BindCallBackTimer();

            BindSaveManagers();
        }

        private void BindCallBackTimer() => Container.Bind<CallBackTimer>().FromNew().AsSingle().WithArguments(this);

        private void BindSaveManagers()
        {
            Container.BindInstance(_settingsManagerConfig).AsSingle();
            Container.BindInterfacesAndSelfTo<SettingsManager>().FromNew().AsSingle();
        }
    }
}