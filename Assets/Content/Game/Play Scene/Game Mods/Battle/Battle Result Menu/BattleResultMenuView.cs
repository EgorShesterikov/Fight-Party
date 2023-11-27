using UnityEngine;
using TMPro;
using UnityEngine.UI;
using I2.Loc;
using FightParty.Audio;

namespace FightParty.Game.PlayScene.Battle
{
    public class BattleResultMenuView : WindowBase
    {
        [SerializeField] private TextMeshProUGUI _resultText;
        [SerializeField] private Button _menuButton;

        private AudioComponent _audioComponent;

        public Button MenuButton => _menuButton;

        public AudioComponent Audio => _audioComponent;

        public void SetWinText()
            => _resultText.text = LocalizationManager.GetTermTranslation("Interfaces/BattleResultMenu-1");

        public void SetLoseText()
           => _resultText.text = LocalizationManager.GetTermTranslation("Interfaces/BattleResultMenu-2");

        public void SetDrawText()
           => _resultText.text = LocalizationManager.GetTermTranslation("Interfaces/BattleResultMenu-5");

        private void Start()
            => _audioComponent = GetComponent<AudioComponent>();
    }
}