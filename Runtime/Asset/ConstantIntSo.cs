using Dythervin.Data.Abstractions;
using UnityEngine;

namespace Dythervin.Data.Asset
{
    [CreateAssetMenu(menuName = MenuName + "Int")]
    public class ConstantIntSo : ConstantSo<int>, INumFloat
    {
        float IVarReadOnly<float>.Value => Value;
    }
}