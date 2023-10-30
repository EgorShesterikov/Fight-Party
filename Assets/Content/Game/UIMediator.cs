using FightParty.Game.SceneLoader;
using Zenject;

namespace FightParty.Game
{
    public abstract class UIMediator
    {
        protected const float SwitchingInterfacesDelay = 0.5f;

        protected SceneLoadMediator _sceneLoader;

        protected ScreenFader _sceenFader;

        protected CallBackTimer _timer;

        [Inject]
        public void Constuctor(CallBackTimer timer, ScreenFader screenFader, SceneLoadMediator sceneLoader)
        {
            _timer = timer;

            _sceenFader = screenFader;

            _sceneLoader = sceneLoader;
        }
    }
}