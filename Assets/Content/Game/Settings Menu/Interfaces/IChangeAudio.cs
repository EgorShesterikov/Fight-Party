using System;

namespace FightParty.Game
{
    public interface IChangeAudio
    {
        event Action<float> ChangedMusic;
        event Action<float> ChangedSound;
    }
}
