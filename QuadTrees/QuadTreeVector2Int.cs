using QuadTrees.Common;
using QuadTrees.QTreeVector2Int;
using UnityEngine;

namespace QuadTrees
{
    /// <summary>
    /// A QuadTree Object that provides fast and efficient storage of Points in a world space, queried using Rectangles.
    /// </summary>
    /// <typeparam name="T">Any object implementing IQuadStorable.</typeparam>
    public class QuadTreeVector2Int<T> : QuadTreeIntCommon<T, QuadTreeVector2IntNode<T>, RectInt> where T : IVector2IntQuadStorable
    {
        public QuadTreeVector2Int(RectInt rect)
            : base(rect)
        {
        }

        public QuadTreeVector2Int(int x, int y, int width, int height)
            : base(x, y, width, height)
        {
        }

        public QuadTreeVector2Int()
            : base()
        {

        }

        protected override QuadTreeVector2IntNode<T> CreateNode(RectInt rect)
        {
            return new QuadTreeVector2IntNode<T>(rect);
        }
    }
}
