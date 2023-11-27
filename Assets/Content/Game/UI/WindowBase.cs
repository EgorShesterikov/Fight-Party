using UnityEngine;

namespace FightParty.Game
{
    [RequireComponent(typeof(Animator))]
    public abstract class WindowBase : MonoBehaviour, IOpenClose
    {
        [SerializeField] private TypesAnimation startAnimation = TypesAnimation.Open;
        private enum TypesAnimation
        {
            Open = 0,
            OpenAction,
            Close,
            CloseAction
        }

        private Animator _animator;

        public void Open() => _animator.Play(TypesAnimation.OpenAction.ToString());
        public void Close() => _animator.Play(TypesAnimation.CloseAction.ToString());

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _animator.Play(startAnimation.ToString());
        }
    }
}
