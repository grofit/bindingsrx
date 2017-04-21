using BindingsRx;
using BindingsRx.Bindings;
using BindingsRx.Overrides;
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
            ObservableProxy.TriggerArtificialUpdate();
            Assert.That(reactiveProperty.Value, Is.EqualTo("second"));
        }

        [Test]
        public void should_correctly_do_two_way_binding_for_simple_property()
        {
            var basicProperty = "";
            var somePretendInput = "";
            GenericBindings.Bind(() => somePretendInput, x => somePretendInput = x, () => basicProperty, x => basicProperty = x );

            basicProperty = "first";
            ObservableProxy.TriggerArtificialUpdate();
            Assert.That(somePretendInput, Is.EqualTo("first"));

            somePretendInput = "second";
            ObservableProxy.TriggerArtificialUpdate();
            Assert.That(basicProperty, Is.EqualTo("second"));
        }

        [Test]
        public void should_correctly_do_one_way_binding_for_reactive_property()
        {
            var reactiveProperty = new ReactiveProperty<string>("");
            var somePretendInput = "";
            GenericBindings.Bind(() => somePretendInput, x => somePretendInput = x, reactiveProperty, BindingTypes.OneWay);

            reactiveProperty.Value = "first";
            ObservableProxy.TriggerArtificialUpdate();
            Assert.That(somePretendInput, Is.EqualTo("first"));

            somePretendInput = "second";
            ObservableProxy.TriggerArtificialUpdate();
            Assert.That(reactiveProperty.Value, Is.EqualTo("first"));
        }

        [Test]
        public void should_only_trigger_update_when_value_is_different_with_reactive_properties()
        {
            var timesUpdated = 0;
            var reactivePropertyA = new ReactiveProperty<int>(1);
            var reactivePropertyB = new ReactiveProperty<int>(1);
            GenericBindings.Bind(reactivePropertyA, reactivePropertyB);

            reactivePropertyB.Subscribe(x =>
            {
                timesUpdated++;
            });
            
            reactivePropertyA.Value = 1;
            reactivePropertyA.Value = 1;
            reactivePropertyA.Value = 1;
            reactivePropertyA.Value = 1;
            
            Assert.That(timesUpdated, Is.EqualTo(1)); // 1 from original assignment
        }

        [Test]
        public void should_only_trigger_update_when_value_is_different_with_non_reactive_properties()
        {
            var timesUpdated = 0;
            var valueA = 1;
            var valueB = 1;
            GenericBindings.Bind(() => valueA, (x) =>
            {
                valueA = x;
                timesUpdated++;
            }, () => valueB, (x) => valueB = x);

            valueB = 1;
            ObservableProxy.TriggerArtificialUpdate();
            valueB = 1;
            ObservableProxy.TriggerArtificialUpdate();
            valueB = 1;
            ObservableProxy.TriggerArtificialUpdate();
            valueB = 1;
            ObservableProxy.TriggerArtificialUpdate();

            Assert.That(timesUpdated, Is.EqualTo(0));
        }
    }
}