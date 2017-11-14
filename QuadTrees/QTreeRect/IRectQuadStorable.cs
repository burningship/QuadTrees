using UnityEngine;

namespace QuadTrees.QTreeRect
{
    /// <summary>
    /// Interface to define Rect, so that QuadTree knows how to store the object.
    /// </summary>
    public interface IRectQuadStorable
    {
        /// <summary>
        /// The Rect that defines the object's boundaries.
        /// </summary>
        Rect Rect { get; }
    }
}