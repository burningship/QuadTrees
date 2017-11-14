using QuadTrees.Common;
using QuadTrees.QTreeRectInt;
using UnityEngine;

namespace QuadTrees
{
    /// <summary>
    /// A QuadTree Object that provides fast and efficient storage of Rectangles in a world space, queried using Rectangles.
    /// </summary>
    /// <typeparam name="T">Any object implementing IQuadStorable.</typeparam>
    public class QuadTreeRectVector2IntInverse<T> : QuadTreeIntCommon<T, QuadTreeRectIntNode<T, Vector2Int>, Vector2Int> where T : IRectIntQuadStorable
    {
        public QuadTreeRectVector2IntInverse(RectInt rect) : base(rect)
        {
        }

        public QuadTreeRectVector2IntInverse(int x, int y, int width, int height)
            : base(x, y, width, height)
        {
        }

        public QuadTreeRectVector2IntInverse()
        {
        }

        protected override QuadTreeRectIntNode<T, Vector2Int> CreateNode(RectInt rect)
        {
            return new QuadTreeRectIntPointIntInvNode<T>(rect);
        }
    }
}
