using System;
using BindingsRx.Filters;
using BindingsRx.Generic;
using BindingsRx.UI;
using UniRx;
using UnityEngine;

namespace BindingsRx.GameObjects
{
    public static class MonobehaviourExtensions
    {
        public static IDisposable BindEnabledTo(this MonoBehaviour input, IReactiveProperty<bool> property, BindingTypes bindingType = BindingTypes.Default, params IFilter<bool>[] filters)
        { return GenericBindings.Bind(() => input.enabled, x => input.enabled = x, property, bindingType, filters); }

        public static IDisposable BindActiveTo(this MonoBehaviour input, Func<bool> getter, Action<bool> setter, BindingTypes bindingType = BindingTypes.Default, params IFilter<bool>[] filters)
        { return GenericBindings.Bind(() => input.enabled, x => input.enabled = x, getter, setter, bindingType, filters); }
    }
}