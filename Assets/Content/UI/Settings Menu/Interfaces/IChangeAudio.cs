using System;

namespace FightParty.UI
{
    public interface IChangeAudio
    {
        event Action<float> ChangedMusic;
        event Action<float> ChangedSound;
    }
}
