using QuadTrees.Common;
using QuadTrees.Helper;
using UnityEngine;

namespace QuadTrees.QTreeRectInt
{
    /// <summary>
    /// A QuadTree Object that provides fast and efficient storage of objects in a world space.
    /// </summary>
    /// <typeparam name="T">Any object implementing IQuadStorable.</typeparam>
    public abstract class QuadTreeRectIntNode<T, TQuery> : QuadTreeIntNodeCommon<T, QuadTreeRectIntNode<T, TQuery>, TQuery> where T : IRectIntQuadStorable
    {
        public QuadTreeRectIntNode(RectInt rect) : base(rect)
        {
        }

        public QuadTreeRectIntNode(int x, int y, int width, int height) : base(x, y, width, height)
        {
        }

        internal QuadTreeRectIntNode(QuadTreeRectIntNode<T, TQuery> parent, RectInt rect) : base(parent, rect)
        {
        }

        protected override bool CheckContains(RectInt rectangle, T data)
        {
            return rectangle.Contains(data.Rect);
        }
    }

    public class QuadTreeRectIntNode<T> : QuadTreeRectIntNode<T, RectInt> where T : IRectIntQuadStorable
    {
        public QuadTreeRectIntNode(RectInt rect) : base(rect)
        {
        }

        public QuadTreeRectIntNode(int x, int y, int width, int height) : base(x, y, width, height)
        {
        }

        internal QuadTreeRectIntNode(QuadTreeRectIntNode<T> parent, RectInt rect) : base(parent, rect)
        {
        }
        protected override QuadTreeRectIntNode<T, RectInt> CreateNode(RectInt Rectangle)
        {
            VerifyNodeAssertions(Rectangle);
            return new QuadTreeRectIntNode<T>(this, Rectangle);
        }

        protected override bool CheckIntersects(RectInt searchRect, T data)
        {
            return searchRect.IntersectsWith(data.Rect);
        }

        public override bool ContainsObject(QuadTreeObject<T, QuadTreeRectIntNode<T, RectInt>> qto)
        {
            return CheckContains(QuadRect, qto.Data);
        }

        protected override bool QueryContains(RectInt search, RectInt rect)
        {
            return search.Contains(rect);
        }

        protected override bool QueryIntersects(RectInt search, RectInt rect)
        {
            return search.IntersectsWith(rect);
        }
        protected override Vector2Int GetMortonPoint(T p)
        {
            return p.Rect.position;//todo: center?
        }
    }
}