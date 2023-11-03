using UnityEngine;

namespace FightParty.Game
{
    [CreateAssetMenu(fileName = "BallsConfig", menuName = "Game/BallsConfig")]
    public class BallsConfig : ScriptableObject
    {
        [SerializeField] private DefaultBall _defaultBall;
        [SerializeField] private DestroyBall _destroyBall;

        public DefaultBall DefaultBall => _defaultBall;
        public DestroyBall DestroyBall => _destroyBall;
    }
}