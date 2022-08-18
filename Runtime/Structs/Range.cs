#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif

namespace Dythervin.Data.Structs
{
#if ODIN_INSPECTOR
#endif

    [System.Serializable]
    public struct Range<T>
    {
#if ODIN_INSPECTOR
        [MaxValue(nameof(max))]
#endif
        public T min;

#if ODIN_INSPECTOR
        [MinValue(nameof(min))]
#endif
        public T max;

        public Range(T min, T max)
        {
            this.min = min;
            this.max = max;
        }
    }
}