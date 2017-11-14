using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using QuadTrees.QTreeRect;
using UnityEngine;

namespace QuadTrees.Tests
{
    [TestFixture]
    public class TestRectPoint
    {
        class QTreeObject : IRectQuadStorable
        {
            private Rect _rect;

            public Rect Rect
            {
                get { return _rect; }
            }

            public QTreeObject(Rect rect)
            {
                _rect = rect;
            }
        }
        [TestCase]
        public void TestListQuery()
        {
            QuadTreeRectPointFInverse<QTreeObject> qtree = new QuadTreeRectPointFInverse<QTreeObject>();
            qtree.AddRange(new List<QTreeObject>
            {
                new QTreeObject(new Rect(10,10,10,10)),
                new QTreeObject(new Rect(-1000,1000,10,10))
            });

            var list = qtree.GetObjects(new Vector2(11,11));
            Assert.AreEqual(1, list.Count);
        }
        [TestCase]
        public void TestListQueryOutput()
        {
            var list = new List<QTreeObject>();
            QuadTreeRectPointFInverse<QTreeObject> qtree = new QuadTreeRectPointFInverse<QTreeObject>();
            qtree.AddRange(new List<QTreeObject>
            {
                new QTreeObject(new Rect(10,10,10,10)),
                new QTreeObject(new Rect(-1000,1000,10,10))
            });

            qtree.GetObjects(new Vector2(11, 11), list);
            Assert.AreEqual(1, list.Count);
        }
        [TestCase]
        public void TestListQueryEnum()
        {
            QuadTreeRectPointFInverse<QTreeObject> qtree = new QuadTreeRectPointFInverse<QTreeObject>();
            qtree.AddRange(new List<QTreeObject>
            {
                new QTreeObject(new Rect(10,10,10,10)),
                new QTreeObject(new Rect(-1000,1000,10,10))
            });

            var list = qtree.EnumObjects(new Vector2(11, 11));
            Assert.AreEqual(1, list.Count());
        }
        [TestCase]
        public void TestListGetAll()
        {
            QuadTreeRectPointFInverse<QTreeObject> qtree = new QuadTreeRectPointFInverse<QTreeObject>();
            qtree.AddRange(new List<QTreeObject>
            {
                new QTreeObject(new Rect(10,10,10,10)),
                new QTreeObject(new Rect(-1000,1000,10,10))
            });

            var list = qtree.GetAllObjects();
            Assert.AreEqual(2, list.Count());
        }
    }
}
