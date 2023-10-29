using System;
using System.Collections;
using UnityEngine;

namespace FightParty
{
    public class CallBackTimer
    {
        private MonoBehaviour _context;

        public CallBackTimer(MonoBehaviour context)
            => _context = context;

        public void Play(float time, Action callBack, bool isUnscaledTime = false) => _context.StartCoroutine(TimeProcess(time, callBack, isUnscaledTime));

        private IEnumerator TimeProcess(float time, Action callBack, bool isUnscaledTime)
        {
            if (isUnscaledTime)
                yield return new WaitForSecondsRealtime(time);
            else
                yield return new WaitForSeconds(time);

            callBack?.Invoke();
        }
    }
}