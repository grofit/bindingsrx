using BindingsRx;
using BindingsRx.Generic;
using NUnit.Framework;
using UniRx;

namespace Editor.Tests
{
    [TestFixture]
    public class GenericBindingTests
    {
        [Test]
        public void should_correctly_do_two_way_binding_for_reactive_property()
        {
            var reactiveProperty = new ReactiveProperty<string>("");
            var somePretendInput = new ReactiveProperty<string>("some value");
            GenericBindings.Bind(() => somePretendInput, x => somePretendInput.Value = x, reactiveProperty);

            reactiveProperty.Value = "first";
            Assert.That(somePretendInput.Value, Is.EqualTo("first"));

            somePretendInput.Value = "second";
            Assert.That(reactiveProperty.Value, Is.EqualTo("second"));
        }

        [Test]
        public void should_correctly_do_two_way_binding_for_simple_property()
        {
            var basicProperty = "";
            var somePretendInput = new ReactiveProperty<string>("some value");
            GenericBindings.Bind(() => somePretendInput, x => somePretendInput.Value = x, () => basicProperty, x => basicProperty = x );

            basicProperty = "first";
            Assert.That(somePretendInput.Value, Is.EqualTo("first"));

            somePretendInput.Value = "second";
            Assert.That(basicProperty, Is.EqualTo("second"));
        }

        [Test]
        public void should_correctly_do_one_way_binding_for_reactive_property()
        {
            var reactiveProperty = new ReactiveProperty<string>("");
            var somePretendInput = new ReactiveProperty<string>("some value");
            GenericBindings.Bind(() => somePretendInput, x => somePretendInput.Value = x, reactiveProperty, BindingTypes.OneWay);

            reactiveProperty.Value = "first";
            Assert.That(somePretendInput.Value, Is.EqualTo("first"));

            somePretendInput.Value = "second";
            Assert.That(reactiveProperty.Value, Is.EqualTo("first"));
        }
    }
}