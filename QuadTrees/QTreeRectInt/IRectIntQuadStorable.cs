using UnityEngine;

namespace QuadTrees.QTreeRectInt
{
    /// <summary>
    /// Interface to define Rect, so that QuadTree knows how to store the object.
    /// </summary>
    public interface IRectIntQuadStorable
    {
        /// <summary>
        /// The Rect that defines the object's boundaries.
        /// </summary>
        RectInt Rect { get; }
    }
}