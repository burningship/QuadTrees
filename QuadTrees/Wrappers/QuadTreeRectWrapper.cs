﻿using QuadTrees.QTreeRect;
using UnityEngine;

namespace QuadTrees.Wrappers
{
    /// <summary>
    /// A simple container for a rectangle in a QuadTree
    /// </summary>
    public struct QuadTreeRectWrapper : IRectQuadStorable
    {
        private Rect _rect;

        public Rect Rect
        {
            get { return _rect; }
        }

        public QuadTreeRectWrapper(Rect rect)
        {
            _rect = rect;
        }
    }
}
