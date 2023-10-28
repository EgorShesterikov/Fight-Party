using UnityEngine;
using UnityEngine.UI;

namespace FightParty.UI.PlayScene
{
    public class ExitMenuView : WindowBase
    {
        [SerializeField] private Button _noExitButton;
        [SerializeField] private Button _yesExitButton;

        public Button NoExitButton => _noExitButton;
        public Button YesExitButton => _yesExitButton;
    }
}
