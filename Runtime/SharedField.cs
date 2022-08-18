using System;
using System.Collections.Generic;
using Dythervin.Data.Abstractions;
using UnityEngine;

namespace Dythervin.Data
{
    [Serializable]
    public class SharedField<T> : IVar<T>, IVarStruct<T>
    {
        public event Action OnChanged;

        [SerializeField]
        private T value;

        public ref readonly T ValueRef => ref value;
        public T Value
        {
            get => value;
            set => SetValue(value);
        }

        public bool IsConst => false;

        public void SetValue(in T value)
        {
            if (EqualityComparer<T>.Default.Equals(this.value, value))
                return;

            this.value = value;
            OnChanged?.Invoke();
        }
    }
}