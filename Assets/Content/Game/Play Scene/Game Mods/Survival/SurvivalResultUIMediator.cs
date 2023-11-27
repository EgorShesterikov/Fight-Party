using FightParty.Game.PlayScene.Survival;
using System;

namespace FightParty.Game.PlayScene.Battle
{
    public class SurvivalResultUIMediator : UIMediator, IDisposable
    {
        private SurvivalResultMenu _resultMenu;

        public void Initialize(SurvivalResultMenu resultMenu)
        {
            _resultMenu = resultMenu;

            _resultMenu.ClickedMenu += GoToMainMenu;
        }

        public void Dispose()
        {
            _resultMenu.ClickedMenu -= GoToMainMenu;
        }

        private void GoToMainMenu()
        {
            SceenFader.Set(ScreenFader.TypeFade.Appear, () =>
            {
                SceneLoader.GoToMainScene();
                SceenFader.Set(ScreenFader.TypeFade.Disappear);
            });
        }
    }
}