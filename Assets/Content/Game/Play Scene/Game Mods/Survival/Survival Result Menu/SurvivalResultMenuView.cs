using FightParty.Audio;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FightParty.Game.PlayScene.Survival
{
    public class SurvivalResultMenuView : WindowBase
    {
        [SerializeField] private TextMeshProUGUI _resultText;
        [SerializeField] private TextMeshProUGUI _recordText;

        [SerializeField] private Button _menuButton;

        private AudioComponent _audioComponent;

        public Button MenuButton => _menuButton;

        public AudioComponent Audio => _audioComponent;

        public void SetResult(int second)
            => _resultText.text = SecondConverter.ConvertSecondInTimeFormat(second);

        public void SetRecord(int second)
            => _recordText.text = LocalizationManager.GetTermTranslation("Interfaces/SurvivalMenu-1")
            + SecondConverter.ConvertSecondInTimeFormat(second);

        private void Start()
            => _audioComponent = GetComponent<AudioComponent>();
    }
}