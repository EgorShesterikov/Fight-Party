namespace FightParty.Game.PlayScene.Battle
{
    public abstract class BattleRaundState : IState
    {
        protected BattleRaundIndication RaundIndication;

        protected readonly IStateSwitcher StateSwitcher;

        protected BattleStateMachineData Data;

        public BattleRaundState(IStateSwitcher stateSwitcher, BattleStateMachineData data, BattleRaundIndication raundIndication)
        {
            StateSwitcher = stateSwitcher;
            Data = data;
            RaundIndication = raundIndication;
        }


        public abstract void Enter();

        public abstract void Exit();

        public abstract void Update();
    }
}