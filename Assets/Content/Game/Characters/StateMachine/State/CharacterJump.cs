using UnityEngine;

namespace FightParty.Game
{
    public class CharacterJump : CharacterState
    {
        private const float PowerJump = 7500;
        private const float LengthJumpAnim = 1.167f;

        private float _timeEndAnim;

        private Vector3 _jumpDirectionEuler;

        public CharacterJump(IStateSwitcher stateSwitcher, CharacterStateMachineData data, Character character) 
            : base(stateSwitcher, data, character)
        {

        }

        public override void Enter()
        {
            Character.Animator.SetTrigger("Jump");
            _timeEndAnim = LengthJumpAnim;

            _jumpDirectionEuler = Character.JumpDirection.transform.eulerAngles;
            Character.transform.eulerAngles = _jumpDirectionEuler;

            Character.Rigidbody.AddForce(Character.transform.forward * PowerJump);

            Character.BallTriggered += TakeDamage;

            Character.Audio.PlaySound(2);
        }

        public override void Exit()
        {
            Character.BallTriggered -= TakeDamage;
        }

        public override void Update() 
        {
            Character.transform.eulerAngles = _jumpDirectionEuler;

            if (_timeEndAnim > 0)
                _timeEndAnim -= Time.deltaTime;
            else
                StateSwitcher.SwitchState<CharacterStay>();
        }

        private void TakeDamage()
            => StateSwitcher.SwitchState<CharacterDamage>();
    }
}