using FightParty.Audio;
using System;
using UnityEngine;

namespace FightParty.Game.MainScene
{
    public partial class CollectionMenu : IDisposable
    {
        public event Action SelectedRing;
        public event Action<int> ChangedRing;

        private int _currentRing = 0;

        private CollectionMenuView _view;

        private GlobalSFXSource _audio;

        public CollectionMenu(CollectionMenuView view, GlobalSFXSource audio)
        {
            _view = view;

            _view.LeftButton.onClick.AddListener(SwitchRingToLeft);
            _view.SelectButton.onClick.AddListener(SelectRing);
            _view.RightButton.onClick.AddListener(SwitchRingToRight);

            _audio = audio;
        }

        public CollectionMenuView View => _view;

        public void Dispose()
        {
            _view.LeftButton.onClick.RemoveAllListeners();
            _view.SelectButton.onClick.RemoveAllListeners();
            _view.RightButton.onClick.RemoveAllListeners();
        }

        private void SwitchRingToLeft()
        {
            _audio.PlayClick();

            Debug.Log("Перелистываем влево!");

            ChangedRing?.Invoke(_currentRing);
        }

        private void SwitchRingToRight()
        {
            _audio.PlayClick();

            Debug.Log("Перелистываем вправо!");

            ChangedRing?.Invoke(_currentRing);
        }

        private void SelectRing()
        {
            _audio.PlayClick();

            Debug.Log("Проверка, можно ли выбрать");

            SelectedRing?.Invoke();
        }
    }
}
