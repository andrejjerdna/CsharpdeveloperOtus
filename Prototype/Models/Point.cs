using System.Text.Json;

namespace Prototype.Models
{
    internal class Point : GeometryObject, IMyCloneable<Point>
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x; 
            Y = y;
        }

        public override object Clone()
        {
            return this.MemberwiseClone();
        }

        public Point GetCopy()
        {
            return new Point(X, Y);
        }

        public Point DeepCopy()
        {
            return JsonSerializer.Deserialize<Point>(JsonSerializer.Serialize(this));
        }

        public override string ToString()
        {
            return $"{X}, {Y}";
        }
    }
}
