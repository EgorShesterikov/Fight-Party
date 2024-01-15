using UnityEngine;

namespace FightParty.Game.PlayScene.Battle
{
    public class BattleFight : BattleRaundState
    {
        private const float TimeDefaultFight = 2f;

        private float _timeDefaultFight;

        private IHidePlayerIndication _playerIndication;

        public BattleFight(IStateSwitcher stateSwitcher, BattleStateMachineData data, BattleRaundIndication raundIndication,
            IHidePlayerIndication playerIndication) 
            : base(stateSwitcher, data, raundIndication)
        {
            _playerIndication = playerIndication;
        }

        public override void Enter()
        {
            RaundIndication.SetStep(BattleRaundsStepTypes.Fight);

            _timeDefaultFight = TimeDefaultFight;

            Data.SelectCharacterPlayer.Jump();
            Data.SelectCharacterEnemy.Jump();

            ChangeInteractableJoystick(false);
        }

        public override void Exit() { }

        public override void Update()
        {
            if (_timeDefaultFight > 0)
                _timeDefaultFight -= Time.deltaTime;
            else
            {
                if (Data.DefaultBall.IsStopped() && Data.SelectCharacterPlayer.IsStopped() && Data.SelectCharacterEnemy.IsStopped())
                {
                    if (Data.SelectCharacterPlayer.CurrentHeal > 0 && Data.SelectCharacterEnemy.CurrentHeal > 0)
                    {
                        ChangeInteractableJoystick(true);
                        StateSwitcher.SwitchState<BattlePreparation>();
                    }
                    else
                        StateSwitcher.SwitchState<BattleResults>();
                }
            }                
        }

        private void ChangeInteractableJoystick(bool value)
        {
            _playerIndication.SetIneterctableFirstJoystick(value);
            _playerIndication.SetIneterctableSecondJoystick(value);
        }
    }
}