using FightParty.Audio;
using FightParty.Save;
using I2.Loc;
using System;
using System.Diagnostics;
using Zenject;

namespace FightParty.UI.MainScene
{
    public class PlayMenu : IDisposable, IInitializable
    {
        public event Action ClickedBattle;
        public event Action ClickedBack;
        public event Action ClickedSurvival;

        private PlayMenuView _view;

        private GlobalSFXSource _audio;

        private ILoad<ProgressJSON> _progressManager;

        public PlayMenu(PlayMenuView view, GlobalSFXSource audio, ILoad<ProgressJSON> progressManager)
        {
            _view = view;

            _view.BattleButton.onClick.AddListener(ClickBattleButton);
            _view.BackButton.onClick.AddListener(ClickBackButton);
            _view.SurvivalButton.onClick.AddListener(ClickSurvivalButton);

            _audio = audio;

            _progressManager = progressManager;
        }

        public PlayMenuView View => _view;

        public void Dispose()
        {
            _view.BattleButton.onClick.RemoveAllListeners();
            _view.BackButton.onClick.RemoveAllListeners();
            _view.SurvivalButton.onClick.RemoveAllListeners();
        }

        public void Initialize()
        {
            ProgressJSON progressJSON = _progressManager.Load();

            _view.ChangeBattleRating(progressJSON.BattleRating);
            _view.ChangeSurvivalTime(progressJSON.SurvivalTime);
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
