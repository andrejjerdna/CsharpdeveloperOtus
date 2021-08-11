namespace Reflection
{
    public class TestClass
    {
        private double _fieldDouble;
        private string _fieldString;

        public double PropertyDouble { get; set; }
        public string PropertyString { get; set; }

        public TestClass()
        {
            PropertyDouble = 89.0;
            PropertyString = "Test";

            _fieldDouble = 45.0;
        }
    }
}