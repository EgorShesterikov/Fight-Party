using UnityEngine;

namespace FightParty.Game
{
    public class CharacterSpawner
    {
        private const int AngleTowardsCamera = 180;
        private const int AngleTowardsInCentrYellow = 135;
        private const int AngleTowardsInCentrBlue = -35;

        private const float DistanceFromCenter = 4;

        private CharacterFactory _factory;

        public CharacterSpawner(CharacterFactory characterFactory)
            => _factory = characterFactory;

        public void SpawnYellowCharacterInCentr()
            => _factory.Get(CharacterTypes.Yellow, Vector3.zero, Quaternion.Euler(0, AngleTowardsCamera, 0));

        public void SpawnBlueCharacterInCentr()
            => _factory.Get(CharacterTypes.Blue, Vector3.zero, Quaternion.Euler(0, AngleTowardsCamera, 0));

        public void SpawnYellowCharacterInLeftCorner()
            => _factory.Get(CharacterTypes.Yellow, new Vector3(-DistanceFromCenter, 0, DistanceFromCenter), Quaternion.Euler(0, AngleTowardsInCentrYellow, 0));

        public void SpawnBlueCharacterInRightCorner()
            => _factory.Get(CharacterTypes.Blue, new Vector3(DistanceFromCenter, 0, -DistanceFromCenter), Quaternion.Euler(0, AngleTowardsInCentrBlue, 0));
    }
}
