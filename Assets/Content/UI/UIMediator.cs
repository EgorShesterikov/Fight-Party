namespace FightParty.UI
{
    public abstract class UIMediator
    {
        protected const float SwitchingInterfacesDelay = 0.5f;

        protected CallBackTimer _timer;

        public UIMediator(CallBackTimer timer)
            => _timer = timer;
    }
}