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
                case CharacterTypes.Yellow:
                    Character yellowCharacter = _container.InstantiatePrefabForComponent<Character>(_config.YellowCharacter, position, rotation, null);
                    _container.BindInstance(yellowCharacter);
                    return yellowCharacter;

                case CharacterTypes.Blue:
                    Character blueCharacter = _container.InstantiatePrefabForComponent<Character>(_config.BlueCharacter, position, rotation, null);
                    _container.BindInstance(blueCharacter);
                    return blueCharacter;

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
