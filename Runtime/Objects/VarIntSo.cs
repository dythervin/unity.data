using Dythervin.Data.Abstractions;
using UnityEngine;

namespace Dythervin.Data.Objects
{
    [CreateAssetMenu(menuName = "Var/Int", order = 0)]
    public sealed class VarIntSo : VariableSo<int>, INumericVar<int>, INumFloat
    {
        public void Add(int value)
        {
            Value += value;
        }

        public void Increment()
        {
            Add(1);
        }

        public void Decrement()
        {
            Add(-1);
        }

        float IVarReadOnly<float>.Value => Value;
    }
}