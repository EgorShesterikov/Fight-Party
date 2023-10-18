using System;
using UnityEngine;

namespace FightParty.UI
{
    public class SettingsMenu : IDisposable
    {
        public event Action<int> ChangedMusic;
        public event Action<int> ChangedSound;
        public event Action<int> ChangedLanguage;
        public event Action ClickedBack;

        private int _currentLanguage = 0;

        private SettingsMenuView _view;

        public SettingsMenu(SettingsMenuView view)
        {
            _view = view;

            _view.MusicSlider.onValueChanged.AddListener((value) => ChangedMusic?.Invoke((int)value));
            _view.SoundSlider.onValueChanged.AddListener((value) => ChangedSound?.Invoke((int)value));
            _view.LanguageButton.onClick.AddListener(() => ChangeLanguage());
            _view.BackButton.onClick.AddListener(() => ClickedBack?.Invoke());
        }

        public SettingsMenuView View => _view;

        public void Dispose()
        {
            _view.MusicSlider.onValueChanged.RemoveAllListeners();
            _view.SoundSlider.onValueChanged.RemoveAllListeners();
            _view.LanguageButton.onClick.RemoveAllListeners();
            _view.BackButton.onClick.RemoveAllListeners();
        }

        private void ChangeLanguage()
        {
            Debug.Log("Изменяем язык");

            ChangedLanguage?.Invoke(_currentLanguage);
        }
    }
}
