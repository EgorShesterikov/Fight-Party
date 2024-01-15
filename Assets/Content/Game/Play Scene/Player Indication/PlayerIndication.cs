using System;
using UnityEngine;

namespace FightParty.Game.PlayScene
{
    public class PlayerIndication : IDisposable, IChooserJoysticks, IReaderJoystick
    {
        public event Action SelectedFirst;
        public event Action SelectedSecond;

        public event Action<Vector2> ChangedPosition;
        public event Action EndChangedPosition;

        private VariableJoystick _selectJoystick;

        private PlayerIndicationView _view;

        private ITriggerBall _firstCharacter;
        private ITriggerBall _secondCharacter;

        private int _currentHealFirstCharacter = 3;
        private int _currentHealSecondCharacter = 3;

        public PlayerIndication(PlayerIndicationView view, ITriggerBall firstCharacter, ITriggerBall secondCharacter)
        {
            _view = view;

            _view.FirstJoystick.OnChanged += SelectFirstJoystick;
            _view.SecondJoystick.OnChanged += SelectSecondJoystick;

            _view.FirstJoystick.OnEndChanged += EndChangeJoystick;
            _view.SecondJoystick.OnEndChanged += EndChangeJoystick;

            _firstCharacter = firstCharacter;
            _secondCharacter = secondCharacter;

            _firstCharacter.BallTriggered += TakeDamageFirst;
            _secondCharacter.BallTriggered += TakeDamageSecond;
        }

        public IHidePlayerIndication View => _view;

        public void Dispose()
        {
            _view.FirstJoystick.OnChanged -= SelectFirstJoystick;
            _view.SecondJoystick.OnChanged -= SelectSecondJoystick;

            _view.FirstJoystick.OnEndChanged -= EndChangeJoystick;
            _view.SecondJoystick.OnEndChanged -= EndChangeJoystick;

            _view.FirstJoystick.OnChanged -= ChangeJoystick;
            _view.SecondJoystick.OnChanged -= ChangeJoystick;

            _firstCharacter.BallTriggered -= TakeDamageFirst;
            _secondCharacter.BallTriggered -= TakeDamageSecond;
        }

        private void SelectFirstJoystick()
        {
            SelectedFirst?.Invoke();

            _view.FirstJoystick.OnChanged += ChangeJoystick;

            _selectJoystick = _view.FirstJoystick;
        }
        private void SelectSecondJoystick()
        {
            SelectedSecond?.Invoke();

            _view.SecondJoystick.OnChanged += ChangeJoystick;

            _selectJoystick = _view.SecondJoystick;
        }

        private void ChangeJoystick()
        {
            if(_selectJoystick != null)
                ChangedPosition?.Invoke(_selectJoystick.Direction);
        }

        private void EndChangeJoystick()
        {
            if (_selectJoystick != null)
                EndChangedPosition?.Invoke();
        }

        private void TakeDamageFirst()
        {
            if (_currentHealFirstCharacter <= 0)
                return;

            _currentHealFirstCharacter--;
            _view.ChangeHealFirst(_currentHealFirstCharacter);
        }
        private void TakeDamageSecond()
        {
            if (_currentHealSecondCharacter <= 0)
                return;

            _currentHealSecondCharacter--;
            _view.ChangeHealSecond(_currentHealSecondCharacter);
        }
    }
}