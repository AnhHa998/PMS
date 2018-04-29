namespace PMS_Object
{
    public class UI_Control : PMSModule
    {
        string _parameterName;
        int _x;
        int _y;
        int _width;
        int _height;

        public string ParameterName { get => _parameterName; set => _parameterName = value; }
        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
        public int Width { get => _width; set => _width = value; }
        public int Height { get => _height; set => _height = value; }
    }
}
