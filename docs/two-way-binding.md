# One way vs Two way binding

So by default most bindings will be 2 way, although in some cases they will only support one way, such as a `Text` UI element in unity, there is no way for the user to change the text value as its a readonly control in the UI, so this only provides a one way mechanism as there would never be a scenario where a user could alter the text.

Now you have control over how you want to bind in most cases so you can optionally specify how the bindings should work

(although some extensions will ONLY work in a one way fashion, but feel free to make your own custom versions if this is a problem).

## BindingTypes

So for most bindings there is the optional `bindingType` argument, which you can omit and it will default based upon the binding, so as mentioned above `Text` is only going to be set, you will never realistically get an update so it defaults to `OneWay` binding by default.

You can however explicitly set `BindingTypes.OneWay` or `BindingTypes.TwoWay` in most cases, and it will ignore the setter aspect of the passed property if it is a `OneWay` binding.