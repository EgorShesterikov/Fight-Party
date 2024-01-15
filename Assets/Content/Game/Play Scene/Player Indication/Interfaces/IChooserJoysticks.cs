using System;

namespace FightParty.Game.PlayScene
{
    public interface IChooserJoysticks
    {
        event Action SelectedFirst;
        event Action SelectedSecond;
    }
}