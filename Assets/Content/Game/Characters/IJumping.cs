using System;

namespace FightParty.Game
{
    public interface IJumping
    {
        event Action Jumped;

        void Jump();
    }
}