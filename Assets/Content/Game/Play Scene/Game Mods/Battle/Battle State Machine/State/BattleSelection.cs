namespace FightParty.Game.PlayScene.Battle
{
    public class BattleSelection : BattleRaundState
    {
        private ISelectJoysticks _changeJoystick;
        private IHidePlayerIndication _hideJoysticks;

        private Character _yellowCharacter;
        private Character _blueCharacter;

        public BattleSelection(IStateSwitcher stateSwitcher, BattleStateMachineData data, BattleRaundIndication raundIndication, 
            ISelectJoysticks changeJoystick, IHidePlayerIndication hideJoysticks, Character yellowCharacter, Character blueCharacter) 
            : base(stateSwitcher, data, raundIndication)
        {
            _changeJoystick = changeJoystick;
            _hideJoysticks = hideJoysticks;

            _yellowCharacter = yellowCharacter;
            _blueCharacter = blueCharacter;
        }

        public override void Enter()
        {
            RaundIndication.SetStep(BattleRaundsStepTypes.Selection);

            _changeJoystick.SelectedBlueJoystick += SetBluePlayerController;
            _changeJoystick.SelectedYellowJoystick += SetYellowPlayerController;
        }

        public override void Update() { }

        public override void Exit()
        {
            _changeJoystick.SelectedBlueJoystick -= SetBluePlayerController;
            _changeJoystick.SelectedYellowJoystick -= SetYellowPlayerController;
        }

        private void SetYellowPlayerController()
        {
            Data.SelectCharacterPlayer = _yellowCharacter;
            Data.SelectCharacterPlayer.SetPlayerController();

            Data.SelectCharacterEnemy = _blueCharacter;
            Data.SelectCharacterEnemy.SetAutoController(Data.SelectCharacterPlayer, Data.DefaultBall);

            _hideJoysticks.SetActivBlueJoystic(false);

            StateSwitcher.SwitchState<BattlePreparation>();
        }

        private void SetBluePlayerController()
        {
            Data.SelectCharacterPlayer = _blueCharacter;
            Data.SelectCharacterPlayer.SetPlayerController();

            Data.SelectCharacterEnemy = _yellowCharacter;
            Data.SelectCharacterEnemy.SetAutoController(Data.SelectCharacterPlayer, Data.DefaultBall);

            _hideJoysticks.SetActivYellowJoystic(false);

            StateSwitcher.SwitchState<BattlePreparation>();
        }
    }
}