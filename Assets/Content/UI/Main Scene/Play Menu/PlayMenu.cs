using System;

namespace FightParty.UI.MainScene
{
    public class PlayMenu : IDisposable
    {
        public event Action ClickedBattle;
        public event Action ClickedBack;
        public event Action ClickedSurvival;

        private PlayMenuView _view;

        public PlayMenu(PlayMenuView view)
        {
            _view = view;

            _view.BattleButton.onClick.AddListener(() => ClickedBattle?.Invoke());
            _view.BackButton.onClick.AddListener(() => ClickedBack?.Invoke());
            _view.SurvivalButton.onClick.AddListener(() => ClickedSurvival?.Invoke());
        }

        public PlayMenuView View => _view;

        public void Dispose()
        {
            _view.BattleButton.onClick.RemoveAllListeners();
            _view.BackButton.onClick.RemoveAllListeners();
            _view.SurvivalButton.onClick.RemoveAllListeners();
        }
    }
}
