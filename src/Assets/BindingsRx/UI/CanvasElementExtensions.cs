using System;
using BindingsRx.GameObjects;
using BindingsRx.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace BindingsRx.UI
{
    public static class CanvasElementExtensions
    {
        public static IDisposable BindPositionTo(this ICanvasElement input, IReactiveProperty<Vector3> property, BindingTypes bindingType = BindingTypes.Default)
        { return input.transform.BindPositionTo(property, bindingType); }

        public static IDisposable BindPositionTo(this ICanvasElement input, Func<Vector3> getter, Action<Vector3> setter, BindingTypes bindingType = BindingTypes.Default)
        { return input.transform.BindPositionTo(getter, setter, bindingType); }

        public static IDisposable BindRotationTo(this ICanvasElement input, IReactiveProperty<Quaternion> property, BindingTypes bindingType = BindingTypes.Default)
        { return input.transform.BindRotationTo(property, bindingType); }

        public static IDisposable BindRotationTo(this ICanvasElement input, Func<Quaternion> getter, Action<Quaternion> setter, BindingTypes bindingType = BindingTypes.Default)
        { return input.transform.BindRotationTo(getter, setter, bindingType); }

        public static IDisposable BindScaleTo(this ICanvasElement input, IReactiveProperty<Vector3> property, BindingTypes bindingType = BindingTypes.Default)
        { return input.transform.BindScaleTo(property, bindingType); }

        public static IDisposable BindScaleTo(this ICanvasElement input, Func<Vector3> getter, Action<Vector3> setter, BindingTypes bindingType = BindingTypes.Default)
        { return input.transform.BindScaleTo(getter, setter, bindingType); }
    }
}