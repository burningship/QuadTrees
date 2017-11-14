using QuadTrees.Common;
using QuadTrees.QTreeRectInt;
using UnityEngine;

namespace QuadTrees
{
    /// <summary>
    /// A QuadTree Object that provides fast and efficient storage of Rectangles in a world space, queried using Rectangles.
    /// </summary>
    /// <typeparam name="T">Any object implementing IQuadStorable.</typeparam>
    public class QuadTreeRectInt<T> : QuadTreeIntCommon<T, QuadTreeRectIntNode<T, RectInt>, RectInt> where T : IRectIntQuadStorable
    {
        public QuadTreeRectInt(RectInt rect) : base(rect)
        {
        }

        public QuadTreeRectInt(int x, int y, int width, int height)
            : base(x, y, width, height)
        {
        }

        public QuadTreeRectInt()
        {
        }

        protected override QuadTreeRectIntNode<T, RectInt> CreateNode(RectInt rect)
        {
            return new QuadTreeRectIntNode<T>(rect);
        }
    }
}
