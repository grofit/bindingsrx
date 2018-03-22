namespace BindingsRx.Convertors
{
    public class DoubleToFloatConvertor : IConvertor<double, float>, IConvertor<float, double>
    {
        public float From(double value)
        { return (float)value; }

        public double From(float value)
        { return value; }
    }
}