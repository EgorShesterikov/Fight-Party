using System;

namespace FightParty.Game.PlayScene
{
    public interface ISelectJoysticks
    {
        event Action SelectedYellowJoystick;
        event Action SelectedBlueJoystick;
    }
}