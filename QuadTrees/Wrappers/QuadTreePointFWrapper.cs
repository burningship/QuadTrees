using QuadTrees.QTreeVector2;
using UnityEngine;

namespace QuadTrees.Wrappers
{
    /// <summary>
    /// A simple container for a point in a QuadTree
    /// </summary>
    public struct QuadTreeVector2Wrapper: IVector2QuadStorable
    {
        private Vector2 _point;

        public Vector2 Point
        {
            get { return _point; }
        }

        public QuadTreeVector2Wrapper(Vector2 point)
        {
            _point = point;
        }
    }
}
