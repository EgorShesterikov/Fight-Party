using System;

namespace FightParty.Game
{
    public interface ITriggerBall
    {
        event Action BallTriggered;
    }
}