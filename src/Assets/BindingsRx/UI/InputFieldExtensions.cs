using System;
using BindingsRx.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace BindingsRx.UI
{
    public static class InputFieldExtensions
    {
        public static IDisposable BindTextTo(this InputField input, IReactiveProperty<string> property, BindingTypes bindingType = BindingTypes.Default)
        { return GenericBindings.ReactivePropertyBinding(() => input.text, x => input.text = x, property, bindingType); }

        public static IDisposable BindTextTo(this InputField input, Func<string> getter, Action<string> setter, BindingTypes bindingType = BindingTypes.Default)
        { return GenericBindings.PropertyBinding(() => input.text, x => input.text = x, getter, setter, bindingType); }

        public static IDisposable BindCaretColorTo(this InputField input, IReactiveProperty<Color> property, BindingTypes bindingType = BindingTypes.Default)
        { return GenericBindings.ReactivePropertyBinding(() => input.caretColor, x => input.caretColor = x, property, bindingType); }

        public static IDisposable BindCaretColorTo(this InputField input, Func<Color> getter, Action<Color> setter, BindingTypes bindingType = BindingTypes.Default)
        { return GenericBindings.PropertyBinding(() => input.caretColor, x => input.caretColor = x, getter, setter, bindingType); }

        public static IDisposable BindColorTo(this InputField input, IReactiveProperty<Color> property, BindingTypes bindingType = BindingTypes.Default)
        {
            var textChild = input.GetComponentInChildren<Text>();
            return textChild.BindColorTo(property, bindingType);
        }

        public static IDisposable BindColorTo(this InputField input, Func<Color> getter, Action<Color> setter, BindingTypes bindingType = BindingTypes.Default)
        {
            var textChild = input.GetComponentInChildren<Text>();
            return textChild.BindColorTo(getter, setter, bindingType);
        }
    }
}
