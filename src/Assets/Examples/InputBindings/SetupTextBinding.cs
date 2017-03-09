using BindingsRx.UI;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Examples.InputBindings
{
    public class SetupTextBinding : MonoBehaviour
    {
        public InputField TextBindingInput;
        public Text TextBindingOutput;
    
        void Start ()
        {
            TextBindingOutput.BindTextTo(() => TextBindingInput.text).AddTo(TextBindingOutput);
        }
    }
}
