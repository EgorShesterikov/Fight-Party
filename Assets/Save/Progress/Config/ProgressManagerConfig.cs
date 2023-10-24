using UnityEngine;

namespace FightParty.Save
{
    [CreateAssetMenu(fileName = "ProgressManagerConfig", menuName = "Save/ProgressManagerConfig")]
    public class ProgressManagerConfig : BaseSaveConfig
    {
        [SerializeField] private int _defaultBattleRating;
        [SerializeField] private int _defaultSurvivalTime;
        [SerializeField] private int _defaultRingIndex;

        public int DefaultBattleRating => _defaultBattleRating;
        public int DefaultSurvivalTime => _defaultSurvivalTime;
        public int DefaultRingIndex => _defaultRingIndex;
    }
}
