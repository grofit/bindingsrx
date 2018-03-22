using System;

namespace BindingsRx.Convertors
{
    public class TextToDateConvertor : IConvertor<string, DateTime>, IConvertor<DateTime, string>
    {
        private string _dateFormat { get; set; }

        public TextToDateConvertor(string dateFormat = "d")
        {
            _dateFormat = dateFormat;
        }

        public string From(DateTime value)
        { return value.ToString(_dateFormat); }

        public DateTime From(string value)
        {
            DateTime output;
            DateTime.TryParse(value, out output);
            return output;
        }
    }
}