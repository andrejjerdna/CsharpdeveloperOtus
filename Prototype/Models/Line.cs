using System.Text.Json;

namespace Prototype.Models
{
    internal sealed  class Line : GeometryObject, IMyCloneable<Line>
    {
        public Point Point1 { get; init; }
        public Point Point2 { get; init; }

        public Line(Point point1, Point point2)
        {
            Point1 = point1;
            Point2 = point2;
        }

        public override object Clone()
        {
            var p1 = Point1.Clone() as Point;
            var p2 = Point2.Clone() as Point;

            if (p1 == null || p2 == null)
                return null;

            return new Line(p1, p2);
        }

        public Line GetCopy()
        {
            return new Line(Point1.GetCopy(), Point2.GetCopy());
        }

        public Line DeepCopy()
        {
            return JsonSerializer.Deserialize<Line>(JsonSerializer.Serialize(this));
        }
    }
}
