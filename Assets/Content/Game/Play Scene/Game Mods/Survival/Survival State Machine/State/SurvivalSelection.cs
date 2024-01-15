namespace FightParty.Game.PlayScene.Survival
{
    public class SurvivalSelection : SurvivalState
    {
        private IChooserJoysticks _chooserJoystick;
        private IHidePlayerIndication _hideIndication;

        private Character _firstCharacter;
        private Character _secondCharacter;

        public SurvivalSelection(IStateSwitcher stateSwitcher, SurvivalStateMachineData data,
           IChooserJoysticks chooserJoystick, IHidePlayerIndication hideIndication, Character firstCharacter, Character secondCharacter)
           : base(stateSwitcher, data)
        {
            _chooserJoystick = chooserJoystick;
            _hideIndication = hideIndication;

            _firstCharacter = firstCharacter;
            _secondCharacter = secondCharacter;
        }

        public override void Enter()
        {
            _chooserJoystick.SelectedSecond += SetSecondPlayerController;
            _chooserJoystick.SelectedFirst += SetFirstPlayerController;
        }

        public override void Update() { }

        public override void Exit()
        {
            _chooserJoystick.SelectedSecond -= SetSecondPlayerController;
            _chooserJoystick.SelectedFirst -= SetFirstPlayerController;
        }

        private void SetFirstPlayerController()
        {
            Data.SelectCharacterPlayer = _firstCharacter;
            Data.SelectCharacterPlayer.SetPlayerController();

            _hideIndication.SetActivSecondIndication(false);
            _secondCharacter.Destroy();

            StateSwitcher.SwitchState<SurvivalProcess>();
        }

        private void SetSecondPlayerController()
        {
            Data.SelectCharacterPlayer = _secondCharacter;
            Data.SelectCharacterPlayer.SetPlayerController();

            _hideIndication.SetActivFirstIndication(false);
            _firstCharacter.Destroy();

            StateSwitcher.SwitchState<SurvivalProcess>();
        }
    }
}
