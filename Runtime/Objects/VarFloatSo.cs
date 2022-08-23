using Dythervin.Data.Abstractions;
using UnityEngine;

namespace Dythervin.Data.Objects
{
    [CreateAssetMenu(menuName = MenuName + "Float", order = 0)]
    public class VarFloatSo : VariableSo<float>, INumericVar<float>
    {
        public void Add(float value)
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
    }
}