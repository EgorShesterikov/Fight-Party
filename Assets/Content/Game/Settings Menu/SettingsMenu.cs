using FightParty.Audio;
using FightParty.Save;
using I2.Loc;
using System;
using Zenject;

namespace FightParty.Game
{
    public class SettingsMenu : IDisposable, IChangeAudio, IInitializable
    {
        public event Action<float> ChangedMusic;
        public event Action<float> ChangedSound;
        public event Action<TypesLanguage> ChangedLanguage;
        public event Action ClickedBack;

        private TypesLanguage _currentLanguage = TypesLanguage.Russian;

        private SettingsMenuView _view;

        private GlobalSFXSource _audio;
        private SettingsManager _settingsManager;

        public SettingsMenu(SettingsMenuView view, GlobalSFXSource audio, SettingsManager settingsManager)
        {
            _view = view;

            _view.MusicSlider.onValueChanged.AddListener(ChangeMusicValue);
            _view.SoundSlider.onValueChanged.AddListener(ChangeSoundValue);
            _view.LanguageButton.onClick.AddListener(ChangeLanguage);
            _view.BackButton.onClick.AddListener(ClickBackButton);

            _audio = audio;

            _view.MusicSlider.PointerUp += _audio.PlayClick;
            _view.SoundSlider.PointerUp += _audio.PlayClick;

            _settingsManager = settingsManager;
        }

        public IOpenClose View => _view;

        public void Dispose()
        {
            _view.MusicSlider.onValueChanged.RemoveAllListeners();
            _view.SoundSlider.onValueChanged.RemoveAllListeners();
            _view.LanguageButton.onClick.RemoveAllListeners();
            _view.BackButton.onClick.RemoveAllListeners();

            _view.MusicSlider.PointerUp -= _audio.PlayClick;
            _view.SoundSlider.PointerUp -= _audio.PlayClick;
        }

        public void Initialize()
        {
            SettingsJSON settingsJSON = _settingsManager.Load();

            _view.ChangeMusicSlider(settingsJSON.Music);
            _view.ChangeSoundSlider(settingsJSON.SFX);

            ChangeTargetLanguage(settingsJSON.Language);
        }

        private void ChangeMusicValue(float value)
        {
            ChangedMusic?.Invoke(value);
        }

        private void ChangeSoundValue(float value)
        {
            ChangedSound?.Invoke(value);
        }

        private void ChangeLanguage()
        {
            _audio.PlayClick();

            _currentLanguage = CheckLastPosLanguage() ? _currentLanguage + 1 : _currentLanguage = 0;

            SetLanguageInLocalizationManager();

            _view.UpdateLanguageText(_currentLanguage);

            ChangedLanguage?.Invoke(_currentLanguage);
        }

        private void ChangeTargetLanguage(TypesLanguage language)
        {
            _currentLanguage = language;

            SetLanguageInLocalizationManager();

            _view.UpdateLanguageText(_currentLanguage);

            ChangedLanguage?.Invoke(_currentLanguage);
        }

        private void ClickBackButton()
        {
            _audio.PlayClick();

            SaveChanges();

            ClickedBack?.Invoke();
        }

        private void SaveChanges()
        {
            SettingsJSON settingsJSON = new SettingsJSON(_view.MusicSlider.value, _view.SoundSlider.value, _currentLanguage);
            _settingsManager.Save(settingsJSON);
        }

        private bool CheckLastPosLanguage()
            => (int)_currentLanguage < Enum.GetNames(typeof(TypesLanguage)).Length - 1;

        private void SetLanguageInLocalizationManager()
            => LocalizationManager.CurrentLanguage = _currentLanguage.ToString();
    }
}
