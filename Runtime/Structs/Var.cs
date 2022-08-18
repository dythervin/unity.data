using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Dythervin.Data.Abstractions;
using Dythervin.SerializedReference.Refs;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif
using UnityEngine;

namespace Dythervin.Data.Structs
{
#if ODIN_INSPECTOR
#endif

    [Serializable]
    [StructLayout(LayoutKind.Auto)]
    public struct NumInt : IVar<int>, INumFloat
    {
        [SerializeField] private bool reference;
#if ODIN_INSPECTOR
        [HideIf(nameof(reference))]
#endif
        [SerializeField]
        private int value;

#if ODIN_INSPECTOR
        [ShowIf(nameof(reference))]
#endif
        [SerializeField]
        private Ref<IVar<int>> refValue;

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

        public int Value
        {
            get => reference
                ? refValue.Value.Value
                : value;
            set
            {
                if (reference)
                {
                    refValue.Value.Value = value;
                }
                else
                {
                    this.value = value;
                    onChanged?.Invoke();
                }
            }
        }

        float IVarReadOnly<float>.Value => Value;

#if !UNITY_2021_4_OR_NEWER
        bool IVarReadOnly.IsConst => false;
#endif

        public NumInt(int value)
        {
            reference = false;
            this.value = value;
            refValue = default;
            onChanged = null;
        }

        public NumInt(IVar<int> value)
        {
            reference = true;
            this.value = default;
            refValue = new Ref<IVar<int>>(value);
            onChanged = null;
        }

        public static implicit operator int(in NumInt value)
        {
            return value.Value;
        }

        public static implicit operator NumInt(int value)
        {
            return new NumInt(value);
        }
    }


    [Serializable]
    [StructLayout(LayoutKind.Auto)]
    public struct NumFloat : IVar<float>, INumFloat
    {
        [SerializeField] private bool reference;
#if ODIN_INSPECTOR
        [HideIf(nameof(reference))]
#endif
        [SerializeField]
        private float value;

#if ODIN_INSPECTOR
        [ShowIf(nameof(reference))]
#endif
        [SerializeField]
        private Ref<IVar<float>> refValue;

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

        public float Value
        {
            get => reference
                ? refValue.Value.Value
                : value;
            set
            {
                if (reference)
                {
                    refValue.Value.Value = value;
                }
                else
                {
                    this.value = value;
                    onChanged?.Invoke();
                }
            }
        }

        float IVarReadOnly<float>.Value => Value;

#if !UNITY_2021_4_OR_NEWER
        bool IVarReadOnly.IsConst => false;
#endif
        public NumFloat(float value)
        {
            reference = false;
            this.value = value;
            refValue = default;
            onChanged = null;
        }

        public NumFloat(IVar<float> value)
        {
            reference = true;
            this.value = default;
            refValue = new Ref<IVar<float>>(value);
            onChanged = null;
        }

        public static implicit operator float(in NumFloat value)
        {
            return value.Value;
        }

        public static implicit operator NumFloat(float value)
        {
            return new NumFloat(value);
        }
    }


    [Serializable]
    [StructLayout(LayoutKind.Auto)]
    public struct Var<T> : IVar<T>
    {
        [SerializeField] private bool reference;
#if ODIN_INSPECTOR
        [HideIf(nameof(reference))]
#endif
        [SerializeField]
        private T value;

#if ODIN_INSPECTOR
        [ShowIf(nameof(reference))]
#endif
        [SerializeField]
        private Ref<IVar<T>> refValue;

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

        public T Value
        {
            get => reference
                ? refValue.Value.Value
                : value;
            set
            {
                if (EqualityComparer<T>.Default.Equals(Value, value))
                    return;

                if (reference)
                {
                    refValue.Value.Value = value;
                }
                else
                {
                    this.value = value;
                    onChanged?.Invoke();
                }
            }
        }


#if !UNITY_2021_4_OR_NEWER
        bool IVarReadOnly.IsConst => false;
#endif
        public Var(T value)
        {
            reference = false;
            this.value = value;
            refValue = default;
            onChanged = null;
        }

        public Var(IVar<T> value)
        {
            reference = true;
            this.value = default;
            refValue = new Ref<IVar<T>>(value);
            onChanged = null;
        }

        public static implicit operator T(in Var<T> value)
        {
            return value.Value;
        }

        public static implicit operator Var<T>(T value)
        {
            return new Var<T>(value);
        }
    }
}