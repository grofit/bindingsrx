using BindingsRx.UI;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class SetupBindings : MonoBehaviour
{
    public InputField TextBindingInput;
    public Text TextBindingOutput;
    
	void Start ()
	{
	    TextBindingOutput.BindTextTo(() => TextBindingInput.text);
	}
}
