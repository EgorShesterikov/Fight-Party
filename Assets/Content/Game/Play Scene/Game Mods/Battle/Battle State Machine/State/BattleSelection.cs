namespace FightParty.Game.PlayScene.Battle
{
    public class BattleSelection : BattleRaundState
    {
        private IChooserJoysticks _chooserJoystick;
        private IHidePlayerIndication _hideJoysticks;

        private Character _firstCharacter;
        private Character _secondCharacter;

        public BattleSelection(IStateSwitcher stateSwitcher, BattleStateMachineData data, BattleRaundIndication raundIndication, 
            IChooserJoysticks chooserJoystick, IHidePlayerIndication hideJoysticks, Character firstCharacter, Character secondCharacter) 
            : base(stateSwitcher, data, raundIndication)
        {
            _chooserJoystick = chooserJoystick;
            _hideJoysticks = hideJoysticks;

            _firstCharacter = firstCharacter;
            _secondCharacter = secondCharacter;
        }

        public override void Enter()
        {
            RaundIndication.SetStep(BattleRaundsStepTypes.Selection);

            _chooserJoystick.SelectedSecond += SetFirstPlayerController;
            _chooserJoystick.SelectedFirst += SetSecondPlayerController;
        }

        public override void Update() { }

        public override void Exit()
        {
            _chooserJoystick.SelectedSecond -= SetFirstPlayerController;
            _chooserJoystick.SelectedFirst -= SetSecondPlayerController;
        }

        private void SetSecondPlayerController()
        {
            Data.SelectCharacterPlayer = _firstCharacter;
            Data.SelectCharacterPlayer.SetPlayerController();

            Data.SelectCharacterEnemy = _secondCharacter;
            Data.SelectCharacterEnemy.SetAutoController(Data.SelectCharacterPlayer, Data.DefaultBall);

            _hideJoysticks.SetActivSecondJoystick(false);

            StateSwitcher.SwitchState<BattlePreparation>();
        }

        private void SetFirstPlayerController()
        {
            Data.SelectCharacterPlayer = _secondCharacter;
            Data.SelectCharacterPlayer.SetPlayerController();

            Data.SelectCharacterEnemy = _firstCharacter;
            Data.SelectCharacterEnemy.SetAutoController(Data.SelectCharacterPlayer, Data.DefaultBall);

            _hideJoysticks.SetActivFirstJoystick(false);

            StateSwitcher.SwitchState<BattlePreparation>();
        }
    }
}