using FightParty.Audio;
using System;

namespace FightParty.UI.MainScene
{
    public class PlayMenu : IDisposable
    {
        public event Action ClickedBattle;
        public event Action ClickedBack;
        public event Action ClickedSurvival;

        private PlayMenuView _view;

        private GlobalSFXSource _audio;

        public PlayMenu(PlayMenuView view, GlobalSFXSource audio)
        {
            _view = view;

            _view.BattleButton.onClick.AddListener(ClickBattleButton);
            _view.BackButton.onClick.AddListener(ClickBackButton);
            _view.SurvivalButton.onClick.AddListener(ClickSurvivalButton);

            _audio = audio;
        }

        public PlayMenuView View => _view;

        public void Dispose()
        {
            _view.BattleButton.onClick.RemoveAllListeners();
            _view.BackButton.onClick.RemoveAllListeners();
            _view.SurvivalButton.onClick.RemoveAllListeners();
        }

        private void ClickBattleButton()
        {
            _audio.PlayClick();

            ClickedBattle?.Invoke();
        }

        private void ClickBackButton()
        {
            _audio.PlayClick();

            ClickedBack?.Invoke();
        }

        private void ClickSurvivalButton()
        {
            _audio.PlayClick();

            ClickedSurvival?.Invoke();
        }
    }
}
