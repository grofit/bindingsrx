using System;
using BindingsRx.Filters;
using BindingsRx.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace BindingsRx.UI
{
    public static class TextExtensions
    {
        public static IDisposable BindTextTo(this Text input, IReactiveProperty<string> property, params IFilter<string>[] filters)
        { return GenericBindings.Bind(() => input.text, x => input.text = x, property, BindingTypes.OneWay, filters).AddTo(input); }

        public static IDisposable BindTextTo(this Text input, Func<string> getter, params IFilter<string>[] filters)
        { return GenericBindings.Bind(() => input.text, x => input.text = x, getter, null, BindingTypes.OneWay, filters).AddTo(input); }

        public static IDisposable BindColorTo(this Text input, IReactiveProperty<Color> property, BindingTypes bindingType = BindingTypes.Default, params IFilter<Color>[] filters)
        { return GenericBindings.Bind(() => input.color, x => input.color = x, property, bindingType, filters).AddTo(input); }

        public static IDisposable BindColorTo(this Text input, Func<Color> getter, Action<Color> setter, BindingTypes bindingType = BindingTypes.Default, params IFilter<Color>[] filters)
        { return GenericBindings.Bind(() => input.color, x => input.color = x, getter, setter, bindingType, filters).AddTo(input); }
    }
}