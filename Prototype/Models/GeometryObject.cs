namespace Prototype.Models
{
    internal abstract class GeometryObject : ICloneable
    {
        public Guid Guid { get; init; } = Guid.NewGuid();

        public abstract object Clone();
    }
}
