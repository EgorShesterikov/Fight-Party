using TMPro;
using UnityEngine;
using System;
using I2.Loc;

namespace FightParty.Game.PlayScene.Battle
{
    public partial class BattleRaundIndicationView : WindowBase
    {
        private const string Localization_RoundInfo_Key = "Interfaces/BattleMenu-0";
        private const string Localization_RoundStage_Key = "Interfaces/BattleMenu-";

        private const int OffsetLocalizationIndex = 1;

        [SerializeField] private TextMeshProUGUI _roundInfo;

        public TextMeshProUGUI RoundInfo => _roundInfo;

        private int _valueRaund;
        private BattleRaundsStepTypes _valueStepType;

        public void ChangeRaundInfo(int raund, BattleRaundsStepTypes stepType)
        {
            if(raund < 0)
                throw new ArgumentOutOfRangeException(nameof(raund));

            _valueRaund = raund;
            _valueStepType = stepType;

            _roundInfo.text = $"{LocalizationManager.GetTermTranslation(Localization_RoundInfo_Key)}{raund} " +
                $"\n {LocalizationManager.GetTermTranslation($"{Localization_RoundStage_Key}{(int)stepType + OffsetLocalizationIndex}")}";
        }

        private void OnEnable()
            => LocalizationManager.OnLocalizeEvent += () => ChangeRaundInfo(_valueRaund, _valueStepType);

        private void OnDisable()
            => LocalizationManager.OnLocalizeEvent -= () => ChangeRaundInfo(_valueRaund, _valueStepType);
    }
}