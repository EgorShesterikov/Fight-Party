using Zenject;

namespace FightParty.Installers
{
    public class GlobalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
             Container.Bind<CallBackTimer>().FromNew().AsSingle().WithArguments(this);
        }
    }
}