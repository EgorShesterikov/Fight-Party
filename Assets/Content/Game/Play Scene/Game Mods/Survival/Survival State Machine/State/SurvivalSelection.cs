namespace FightParty.Game.PlayScene.Survival
{
    public class SurvivalSelection : SurvivalState
    {
        private ISelectJoysticks _changeJoystick;
        private IHidePlayerIndication _hideIndication;

        private Character _yellowCharacter;
        private Character _blueCharacter;

        public SurvivalSelection(IStateSwitcher stateSwitcher, SurvivalStateMachineData data,
           ISelectJoysticks changeJoystick, IHidePlayerIndication hideIndication, Character yellowCharacter, Character blueCharacter)
           : base(stateSwitcher, data)
        {
            _changeJoystick = changeJoystick;
            _hideIndication = hideIndication;

            _yellowCharacter = yellowCharacter;
            _blueCharacter = blueCharacter;
        }

        public override void Enter()
        {
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

            _hideIndication.SetActivBlueIndication(false);
            _blueCharacter.Destroy();

            StateSwitcher.SwitchState<SurvivalProcess>();
        }

        private void SetBluePlayerController()
        {
            Data.SelectCharacterPlayer = _blueCharacter;
            Data.SelectCharacterPlayer.SetPlayerController();

            _hideIndication.SetActivYellowIndication(false);
            _yellowCharacter.Destroy();

            StateSwitcher.SwitchState<SurvivalProcess>();
        }
    }
}
