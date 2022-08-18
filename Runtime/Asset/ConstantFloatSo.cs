using Dythervin.Data.Abstractions;
using UnityEngine;

namespace Dythervin.Data.Asset
{
    [CreateAssetMenu(menuName = MenuName + "Float")]
    public class ConstantFloatSo : ConstantSo<float>, INumFloat { }
}