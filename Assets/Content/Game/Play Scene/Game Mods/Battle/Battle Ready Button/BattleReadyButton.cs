using FightParty.Audio;
using System;

namespace FightParty.Game.PlayScene.Battle
{
    public class BattleReadyButton : IDisposable
    {
        public event Action OnClickedReady;

        private BattleReadyButtonView _view;

        private GlobalSFXSource _audio;

        public BattleReadyButton(BattleReadyButtonView view, GlobalSFXSource audio)
        {
            _view = view;

            _audio = audio;

            _view.ReadyButton.onClick.AddListener(ClickReadyButton);
        }

        public IOpenClose View => _view;

        private void ClickReadyButton()
        {
            _audio.PlayClick();

            OnClickedReady?.Invoke();
        }

        public void Dispose()
            => _view.ReadyButton.onClick.RemoveListener(ClickReadyButton);
    }
}
