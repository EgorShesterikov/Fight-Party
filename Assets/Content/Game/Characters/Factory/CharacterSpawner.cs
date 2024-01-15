using UnityEngine;

namespace FightParty.Game
{
    public class CharacterSpawner
    {
        private CharacterFactory _factory;

        public CharacterSpawner(CharacterFactory characterFactory)
            => _factory = characterFactory;

        private Vector3 LeftCornerPosition => new Vector3(-4, 0, 4);
        private Vector3 RightCornerPosition => new Vector3(4, 0, -4);

        private Vector3 LeftCentrPosition => new Vector3(-1, 0, 0);
        private Vector3 RightCentrPosition => new Vector3(1, 0, 0);

        private Quaternion AngleTowardsCamera => Quaternion.Euler(0, 180, 0);
        private Quaternion AngleTowardsInCentrFirst => Quaternion.Euler(0, 135, 0);
        private Quaternion AngleTowardsInCentrSecond => Quaternion.Euler(0, -35, 0);

        public void SpawnFirstCharacterInCentr()
            => _factory.Get(CharacterTypes.First, LeftCentrPosition, AngleTowardsCamera);

        public void SpawnSecondCharacterInCentr()
            => _factory.Get(CharacterTypes.Second, RightCentrPosition, AngleTowardsCamera);

        public void SpawnFirstCharacterInLeftCorner()
            => _factory.Get(CharacterTypes.First, LeftCornerPosition, AngleTowardsInCentrFirst);

        public void SpawnSecondCharacterInRightCorner()
            => _factory.Get(CharacterTypes.Second, RightCornerPosition, AngleTowardsInCentrSecond);
    }
}
