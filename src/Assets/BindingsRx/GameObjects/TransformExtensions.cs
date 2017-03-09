using System;
using BindingsRx.Filters;
using BindingsRx.Generic;
using BindingsRx.UI;
using UniRx;
using UnityEngine;

namespace BindingsRx.GameObjects
{
    public static class TransformExtensions
    {
        public static IDisposable BindPositionTo(this Transform input, IReactiveProperty<Vector3> property, BindingTypes bindingType = BindingTypes.Default, params IFilter<Vector3>[] filters)
        { return GenericBindings.Bind(() => input.position, x => input.transform.position = x, property, bindingType, filters); }

        public static IDisposable BindPositionTo(this Transform input, Func<Vector3> getter, Action<Vector3> setter, BindingTypes bindingType = BindingTypes.Default, params IFilter<Vector3>[] filters)
        { return GenericBindings.Bind(() => input.position, x => input.transform.position = x, getter, setter, bindingType, filters); }

        public static IDisposable BindRotationTo(this Transform input, IReactiveProperty<Quaternion> property, BindingTypes bindingType = BindingTypes.Default, params IFilter<Quaternion>[] filters)
        { return GenericBindings.Bind(() => input.rotation, x => input.transform.rotation = x, property, bindingType, filters); }

        public static IDisposable BindRotationTo(this Transform input, Func<Quaternion> getter, Action<Quaternion> setter, BindingTypes bindingType = BindingTypes.Default, params IFilter<Quaternion>[] filters)
        { return GenericBindings.Bind(() => input.rotation, x => input.transform.rotation = x, getter, setter, bindingType, filters); }

        public static IDisposable BindScaleTo(this Transform input, IReactiveProperty<Vector3> property, BindingTypes bindingType = BindingTypes.Default, params IFilter<Vector3>[] filters)
        { return GenericBindings.Bind(() => input.localScale, x => input.transform.localScale = x, property, bindingType, filters); }

        public static IDisposable BindScaleTo(this Transform input, Func<Vector3> getter, Action<Vector3> setter, BindingTypes bindingType = BindingTypes.Default, params IFilter<Vector3>[] filters)
        { return GenericBindings.Bind(() => input.localScale, x => input.transform.localScale = x, getter, setter, bindingType, filters); }
    }
}