using System;
using UnityEngine;
using Zenject;

namespace FightParty.Game
{
    public class BallFactory : WorldFactory
    {
        private const float OffsetBallCentrPosition = 0.8f;

        private BallsConfig _config;

        public BallFactory(DiContainer container, BallsConfig ballsConfig) : base(container)
            => _config = ballsConfig;

        public Ball Get(BallTypes type, Vector3 position)
        {
            position.x += OffsetXPosition;
            position.y += OffsetYPosition;

            position.y += OffsetBallCentrPosition;

            switch (type)
            {
                case BallTypes.Default:
                    DefaultBall defaultBall = Container.InstantiatePrefabForComponent<DefaultBall>(_config.DefaultBall,
                        position, Quaternion.identity, null);
                    Container.BindInstance(defaultBall);
                    return defaultBall;

                case BallTypes.Destroy:
                    DestroyBall destroyBall = Container.InstantiatePrefabForComponent<DestroyBall>(_config.DestroyBall,
                        position, Quaternion.identity, null);
                    Container.BindInstance(destroyBall);
                    return destroyBall;

                default:
                    throw new NotImplementedException();
            }
        }
    }
}