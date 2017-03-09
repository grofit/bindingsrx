using BindingsRx.UI;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Examples.InputBindings
{
    /// <summary>
    /// A simple binding to bind the text of an input field to a text field
    /// </summary>
    public class SetupTextBinding : MonoBehaviour
    {
        public InputField TextBindingInput;
        public Text TextBindingOutput;
    
        void Start ()
        {
            TextBindingOutput.BindTextTo(() => TextBindingInput.text);
        }
    }
}
