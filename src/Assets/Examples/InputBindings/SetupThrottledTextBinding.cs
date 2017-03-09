using System;
using BindingsRx.Filters;
using BindingsRx.UI;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Examples.InputBindings
{
    /// <summary>
    /// Due to the way throttle works, the sample filter is basically providing us what we 
    /// need here where we are able to throttle the updates so we only actually process them
    /// at a given intervals which allows you to reduce overhead on bindings that fire too frequently
    /// </summary>
    public class SetupThrottledTextBinding : MonoBehaviour
    {
        public InputField TextBindingInput;
        public InputField ThrottleTextBindingInput;
        public Text TextBindingOutput;

        void Start()
        {
            var dynamicSampleFilter = new DynamicSampleFilter<string>(TimeSpan.FromMilliseconds(500)).AddTo(TextBindingOutput);
            TextBindingOutput.BindTextTo(() => TextBindingInput.text, dynamicSampleFilter).AddTo(TextBindingOutput);

            ThrottleTextBindingInput.BindTextTo(() => dynamicSampleFilter.SampleRate.Value.TotalMilliseconds.ToString(), 
               UpdateThrottleValue(dynamicSampleFilter))
               .AddTo(ThrottleTextBindingInput);
        }

        private static Action<string> UpdateThrottleValue(DynamicSampleFilter<string> sampleFilter)
        {
            return x =>
            {
                int intValue;
                var wasValid = int.TryParse(x, out intValue);

                if(wasValid)
                { sampleFilter.SampleRate.Value = TimeSpan.FromMilliseconds(intValue); }
                else
                {
                    Debug.LogError("INVALID THROTTLE NUMBER: " + intValue);
                }
            };
        }
    }
}