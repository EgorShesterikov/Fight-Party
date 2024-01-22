using UnityEngine;

namespace FightParty.Game
{
    public class CharacterDamage : CharacterState
    {
        private const string NameDamageSound_1 = "Damage_1";
        private const string NameDamageSound_2 = "Damage_2";

        private const string AnimDamageTrigger = "Damage";

        private const float LengthDamageAnim = 0.533f;
        private float _timeEndAnim;

        public CharacterDamage(IStateSwitcher stateSwitcher, CharacterStateMachineData data, Character character) 
            : base(stateSwitcher, data, character)
        {

        }

        public override void Enter()
        {
            Character.CurrentHeal--;

            if(Random.Range(0, 2) == 0)
                Character.Audio.PlaySound(NameDamageSound_1);
            else
                Character.Audio.PlaySound(NameDamageSound_2);

            if (Character.CurrentHeal > 0)
            {
                Character.Animator.SetTrigger(AnimDamageTrigger);
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