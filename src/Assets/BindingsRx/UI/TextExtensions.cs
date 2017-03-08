using System;
using BindingsRx.Generic;
using UniRx;
using UnityEngine.UI;

namespace BindingsRx.UI
{
    public static class TextExtensions
    {
        public static IDisposable BindTextTo(this Text input, IReactiveProperty<string> property)
        { return GenericBindings.ReactivePropertyBinding(() => input.text, x => input.text = x, property, BindingTypes.OneWay); }

        public static IDisposable BindTextTo(this Text input, Func<string> getter)
        { return GenericBindings.PropertyBinding(() => input.text, x => input.text = x, getter, null, BindingTypes.OneWay); }
    }
}