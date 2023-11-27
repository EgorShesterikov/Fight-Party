using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FightParty.Game.MainScene
{
    public class CollectionMenuView : WindowBase
    {
        [SerializeField] private Button _leftButton;
        [SerializeField] private Button _selectButton;
        [SerializeField] private Button _rightButton;

        [Space]
        [SerializeField] private GameObject _lockPanel;
        [SerializeField] private TextMeshProUGUI _lockText;

        public Button LeftButton => _leftButton;
        public Button RightButton => _rightButton;
        public Button SelectButton => _selectButton;

        public void OpenLockPanel(string text)
        {
            _lockPanel.SetActive(true);
            _lockText.text = text;
        }

        public void CloseLockPanel()
        {
            _lockPanel.SetActive(false);
        }
    }
}
