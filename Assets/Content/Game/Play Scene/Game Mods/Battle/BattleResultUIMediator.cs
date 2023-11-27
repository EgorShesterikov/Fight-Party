using System;

namespace FightParty.Game.PlayScene.Battle
{
    public class BattleResultUIMediator : UIMediator, IDisposable
    {
        private BattleResultMenu _resultMenu;

        public void Initialize(BattleResultMenu resultMenu)
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