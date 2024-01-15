using UnityEngine;
using System;
using Zenject;

namespace FightParty.Game
{
    public class CharacterFactory : WorldFactory
    {
        private CharacterConfig _config;

        public CharacterFactory(DiContainer container, CharacterConfig config) : base(container)
            => _config = config;

        public Character Get(CharacterTypes characterTypes, Vector3 position, Quaternion rotation)
        {
            position.x += OffsetXPosition;
            position.y += OffsetYPosition;

            switch(characterTypes)
            {
                case CharacterTypes.First:
                    Character firstCharacter = Container.InstantiatePrefabForComponent<Character>(_config.FirstCharacter, position, rotation, null);
                    Container.BindInstance(firstCharacter);
                    return firstCharacter;

                case CharacterTypes.Second:
                    Character secondCharacter = Container.InstantiatePrefabForComponent<Character>(_config.SecondCharacter, position, rotation, null);
                    Container.BindInstance(secondCharacter);
                    return secondCharacter;

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
