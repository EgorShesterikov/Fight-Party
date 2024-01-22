using UnityEngine;
using TMPro;
using UnityEngine.UI;
using I2.Loc;
using FightParty.Audio;

namespace FightParty.Game.PlayScene.Battle
{
    public class BattleResultMenuView : WindowBase
    {
        private const string Localization_ResultWin_Key = "Interfaces/BattleResultMenu-1";
        private const string Localization_ResultLose_Key = "Interfaces/BattleResultMenu-2";
        private const string Localization_ResultDraw_Key = "Interfaces/BattleResultMenu-3";

        [SerializeField] private TextMeshProUGUI _resultText;
        [SerializeField] private Button _menuButton;

        private AudioComponent _audioComponent;

        public Button MenuButton => _menuButton;

        public AudioComponent Audio => _audioComponent;

        public void SetWinText()
            => _resultText.text = LocalizationManager.GetTermTranslation(Localization_ResultWin_Key);

        public void SetLoseText()
           => _resultText.text = LocalizationManager.GetTermTranslation(Localization_ResultLose_Key);

        public void SetDrawText()
           => _resultText.text = LocalizationManager.GetTermTranslation(Localization_ResultDraw_Key);

        private void Start()
            => _audioComponent = GetComponent<AudioComponent>();
    }
}