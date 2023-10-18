using UnityEngine;
using UnityEngine.UI;

namespace FightParty.UI
{
    public class SettingsMenuView : WindowBase
    {
        [SerializeField] private Slider _musicSlider;
        [SerializeField] private Slider _soundSlider;
        [SerializeField] private Button _languageButton;
        [SerializeField] private Button _backButton;

        public Slider MusicSlider => _musicSlider;
        public Slider SoundSlider => _soundSlider;
        public Button LanguageButton => _languageButton;
        public Button BackButton => _backButton;
    }
}
