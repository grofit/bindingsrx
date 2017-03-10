using BindingsRx.Bindings;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Examples.InputBindings
{
    /// <summary>
    /// An example of how to bind a reactive collection to dropdown's options as well as value
    /// </summary>
    public class SetupDropdownBinding : MonoBehaviour
    {
        public Dropdown DropdownElement;
        public InputField ValueInputElement;

        void Start()
        {
            var exampleOptions = new ReactiveCollection<string>();
            exampleOptions.Add("Option 1");
            exampleOptions.Add("Option 2");
            exampleOptions.Add("Some Other Option");
            DropdownElement.BindOptionsTo(exampleOptions);
            DropdownElement.BindValueTo(() => ValueInputElement.text, x => ValueInputElement.text = x);
        }
    }
}