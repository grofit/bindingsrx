# Custom & Generic Bindings

This framework adds some basic extension methods to help you just get on and do common databinding with the built in stuff with unity, but if you were to start working with 3rd party libs or your own core objects you may want to write your own custom bindings, which can often be created quite easily by building off a `GenericBinding`.

## Using Generic Bindings

These are used under the hood in 99% of the built in bindings as it offers a simpler way to just bind 2 variables together, so for example if we look at the slightly more complicated `InputBinding.BindTextTo` binding:

```csharp
public static IDisposable BindTextTo(this InputField input, Func<string> getter, Action<string> setter, BindingTypes bindingType = BindingTypes.Default, params IFilter<string>[] filters)
{ return GenericBindings.Bind(() => input.text, x => input.text = x, getter, setter, bindingType, filters); }
```

So this would be used like so:

```csharp
var myProperty = "hello"; 
var myInputField = GetComponent<InputField>();
myInputField.BindTextTo(() => myProperty, x => myProperty = x);
```

Under the hood though you can see it is using the `GenericBindings.Bind` method which basically provides a few common helper overloads for binding 2 values togeher.

So the example above uses the `Bind` method shown below:

```csharp
public static IDisposable Bind<T>(Func<T> propertyAGetter, Action<T> propertyASetter, Func<T> propertyBGetter, Action<T> propertyBSetter, BindingTypes bindingTypes = BindingTypes.Default, params IFilter<T>[] filters)
{
    var propertyBBinding = Observable.EveryUpdate()
        .Select(x => propertyBGetter())
        .ApplyInputFilters(filters)
        .DistinctUntilChanged()
        .Subscribe(propertyASetter);

    if (bindingTypes == BindingTypes.OneWay)
    { return propertyBBinding; }

    if (propertyBSetter == null)
    { throw new SetterNotProvidedException(); }

    var propertyABinding = Observable.EveryUpdate()
        .Select(x => propertyAGetter())
        .ApplyOutputFilters(filters)
        .DistinctUntilChanged()
        .Subscribe(propertyBSetter);

    return new CompositeDisposable(propertyABinding, propertyBBinding);
}
```

That may look a bit complex at first, but if you look at the args, it basically takes a `getter` and `setter` method for both `propertyA` and `propertyB`, it also takes the binding type and any filters needed (which are explained in the filters doc).

So you could easily bind almost anything to anything else using this binding method, which may be a bit messy if you use it directly but when proxied via an extension method it can be quite easy to make your own bindings, as all you need to do is provide a way to get and set both properties and off you go, the underlying logic will handle the binding mechanism and allowing filters to be run on it.

There are quite a few overloads which allow you to pass in `ReactiveProperty` objects instead of `getter` and `setters` methods, but unless you have a really complex bespoke binding you are probably best off just proxying the generic bind method.

## Custom bindings without the generic binding helpers

So you may have a scenario where you have a complex bind that has to do multiple things under the hood, so its not a great fit for a 1-1 binding using the built in `GenericBinding` helpers.

To keep things consistent it is recommended you keep the last 2 args to be the defaulted `bindingType = BindingTypes.Default` and `param IFilter<T>[] filters`. This way with little effort you can allow your binding to plug into the filtering process if it makes sense as well as allowing one way or two way bindings, however not all use cases will make sense to do this.

One of the most complex examples within the framework is the `Dropdown` binding for options which looks like this:

```csharp
public static IDisposable BindOptionsTo(this Dropdown input, IReactiveCollection<string> options)
{
    var addSubscription = options.ObserveAdd().Subscribe(x =>
    {
        var newOption = new Dropdown.OptionData { text = x.Value };
        input.options.Insert(x.Index, newOption);
    });

    var updateSubscription = options.ObserveReplace().Subscribe(x =>
    {
        var existingOption = input.options[x.Index];
        existingOption.text = x.NewValue;
    });

    var removeSubscription = options.ObserveRemove().Subscribe(x => input.options.RemoveAt(x.Index));

    input.options.Clear();

    foreach (var option in options)
    {
        var newOption = new Dropdown.OptionData { text = option };
        input.options.Add(newOption);
    }
    
    return new CompositeDisposable(addSubscription, updateSubscription, removeSubscription);
}
```

This only allows one way binding and does not support filters, so you do whatever makes sense for your scenario and make it as bespoke as you want, just remember there are helpers available to assist you and there are a few complex and simple examples available for reference within this framework.