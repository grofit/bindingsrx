using System;
using BindingsRx.Generic;
using BindingsRx.UI;
using UniRx;
using UnityEngine;

namespace BindingsRx.GameObjects
{
    public static class MonobehaviourExtensions
    {
        public static IDisposable BindEnabledTo(this MonoBehaviour input, IReactiveProperty<bool> property, BindingTypes bindingType = BindingTypes.Default)
        { return GenericBindings.ReactivePropertyBinding(() => input.enabled, x => input.enabled = x, property, bindingType); }

        public static IDisposable BindActiveTo(this MonoBehaviour input, Func<bool> getter, Action<bool> setter, BindingTypes bindingType = BindingTypes.Default)
        { return GenericBindings.PropertyBinding(() => input.enabled, x => input.enabled = x, getter, setter, bindingType); }
    }
}