using System.Collections.Generic;
using System.Linq;
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
    }
}
