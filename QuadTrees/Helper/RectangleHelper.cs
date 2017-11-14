using UnityEngine;

namespace QuadTrees.Helper
{
    internal static class RectangleHelper
    {
        public static bool Intersects(this Rect a, Rect b)
        {
            if (b.x < a.xMax && a.x < b.xMax && b.y < a.yMax)
                return a.y < b.yMax;
            return false;
        }
        public static bool Intersects(this RectInt a, RectInt b)
        {
            if (b.x < a.xMax && a.x < b.xMax && b.y < a.yMax)
                return a.y < b.yMax;
            return false;
        }

        public static bool IntersectsWith(this Rect a, Rect b)
        {
            return a.x < b.xMax && a.xMax > b.x && a.y < b.yMax && a.yMax > b.y;
        }
        public static bool IntersectsWith(this RectInt a, RectInt b)
        {
            return a.x < b.xMax && a.xMax > b.x && a.y < b.yMax && a.yMax > b.y;
        }

        public static bool Contains(this Rect a, Rect b)
        {
            if (b.x > a.x && b.xMax < a.xMax && b.y > a.y)
                return b.yMax < a.yMax;
            return false;
        }
        public static bool Contains(this RectInt a, RectInt b)
        {
            if (b.x > a.x && b.xMax < a.xMax && b.y > a.y)
                return b.yMax < a.yMax;
            return false;
        }

        public static bool Contains(this RectInt a, Vector2Int point)
        {
            return point.x < a.xMax && point.x > a.xMin && point.y < a.yMax && point.y > a.yMin;
        }
    }
}