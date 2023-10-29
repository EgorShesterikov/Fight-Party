using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace FightParty.Game
{
    [RequireComponent(typeof(Canvas))]
    public class ScreenFader : MonoBehaviour
    {
        public enum TypeFade
        {
            Disappear = 0,
            Appear
        }

        private const float TickDelay = 0.05f;

        [SerializeField] private Image _fadeImage;
        private Coroutine _coroutine;

        private Color _color;

        public void Set(TypeFade typeFade, Action callBack = null, bool isUnscaledTime = false)
        {
            if (_coroutine != null) StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(FadeProcess(typeFade, callBack, isUnscaledTime));
        }

        private IEnumerator FadeProcess(TypeFade typeFade, Action callBack, bool isUnscaledTime)
        {
            _fadeImage.raycastTarget = Convert.ToBoolean(typeFade);

            Color targetColor = new Color(_color.r, _color.g, _color.b, (int)typeFade);

            if (targetColor != _fadeImage.color)
            {
                float step = 0.05f;

                for (float lerp = 0; lerp < 1; lerp += step)
                {
                    _fadeImage.color = Color.Lerp(_fadeImage.color, targetColor, lerp);

                    if (isUnscaledTime)
                        yield return new WaitForSecondsRealtime(TickDelay);
                    else
                        yield return new WaitForSeconds(TickDelay);
                }

                _fadeImage.color = targetColor;
            }

            callBack?.Invoke();
        }

        private void Awake()
            => _color = _fadeImage.color;
    }
}