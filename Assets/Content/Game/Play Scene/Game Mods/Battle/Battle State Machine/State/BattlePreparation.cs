namespace FightParty.Game.PlayScene.Battle
{
    public class BattlePreparation : BattleRaundState
    {
        private const string ClipNamePreparation = "Defence";

        private BattleReadyButton _readyButton;

        public BattlePreparation(IStateSwitcher stateSwitcher, BattleStateMachineData data, BattleRaundIndication raundIndication, 
            BattleReadyButton readyButton) 
            : base(stateSwitcher, data, raundIndication)
        {
            _readyButton = readyButton;
        }
    
        public override void Enter()
        {
            RaundIndication.NewRaund();

            RaundIndication.SetStep(BattleRaundsStepTypes.Preparation);

            Data.SelectCharacterPlayer.Preparation();
            Data.SelectCharacterEnemy.Preparation();

            _readyButton.OnClickedReady += Ready;

            _readyButton.View.Open();

            Data.DefaultBall.SetFreezing(true);
        }

        public override void Exit()
        {
            _readyButton.OnClickedReady -= Ready;

            Data.DefaultBall.SetFreezing(false);
        }

        public override void Update() 
        {
            if (Data.SelectCharacterEnemy.Animator.GetCurrentAnimatorClipInfo(0)[0].clip.name != ClipNamePreparation)
                Data.SelectCharacterEnemy.Preparation();

            if (Data.SelectCharacterPlayer.Animator.GetCurrentAnimatorClipInfo(0)[0].clip.name != ClipNamePreparation)
                Data.SelectCharacterPlayer.Preparation();
        }

        private void Ready()
        {
            _readyButton.View.Close();

            StateSwitcher.SwitchState<BattleFight>();
        }
    }
}