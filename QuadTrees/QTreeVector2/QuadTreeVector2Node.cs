using QuadTrees.Common;
using UnityEngine;

namespace QuadTrees.QTreeVector2
{
    /// <summary>
    /// A QuadTree Object that provides fast and efficient storage of objects in a world space.
    /// </summary>
    /// <typeparam name="T">Any object implementing IQuadStorable.</typeparam>
    public class QuadTreeVector2Node<T> : QuadTreeFloatNodeCommon<T, QuadTreeVector2Node<T>> where T : IVector2QuadStorable
    {
        public QuadTreeVector2Node(Rect rect)
            : base(rect)
        {
        }

        public QuadTreeVector2Node(float x, float y, float width, float height)
            : base(x, y, width, height)
        {
        }

        internal QuadTreeVector2Node(QuadTreeVector2Node<T> parent, Rect rect)
            : base(parent, rect)
        {
        }

        protected override QuadTreeVector2Node<T> CreateNode(Rect Rect)
        {
            VerifyNodeAssertions(Rect);
            return new QuadTreeVector2Node<T>(this, Rect);
        }

        protected override bool CheckContains(Rect Rect, T data)
        {
            return Rect.Contains(data.Point);
        }

        public override bool ContainsObject(QuadTreeObject<T, QuadTreeVector2Node<T>> qto)
        {
            return CheckContains(QuadRect, qto.Data);
        }

        protected override bool CheckIntersects(Rect searchRect, T data)
        {
            return CheckContains(searchRect, data);
        }


        protected override Vector2 GetMortonPoint(T p)
        {
            return p.Point;
        }
        protected override bool IsDataIntersectingPoint(T data, Vector2 point)
        {
            return Vector2.SqrMagnitude(data.Point - point) < Mathf.Epsilon;
            //return data.Point.x == point.x && data.Point.y == point.y;
        }
    }
}