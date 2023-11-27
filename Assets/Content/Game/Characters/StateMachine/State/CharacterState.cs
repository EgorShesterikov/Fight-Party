namespace FightParty.Game
{
    public abstract class CharacterState : IState
    {
        protected IStateSwitcher StateSwitcher;
        protected CharacterStateMachineData Data;

        protected Character Character;

        public CharacterState(IStateSwitcher stateSwitcher, CharacterStateMachineData data, Character character)
        {
            StateSwitcher = stateSwitcher;
            Data = data;

            Character = character;
        }

        public abstract void Enter();

        public abstract void Exit();

        public abstract void Update();
    }
}