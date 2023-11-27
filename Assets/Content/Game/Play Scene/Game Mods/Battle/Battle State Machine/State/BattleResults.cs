namespace FightParty.Game.PlayScene.Battle
{
    public class BattleResults : BattleRaundState
    {
        private BattleResultMenu _resultMenu;

        public BattleResults(IStateSwitcher stateSwitcher, BattleStateMachineData data, BattleRaundIndication raundIndication,
            BattleResultMenu resultMenu) 
            : base(stateSwitcher, data, raundIndication)
        {
            _resultMenu = resultMenu;
        }

        public override void Enter()
        {
            RaundIndication.SetStep(BattleRaundsStepTypes.Results);

            Data.DefaultBall.SetFreezing(true);

            if (Data.SelectCharacterPlayer.CurrentHeal > 0 && Data.SelectCharacterEnemy.CurrentHeal <= 0)
            {
                _resultMenu.Win();
                Data.SelectCharacterPlayer.Dance();
            }
            else if (Data.SelectCharacterPlayer.CurrentHeal <= 0 && Data.SelectCharacterEnemy.CurrentHeal > 0)
            {
                _resultMenu.Lose();
                Data.SelectCharacterEnemy.Dance();
            }
            else
            {
                _resultMenu.Draw();
            }
        }

        public override void Exit() { }

        public override void Update() { }
    }
}