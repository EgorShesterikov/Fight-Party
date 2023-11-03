using FightParty.Game.SceneLoader;
using System;

namespace FightParty.Game.MainScene
{
    public class MainSceneUIMediator : UIMediator, IDisposable
    {
        private MainMenu _mainMenu;
        private PlayMenu _playMenu;
        private CollectionMenu _collectionMenu;
        private SettingsMenu _settingsMenu;

        private GameModeFactory _gameModeFactory;

        public MainSceneUIMediator(MainMenu mainMenu, PlayMenu playMenu, 
            CollectionMenu collectionMenu, SettingsMenu settingsMenu, 
            GameModeFactory gameModeFactory)
        {
            _mainMenu = mainMenu;
            _playMenu = playMenu;
            _collectionMenu = collectionMenu;
            _settingsMenu = settingsMenu;

            _mainMenu.ClickedPlay += OpenPlayMenu;
            _mainMenu.ClickedCollection += OpenCollectionMenu;
            _mainMenu.ClickedSettings += OpenSettingsMenu;

            _playMenu.ClickedBattle += StartBattleMode;
            _playMenu.ClickedBack += ClosePlayMenu;
            _playMenu.ClickedSurvival += StartSurvivalMode;

            _collectionMenu.SelectedRing += CloseCollectionMenu;

            _settingsMenu.ClickedBack += CloseSettingsMenu;

            _gameModeFactory = gameModeFactory;
        }

        public void Dispose()
        {
            _mainMenu.ClickedPlay -= OpenPlayMenu;
            _mainMenu.ClickedCollection -= OpenCollectionMenu;
            _mainMenu.ClickedSettings -= OpenSettingsMenu;

            _playMenu.ClickedBattle -= StartBattleMode;
            _playMenu.ClickedBack -= ClosePlayMenu;
            _playMenu.ClickedSurvival -= StartSurvivalMode;

            _collectionMenu.SelectedRing -= CloseCollectionMenu;

            _settingsMenu.ClickedBack -= CloseSettingsMenu;
        }

        private void OpenCollectionMenu()
        {
            _mainMenu.View.Close();
            _timer.Play(SwitchingInterfacesDelay, _collectionMenu.View.Open);
        }
        private void OpenPlayMenu()
        {
            _mainMenu.View.Close();
            _timer.Play(SwitchingInterfacesDelay, _playMenu.View.Open);
        }
        private void OpenSettingsMenu()
        {
            _settingsMenu.View.Open();
        }

        private void StartBattleMode()
        {
            _sceenFader.Set(ScreenFader.TypeFade.Appear, () =>
            {
                _sceneLoader.GoToPlayScene(new LoadingData(_gameModeFactory.Get(GameTypes.Battle)));
                _sceenFader.Set(ScreenFader.TypeFade.Disappear);
            });
        }
        private void ClosePlayMenu()
        {
            _playMenu.View.Close();
            _timer.Play(SwitchingInterfacesDelay, _mainMenu.View.Open);
        }
        private void StartSurvivalMode()
        {
            _sceenFader.Set(ScreenFader.TypeFade.Appear, () =>
            {
                _sceneLoader.GoToPlayScene(new LoadingData(_gameModeFactory.Get(GameTypes.Survival)));
                _sceenFader.Set(ScreenFader.TypeFade.Disappear);
            }); 
        }

        private void CloseCollectionMenu()
        {
            _collectionMenu.View.Close();
            _timer.Play(SwitchingInterfacesDelay, _mainMenu.View.Open);
        }

        private void CloseSettingsMenu()
        {
            _settingsMenu.View.Close();
        }
    }
}