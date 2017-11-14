using QuadTrees.QTreeRectInt;
using UnityEngine;

namespace QuadTrees.Wrappers
{
    /// <summary>
    /// A simple container for a rectangle in a QuadTree
    /// </summary>
    public struct QuadTreeRectIntWrapper : IRectIntQuadStorable
    {
        private RectInt _rect;

        public RectInt Rect
        {
            get { return _rect; }
        }

        public QuadTreeRectIntWrapper(RectInt rect)
        {
            _rect = rect;
        }
    }
}
