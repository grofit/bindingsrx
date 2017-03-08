using System;
using BindingsRx.Generic;
using BindingsRx.UI;
using UniRx;
using UnityEngine;

namespace BindingsRx.GameObjects
{
    public static class RectTransformExtensions
    {
        public static IDisposable BindPositionTo(this RectTransform input, IReactiveProperty<Vector3> property, BindingTypes bindingType = BindingTypes.Default)
        { return GenericBindings.ReactivePropertyBinding(() => input.position, x => input.transform.position = x, property, bindingType); }

        public static IDisposable BindPositionTo(this RectTransform input, Func<Vector3> getter, Action<Vector3> setter, BindingTypes bindingType = BindingTypes.Default)
        { return GenericBindings.PropertyBinding(() => input.position, x => input.transform.position = x, getter, setter, bindingType); }

        public static IDisposable BindRotationTo(this RectTransform input, IReactiveProperty<Quaternion> property, BindingTypes bindingType = BindingTypes.Default)
        { return GenericBindings.ReactivePropertyBinding(() => input.rotation, x => input.transform.rotation = x, property, bindingType); }

        public static IDisposable BindRotationTo(this RectTransform input, Func<Quaternion> getter, Action<Quaternion> setter, BindingTypes bindingType = BindingTypes.Default)
        { return GenericBindings.PropertyBinding(() => input.rotation, x => input.transform.rotation = x, getter, setter, bindingType); }

        public static IDisposable BindScaleTo(this RectTransform input, IReactiveProperty<Vector3> property, BindingTypes bindingType = BindingTypes.Default)
        { return GenericBindings.ReactivePropertyBinding(() => input.localScale, x => input.transform.localScale = x, property, bindingType); }

        public static IDisposable BindScaleTo(this RectTransform input, Func<Vector3> getter, Action<Vector3> setter, BindingTypes bindingType = BindingTypes.Default)
        { return GenericBindings.PropertyBinding(() => input.localScale, x => input.transform.localScale = x, getter, setter, bindingType); }
    }
}