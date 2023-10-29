using FightParty.Audio;
using System;

namespace FightParty.Game.PlayScene
{
    public class ExitMenu : IDisposable
    {
        public event Action ClickedYesExit;
        public event Action ClickedNoExit;

        private ExitMenuView _view;

        private GlobalSFXSource _audio;

        public ExitMenu(ExitMenuView view, GlobalSFXSource audio) 
        { 
            _view = view;

            _view.YesExitButton.onClick.AddListener(ClickYesExitButton);
            _view.NoExitButton.onClick.AddListener(ClickNoExitButton);

            _audio = audio;
        }

        public ExitMenuView View => _view;

        public void Dispose()
        {
            _view.YesExitButton.onClick.RemoveAllListeners();
            _view.NoExitButton.onClick.RemoveAllListeners();
        }

        private void ClickYesExitButton()
        {
            _audio.PlayClick();

            ClickedYesExit?.Invoke();
        }

        private void ClickNoExitButton()
        {
            _audio.PlayClick();

            ClickedNoExit?.Invoke();
        }
    }
}