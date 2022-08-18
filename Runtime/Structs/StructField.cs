using System;
using Dythervin.Data.Abstractions;
using Dythervin.SerializedReference.Refs;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif
using UnityEngine;

namespace Dythervin.Data.Structs
{
    [Serializable]
    public class StructField<T> : IVarStruct<T>, IVar<T>
    {
        [SerializeField] private bool reference;
        [SerializeField] private bool readOnly;

#if ODIN_INSPECTOR
        [HideIf(nameof(reference))]
#endif
        [SerializeField] private T value;

#if ODIN_INSPECTOR
        [ShowIf(nameof(reference))]
#endif
        [SerializeField] private Ref<IVarStruct<T>> refValue;

        private Action onChanged;

        public event Action OnChanged
        {
            add
            {
                if (reference)
                    refValue.Value.OnChanged += value;
                else
                    onChanged += value;
            }

            remove
            {
                if (reference)
                    refValue.Value.OnChanged -= value;
                else
                    onChanged -= value;
            }
        }

        public ref readonly T ValueRef => ref reference ? ref refValue.Value.ValueRef : ref value;

        public T Value
        {
            get => ValueRef;
            set => SetValue(value);
        }


        public void SetValue(in T value)
        {
            if (readOnly)
                return;

            if (reference)
            {
                refValue.Value.SetValue(value);
            }
            else
            {
                this.value = value;
                onChanged?.Invoke();
            }
        }

        public StructField(T value, bool readOnly = false)
        {
            reference = false;
            this.readOnly = readOnly;
            this.value = value;
            refValue = default;
            onChanged = null;
        }

        public static implicit operator T(StructField<T> value)
        {
            return value.ValueRef;
        }

        public static implicit operator StructField<T>(T value)
        {
            return new StructField<T>(value);
        }

        public bool IsConst => false;
    }
}