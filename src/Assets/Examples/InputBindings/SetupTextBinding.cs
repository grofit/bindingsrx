using BindingsRx.Bindings;
using UnityEngine;
using UnityEngine.UI;

namespace Examples.InputBindings
{
    /// <summary>
    /// A simple binding to bind the text of an input field to a text field
    /// </summary>
    public class SetupTextBinding : MonoBehaviour
    {
        public InputField InputElement;
        public Text TextElement;

        void Start()
        {
            TextElement.BindTextTo(() => InputElement.text);
        }
    }
}
