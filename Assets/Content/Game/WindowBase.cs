using System.Collections;
using UnityEngine;

namespace FightParty.Game
{
    [RequireComponent(typeof(Animator))]
    public abstract class WindowBase : MonoBehaviour
    {
        [SerializeField] private TypesAnimation startAnimation = TypesAnimation.Open;
        private enum TypesAnimation
        {
            Open = 0,
            OpenAction,
            Close,
            CloseAction
        }

        private RectTransform _rectTransform;

        private Animator _animator;

        public void Open() => _animator.Play(TypesAnimation.OpenAction.ToString());
        public void Close() => _animator.Play(TypesAnimation.CloseAction.ToString());

        public void SetDefaultPos()
        {
            _rectTransform.anchoredPosition = Vector3.zero;
            _rectTransform.sizeDelta = Vector3.zero;
        }

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();

            _animator = GetComponent<Animator>();
            _animator.Play(startAnimation.ToString());
        }
    }
}
