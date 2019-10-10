using System;
using BindingsRx.Filters;
using UniRx;
using UnityEngine;

namespace BindingsRx.Bindings
{
    public static class GameObjectExtensions
    {
        public static IDisposable BindActiveTo(this GameObject input, IReactiveProperty<bool> property, BindingTypes bindingType = BindingTypes.Default, params IFilter<bool>[] filters)
        { return GenericBindings.Bind(() => input.activeSelf, input.SetActive, property, bindingType, filters).AddTo(input); }

        public static IDisposable BindActiveTo(this GameObject input, Func<bool> getter, Action<bool> setter, BindingTypes bindingType = BindingTypes.Default, params IFilter<bool>[] filters)
        { return GenericBindings.Bind(() => input.activeSelf, input.SetActive, getter, setter, bindingType, filters).AddTo(input); }

        public static IDisposable BindLayerTo(this GameObject input, IReactiveProperty<int> property, BindingTypes bindingType = BindingTypes.Default, params IFilter<int>[] filters)
        { return GenericBindings.Bind(() => input.layer, x => input.layer = x, property, bindingType, filters).AddTo(input); }

        public static IDisposable BindLayerTo(this GameObject input, Func<int> getter, Action<int> setter, BindingTypes bindingType = BindingTypes.Default, params IFilter<int>[] filters)
        { return GenericBindings.Bind(() => input.layer, x => input.layer = x, getter, setter, bindingType, filters).AddTo(input); }

        public static IDisposable BindLayerTo(this GameObject input, IReactiveProperty<LayerMask> property, BindingTypes bindingType = BindingTypes.Default, params IFilter<LayerMask>[] filters)
        { return GenericBindings.Bind(() => input.layer, x => input.layer = x, property, bindingType, filters).AddTo(input); }

        public static IDisposable BindLayerTo(this GameObject input, Func<LayerMask> getter, Action<LayerMask> setter, BindingTypes bindingType = BindingTypes.Default, params IFilter<LayerMask>[] filters)
        { return GenericBindings.Bind(() => input.layer, x => input.layer = x, getter, setter, bindingType, filters).AddTo(input); }

        public static IDisposable BindNameTo(this GameObject input, IReactiveProperty<string> property, BindingTypes bindingType = BindingTypes.Default, params IFilter<string>[] filters)
        { return GenericBindings.Bind(() => input.name, x => input.name = x, property, bindingType, filters).AddTo(input); }

        public static IDisposable BindNameTo(this GameObject input, Func<string> getter, Action<string> setter, BindingTypes bindingType = BindingTypes.Default, params IFilter<string>[] filters)
        { return GenericBindings.Bind(() => input.name, x => input.name = x, getter, setter, bindingType, filters).AddTo(input); }

        public static IDisposable BindTagTo(this GameObject input, IReactiveProperty<string> property, BindingTypes bindingType = BindingTypes.Default, params IFilter<string>[] filters)
        { return GenericBindings.Bind(() => input.tag, x => input.tag = x, property, bindingType, filters).AddTo(input); }

        public static IDisposable BindTagTo(this GameObject input, Func<string> getter, Action<string> setter, BindingTypes bindingType = BindingTypes.Default, params IFilter<string>[] filters)
        { return GenericBindings.Bind(() => input.tag, x => input.tag = x, getter, setter, bindingType, filters).AddTo(input); }

        public static IDisposable BindChildPrefabsTo<T>(this GameObject input, IReadOnlyReactiveCollection<T> list,
            GameObject prefab, Action<T, GameObject> onChildCreated = null, Action<T, GameObject> onChildRemoving = null)
        { return BindChildPrefabsTo(input, list, prefab, GameObject.Instantiate, onChildCreated, onChildRemoving); }
        
        public static IDisposable BindChildPrefabsTo<T>(this GameObject input, IReadOnlyReactiveCollection<T> list,
            GameObject prefab, Func<GameObject, Transform, GameObject> instantiator,
            Action<T, GameObject> onChildCreated = null, Action<T, GameObject> onChildRemoving = null)
        {
            var disposable = new CompositeDisposable();

            void onElementAdded(CollectionAddEvent<T> data)
            {
                var newChild = instantiator(prefab, input.transform);
                onChildCreated?.Invoke(data.Value, newChild);
            }
            
            void onElementUpdated(CollectionReplaceEvent<T> data)
            {
                var existingChild = input.transform.GetChild(data.Index);
                onChildCreated?.Invoke(data.NewValue, existingChild.gameObject);
            }
            
            void onElementRemoved(CollectionRemoveEvent<T> data)
            {
                var existingChild = input.transform.GetChild(data.Index);
                onChildRemoving?.Invoke(data.Value, existingChild.gameObject);
                GameObject.Destroy(existingChild);
            }

            list.ObserveAdd().Subscribe(onElementAdded).AddTo(disposable);
            list.ObserveReplace().Subscribe(onElementUpdated).AddTo(disposable);
            list.ObserveRemove().Subscribe(onElementRemoved).AddTo(disposable);

            input.transform.DeleteAllChildren();
            foreach (var element in list)
            {
                var newChild = instantiator(prefab, input.transform);
                onChildCreated?.Invoke(element, newChild);
            }

            return disposable.AddTo(input);
        }
    }
}