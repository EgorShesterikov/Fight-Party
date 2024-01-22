using FightParty.Audio;
using FightParty.Save;
using System;

namespace FightParty.Game.PlayScene.Battle
{
    public class BattleResultMenu : IDisposable, IResults
    {
        private const string NameWinSound = "Win";
        private const string NameLoseSound = "Lose";
        private const string NameDrawSound = "Draw";

        public event Action ClickedMenu;

        private BattleResultMenuView _view;

        private GlobalSFXSource _globalAudio;

        private ProgressManager _progressManager;

        public BattleResultMenu(BattleResultMenuView view, GlobalSFXSource globalAudio, ProgressManager progressManager)
        {
            _view = view;

            _view.MenuButton.onClick.AddListener(ClickMenuButton);

            _globalAudio = globalAudio;

            _progressManager = progressManager;
        }

        public void Dispose()
        {
            _view.MenuButton.onClick.RemoveListener(ClickMenuButton);
        }

        public void Win()
        {
            _view.Open();
            _view.SetWinText();

            _view.Audio.PlaySound(NameWinSound);

            ProgressJSON progressJSON = _progressManager.Load();

            progressJSON.BattleVictories++;

            _progressManager.Save(progressJSON);
        }

        public void Lose()
        {
            _view.Open();
            _view.SetLoseText();

            _view.Audio.PlaySound(NameLoseSound);
        }

        public void Draw()
        {
            _view.Open();
            _view.SetDrawText();

            _view.Audio.PlaySound(NameDrawSound);
        }

        private void ClickMenuButton()
        {
            _globalAudio.PlayClick();

            _view.Close();

            ClickedMenu?.Invoke();
        }
    }
}