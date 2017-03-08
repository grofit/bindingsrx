using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace BindingsRx.UI
{
    public static class TextExtensions
    {
        public static IDisposable BindTextTo(this Text input, IObservable<string> property)
        {
            return property.DistinctUntilChanged()
                .Subscribe(x => input.text = x);
        }

        public static IDisposable BindTextTo(this Text input, Func<string> getter)
        {
            return Observable.EveryUpdate()
                .Select(x => getter())
                .DistinctUntilChanged()
                .Subscribe(x => input.text = x);
        }
    }
}