using System.Collections.Generic;
using System.Linq;
using Microsoft.Win32.SafeHandles;
using NUnit.Framework;
using QuadTrees.QTreeVector2;
using UnityEngine;

namespace QuadTrees.Tests
{
    [TestFixture]
    public class TestPoint
    {
        class QTreeObject: IVector2QuadStorable
        {
            private Vector2 _rect;

            public Vector2 Point
            {
                get { return _rect; }
            }

            public QTreeObject(Vector2 rect)
            {
                _rect = rect;
            }
        }
        [TestCase]
        public void TestListQuery()
        {
            QuadTreeVector2<QTreeObject> qtree = new QuadTreeVector2<QTreeObject>();
            qtree.AddRange(new List<QTreeObject>
            {
                new QTreeObject(new Vector2(10,10)),
                new QTreeObject(new Vector2(-1000,1000))
            });

            var list = qtree.GetObjects(new Rect(9, 9, 20, 20));
            Assert.AreEqual(1, list.Count);
        }
        [TestCase]
        public void TestListQueryOutput()
        {
            QuadTreeVector2<QTreeObject> qtree = new QuadTreeVector2<QTreeObject>();
            qtree.AddRange(new List<QTreeObject>
            {
                new QTreeObject(new Vector2(10,10)),
                new QTreeObject(new Vector2(-1000,1000))
            }); ;

            var list = new List<QTreeObject>();
            qtree.GetObjects(new Rect(9, 9, 20, 20), list);
            Assert.AreEqual(1, list.Count);
        }
        [TestCase]
        public void TestListQueryEnum()
        {
            QuadTreeVector2<QTreeObject> qtree = new QuadTreeVector2<QTreeObject>();
            qtree.AddRange(new List<QTreeObject>
            {
                new QTreeObject(new Vector2(10,10)),
                new QTreeObject(new Vector2(-1000,1000))
            });

            var list = qtree.EnumObjects(new Rect(9, 9, 20, 20));
            Assert.AreEqual(1, list.Count());
        }
        [TestCase]
        public void TestListGetAll()
        {
            QuadTreeVector2<QTreeObject> qtree = new QuadTreeVector2<QTreeObject>();
            qtree.AddRange(new List<QTreeObject>
            {
                new QTreeObject(new Vector2(10,10)),
                new QTreeObject(new Vector2(-1000,1000))
            });

            var list = qtree.GetAllObjects();
            Assert.AreEqual(2, list.Count());
        }

        [TestCase]
        public void TestListGetPointsAt()
        {
            QuadTreeVector2<QTreeObject> qtree = new QuadTreeVector2<QTreeObject>();
            qtree.AddRange(new List<QTreeObject>
            {
                new QTreeObject(Vector2.one),
                new QTreeObject(Vector2.one)
            });

            var list = new List<QTreeObject>();
            qtree.GetObjectsAt(Vector2.one, list);

            Assert.AreEqual(2, list.Count);
        }

        [TestCase]
        public void TestListGetPointsWithin()
        {
            QuadTreeVector2<QTreeObject> qtree = new QuadTreeVector2<QTreeObject>();
            qtree.AddRange(new List<QTreeObject>
            {
                new QTreeObject(Vector2.one),
                new QTreeObject(Vector2.one)
            });
            
            var list = qtree.GetObjects(new Rect(0f, 0f, 1.1f, 1.1f));

            Assert.AreEqual(2, list.Count);
        }

        [TestCase]
        public void TestListGetPointAt()
        {
            QuadTreeVector2<QTreeObject> qtree = new QuadTreeVector2<QTreeObject>();
            qtree.AddRange(new List<QTreeObject>
            {
                new QTreeObject(Vector2.one),
                new QTreeObject(Vector2.one)
            });

            QTreeObject result = null;
            qtree.TryGetObjectAt(Vector2.one, out result);
            Assert.AreEqual(result.Point, Vector2.one);
        }

        [TestCase]
        public void TestListGetPointNotAt()
        {
            QuadTreeVector2<QTreeObject> qtree = new QuadTreeVector2<QTreeObject>();

            QTreeObject result = null;
            qtree.TryGetObjectAt(Vector2.zero, out result);
            Assert.IsNull(result);

            qtree.Add(new QTreeObject(Vector2.zero));
            qtree.TryGetObjectAt(Vector2.zero, out result);
            Assert.NotNull(result);
            Assert.AreEqual(result.Point, Vector2.zero);

            result = null;
            qtree.TryGetObjectAt(Vector2.one, out result);
            Assert.IsNull(result);

            qtree.Add(new QTreeObject(Vector2.one));
            qtree.TryGetObjectAt(Vector2.one, out result);
            Assert.NotNull(result);
            Assert.AreEqual(result.Point, Vector2.one);
        }
    }
}
