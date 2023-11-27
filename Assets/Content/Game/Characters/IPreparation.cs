using System;

namespace FightParty.Game
{
    public interface IPreparation
    {
        event Action Prepared;

        void Preparation();
    }
}