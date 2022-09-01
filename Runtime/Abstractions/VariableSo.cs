using System;
using System.Collections.Generic;
using Dythervin.AssetIdentifier;
using Dythervin.Callbacks;
using Dythervin.PersistentData;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif
using UnityEngine;
using UnityEngine.Events;

namespace Dythervin.Data.Abstractions
{
    [AssetGroup("VariableSO")]
    public abstract class VariableSo<T> : DataObject, IVar<T>, IPlayModeListener
    {
        public const string MenuName = "Var/";
        [Space] [SerializeField] private bool persistent;

#if ODIN_INSPECTOR
        [HideIf(nameof(persistent))]
#endif
        [SerializeField]
        private bool hasDefaultValue;

#if ODIN_INSPECTOR
        [ShowIf("@" + nameof(hasDefaultValue) + "||" + nameof(persistent))]
#endif
        [SerializeField]
        protected T defaultValue;

        [Space] [SerializeField] private UnityEvent<T> onChanged;

#if ODIN_INSPECTOR
        [ShowInInspector] [ReadOnly]
#endif
        protected T value;
        private Pref<T> _pref;
        public event Action OnChanged;

        public T Value
        {
            get => value;
            set
            {
                if (EqualityComparer<T>.Default.Equals(this.value, value))
                    return;

                if (persistent)
                    _pref.Value = value;

                this.value = value;
                onChanged.Invoke(value);
                OnChanged?.Invoke();
            }
        }

#if !UNITY_2021_4_OR_NEWER
        bool IVarReadOnly.IsConst=> false;
#endif

        bool IPlayModeListener.MainThreadOnly => true;

        void IPlayModeListener.OnEnterPlayMode()
        {
            OnEnterPlayMode();
        }

        public static implicit operator T(VariableSo<T> value)
        {
            return value.Value;
        }

        protected virtual void OnDestroy()
        {
            if (persistent)
                _pref.Value = value;
        }

        protected virtual void OnEnterPlayMode()
        {
            if (persistent)
            {
                _pref = Prefs.Default.Get($"VariableSo-{Id.ToString()}", defaultValue);
                value = _pref;
            }
            else if (hasDefaultValue)
            {
                value = defaultValue;
            }
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            this.PlayModeSubscribe();
        }
    }
}