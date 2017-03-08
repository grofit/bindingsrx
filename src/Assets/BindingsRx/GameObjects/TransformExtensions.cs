using System;
using BindingsRx.Generic;
using BindingsRx.UI;
using UniRx;
using UnityEngine;

namespace BindingsRx.GameObjects
{
    public static class TransformExtensions
    {
        public static IDisposable BindPositionTo(this Transform input, IReactiveProperty<Vector3> property, BindingTypes bindingType = BindingTypes.Default)
        { return GenericBindings.ReactivePropertyBinding(() => input.position, x => input.transform.position = x, property, bindingType); }

        public static IDisposable BindPositionTo(this Transform input, Func<Vector3> getter, Action<Vector3> setter, BindingTypes bindingType = BindingTypes.Default)
        { return GenericBindings.PropertyBinding(() => input.position, x => input.transform.position = x, getter, setter, bindingType); }

        public static IDisposable BindRotationTo(this Transform input, IReactiveProperty<Quaternion> property, BindingTypes bindingType = BindingTypes.Default)
        { return GenericBindings.ReactivePropertyBinding(() => input.rotation, x => input.transform.rotation = x, property, bindingType); }

        public static IDisposable BindRotationTo(this Transform input, Func<Quaternion> getter, Action<Quaternion> setter, BindingTypes bindingType = BindingTypes.Default)
        { return GenericBindings.PropertyBinding(() => input.rotation, x => input.transform.rotation = x, getter, setter, bindingType); }

        public static IDisposable BindScaleTo(this Transform input, IReactiveProperty<Vector3> property, BindingTypes bindingType = BindingTypes.Default)
        { return GenericBindings.ReactivePropertyBinding(() => input.localScale, x => input.transform.localScale = x, property, bindingType); }

        public static IDisposable BindScaleTo(this Transform input, Func<Vector3> getter, Action<Vector3> setter, BindingTypes bindingType = BindingTypes.Default)
        { return GenericBindings.PropertyBinding(() => input.localScale, x => input.transform.localScale = x, getter, setter, bindingType); }
    }
}