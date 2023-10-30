using FightParty.Audio;
using System;

namespace FightParty.Game.PlayScene
{
    public partial class GamePlayMenu : IDisposable
    {
        public event Action ClickedSettings;
        public event Action ClickedExit;

        private GamePlayMenuView _view;

        private GlobalSFXSource _audio;

        public GamePlayMenu(GamePlayMenuView view, GlobalSFXSource audio)
        {
            _view = view;

            _view.SettingsButton.onClick.AddListener(ClickSettingsButton);
            _view.ExitButton.onClick.AddListener(ClickExitButton);

            _audio = audio;
        }

        public GamePlayMenuView View => _view;

        public void Dispose()
        {
            _view.SettingsButton.onClick.RemoveListener(ClickSettingsButton);
            _view.ExitButton.onClick.RemoveListener(ClickExitButton);
        }

        private void ClickSettingsButton()
        {
            _audio.PlayClick();

            ClickedSettings?.Invoke();
        }

        private void ClickExitButton()
        {
            _audio.PlayClick();

            ClickedExit?.Invoke();
        }
    }
}