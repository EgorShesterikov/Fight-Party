using UnityEngine;

namespace FightParty.Game.PlayScene.Survival
{
    public class SurvivalTimeIndication
    {
        private float _currentSecond = 0;

        private SurvivalTimeIndicationView _view;

        public SurvivalTimeIndication(SurvivalTimeIndicationView survivalTimeIndicationView)
            => _view = survivalTimeIndicationView;

        public int CurrentSecond
        {
            get => Mathf.FloorToInt(_currentSecond);
        }

        public void UpdateSecond()
        {
            _currentSecond += Time.deltaTime;

            _view.SetTime(CurrentSecond);
        }
    }
}