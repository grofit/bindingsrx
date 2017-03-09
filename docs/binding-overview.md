# Binding Overview

So the meat and potato of this framework is to be able to bind two things togther in their a one way or two way binding.

## Built In Bindings
Currently there is support for built in bindings on:

### Unity UI
- InputField
- Text
- Slider
- Dropdown
- RectTransform
- ICanvasElement implementations

### Scene Related
- GameObject
- MonoBehaviour
- Transform

There are also generic bindings which offer a unified way of doing basic bindings between 2 properties, and they will be touched upon later. 

## Using Bindings

If you are unsure about the notion of data-binding then it is worth looking into MVVM frameworks which provide this as the core of their view binding mechanism, however here are some examples which will attempt to explain how it all works if you want a quick overview.

### Basic Binding
So lets start with something simple like binding some text to an input field.

```csharp
var myReactiveProperty = new ReactiveProperty<string>("hello"); 
var myInputField = GetComponent<InputField>();
myInputField.BindTextTo(myReactiveProperty);
```

This tells `myInputField` that it should update its value when `myReactiveProperty` changes, and by default this is a 2 way binding, so this also means that if `myInputField` is updated then `myReactiveProperty` should also reflect that change. So this simply means that both the text in the input field and the value in the reactive property should be kept in line with each other.

### What if I dont have ReactiveProperty fields?
Never fear, if you are working with 3rd party libraries/frameworks then they probably wont be using any uniRx based data structures, but thats not a problem as there is a way to get the same behaviour as above but with non reactive objects.

So lets take the same example but without a reactive property.

```csharp
var myProperty = "hello"; 
var myInputField = GetComponent<InputField>();
myInputField.BindTextTo(() => myProperty, x => myProperty = x);
```

This isn't quite as succinct as the reactive property example but this basically allows you to manually provide a way for the binding to `get` your value as well as `set` your properties value. The reason this is needed is because some objects are immutable so this provides a consistent way to do 2 way binding to any field on any object be it immutable or not.

### Explicit Binding Behaviour

There is a doc with more detail on two way binding but you can easily change the above examples to explicitly set the binding behaviour you wish, by default it will intelligently work out what makes more sense, but you can explicitly provide it, like so for the previous example:

```csharp
var myProperty = "hello"; 
var myInputField = GetComponent<InputField>();
myInputField.BindTextTo(() => myProperty, null, BindingTypes.OneWay);
```

As seen here we can tell it that we explicitly only want one way binding and we can omit the setter argument as it is no longer needed.

## Cleaning Up

So currently we have created bindings however almost everything in the rx world requires disposing once its dealt with, so for all unity based objects the binding will be bound to the lifetime of the object you are invoking on and be disposed of internally.

So for example if you were to be using an `InputField` and using a `BindTextTo` binding, it would automatically clean up the binding with the `InputField` which is handled inside the extension method in most cases.

### Additional Cleanup
so in most cases you would want to cleanup with the unity object, which is fine, however if you need to clean up with something else, such as a `ReactiveProperty` or some other object you may need to use the `AddTo` extension to clean up with the binding, so for example to clean up our previous example you would do:

```csharp
var myReactiveProperty = new ReactiveProperty<string>("hello"); 
var myInputField = GetComponent<InputField>();
myInputField.BindTextTo(myReactiveProperty)
.AddTo(myReactiveProperty);
```

Which would also dispose with the `ReactiveProperty` if that was disposed before the input, but in most cases you would not have to worry too much about explicitly tidying up.