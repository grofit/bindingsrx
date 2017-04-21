using System;
using UniRx;
using UnityEngine;

namespace BindingsRx.Overrides
{
    public static class ObservableProxy
    {
        private static readonly Subject<long> UpdateSubject = new Subject<long>();

        public static void TriggerArtificialUpdate()
        { UpdateSubject.OnNext(0); }

        public static IObservable<long> EveryUpdate()
        {
#if UNITY_EDITOR
            return !Application.isPlaying ? UpdateSubject : Observable.EveryUpdate();
#else
            return Observable.EveryUpdate();
#endif
        }
    }
}