using System;
using System.Collections.Generic;
using Dythervin.Data.Abstractions;
using UnityEngine;
using UnityEngine.Events;

namespace Dythervin.Data.Objects
{
    public abstract class VarComponent<T> : MonoBehaviour, IVar<T>
        where T : IEquatable<T>
    {
        [SerializeField] private T value;

        [Space] [SerializeField] private UnityEvent<T> onChanged;

        public event Action OnChanged;

        public T Value
        {
            get => value;
            set
            {
                if (EqualityComparer<T>.Default.Equals(this.value, value))
                    return;

                this.value = value;
                onChanged.Invoke(value);
                OnChanged?.Invoke();
            }
        }

#if !UNITY_2021_4_OR_NEWER
        bool IVarReadOnly.IsConst => false;
#endif
        public static implicit operator T(VarComponent<T> value)
        {
            return value.Value;
        }

        protected virtual void Awake() { }
    }
}