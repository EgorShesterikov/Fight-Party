using UnityEngine;
using UnityEngine.UI;

namespace FightParty.UI.MainScene
{
    public class PlayMenuView : WindowBase
    {
        [SerializeField] private Button _battleButton;
        [SerializeField] private Button _backButton;
        [SerializeField] private Button _survivalButton;

        public Button BattleButton => _battleButton;
        public Button BackButton => _backButton;
        public Button SurvivalButton => _survivalButton;
    }
}
