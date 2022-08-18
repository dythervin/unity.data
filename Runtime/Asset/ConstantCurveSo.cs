using Dythervin.Data.Abstractions;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif
using UnityEngine;

namespace Dythervin.Data.Asset
{
    [CreateAssetMenu(menuName = MenuName + "Curve")]
    public class ConstantCurveSo : ConstantSo<AnimationCurve>
    {
#if ODIN_INSPECTOR
        [Button]
#endif
        public float EvaluateAt(float t)
        {
            return Value.Evaluate(t);
        }

        public int EvaluateAtInt(float t)
        {
            return (int)Value.Evaluate(t);
        }
    }
}