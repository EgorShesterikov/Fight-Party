namespace FightParty.Game
{
    public class CharacterVictory : CharacterState
    {
        private const string AnimVictoryTrigger = "Victory";

        public CharacterVictory(IStateSwitcher stateSwitcher, CharacterStateMachineData data, Character character)
            : base(stateSwitcher, data, character)
        {
        }

        public override void Enter()
        {
            Character.Animator.SetTrigger(AnimVictoryTrigger);
        }

        public override void Exit() { }

        public override void Update() { }
    }
}