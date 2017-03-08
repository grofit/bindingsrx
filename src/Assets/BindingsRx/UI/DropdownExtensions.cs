using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using BindingsRx.Generic;
using UniRx;
using UnityEngine.UI;

namespace BindingsRx.UI
{
    public static class DropdownExtensions
    {
        public static IDisposable BindValueTo(this Dropdown input, IReactiveProperty<int> property, BindingTypes bindingType = BindingTypes.Default)
        { return GenericBindings.ReactivePropertyBinding(() => input.value, x => input.value = x, property, bindingType); }

        public static IDisposable BindValueTo(this Dropdown input, Func<int> getter, Action<int> setter, BindingTypes bindingType = BindingTypes.Default)
        { return GenericBindings.PropertyBinding(() => input.value, x => input.value = x, getter, setter, bindingType); }

        public static IDisposable BindValueTo(this Dropdown input, IReactiveProperty<string> property, BindingTypes bindingType = BindingTypes.Default)
        {
            return GenericBindings.ReactivePropertyBinding(() => input.options[input.value].text, x =>
            {
                var matchingIndex = 0;
                for (var i = 0; i < input.options.Count; i++)
                {
                    if (input.options[i].text == property.Value)
                    {
                        matchingIndex = i;
                        break;
                    }
                }
                input.value = matchingIndex;
            }, property, bindingType);
        }

        public static IDisposable BindValueTo(this Dropdown input, Func<string> getter, Action<string> setter, BindingTypes bindingType = BindingTypes.Default)
        {
            return GenericBindings.PropertyBinding(() => input.options[input.value].text, x =>
            {
                var matchingIndex = 0;
                var currentValue = getter();
                for (var i = 0; i < input.options.Count; i++)
                {
                    if (input.options[i].text == currentValue)
                    {
                        matchingIndex = i;
                        break;
                    }
                }
                input.value = matchingIndex;
            }, getter, setter, bindingType);
        }

        public static IDisposable BindOptionsTo(this Dropdown input, IReactiveCollection<string> options)
        {
            var addSubscription = options.ObserveAdd().Subscribe(x =>
            {
                var newOption = new Dropdown.OptionData { text = x.Value };
                input.options.Insert(x.Index, newOption);
            });

            var removeSubscription = options.ObserveRemove().Subscribe(x =>
            {
                input.options.RemoveAt(x.Index);
            });

            input.options.Clear();

            foreach (var option in options)
            {
                var newOption = new Dropdown.OptionData { text = option };
                input.options.Add(newOption);
            }
            
            return new CompositeDisposable(addSubscription, removeSubscription);
        }
    }
}