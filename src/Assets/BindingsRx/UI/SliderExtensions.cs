using System;
using BindingsRx.Exceptions;
using BindingsRx.Generic;
using UniRx;
using UnityEngine.UI;

namespace BindingsRx.UI
{
    public static class SliderExtensions
    {
        public static IDisposable BindValueTo(this Slider input, IReactiveProperty<float> property, BindingTypes bindingType = BindingTypes.Default)
        { return GenericBindings.ReactivePropertyBinding(() => input.OnValueChangedAsObservable(), x => input.maxValue = x, property, bindingType); }

        public static IDisposable BindValueTo(this Slider input, Func<float> getter, Action<float> setter, BindingTypes bindingType = BindingTypes.Default)
        { return GenericBindings.PropertyBinding(() => input.OnValueChangedAsObservable(), x => input.maxValue = x, getter, setter, bindingType); }

        public static IDisposable BindMaxValueTo(this Slider input, IReactiveProperty<float> property, BindingTypes bindingType = BindingTypes.Default)
        { return GenericBindings.ReactivePropertyBinding(() => input.maxValue, x => input.maxValue = x, property, bindingType); }

        public static IDisposable BindMaxValueTo(this Slider input, Func<float> getter, Action<float> setter, BindingTypes bindingType = BindingTypes.Default)
        { return GenericBindings.PropertyBinding(() => input.maxValue, x => input.maxValue = x, getter, setter, bindingType); }

        public static IDisposable BindMinValueTo(this Slider input, IReactiveProperty<float> property, BindingTypes bindingType = BindingTypes.Default)
        { return GenericBindings.ReactivePropertyBinding(() => input.minValue, x => input.minValue = x, property, bindingType); }

        public static IDisposable BindMinValueTo(this Slider input, Func<float> getter, Action<float> setter, BindingTypes bindingType = BindingTypes.Default)
        { return GenericBindings.PropertyBinding(() => input.minValue, x => input.minValue = x, getter, setter, bindingType); }
        
        public static IDisposable BindNormalizedValueTo(this Slider input, IReactiveProperty<float> property, BindingTypes bindingType = BindingTypes.Default)
        { return GenericBindings.ReactivePropertyBinding(() => input.normalizedValue, x => input.normalizedValue = x, property, bindingType); }

        public static IDisposable BindNormalizedValueTo(this Slider input, Func<float> getter, Action<float> setter, BindingTypes bindingType = BindingTypes.Default)
        { return GenericBindings.PropertyBinding(() => input.normalizedValue, x => input.normalizedValue = x, getter, setter, bindingType); }
    }
}