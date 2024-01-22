namespace FightParty.Game
{
    public class CharacterStay : CharacterState
    {
        private const string AnimStayTrigger = "Stay";

        public CharacterStay(IStateSwitcher stateSwitcher, CharacterStateMachineData data, Character character) 
            : base(stateSwitcher, data, character)
        {
        }

        public override void Enter()
        {
            Character.Animator.SetTrigger(AnimStayTrigger);

            Character.Prepared += GoToPreparation;
            Character.BallTriggered += TakeDamage;
            Character.Danced += GoToDance;
        }

        public override void Exit()
        {
            Character.Prepared -= GoToPreparation;
            Character.BallTriggered -= TakeDamage;
            Character.Danced -= GoToDance;
        }

        public override void Update() { }

        private void GoToPreparation()
            => StateSwitcher.SwitchState<CharacterPreparation>();

        private void TakeDamage()
            => StateSwitcher.SwitchState<CharacterDamage>();

        private void GoToDance()
            => StateSwitcher.SwitchState<CharacterVictory>();
    }
}