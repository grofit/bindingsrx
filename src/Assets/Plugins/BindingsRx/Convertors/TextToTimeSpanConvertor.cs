using System;

namespace BindingsRx.Convertors
{
    public class TextToTimeSpanConvertor : IConvertor<string, TimeSpan>, IConvertor<TimeSpan, string>
    {
        public string From(TimeSpan value)
        { return value.ToString(); }

        public TimeSpan From(string value)
        {
            TimeSpan output;
            TimeSpan.TryParse(value, out output);
            return output;
        }
    }
}