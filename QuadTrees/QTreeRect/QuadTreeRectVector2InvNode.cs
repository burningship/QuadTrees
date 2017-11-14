using QuadTrees.Common;
using UnityEngine;

namespace QuadTrees.QTreeRect
{

    public class QuadTreeRectVector2InvNode<T> : QuadTreeRectNode<T, Vector2> where T : IRectQuadStorable
    {
        public QuadTreeRectVector2InvNode(Rect rect) : base(rect)
        {
        }

        public QuadTreeRectVector2InvNode(int x, int y, int width, int height) : base(x, y, width, height)
        {
        }

        internal QuadTreeRectVector2InvNode(QuadTreeRectNode<T, Vector2> parent, Rect rect)
            : base(parent, rect)
        {
        }
        protected override QuadTreeRectNode<T, Vector2> CreateNode(Rect rectangleF)
        {
            VerifyNodeAssertions(rectangleF);
            return new QuadTreeRectVector2InvNode<T>(this, rectangleF);
        }

        protected override bool CheckIntersects(Vector2 searchRect, T data)
        {
            return data.Rect.Contains(searchRect);
        }

        public override bool ContainsObject(QuadTreeObject<T, QuadTreeRectNode<T, Vector2>> qto)
        {
            return CheckContains(QuadRect, qto.Data);
        }

        protected override bool QueryContains(Vector2 search, Rect rect)
        {
            return false;
        }

        protected override bool QueryIntersects(Vector2 search, Rect rect)
        {
            return rect.Contains(search);
        }

        protected override Vector2 GetMortonPoint(T p)
        {
            return p.Rect.position;//todo: center?
        }
    }
}