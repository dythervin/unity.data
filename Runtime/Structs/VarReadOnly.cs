using System;
using System.Runtime.InteropServices;
using Dythervin.Data.Abstractions;
using Dythervin.SerializedReference.Refs;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif
using UnityEngine;

namespace Dythervin.Data.Structs
{

    [Serializable]
    [StructLayout(LayoutKind.Auto)]
    public struct VarReadOnly<T> : IVarReadOnly<T>
    {
        [SerializeField] private bool isRef;
#if ODIN_INSPECTOR
        [HideIf(nameof(isRef))]
#endif
        [SerializeField]
        private T value;

#if ODIN_INSPECTOR
        [ShowIf(nameof(isRef))]
#endif
        [SerializeField]
        private Ref<IVarReadOnly<T>> reference;

        public event Action OnChanged
        {
            add => reference.Value.OnChanged += value;
            remove => reference.Value.OnChanged -= value;
        }

        public T Value => isRef
            ? reference.Value.Value
            : value;

        public VarReadOnly(T value)
        {
            isRef = false;
            this.value = value;
            reference = default;
        }

        public VarReadOnly(IVarReadOnly<T> value)
        {
            isRef = true;
            this.value = default;
            reference = new Ref<IVarReadOnly<T>>(value);
        }

        public static implicit operator T(in VarReadOnly<T> value)
        {
            return value.Value;
        }

        public static implicit operator VarReadOnly<T>(T value)
        {
            return new VarReadOnly<T>(value);
        }

        public bool IsConst => !isRef || reference.Value.IsConst;
    }
}