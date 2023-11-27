using System;

namespace FightParty.Game
{
    public interface IDancing
    {
        event Action Danced;

        void Dance();
    }
}