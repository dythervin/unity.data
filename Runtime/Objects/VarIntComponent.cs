using Dythervin.Data.Abstractions;

namespace Dythervin.Data.Objects
{
    public class VarIntComponent : VarComponent<int>, INumericVar<int>, INumFloat
    {
        float IVarReadOnly<float>.Value => Value;

        public void Add(int value)
        {
            Value += value;
        }

        public void Decrement()
        {
            Value--;
        }

        public void Increment()
        {
            Value++;
        }
    }
}