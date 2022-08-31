using System;
using System.Diagnostics;
using Dythervin.Core.Extensions;
using Dythervin.Core.Utils;
using UnityEngine;

namespace Dythervin.Data.Abstractions
{
    public abstract class ConstantSo<T> : ScriptableObject, IVarReadOnly<T>
    {
        protected const string MenuName = "Constants/";

        /// <summary>
        /// Not applicable
        /// </summary>
        public event Action OnChanged
        {
            add => throw new NotSupportedException("Constant not modifiable");
            remove => throw new NotSupportedException("Constant not modifiable");
        }

        [SerializeField]
        private T value;
        public T Value => value;
        bool IVarReadOnly.IsConst => true;

        [Conditional(Symbols.UNITY_EDITOR)]
        public virtual void SetValueEditor(T value)
        {
            this.value = value;
            this.Dirty();
        }

        public static implicit operator T(ConstantSo<T> obj)
        {
            return obj.value;
        }
    }
}