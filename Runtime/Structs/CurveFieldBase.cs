using System;
using Dythervin.Data.Asset;
using UnityEngine;

namespace Dythervin.Data.Structs
{
    [Serializable]
    public abstract class CurveFieldBase
    {
        [SerializeField]
        protected ConstantCurveSo curve;

        protected abstract float BaseValue { get; }

        public float EvaluateAt(float t)
        {
            return BaseValue * curve.EvaluateAt(t);
        }

        public int EvaluateAtInt(float t)
        {
            return ToInt(EvaluateAt(t));
        }

        public static int ToInt(float value)
        {
            return (int)value;
        }
    }
}