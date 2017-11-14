using QuadTrees.Common;
using QuadTrees.QTreeRect;
using UnityEngine;

namespace QuadTrees
{
    /// <summary>
    /// A QuadTree Object that provides fast and efficient storage of Rectangles in a world space, queried using Rectangles.
    /// </summary>
    /// <typeparam name="T">Any object implementing IQuadStorable.</typeparam>
    public class QuadTreeRectVector2Inverse<T> : QuadTreeFloatCommon<T, QuadTreeRectNode<T, Vector2>, Vector2> where T : IRectQuadStorable
    {
        public QuadTreeRectVector2Inverse(Rect rect) : base(rect)
        {
        }

        public QuadTreeRectVector2Inverse(float x, float y, float width, float height) : base(x, y, width, height)
        {
        }

        public QuadTreeRectVector2Inverse()
        {
        }

        protected override QuadTreeRectNode<T, Vector2> CreateNode(Rect rect)
        {
            return new QuadTreeRectVector2InvNode<T>(rect);
        }
    }
}
