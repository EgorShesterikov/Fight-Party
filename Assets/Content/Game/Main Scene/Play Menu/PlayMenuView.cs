using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using I2.Loc;

namespace FightParty.Game.MainScene
{
    public class PlayMenuView : WindowBase
    {
        private const string Localization_BattleRecord_Key = "Interfaces/PlayMenu-3";
        private const string Localization_SurvivalTime_Key = "Interfaces/PlayMenu-6";

        [SerializeField] private Button _battleButton;
        [SerializeField] private Button _backButton;
        [SerializeField] private Button _survivalButton;

        [Space]
        [SerializeField] private TextMeshProUGUI _battleRacordText;
        [SerializeField] private TextMeshProUGUI _survivalTimeText;

        private int _valueBattleRecord;
        private int _valueSurvivalTime;

        public Button BattleButton => _battleButton;
        public Button BackButton => _backButton;
        public Button SurvivalButton => _survivalButton;

        public void ChangeBattleRating(int value)
        {
            if(value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _valueBattleRecord = value;

            _battleRacordText.text = LocalizationManager.GetTermTranslation(Localization_BattleRecord_Key) + _valueBattleRecord;
        }

        public void ChangeSurvivalTime(int value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _valueSurvivalTime = value;

            string time = ConvertSecondInTimeFormat(_valueSurvivalTime);

            _survivalTimeText.text = LocalizationManager.GetTermTranslation(Localization_SurvivalTime_Key) + time;
        }

        private string ConvertSecondInTimeFormat(int second)
        {
            int hour = 0;
            int minute = 0;

            for (; second >= 3600; second -= 3600)
                hour++;

            for (; second >= 60; second -= 60)
                minute++;

            return $"{hour:00}:{minute:00}:{second:00}";
        }

        private void OnEnable()
        {
            LocalizationManager.OnLocalizeEvent += () => ChangeBattleRating(_valueBattleRecord);
            LocalizationManager.OnLocalizeEvent += () => ChangeSurvivalTime(_valueSurvivalTime);
        }

        private void OnDisable()
        {
            LocalizationManager.OnLocalizeEvent -= () => ChangeBattleRating(_valueBattleRecord);
            LocalizationManager.OnLocalizeEvent -= () => ChangeSurvivalTime(_valueSurvivalTime);
        }
    }
}
