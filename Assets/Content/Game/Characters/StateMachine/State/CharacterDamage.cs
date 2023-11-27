using UnityEngine;

namespace FightParty.Game
{
    public class CharacterDamage : CharacterState
    {
        private const float LengthDamageAnim = 0.533f;
        private float _timeEndAnim;

        public CharacterDamage(IStateSwitcher stateSwitcher, CharacterStateMachineData data, Character character) 
            : base(stateSwitcher, data, character)
        {

        }

        public override void Enter()
        {
            Character.CurrentHeal--;

            Character.Audio.PlaySound(Random.Range(0, 2));

            if (Character.CurrentHeal > 0)
            {
                Character.Animator.SetTrigger("Damage");
                _timeEndAnim = LengthDamageAnim;
            }
            else
                StateSwitcher.SwitchState<CharacterDead>();
        }

        public override void Exit() { }

        public override void Update()
        {
            if (_timeEndAnim > 0)
                _timeEndAnim -= Time.deltaTime;
            else
                StateSwitcher.SwitchState<CharacterStay>();
        }
    }
}