using FightParty.Audio;
using FightParty.Save;
using System;

namespace FightParty.Game.PlayScene.Survival
{
    public class SurvivalResultMenu : IDisposable, IResult<int>
    {
        private const string NameResultSound = "Result";

        public event Action ClickedMenu;

        private SurvivalResultMenuView _view;

        private GlobalSFXSource _globalAudio;

        private ProgressManager _progressManager;

        public SurvivalResultMenu(SurvivalResultMenuView view, GlobalSFXSource globalAudio, ProgressManager progressManager)
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

        public void Result(int second)
        {
            _view.Open();

            _view.Audio.PlaySound(NameResultSound);

            _view.SetResult(second);

            ProgressJSON progressJSON = _progressManager.Load();

            if (second > progressJSON.SurvivalTime)
            {
                _view.SetRecord(second);
                progressJSON.SurvivalTime = second;
                _progressManager.Save(progressJSON);
            }
            else
                _view.SetRecord(progressJSON.SurvivalTime);
        }

        private void ClickMenuButton()
        {
            _globalAudio.PlayClick();

            _view.Close();

            ClickedMenu?.Invoke();
        }
    }
}