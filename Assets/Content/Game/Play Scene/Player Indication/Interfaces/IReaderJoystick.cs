using System;
using UnityEngine;

namespace FightParty.Game.PlayScene
{
    public interface IReaderJoystick
    {
        event Action<Vector2> ChangedPosition;
        event Action EndChangedPosition;
    }
}