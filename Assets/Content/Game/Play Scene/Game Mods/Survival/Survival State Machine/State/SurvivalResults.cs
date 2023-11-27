namespace FightParty.Game.PlayScene.Survival
{
    public class SurvivalResults : SurvivalState
    {
        private SurvivalTimeIndication _timeIndication;
        private SurvivalResultMenu _resultMenu;

        public SurvivalResults(IStateSwitcher stateSwitcher, SurvivalStateMachineData data,
            SurvivalTimeIndication timeIndication, SurvivalResultMenu resultMenu) 
            : base(stateSwitcher, data)
        {
            _timeIndication = timeIndication;
            _resultMenu = resultMenu;
        }

        public override void Enter()
        {
            _resultMenu.Result(_timeIndication.CurrentSecond);
        }

        public override void Exit() { }

        public override void Update() { }
    }
}