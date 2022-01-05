namespace Prototype
{
    internal interface IMyCloneable<T>
    {
        T GetCopy();

        T DeepCopy();
    }
}
