using System;
using BindingsRx.Generic;
using BindingsRx.UI;
using UniRx;
using UnityEngine;

namespace BindingsRx.GameObjects
{
    public static class GameObjectExtensions
    {
        public static IDisposable BindActiveTo(this GameObject input, IReactiveProperty<bool> property, BindingTypes bindingType = BindingTypes.Default)
        { return GenericBindings.ReactivePropertyBinding(() => input.activeSelf, input.SetActive, property, bindingType); }

        public static IDisposable BindActiveTo(this GameObject input, Func<bool> getter, Action<bool> setter, BindingTypes bindingType = BindingTypes.Default)
        { return GenericBindings.PropertyBinding(() => input.activeSelf, input.SetActive, getter, setter, bindingType); }

        public static IDisposable BindLayerTo(this GameObject input, IReactiveProperty<int> property, BindingTypes bindingType = BindingTypes.Default)
        { return GenericBindings.ReactivePropertyBinding(() => input.layer, x => input.layer = x, property, bindingType); }

        public static IDisposable BindLayerTo(this GameObject input, Func<int> getter, Action<int> setter, BindingTypes bindingType = BindingTypes.Default)
        { return GenericBindings.PropertyBinding(() => input.layer, x => input.layer = x, getter, setter, bindingType); }

        public static IDisposable BindLayerTo(this GameObject input, IReactiveProperty<LayerMask> property, BindingTypes bindingType = BindingTypes.Default)
        { return GenericBindings.ReactivePropertyBinding(() => input.layer, x => input.layer = x, property, bindingType); }

        public static IDisposable BindLayerTo(this GameObject input, Func<LayerMask> getter, Action<LayerMask> setter, BindingTypes bindingType = BindingTypes.Default)
        { return GenericBindings.PropertyBinding(() => input.layer, x => input.layer = x, getter, setter, bindingType); }

        public static IDisposable BindNameTo(this GameObject input, IReactiveProperty<string> property, BindingTypes bindingType = BindingTypes.Default)
        { return GenericBindings.ReactivePropertyBinding(() => input.name, x => input.name = x, property, bindingType); }

        public static IDisposable BindNameTo(this GameObject input, Func<string> getter, Action<string> setter, BindingTypes bindingType = BindingTypes.Default)
        { return GenericBindings.PropertyBinding(() => input.name, x => input.name = x, getter, setter, bindingType); }

        public static IDisposable BindTagTo(this GameObject input, IReactiveProperty<string> property, BindingTypes bindingType = BindingTypes.Default)
        { return GenericBindings.ReactivePropertyBinding(() => input.tag, x => input.tag = x, property, bindingType); }

        public static IDisposable BindTagTo(this GameObject input, Func<string> getter, Action<string> setter, BindingTypes bindingType = BindingTypes.Default)
        { return GenericBindings.PropertyBinding(() => input.tag, x => input.tag = x, getter, setter, bindingType); }
    }
}