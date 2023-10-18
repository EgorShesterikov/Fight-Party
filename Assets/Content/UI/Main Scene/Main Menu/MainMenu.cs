using System;

namespace FightParty.UI.MainScene
{
    public class MainMenu : IDisposable
    {
        public event Action ClickedPlay;
        public event Action ClickedCollection;
        public event Action ClickedSettings;

        private MainMenuView _view;

        public MainMenu(MainMenuView view)
        { 
            _view = view;

            _view.PlayButton.onClick.AddListener(() => ClickedPlay?.Invoke());
            _view.CollectionButton.onClick.AddListener(() => ClickedCollection?.Invoke());
            _view.SettingsButton.onClick.AddListener(() => ClickedSettings?.Invoke());
        }

        public MainMenuView View => _view;

        public void Dispose()
        {
            _view.PlayButton.onClick.RemoveAllListeners();
            _view.CollectionButton.onClick.RemoveAllListeners();
            _view.SettingsButton.onClick.RemoveAllListeners();
        }
    }
}