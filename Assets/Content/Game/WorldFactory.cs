using Zenject;

namespace FightParty.Game
{
    public abstract class WorldFactory
    {
        protected const float OffsetXPosition = -100f;
        protected const float OffsetYPosition = 1.32f;

        protected DiContainer _container;

        public WorldFactory(DiContainer container)
            => _container = container;
    }
}