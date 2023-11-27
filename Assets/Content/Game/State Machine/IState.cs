namespace FightParty.Game
{
    public interface IState
    {
        void Enter();
        void Exit();
        void Update();
    }
}