using UnityEngine;
using UnityEngine.UI;

namespace FightParty.UI.MainScene
{
    public class MainMenuView : WindowBase
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _collectionButton;
        [SerializeField] private Button _settingsButton;

        public Button PlayButton => _playButton;
        public Button CollectionButton => _collectionButton;
        public Button SettingsButton => _settingsButton;
    }
}