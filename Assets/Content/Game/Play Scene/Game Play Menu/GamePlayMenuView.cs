using UnityEngine;
using UnityEngine.UI;

namespace FightParty.Game.PlayScene
{
    public class GamePlayMenuView : WindowBase
    {
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _exitButton;

        public Button SettingsButton => _settingsButton;
        public Button ExitButton => _exitButton;
    }
}