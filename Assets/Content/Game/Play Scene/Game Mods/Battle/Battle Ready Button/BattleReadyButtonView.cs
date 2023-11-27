using UnityEngine;
using UnityEngine.UI;

namespace FightParty.Game.PlayScene.Battle
{
    public class BattleReadyButtonView : WindowBase
    {
        [SerializeField] private Button _readyButton;

        public Button ReadyButton => _readyButton;
    }
}
