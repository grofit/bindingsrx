using System;
using BindingsRx.Exceptions;
using BindingsRx.UI;
using UniRx;

namespace BindingsRx.Generic
{
    public static class GenericBindings
    {
        public static IDisposable ReactivePropertyBinding<T>(IReactiveProperty<T> propertyA , IReactiveProperty<T> propertyB, BindingTypes bindingTypes = BindingTypes.Default)
        {
            var propertyBBinding = propertyB
                .DistinctUntilChanged()
                .Subscribe(x => propertyA.Value = x);

            if (bindingTypes != BindingTypes.Default && bindingTypes != BindingTypes.TwoWay)
            { return propertyBBinding; }

            var propertyABinding = propertyA
                .DistinctUntilChanged()
                .Subscribe(x => propertyB.Value = x);

            return new CompositeDisposable(propertyABinding, propertyBBinding);
        }

        public static IDisposable ReactivePropertyBinding<T>(Func<IObservable<T>> propertyAGetter, Action<T> propertyASetter, IReactiveProperty<T> propertyB, BindingTypes bindingTypes = BindingTypes.Default)
        {
            var propertyBBinding = propertyB.DistinctUntilChanged()
                .Subscribe(propertyASetter);

            if (bindingTypes != BindingTypes.Default && bindingTypes != BindingTypes.TwoWay)
            { return propertyBBinding; }

            var propertyABinding = propertyAGetter()
                .DistinctUntilChanged()
                .Subscribe(x => propertyB.Value = x);

            return new CompositeDisposable(propertyABinding, propertyBBinding);
        }

        public static IDisposable ReactivePropertyBinding<T>(Func<T> propertyAGetter, Action<T> propertyASetter, IReactiveProperty<T> propertyB, BindingTypes bindingTypes = BindingTypes.Default)
        {
            var propertyBBinding = propertyB.DistinctUntilChanged()
                .Subscribe(propertyASetter);

            if (bindingTypes != BindingTypes.Default && bindingTypes != BindingTypes.TwoWay)
            { return propertyBBinding; }

            var propertyABinding = Observable.EveryUpdate()
                .DistinctUntilChanged(x => propertyAGetter())
                .Subscribe(x => propertyB.Value = propertyAGetter());

            return new CompositeDisposable(propertyABinding, propertyBBinding);
        }

        public static IDisposable PropertyBinding<T>(Func<IObservable<T>> propertyAGetter, Action<T> propertyASetter, Func<T> propertyBGetter, Action<T> propertyBSetter, BindingTypes bindingTypes = BindingTypes.Default)
        {
            var propertyBBinding = Observable.EveryUpdate()
                .Select(x => propertyBGetter())
                .DistinctUntilChanged()
                .Subscribe(propertyASetter);

            if (bindingTypes != BindingTypes.Default && bindingTypes != BindingTypes.TwoWay)
            { return propertyBBinding; }

            if (propertyBSetter == null)
            { throw new SetterNotProvidedException(); }

            var propertyABinding = propertyAGetter()
                .DistinctUntilChanged()
                .Subscribe(propertyBSetter);

            return new CompositeDisposable(propertyABinding, propertyBBinding);
        }

        public static IDisposable PropertyBinding<T>(Func<T> propertyAGetter, Action<T> propertyASetter, Func<T> propertyBGetter, Action<T> propertyBSetter, BindingTypes bindingTypes = BindingTypes.Default)
        {
            var propertyBBinding = Observable.EveryUpdate()
                .Select(x => propertyBGetter())
                .DistinctUntilChanged()
                .Subscribe(propertyASetter);

            if (bindingTypes != BindingTypes.Default && bindingTypes != BindingTypes.TwoWay)
            { return propertyBBinding; }

            if (propertyBSetter == null)
            { throw new SetterNotProvidedException(); }

            var propertyABinding = Observable.EveryUpdate()
                .DistinctUntilChanged(x => propertyAGetter())
                .Select(x => propertyAGetter())
                .Subscribe(propertyBSetter);

            return new CompositeDisposable(propertyABinding, propertyBBinding);
        }
    }
}