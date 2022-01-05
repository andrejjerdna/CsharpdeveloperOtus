using System.Text.Json;

namespace Prototype.Models
{
    internal sealed class Triangle : Figure, IMyCloneable<Triangle>
    {
        public Point Point1 { get; init; }
        public Point Point2 { get; init; }
        public Point Point3 { get; init; }

        public Triangle(Point point1, Point point2, Point point3)
        {
            Point1 = point1;
            Point2 = point2;
            Point3 = point3;
        }

        public override object Clone()
        {
            var p1 = Point1.Clone() as Point;
            var p2 = Point2.Clone() as Point;
            var p3 = Point2.Clone() as Point;

            if (p1 == null || p2 == null || p3 == null)
                return null;

            return new Triangle(p1, p2, p3)
            {
                Name = this.Name
            };
        }

        public override double GetSquare()
        {
            return 100.0;
        }

        public Triangle GetCopy()
        {
            return new Triangle(Point1.GetCopy(),
                                Point2.GetCopy(),
                                Point3.GetCopy())
            { 
                Name = this.Name 
            };
        }

        public Triangle DeepCopy()
        {
            return JsonSerializer.Deserialize<Triangle>(JsonSerializer.Serialize(this));
        }

        public override IEnumerable<Point> GetPoints()
        {
            return new List<Point> { Point1, Point2, Point3 };
        }

        public override string ToString()
        {
            return $"Triangle name: {Name}, Coordinates: (({Point1.ToString()}), " +
                $"({Point2.ToString()}), ({Point3.ToString()}))";
        }
    }
}
