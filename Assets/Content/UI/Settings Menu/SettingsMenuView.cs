using UnityEngine;
using UnityEngine.UI;
using TMPro;
using I2.Loc;

namespace FightParty.UI
{
    public partial class SettingsMenuView : WindowBase
    {
        private const string Localization_Language_Key = "Interfaces/Language-";

        [SerializeField] private EventSlider _musicSlider;
        [SerializeField] private EventSlider _soundSlider;
        [SerializeField] private Button _languageButton;
        [SerializeField] private Button _backButton;

        [Space]
        [SerializeField] private TextMeshProUGUI _languageText;

        public EventSlider MusicSlider => _musicSlider;
        public EventSlider SoundSlider => _soundSlider;
        public Button LanguageButton => _languageButton;
        public Button BackButton => _backButton;

        public void ChangeMusicSlider(float value) => _musicSlider.value = value;
        public void ChangeSoundSlider(float value) => _soundSlider.value = value;

        public void UpdateLanguageText(TypesLanguage language) 
            => _languageText.text = LocalizationManager.GetTermTranslation(Localization_Language_Key + (int)language);
    }
}
