using QuadTrees.Common;
using UnityEngine;

namespace QuadTrees.QTreeVector2Int
{
    /// <summary>
    /// A QuadTree Object that provides fast and efficient storage of objects in a world space.
    /// </summary>
    /// <typeparam name="T">Any object implementing IQuadStorable.</typeparam>
    public class QuadTreeVector2IntNode<T> : QuadTreeIntNodeCommon<T, QuadTreeVector2IntNode<T>> where T : IVector2IntQuadStorable
    {
        public QuadTreeVector2IntNode(RectInt rect)
            : base(rect)
        {
        }

        public QuadTreeVector2IntNode(int x, int y, int width, int height)
            : base(x, y, width, height)
        {
        }

        internal QuadTreeVector2IntNode(QuadTreeVector2IntNode<T> parent, RectInt rect)
            : base(parent, rect)
        {
        }

        protected override QuadTreeVector2IntNode<T> CreateNode(RectInt Rect)
        {
            VerifyNodeAssertions(Rect);
            return new QuadTreeVector2IntNode<T>(this, Rect);
        }

        protected override bool CheckContains(RectInt Rect, T data)
        {
            if (Rect.width == 0 && Rect.height == 0)
            {
                return data.Point == Rect.position;
            }
            return Rect.Contains(data.Point);
        }

        public override bool ContainsObject(QuadTreeObject<T, QuadTreeVector2IntNode<T>> qto)
        {
            return CheckContains(QuadRect, qto.Data);
        }

        protected override bool CheckIntersects(RectInt searchRect, T data)
        {
            return CheckContains(searchRect, data);
        }

        protected override Vector2Int GetMortonPoint(T p)
        {
            return p.Point;
        }
    }
}