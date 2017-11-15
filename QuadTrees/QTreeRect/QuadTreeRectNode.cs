using QuadTrees.Common;
using QuadTrees.Helper;
using UnityEngine;

namespace QuadTrees.QTreeRect
{
    /// <summary>
    /// A QuadTree Object that provides fast and efficient storage of objects in a world space.
    /// </summary>
    /// <typeparam name="T">Any object implementing IQuadStorable.</typeparam>
    public abstract class QuadTreeRectNode<T, TQuery> : QuadTreeFloatNodeCommon<T, QuadTreeRectNode<T, TQuery>, TQuery> where T : IRectQuadStorable
    {
        public QuadTreeRectNode(Rect rect) : base(rect)
        {
        }

        public QuadTreeRectNode(int x, int y, int width, int height) : base(x, y, width, height)
        {
        }

        internal QuadTreeRectNode(QuadTreeRectNode<T, TQuery> parent, Rect rect) : base(parent, rect)
        {
        }

        protected override bool CheckContains(Rect rectangleF, T data)
        {
            return rectangleF.Contains(data.Rect);
        }
    }

    public class QuadTreeRectNode<T> : QuadTreeRectNode<T, Rect> where T : IRectQuadStorable
    {
        public QuadTreeRectNode(Rect rect) : base(rect)
        {
        }

        public QuadTreeRectNode(int x, int y, int width, int height) : base(x, y, width, height)
        {
        }

        internal QuadTreeRectNode(QuadTreeRectNode<T> parent, Rect rect) : base(parent, rect)
        {
        }
        protected override QuadTreeRectNode<T, Rect> CreateNode(Rect rectangleF)
        {
            VerifyNodeAssertions(rectangleF);
            return new QuadTreeRectNode<T>(this, rectangleF);
        }

        protected override bool CheckIntersects(Rect searchRect, T data)
        {
            return searchRect.Intersects(data.Rect);
        }

        public override bool ContainsObject(QuadTreeObject<T, QuadTreeRectNode<T, Rect>> qto)
        {
            return CheckContains(QuadRect, qto.Data);
        }

        protected override bool QueryContains(Rect search, Rect rect)
        {
            return search.Contains(rect);
        }

        protected override bool QueryIntersects(Rect search, Rect rect)
        {
            return search.Intersects(rect);
        }
        protected override Vector2 GetMortonPoint(T p)
        {
            return p.Rect.position;//todo: center?
        }

        protected override bool IsDataIntersectingPoint(T data, Vector2 point)
        {
            return data.Rect.Contains(point);
        }
    }
}