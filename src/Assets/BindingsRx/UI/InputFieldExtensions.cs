using System;
using BindingsRx.Filters;
using BindingsRx.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace BindingsRx.UI
{
    public static class InputFieldExtensions
    {
        public static IDisposable BindTextTo(this InputField input, IReactiveProperty<string> property, BindingTypes bindingType = BindingTypes.Default, params IFilter<string>[] filters)
        { return GenericBindings.Bind(() => input.text, x => input.text = x, property, bindingType, filters); }

        public static IDisposable BindTextTo(this InputField input, Func<string> getter, Action<string> setter, BindingTypes bindingType = BindingTypes.Default, params IFilter<string>[] filters)
        { return GenericBindings.Bind(() => input.text, x => input.text = x, getter, setter, bindingType, filters); }

        public static IDisposable BindCaretColorTo(this InputField input, IReactiveProperty<Color> property, BindingTypes bindingType = BindingTypes.Default, params IFilter<Color>[] filters)
        { return GenericBindings.Bind(() => input.caretColor, x => input.caretColor = x, property, bindingType, filters); }

        public static IDisposable BindCaretColorTo(this InputField input, Func<Color> getter, Action<Color> setter, BindingTypes bindingType = BindingTypes.Default, params IFilter<Color>[] filters)
        { return GenericBindings.Bind(() => input.caretColor, x => input.caretColor = x, getter, setter, bindingType, filters); }

        public static IDisposable BindColorTo(this InputField input, IReactiveProperty<Color> property, BindingTypes bindingType = BindingTypes.Default, params IFilter<Color>[] filters)
        {
            var textChild = input.GetComponentInChildren<Text>();
            return textChild.BindColorTo(property, bindingType, filters);
        }

        public static IDisposable BindColorTo(this InputField input, Func<Color> getter, Action<Color> setter, BindingTypes bindingType = BindingTypes.Default, params IFilter<Color>[] filters)
        {
            var textChild = input.GetComponentInChildren<Text>();
            return textChild.BindColorTo(getter, setter, bindingType, filters);
        }
    }
}
