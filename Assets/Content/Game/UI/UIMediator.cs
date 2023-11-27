using FightParty.Game.SceneLoader;
using Zenject;

namespace FightParty.Game
{
    public abstract class UIMediator
    {
        protected const float SwitchingInterfacesDelay = 0.5f;

        protected SceneLoadMediator SceneLoader;

        protected ScreenFader SceenFader;

        protected CallBackTimer Timer;

        [Inject]
        public void Constuctor(CallBackTimer timer, ScreenFader screenFader, SceneLoadMediator sceneLoader)
        {
            Timer = timer;

            SceenFader = screenFader;

            SceneLoader = sceneLoader;
        }
    }
}