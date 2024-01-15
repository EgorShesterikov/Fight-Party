using FightParty.Game.PlayScene;
using UnityEngine;

namespace FightParty.Game
{
    public class CharacterPreparation : CharacterState
    {
        private const int ChanceRandomJump = 30;
        private const int ChanceTargetPlayerJump = ChanceRandomJump + 10;
        private const int ChanceTargetBallJump = ChanceTargetPlayerJump + 20;
        private const int ChancePerfectJump = ChanceTargetBallJump + 40;

        private IReaderJoystick _readerJoystick;

        public CharacterPreparation(IStateSwitcher stateSwitcher, CharacterStateMachineData data, Character character, 
            IReaderJoystick readerJoystick) 
            : base(stateSwitcher, data, character)
        {
            _readerJoystick = readerJoystick;
        }

        public override void Enter()
        {
            Character.Animator.SetTrigger("Preparation");

            Character.Jumped += GoToJump;
            Character.BallTriggered += TakeDamage;

            Character.JumpDirection.rotation = Quaternion.LookRotation(Character.transform.forward);
            
            if (Character.IsPlayerController)
            {
                Character.JumpDirection.gameObject.SetActive(true);
                _readerJoystick.ChangedPosition += SetJumpDirection;
            }
            else
                SetAutoJumpDirection();
        }

        public override void Exit()
        {
            Character.Jumped -= GoToJump;
            Character.BallTriggered -= TakeDamage;

            if (Character.IsPlayerController)
            {
                Character.JumpDirection.gameObject.SetActive(false);
                _readerJoystick.ChangedPosition -= SetJumpDirection;
            }
        }

        public override void Update() { }

        private void SetJumpDirection(Vector2 direction)
        {
            Vector3 jumpDirection = new Vector3(direction.x, 0, direction.y);
            Character.JumpDirection.rotation = Quaternion.LookRotation(jumpDirection);
        }
        private void SetAutoJumpDirection()
        {
            if (Character.AutoControllerData == null)
                return;

            Vector3 jumpDirection = Vector3.one;
            int random = Random.Range(0, 100);

            if(random < ChanceRandomJump)
            {
                jumpDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
            }
            else if(random < ChanceTargetPlayerJump)
            {
                jumpDirection = Character.AutoControllerData.TargetPlayer.transform.position - Character.JumpDirection.transform.position;
            }
            else if(random < ChanceTargetBallJump)
            {
                jumpDirection = Character.AutoControllerData.Ball.transform.position - Character.JumpDirection.transform.position;
            }
            else if(random < ChancePerfectJump)
            {
                Vector3 ballPerfectDirection = Character.AutoControllerData.Ball.transform.position - Character.AutoControllerData.TargetPlayer.transform.position;
                ballPerfectDirection.Normalize();

                jumpDirection = Character.AutoControllerData.Ball.transform.position - Character.JumpDirection.transform.position + ballPerfectDirection;
            }

            jumpDirection.y = 0;

            Character.JumpDirection.rotation = Quaternion.LookRotation(jumpDirection);
        }

        private void GoToJump()
            => StateSwitcher.SwitchState<CharacterJump>();

        private void TakeDamage()
            => StateSwitcher.SwitchState<CharacterDamage>();
    }
}