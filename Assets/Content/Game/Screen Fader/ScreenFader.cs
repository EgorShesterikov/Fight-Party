using System;
using System.Collections;
using UnityEngine;

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

        private CanvasGroup _canvasGroup;
        private Coroutine _coroutine;

        public void Set(TypeFade typeFade, Action callBack = null, bool isUnscaledTime = false)
        {
            if (_coroutine != null) StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(FadeProcess(typeFade, callBack, isUnscaledTime));
        }

        private IEnumerator FadeProcess(TypeFade typeFade, Action callBack, bool isUnscaledTime)
        {
            _canvasGroup.blocksRaycasts = Convert.ToBoolean(typeFade);

            float targetAlpha = (int)typeFade;

            float step = 0.05f;

            for (float lerp = 0; lerp < 1; lerp += step)
            {
                _canvasGroup.alpha = Mathf.Lerp(_canvasGroup.alpha, targetAlpha, lerp);

                if (isUnscaledTime)
                    yield return new WaitForSecondsRealtime(TickDelay);
                else
                    yield return new WaitForSeconds(TickDelay);
            }

            _canvasGroup.alpha = targetAlpha;

            callBack?.Invoke();
        }

        private void Awake()
            => _canvasGroup = GetComponent<CanvasGroup>();
    }
}