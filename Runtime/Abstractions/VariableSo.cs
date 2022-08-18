﻿using System;
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
                    PersistentValue = value;

                this.value = value;
                onChanged.Invoke(value);
                OnChanged?.Invoke();
            }
        }

#if !UNITY_2021_4_OR_NEWER
        bool IVarReadOnly.IsConst=> false;
#endif
        protected T PersistentValue
        {
            get => _pref;
            set => _pref.Value = value;
        }

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
                PersistentValue = value;
        }

        protected virtual void OnEnterPlayMode()
        {
            if (persistent)
            {
                _pref = Prefs.Default.Get<T>($"VariableSo-{Id.ToString()}");
                value = PersistentValue;
            }
            else if (hasDefaultValue)
            {
                value = defaultValue;
            }
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            this.TryEnterPlayMode();
        }
    }
}