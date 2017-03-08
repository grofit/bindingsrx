using System;
using BindingsRx.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace BindingsRx.UI
{
    public static class TextExtensions
    {
        public static IDisposable BindTextTo(this Text input, IReactiveProperty<string> property)
        { return GenericBindings.ReactivePropertyBinding(() => input.text, x => input.text = x, property, BindingTypes.OneWay); }

        public static IDisposable BindTextTo(this Text input, Func<string> getter)
        { return GenericBindings.PropertyBinding(() => input.text, x => input.text = x, getter, null, BindingTypes.OneWay); }

        public static IDisposable BindColorTo(this Text input, IReactiveProperty<Color> property, BindingTypes bindingType = BindingTypes.Default)
        { return GenericBindings.ReactivePropertyBinding(() => input.color, x => input.color = x, property, bindingType); }

        public static IDisposable BindColorTo(this Text input, Func<Color> getter, Action<Color> setter, BindingTypes bindingType = BindingTypes.Default)
        { return GenericBindings.PropertyBinding(() => input.color, x => input.color = x, getter, setter, bindingType); }
    }
}