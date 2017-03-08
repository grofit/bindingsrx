using System;
using BindingsRx.Generic;
using UniRx;
using UnityEngine.UI;

namespace BindingsRx.UI
{
    public static class InputFieldExtensions
    {
        public static IDisposable BindTextTo(this InputField input, IReactiveProperty<string> property, BindingTypes bindingType = BindingTypes.Default)
        { return GenericBindings.ReactivePropertyBinding(() => input.text, x => input.text = x, property, bindingType); }

        public static IDisposable BindTextTo(this InputField input, Func<string> getter, Action<string> setter, BindingTypes bindingType = BindingTypes.Default)
        { return GenericBindings.PropertyBinding(() => input.text, x => input.text = x, getter, setter, bindingType); }
    }
}
