namespace FightParty.Game.PlayScene.Battle
{
    public class BattleRaundIndication
    {
        private int _currentRaund = 0;
        private BattleRaundsStepTypes _currentStep = BattleRaundsStepTypes.Selection;

        private BattleRaundIndicationView _view;

        public BattleRaundIndication(BattleRaundIndicationView battleRaundIndicationView)
            => _view = battleRaundIndicationView;

        public void SetStep(BattleRaundsStepTypes stepType)
        {
            _currentStep = stepType;

            _view.ChangeRaundInfo(_currentRaund, _currentStep);
        }

        public void NewRaund()
        {
            _currentRaund++;

            _view.ChangeRaundInfo(_currentRaund, _currentStep);
        }
    }
}