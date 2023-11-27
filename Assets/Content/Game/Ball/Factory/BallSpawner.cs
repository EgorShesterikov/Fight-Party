using UnityEngine;

namespace FightParty.Game
{
    public class BallSpawner
    {
        private const float MaxSkyHeight = 10f;
        private const float RingSideLenght = 4.5f;

        private BallFactory _ballFactory;

        public BallSpawner(BallFactory ballFactory)
            => _ballFactory = ballFactory;

        public void SpawnDefaultBallInCenter()
            => _ballFactory.Get(BallTypes.Default, Vector3.up);

        public void SpawnDestroyBallInSky()
            => _ballFactory.Get(BallTypes.Destroy, new Vector3(RandomPosInRing(), MaxSkyHeight, RandomPosInRing()));

        private float RandomPosInRing()
            => Random.Range(-RingSideLenght, RingSideLenght);
    }
}