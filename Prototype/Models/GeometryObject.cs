namespace Prototype.Models
{
    internal abstract class GeometryObject : ICloneable
    {
        public Guid Guid { get; init; } = Guid.NewGuid();

        public virtual object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
