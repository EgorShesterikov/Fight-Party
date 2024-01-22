using FightParty.Audio;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FightParty.Game.PlayScene.Survival
{
    public class SurvivalResultMenuView : WindowBase
    {
        private const string Localization_SurvivalRecord_Key = "Interfaces/SurvivalMenu-1";

        [SerializeField] private TextMeshProUGUI _resultText;
        [SerializeField] private TextMeshProUGUI _recordText;

        [SerializeField] private Button _menuButton;

        private AudioComponent _audioComponent;

        public Button MenuButton => _menuButton;

        public AudioComponent Audio => _audioComponent;

        public void SetResult(int second)
            => _resultText.text = SecondConverter.ConvertSecondInTimeFormat(second);

        public void SetRecord(int second)
            => _recordText.text = LocalizationManager.GetTermTranslation(Localization_SurvivalRecord_Key)
            + SecondConverter.ConvertSecondInTimeFormat(second);

        private void Start()
            => _audioComponent = GetComponent<AudioComponent>();
    }
}