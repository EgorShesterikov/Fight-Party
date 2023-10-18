using System;
using UnityEngine;

namespace FightParty.UI.MainScene
{
    public partial class CollectionMenu : IDisposable
    {
        public event Action SelectedRing;
        public event Action<int> ChangedRing;

        private int _currentRing = 0;

        private CollectionMenuView _view;

        public CollectionMenu(CollectionMenuView view)
        {
            _view = view;

            _view.LeftButton.onClick.AddListener(() => SwitchRingToLeft());
            _view.SelectButton.onClick.AddListener(() => SelectRing());
            _view.RightButton.onClick.AddListener(() => SwitchRingToRight());
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
            Debug.Log("Перелистываем влево!");

            ChangedRing?.Invoke(_currentRing);
        }

        private void SwitchRingToRight()
        {
            Debug.Log("Перелистываем вправо!");

            ChangedRing?.Invoke(_currentRing);
        }

        private void SelectRing()
        {
            Debug.Log("Проверка, можно ли выбрать");

            SelectedRing?.Invoke();
        }
    }
}
