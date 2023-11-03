using System;
using UnityEngine;
using Zenject;

namespace FightParty.Game
{
    public class BallFactory : WorldFactory
    {
        private BallsConfig _config;

        public BallFactory(DiContainer container, BallsConfig ballsConfig) : base(container)
            => _config = ballsConfig;

        public Ball Get(BallTypes type, Vector3 position)
        {
            position.x += OffsetXPosition;
            position.y += OffsetYPosition;

            switch (type)
            {
                case BallTypes.Default:
                    DefaultBall defaultBall = _container.InstantiatePrefabForComponent<DefaultBall>(_config.DefaultBall,
                        position, Quaternion.identity, null);
                    _container.BindInstance(defaultBall);
                    return defaultBall;

                case BallTypes.Destroy:
                    DestroyBall destroyBall = _container.InstantiatePrefabForComponent<DestroyBall>(_config.DestroyBall,
                        position, Quaternion.identity, null);
                    _container.BindInstance(destroyBall);
                    return destroyBall;

                default:
                    throw new NotImplementedException();
            }
        }
    }
}