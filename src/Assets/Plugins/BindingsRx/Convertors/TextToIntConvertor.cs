namespace BindingsRx.Convertors
{
    public class TextToIntConvertor : IConvertor<string, int>, IConvertor<int, string>
    {
        public string From(int value)
        { return value.ToString(); }

        public int From(string value)
        {
            int output;
            int.TryParse(value, out output);
            return output;            
        }
    }
}