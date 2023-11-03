using UnityEngine;

namespace FightParty.Game
{
    [CreateAssetMenu(fileName = "CharacterConfig", menuName = "Game/CharacterConfig")]
    public class CharacterConfig : ScriptableObject
    {
        [SerializeField] private Character _yellowCharacter;
        [SerializeField] private Character _blueCharacter;

        public Character YellowCharacter => _yellowCharacter;
        public Character BlueCharacter => _blueCharacter;
    }
}
