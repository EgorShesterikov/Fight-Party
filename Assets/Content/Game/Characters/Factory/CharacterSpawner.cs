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
        private Quaternion AngleTowardsInCentrYellow => Quaternion.Euler(0, 135, 0);
        private Quaternion AngleTowardsInCentrBlue => Quaternion.Euler(0, -35, 0);

        public void SpawnYellowCharacterInCentr()
            => _factory.Get(CharacterTypes.Yellow, LeftCentrPosition, AngleTowardsCamera);

        public void SpawnBlueCharacterInCentr()
            => _factory.Get(CharacterTypes.Blue, RightCentrPosition, AngleTowardsCamera);

        public void SpawnYellowCharacterInLeftCorner()
            => _factory.Get(CharacterTypes.Yellow, LeftCornerPosition, AngleTowardsInCentrYellow);

        public void SpawnBlueCharacterInRightCorner()
            => _factory.Get(CharacterTypes.Blue, RightCornerPosition, AngleTowardsInCentrBlue);
    }
}
