using UnityEngine;

namespace QuadTrees.QTreeVector2
{
    /// <summary>
    /// Interface to define Rect, so that QuadTree knows how to store the object.
    /// </summary>
    public interface IVector2QuadStorable
    {
        /// <summary>
        /// The Vector2 that defines the object's boundaries.
        /// </summary>
        Vector2 Point { get; }
    }
}