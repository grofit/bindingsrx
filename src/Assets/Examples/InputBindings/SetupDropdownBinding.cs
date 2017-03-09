using BindingsRx.UI;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Examples.InputBindings
{
    public class SetupDropdownBinding : MonoBehaviour
    {
        public Dropdown DropdownOutput;
        public InputField DropdownValueInput;

        void Start()
        {
            var exampleOptions = new ReactiveCollection<string>();
            exampleOptions.Add("Option 1");
            exampleOptions.Add("Option 2");
            exampleOptions.Add("Some Other Option");
            DropdownOutput.BindOptionsTo(exampleOptions);
            DropdownOutput.BindValueTo(() => DropdownValueInput.text, x => DropdownValueInput.text = x).AddTo(DropdownOutput);
        }
    }
}