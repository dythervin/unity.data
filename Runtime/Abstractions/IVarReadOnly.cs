namespace Dythervin.Data.Abstractions
{
    public interface IVarReadOnly
    {
        bool IsConst { get; }
    }

    public interface IChangeable
    {
        event System.Action OnChanged;
    }

    public interface IVarReadOnly<out T> : IChangeable, IVarReadOnly
    {
        T Value { get; }
    }

    public interface IVarStructReadOnly<T> : IChangeable, IVarReadOnly
    {
        ref readonly T ValueRef { get; }
    }
}