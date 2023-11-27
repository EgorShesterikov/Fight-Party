using UnityEngine;
using TMPro;

namespace FightParty.Game.PlayScene.Survival
{
    public class SurvivalTimeIndicationView : WindowBase
    {
        [SerializeField] private TextMeshProUGUI _timeText;

        public void SetTime(int second)
            => _timeText.text = SecondConverter.ConvertSecondInTimeFormat(second);
    }
}