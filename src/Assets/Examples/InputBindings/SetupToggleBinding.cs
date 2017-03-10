using BindingsRx;
using BindingsRx.Bindings;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Examples.InputBindings
{
    /// <summary>
    /// A simple toggle example
    /// </summary>
    public class SetupToggleBinding : MonoBehaviour
    {
        public ReactiveProperty<bool> ToggleState = new ReactiveProperty<bool>();
        public Toggle ToggleElement;
        public Text TextElement;

        void Start()
        {
            ToggleElement.BindToggleTo(ToggleState);

            var textualRepresentation = ToggleState.Select(GetTextualState).ToReactiveProperty();
            textualRepresentation.AddTo(TextElement);

            TextElement.BindTextTo(textualRepresentation);
        }

        string GetTextualState(bool state)
        {
            return "Magic is " + (state ? "Enabled" : "Disabled");
        }
    }
}