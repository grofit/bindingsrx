using System;
using BindingsRx.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace BindingsRx.UI
{
    public static class CanvasElementExtensions
    {
        public static IDisposable BindPositionTo(this ICanvasElement input, IReactiveProperty<Vector3> property, BindingTypes bindingType = BindingTypes.Default)
        { return GenericBindings.ReactivePropertyBinding(() => input.transform.position, x => input.transform.position = x, property, bindingType); }

        public static IDisposable BindPositionTo(this ICanvasElement input, Func<Vector3> getter, Action<Vector3> setter, BindingTypes bindingType = BindingTypes.Default)
        { return GenericBindings.PropertyBinding(() => input.transform.position, x => input.transform.position = x, getter, setter, bindingType); }

        public static IDisposable BindRotationTo(this ICanvasElement input, IReactiveProperty<Quaternion> property, BindingTypes bindingType = BindingTypes.Default)
        { return GenericBindings.ReactivePropertyBinding(() => input.transform.rotation, x => input.transform.rotation = x, property, bindingType); }

        public static IDisposable BindRotationTo(this ICanvasElement input, Func<Quaternion> getter, Action<Quaternion> setter, BindingTypes bindingType = BindingTypes.Default)
        { return GenericBindings.PropertyBinding(() => input.transform.rotation, x => input.transform.rotation = x, getter, setter, bindingType); }
    }
}