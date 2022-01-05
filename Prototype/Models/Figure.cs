using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype.Models
{
    internal abstract class Figure : GeometryObject
    {
        public string Name { get; set; } = "DefaulName";
        public abstract double GetSquare();
        public abstract IEnumerable<Point> GetPoints();
    }
}
