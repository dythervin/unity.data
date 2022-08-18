using System;
using Dythervin.Callbacks;
using Dythervin.Data.Abstractions;
using UnityEngine;

namespace Dythervin.Data.Structs
{
    [Serializable]
    public class CurveField<T> : CurveFieldBase, IPlayModeListener where T: IVarReadOnly<float>
    {
        [SerializeField]
        private T baseValue;

        public CurveField()
        {
            this.TryEnterPlayMode();
        }

        protected override float BaseValue => baseValue.Value;
        bool IPlayModeListener.MainThreadOnly => false;

        void IPlayModeListener.OnEnterPlayMode()
        {
            OnEnterPlayMode();
        }

        protected virtual void OnEnterPlayMode()
        {
            if (baseValue.IsConst)
                return;

            baseValue.OnChanged += BaseValueOnOnChanged;
        }

        protected virtual void BaseValueOnOnChanged() { }
    }
}