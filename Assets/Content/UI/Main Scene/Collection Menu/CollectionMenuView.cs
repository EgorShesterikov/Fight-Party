using UnityEngine;
using UnityEngine.UI;

namespace FightParty.UI.MainScene
{
    public class CollectionMenuView : WindowBase
    {
        [SerializeField] private Button _leftButton;
        [SerializeField] private Button _selectButton;
        [SerializeField] private Button _rightButton;

        public Button LeftButton => _leftButton;
        public Button RightButton => _rightButton;
        public Button SelectButton => _selectButton;
    }
}
