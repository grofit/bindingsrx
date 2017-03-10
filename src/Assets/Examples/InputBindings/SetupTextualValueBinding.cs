using System;
using BindingsRx.Bindings;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Examples.InputBindings
{
    /// <summary>
    /// This shows how to easy it is to bind non strings to textual bindings in a 2-way fashion
    /// </summary>
    public class SetupTextualValueBinding : MonoBehaviour
    {
        public InputField InputElement;
        public ReactiveProperty<int> ReactiveInt = new ReactiveProperty<int>(1);

        void Start()
        {
            InputElement.BindTextTo(ReactiveInt);
            Observable.Interval(TimeSpan.FromSeconds(1)).Subscribe(x => ReactiveInt.Value += 1);
        }
    }
}