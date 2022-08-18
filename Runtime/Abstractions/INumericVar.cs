namespace Dythervin.Data.Abstractions
{
    public interface INumericVar<T> : IVar<T>
    {
        void Add(T value);
        void Increment();
        void Decrement();
    }
}