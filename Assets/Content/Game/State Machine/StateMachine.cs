using System.Collections.Generic;
using System.Linq;

namespace FightParty.Game
{ 
    public abstract class StateMachine : IStateSwitcher
    {
        protected List<IState> States;
        protected IState CurrentState;

        public void SwitchState<T>() where T : IState
        {
            IState state = States.FirstOrDefault(state => state is T);

            CurrentState.Exit();
            CurrentState = state;
            CurrentState.Enter();
        }

        public void Tick()
            => CurrentState.Update();

        protected void Init()
        {
            States = CreateStates();

            CurrentState = States[0];
            CurrentState.Enter();
        }

        protected abstract List<IState> CreateStates();
    }
}