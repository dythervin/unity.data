namespace Dythervin.Data.Abstractions
{
    public interface IVar<T> : IVarReadOnly<T>
    {
        new T Value { get; set; }
#if UNITY_2021_3_OR_NEWER
        bool IVarReadOnly.IsConst=> false;
#endif
    }

    public interface IVarStruct<T> : IVarStructReadOnly<T>
    {
#if UNITY_2021_3_OR_NEWER
        bool IVarReadOnly.IsConst=> false;
#endif
        void SetValue(in T value);
    }
}