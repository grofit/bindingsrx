using BindingsRx;
using BindingsRx.Bindings;
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
            var somePretendInput = "";
            GenericBindings.Bind(() => somePretendInput, x => somePretendInput = x, reactiveProperty);

            reactiveProperty.Value = "first";
            Assert.That(somePretendInput, Is.EqualTo("first"));

            somePretendInput = "second";
            Assert.That(reactiveProperty.Value, Is.EqualTo("second"));
        }

        [Test]
        [Ignore("Need to find out how to trigger observable Next")]
        public void should_correctly_do_two_way_binding_for_simple_property()
        {
            var basicProperty = "";
            var somePretendInput = "";
            GenericBindings.Bind(() => somePretendInput, x => somePretendInput = x, () => basicProperty, x => basicProperty = x );

            basicProperty = "first";
            Assert.That(somePretendInput, Is.EqualTo("first"));

            somePretendInput = "second";
            Assert.That(basicProperty, Is.EqualTo("second"));
        }

        [Test]
        [Ignore("Need to find out how to trigger observable Next")]
        public void should_correctly_do_one_way_binding_for_reactive_property()
        {
            var reactiveProperty = new ReactiveProperty<string>("");
            var somePretendInput = "";
            GenericBindings.Bind(() => somePretendInput, x => somePretendInput = x, reactiveProperty, BindingTypes.OneWay);

            reactiveProperty.Value = "first";
            Assert.That(somePretendInput, Is.EqualTo("first"));

            somePretendInput = "second";
            Assert.That(reactiveProperty.Value, Is.EqualTo("first"));
        }
    }
}