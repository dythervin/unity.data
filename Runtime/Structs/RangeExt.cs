using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Dythervin.Data.Structs
{
    public static class RangeExt
    {
        public static int GetRandom(this in Range<int> range)
        {
            return Random.Range(range.min, range.max);
        }

        public static float GetRandom(this in Range<float> range)
        {
            return Random.Range(range.min, range.max);
        }

        public static Vector3 GetRandom(this in Range<Vector3> range)
        {
            var x = new Range<float>(range.min.x, range.max.x);
            var y = new Range<float>(range.min.y, range.max.y);
            var z = new Range<float>(range.min.z, range.max.z);
            
            return new Vector3(x.GetRandom(), y.GetRandom(), z.GetRandom());
        }

        public static int Lerp(this in Range<int> range, float t)
        {
            t = math.clamp(t, 0, 1);
            return (int)math.lerp(range.min, range.max, t);
        }

        public static float Lerp(this in Range<float> range, float t)
        {
            t = math.clamp(t, 0, 1);
            return math.lerp(range.min, range.max, t);
        }

        public static int SmoothStep(this in Range<int> range, float t)
        {
            t = math.clamp(t, 0, 1);
            return (int)Mathf.SmoothStep(range.min, range.max, t);
        }

        public static float SmoothStep(this in Range<float> range, float t)
        {
            t = math.clamp(t, 0, 1);
            return Mathf.SmoothStep(range.min, range.max, t);
        }

        public static float Unlerp(this in Range<int> range, int value)
        {
            return (value - range.min) / (float)(range.max - range.min);
        }

        public static float Unlerp(this in Range<float> range, float value)
        {
            return (value - range.min) / (range.max - range.min);
        }

        public static float Clamp(this in Range<int> range, int value)
        {
            return math.clamp(value, range.min, range.max);
        }

        public static float Clamp(this in Range<float> range, float value)
        {
            return math.clamp(value, range.min, range.max);
        }

        public static int GetDelta(this in Range<int> range)
        {
            return range.max - range.min;
        }

        public static float GetDelta(this in Range<float> range)
        {
            return range.max - range.min;
        }
    }
}