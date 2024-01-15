using UnityEngine;

namespace FightParty.Game
{
    [CreateAssetMenu(fileName = "CharacterConfig", menuName = "Game/CharacterConfig")]
    public class CharacterConfig : ScriptableObject
    {
        [SerializeField] private Character _firstCharacter;
        [SerializeField] private Character _secondCharacter;

        public Character FirstCharacter => _firstCharacter;
        public Character SecondCharacter => _secondCharacter;
    }
}
