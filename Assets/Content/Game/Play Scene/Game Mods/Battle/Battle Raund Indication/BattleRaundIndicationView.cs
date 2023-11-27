using TMPro;
using UnityEngine;
using System;
using I2.Loc;

namespace FightParty.Game.PlayScene.Battle
{
    public partial class BattleRaundIndicationView : WindowBase
    {
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

            _roundInfo.text = $"{LocalizationManager.GetTermTranslation($"Interfaces/BattleMenu-0")}{raund} " +
                $"\n {LocalizationManager.GetTermTranslation($"Interfaces/BattleMenu-{(int)stepType + OffsetLocalizationIndex}")}";
        }

        private void OnEnable()
            => LocalizationManager.OnLocalizeEvent += () => ChangeRaundInfo(_valueRaund, _valueStepType);

        private void OnDisable()
            => LocalizationManager.OnLocalizeEvent -= () => ChangeRaundInfo(_valueRaund, _valueStepType);
    }
}