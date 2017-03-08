using BindingsRx.UI;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class SetupBindings : MonoBehaviour
{
    public InputField TextBindingInput;
    public Text TextBindingOutput;

    public Dropdown DropdownOutput;
    public InputField DropdownValueInput;
    
	void Start ()
	{
	    TextBindingOutput.BindTextTo(() => TextBindingInput.text);

        var exampleOptions = new ReactiveCollection<string>();
        exampleOptions.Add("Option 1");
        exampleOptions.Add("Option 2");
        exampleOptions.Add("Some Other Option");

	    DropdownOutput.BindOptionsTo(exampleOptions);
	    DropdownOutput.BindValueTo(() => DropdownValueInput.text, x => DropdownValueInput.text = x);
	}
}
