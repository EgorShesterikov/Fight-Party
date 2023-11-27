using FightParty.Game.PlayScene;
using System.Collections.Generic;

namespace FightParty.Game
{
    public class CharacterStateMachine : StateMachine
    {
        private CharacterStateMachineData _data;

        private Character _character;
        private IChangeJoystick _changeJoystick;

        public CharacterStateMachine(Character character, IChangeJoystick changeJoystick) 
        {
            _data = new CharacterStateMachineData();

            _character = character;

            _changeJoystick = changeJoystick;

            Init();
        }

        protected override List<IState> CreateStates()
            => new List<IState>()
            {
                new CharacterStay(this, _data, _character),
                new CharacterPreparation(this, _data, _character, _changeJoystick),
                new CharacterJump(this, _data, _character),
                new CharacterDamage(this, _data, _character),
                new CharacterDead(this, _data, _character),
                new CharacterVictory(this, _data, _character)
            };
    }
}