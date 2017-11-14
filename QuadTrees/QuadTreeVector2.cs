using QuadTrees.Common;
using QuadTrees.QTreeVector2;
using UnityEngine;

namespace QuadTrees
{
    /// <summary>
    /// A QuadTree Object that provides fast and efficient storage of Points in a world space, queried using Rectangles.
    /// </summary>
    /// <typeparam name="T">Any object implementing IQuadStorable.</typeparam>
    public class QuadTreeVector2<T> : QuadTreeFloatCommon<T, QuadTreeVector2Node<T>, Rect> where T : IVector2QuadStorable
    {
        public QuadTreeVector2(Rect rect)
            : base(rect)
        {
        }

        public QuadTreeVector2(float x, float y, float width, float height)
            : base(x, y, width, height)
        {
        }

        public QuadTreeVector2()
            : base()
        {

        }

        protected override QuadTreeVector2Node<T> CreateNode(Rect rect)
        {
            return new QuadTreeVector2Node<T>(rect);
        }
    }
}
