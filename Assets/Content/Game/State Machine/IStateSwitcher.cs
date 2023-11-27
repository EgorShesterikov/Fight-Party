namespace FightParty.Game
{
    public interface IStateSwitcher
    {
        void SwitchState<T>() where T : IState;    
    }
}