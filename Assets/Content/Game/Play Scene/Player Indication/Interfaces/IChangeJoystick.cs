using System;
using UnityEngine;

namespace FightParty.Game.PlayScene
{
    public interface IChangeJoystick
    {
        event Action<Vector2> ChangedJoystick;
        event Action EndChangedJoystick;
    }
}