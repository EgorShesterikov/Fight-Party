using System.Collections.Generic;
using UnityEngine;

namespace FightParty.Game.PlayScene
{
    public class PlayerIndicationView : WindowBase, IHidePlayerIndication
    {
        [SerializeField] private GameObject _firstIndication;
        [SerializeField] private GameObject _secondIndication;

        [Space]
        [SerializeField] private VariableJoystick _firstJoystick;
        [SerializeField] private VariableJoystick _secondJoystick;

        [Space]
        [SerializeField] private List<GameObject> _firstHeals;
        [SerializeField] private List<GameObject> _secondHeals;

        public VariableJoystick FirstJoystick => _firstJoystick;
        public VariableJoystick SecondJoystick => _secondJoystick;

        public void SetActivFirstJoystick(bool value)
            => _firstJoystick.gameObject.SetActive(value);
        public void SetActivSecondJoystick(bool value)
            => _secondJoystick.gameObject.SetActive(value);

        public void ChangeHealFirst(int value)
            => _firstHeals[value].gameObject.SetActive(false);
        public void ChangeHealSecond(int value)
            => _secondHeals[value].gameObject.SetActive(false);

        public void SetActivFirstIndication(bool value)
            => _firstIndication.SetActive(value);

        public void SetActivSecondIndication(bool value)
            => _secondIndication.SetActive(value);

        public void SetIneterctableFirstJoystick(bool value)
            => _firstJoystick.IsInterectable(value);

        public void SetIneterctableSecondJoystick(bool value)
            => _secondJoystick.IsInterectable(value);
    }
}