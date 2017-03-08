using System;
using BindingsRx.Exceptions;
using UniRx;
using UnityEngine.UI;

namespace BindingsRx.UI
{
    public static class InputFieldExtensions
    {
        public static IDisposable BindTextTo(this InputField input, IReactiveProperty<string> property, BindingTypes bindingTypes = BindingTypes.Default)
        {
            var propertyBinding = property.DistinctUntilChanged()
                .Subscribe(x => input.text = x);

            if (bindingTypes != BindingTypes.Default && bindingTypes != BindingTypes.TwoWay)
            { return propertyBinding; }

            var inputBinding = input.OnValueChangedAsObservable()
                .DistinctUntilChanged()
                .Subscribe(x => property.Value = x);

            return new CompositeDisposable(inputBinding, propertyBinding);
        }

        public static IDisposable BindTextTo(this InputField input, Func<string> getter, Action<string> setter, BindingTypes bindingTypes = BindingTypes.Default)
        {
            var propertyBinding = Observable.EveryUpdate()
                .Select(x => getter())
                .DistinctUntilChanged()
                .Subscribe(x => input.text = x);

            if (bindingTypes != BindingTypes.Default && bindingTypes != BindingTypes.TwoWay)
            { return propertyBinding; }

            if (setter == null)
            { throw new SetterNotProvidedException(); }

            var inputBinding = input.OnValueChangedAsObservable()
                .DistinctUntilChanged()
                .Subscribe(setter);

            return new CompositeDisposable(inputBinding, propertyBinding);
        }
    }
}
