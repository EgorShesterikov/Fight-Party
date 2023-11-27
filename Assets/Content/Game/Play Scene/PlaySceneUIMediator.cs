using System;

namespace FightParty.Game.PlayScene
{
    public class PlaySceneUIMediator : UIMediator, IDisposable
    {
        private GamePlayMenu _gamePlayMenu;
        private ExitMenu _exitMenu;
        private SettingsMenu _settingsMenu;

        public PlaySceneUIMediator(GamePlayMenu gamePlayMenu, ExitMenu exitMenu, 
            SettingsMenu settingsMenu)
        {
            _gamePlayMenu = gamePlayMenu;
            _exitMenu = exitMenu;
            _settingsMenu = settingsMenu;

            _gamePlayMenu.ClickedSettings += OpenSettingsMenu;
            _gamePlayMenu.ClickedExit += OpenExitMenu;

            _exitMenu.ClickedNoExit += DontExitPlayScene;
            _exitMenu.ClickedYesExit += ExitPlayScene;

            _settingsMenu.ClickedBack += CloseSettingsMenu;
        }

        public void Dispose()
        {
            _gamePlayMenu.ClickedSettings -= OpenSettingsMenu;
            _gamePlayMenu.ClickedExit -= OpenExitMenu;

            _settingsMenu.ClickedBack -= CloseSettingsMenu;
        }

        private void OpenSettingsMenu()
        {
            _settingsMenu.View.Open();
        }
        private void OpenExitMenu()
        {
            _exitMenu.View.Open();
        }

        private void ExitPlayScene()
        {
            SceenFader.Set(ScreenFader.TypeFade.Appear, () =>
            {
                SceneLoader.GoToMainScene();
                SceenFader.Set(ScreenFader.TypeFade.Disappear);
            });
        }
        private void DontExitPlayScene()
        {
            _exitMenu.View.Close();
        }

        private void CloseSettingsMenu()
        {
            _settingsMenu.View.Close();
        }
    }
}
