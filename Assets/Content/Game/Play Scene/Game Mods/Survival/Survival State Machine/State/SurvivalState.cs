namespace FightParty.Game.PlayScene.Survival
{
    public abstract class SurvivalState : IState
    {
        protected readonly IStateSwitcher StateSwitcher;

        protected SurvivalStateMachineData Data;

        public SurvivalState(IStateSwitcher stateSwitcher, SurvivalStateMachineData data)
        {
            StateSwitcher = stateSwitcher;
            Data = data;
        }


        public abstract void Enter();

        public abstract void Exit();

        public abstract void Update();
    }
}