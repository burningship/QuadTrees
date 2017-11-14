using QuadTrees.Common;
using QuadTrees.QTreeRect;
using UnityEngine;

namespace QuadTrees
{
    /// <summary>
    /// A QuadTree Object that provides fast and efficient storage of Rectangles in a world space, queried using Rectangles.
    /// </summary>
    /// <typeparam name="T">Any object implementing IQuadStorable.</typeparam>
    public class QuadTreeRect<T> : QuadTreeFloatCommon<T, QuadTreeRectNode<T, Rect>, Rect> where T : IRectQuadStorable
    {
        public QuadTreeRect(Rect rect) : base(rect)
        {
        }

        public QuadTreeRect(float x, float y, float width, float height) : base(x, y, width, height)
        {
        }

        public QuadTreeRect()
        {
        }

        protected override QuadTreeRectNode<T, Rect> CreateNode(Rect rect)
        {
            return new QuadTreeRectNode<T>(rect);
        }
    }
}
