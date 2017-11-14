using UnityEngine;

namespace QuadTrees.QTreeVector2Int
{
    /// <summary>
    /// Interface to define Rect, so that QuadTree knows how to store the object.
    /// </summary>
    public interface IVector2IntQuadStorable
    {
        /// <summary>
        /// The Vector2 that defines the object's boundaries.
        /// </summary>
        Vector2Int Point { get; }
    }
}