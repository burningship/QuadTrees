using QuadTrees.Common;
using UnityEngine;

namespace QuadTrees.QTreeRectInt
{

    public class QuadTreeRectIntPointIntInvNode<T> : QuadTreeRectIntNode<T, Vector2Int> where T : IRectIntQuadStorable
    {
        public QuadTreeRectIntPointIntInvNode(RectInt rect) : base(rect)
        {
        }

        public QuadTreeRectIntPointIntInvNode(int x, int y, int width, int height) : base(x, y, width, height)
        {
        }

        internal QuadTreeRectIntPointIntInvNode(QuadTreeRectIntNode<T, Vector2Int> parent, RectInt rect)
            : base(parent, rect)
        {
        }
        protected override QuadTreeRectIntNode<T, Vector2Int> CreateNode(RectInt rectangleF)
        {
            VerifyNodeAssertions(rectangleF);
            return new QuadTreeRectIntPointIntInvNode<T>(this, rectangleF);
        }

        protected override bool CheckIntersects(Vector2Int searchRect, T data)
        {
            return data.Rect.Contains(searchRect);
        }

        public override bool ContainsObject(QuadTreeObject<T, QuadTreeRectIntNode<T, Vector2Int>> qto)
        {
            return CheckContains(QuadRect, qto.Data);
        }

        protected override bool QueryContains(Vector2Int search, RectInt rect)
        {
            return false;
        }

        protected override bool QueryIntersects(Vector2Int search, RectInt rect)
        {
            return rect.Contains(search);
        }

        protected override Vector2Int GetMortonPoint(T p)
        {
            return p.Rect.position;//todo: center?
        }
    }
}