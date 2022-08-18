using System.Collections.Generic;
using Dythervin.AssetIdentifier;
using Dythervin.Core.Extensions;
using UnityEngine;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif

namespace Dythervin.Data.Objects
{
    [CreateAssetMenu(menuName = "Enum")]
    [AssetGroup("Enum")]
    public sealed class EnumAsset : DataObject
    {
#if UNITY_EDITOR
        private enum Type
        {
            Bool,
            Enum
        }

#if ODIN_INSPECTOR
        [OnValueChanged(nameof(OnTypeChanged))]
#endif
        [SerializeField]
        private Type type;

#if ODIN_INSPECTOR
        [ShowIf(nameof(type), Type.Enum)]
        [ListDrawerSettings(DraggableItems = false)]
#endif
        [SerializeField]
        private List<string> values;

        private static readonly string[] BoolValues = { "false", "true" };
        private static readonly string[] EnumValues = { "None" };

        public string this[int index] => values[index];

        public int Count => values.Count;

        private void Awake()
        {
            values = values ?? new List<string>();
            if (values.Count == 0)
            {
                OnTypeChanged();
                this.Dirty();
            }
        }

        private void OnTypeChanged()
        {
            switch (type)
            {
                case Type.Bool:
                    values.Clear();
                    foreach (string value in BoolValues)
                    {
                        values.Add(value);
                    }

                    break;
                case Type.Enum:
                    values.Clear();
                    foreach (string value in EnumValues)
                    {
                        values.Add(value);
                    }

                    break;
            }
        }
#endif
#if ODIN_INSPECTOR
        private static readonly ValueDropdownList<byte> Buffer = new ValueDropdownList<byte>();

        public ValueDropdownList<byte> Values
        {
            get
            {
#if UNITY_EDITOR
                Buffer.Clear();
                for (byte i = 0; i < values.Count; i++)
                {
                    Buffer.Add(values[i], i);
                }
#endif

                return Buffer;
            }
        }
#endif
    }
}