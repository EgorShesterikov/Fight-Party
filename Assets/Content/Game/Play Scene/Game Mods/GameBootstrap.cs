using UnityEngine;

namespace FightParty.Game
{
    public abstract class GameBootstrap : MonoBehaviour
    {
        protected abstract void Binding();

        private void Awake() => Binding();
    }
}
