using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using QuadTrees.QTreeRect;
using UnityEngine;
using Random = System.Random;

namespace QuadTrees.Tests
{
    [TestFixture]
    public class TestRectangle
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
            QuadTreeRect<QTreeObject> qtree = new QuadTreeRect<QTreeObject>();
            qtree.AddRange(new List<QTreeObject>
            {
                new QTreeObject(new Rect(10,10,10,10)),
                new QTreeObject(new Rect(-1000,1000,10,10))
            });

            var list = qtree.GetObjects(new Rect(9, 9, 20, 20));
            Assert.AreEqual(1, list.Count);
        }
        [TestCase]
        public void TestListQueryOutput()
        {
            QuadTreeRect<QTreeObject> qtree = new QuadTreeRect<QTreeObject>();
            qtree.AddRange(new List<QTreeObject>
            {
                new QTreeObject(new Rect(10,10,10,10)),
                new QTreeObject(new Rect(-1000,1000,10,10))
            });

            var list = new List<QTreeObject>();
            qtree.GetObjects(new Rect(9, 9, 20, 20), list);
            Assert.AreEqual(1, list.Count);
        }
        [TestCase]
        public void TestListQueryEnum()
        {
            QuadTreeRect<QTreeObject> qtree = new QuadTreeRect<QTreeObject>();
            qtree.AddRange(new List<QTreeObject>
            {
                new QTreeObject(new Rect(10,10,10,10)),
                new QTreeObject(new Rect(-1000,1000,10,10))
            });

            var list = qtree.EnumObjects(new Rect(9, 9, 20, 20));
            Assert.AreEqual(1, list.Count());
        }
        [TestCase]
        public void TestListGetAll()
        {
            QuadTreeRect<QTreeObject> qtree = new QuadTreeRect<QTreeObject>();
            qtree.AddRange(new List<QTreeObject>
            {
                new QTreeObject(new Rect(10,10,10,10)),
                new QTreeObject(new Rect(-1000,1000,10,10))
            });

            var list = qtree.GetAllObjects();
            Assert.AreEqual(2, list.Count());
        }
        [TestCase]
        public void TestAddMany()
        {
            Random r = new Random(1000);
            QuadTreeRect<QTreeObject> qtree = new QuadTreeRect<QTreeObject>();
            for (int i = 0; i < 10000; i++)
            {
                qtree.Add(new QTreeObject(new Rect(r.Next(0, 1000) / 1000f, r.Next(0, 1000) / 1000f, r.Next(1000, 20000) / 1000f, r.Next(1000, 20000) / 1000f)));
            }

            var result = qtree.GetObjects(new Rect(-100, -100, 200, 200));
            Assert.AreEqual(result.Distinct().Count(), result.Count);

            result = qtree.GetObjects(new Rect(-.100f, -.100f, .200f, .200f));
            Assert.AreEqual(result.Distinct().Count(), result.Count);
        }

        [TestCase]
        public void TestBulkAddManyThreaded()
        {
            Random r = new Random(1000);
            QuadTreeRect<QTreeObject> qtree = new QuadTreeRect<QTreeObject>();
            List<QTreeObject> list = new List<QTreeObject>();
            for (int i = 0; i < 10000; i++)
            {
                list.Add(new QTreeObject(new Rect(r.Next(0, 1000) / 1000f, r.Next(0, 1000) / 1000f, r.Next(1000, 20000) / 1000f, r.Next(1000, 20000) / 1000f)));
            }
            qtree.AddBulk(list, 1);

            var result = qtree.GetObjects(new Rect(-100, -100, 200, 200));
            Assert.AreEqual(result.Distinct().Count(), result.Count);

            result = qtree.GetObjects(new Rect(-.100f, -.100f, .200f, .200f));
            Assert.AreEqual(result.Distinct().Count(), result.Count);
        }

        [TestCase]
        public void TestBulkAddMany()
        {
            Random r = new Random(1000);
            QuadTreeRect<QTreeObject> qtree = new QuadTreeRect<QTreeObject>();
            List<QTreeObject> list = new List<QTreeObject>();
            for (int i = 0; i < 10000; i++)
            {
                list.Add(new QTreeObject(new Rect(r.Next(0, 1000) / 1000f, r.Next(0, 1000) / 1000f, r.Next(1000, 20000) / 1000f, r.Next(1000, 20000) / 1000f)));
            }
            qtree.AddBulk(list);

            var result = qtree.GetObjects(new Rect(-100, -100, 200, 200));
            Assert.AreEqual(result.Distinct().Count(), result.Count);

            result = qtree.GetObjects(new Rect(-.100f, -.100f, .200f, .200f));
            Assert.AreEqual(result.Distinct().Count(), result.Count);
        }

        [TestCase]
        public void TestAddManySame()
        {
            QuadTreeRect<QTreeObject> qtree = new QuadTreeRect<QTreeObject>();
            List<QTreeObject> list = new List<QTreeObject>();
            for (int i = 0; i < 10000; i++)
            {
                list.Add(new QTreeObject(new Rect(1, 1, 1, 1)));
            }
            qtree.AddRange(list);

            var result = qtree.GetObjects(new Rect(-100, -100, 200, 200));
            Assert.AreEqual(result.Distinct().Count(), result.Count);
            Assert.AreEqual(10000, result.Count);
        }

        [TestCase]
        public void TestBulkAddManySame()
        {
            QuadTreeRect<QTreeObject> qtree = new QuadTreeRect<QTreeObject>();
            List<QTreeObject> list = new List<QTreeObject>();
            for (int i = 0; i < 10000; i++)
            {
                list.Add(new QTreeObject(new Rect(1, 1, 1, 1)));
            }
            qtree.AddBulk(list);

            var result = qtree.GetObjects(new Rect(-100, -100, 200, 200));
            Assert.AreEqual(result.Distinct().Count(), result.Count);
            Assert.AreEqual(10000, result.Count);
        }

        [TestCase]
        public void TestAddSameIndividual()
        {
            QuadTreeRect<QTreeObject> qtree = new QuadTreeRect<QTreeObject>();
            List<QTreeObject> list = new List<QTreeObject>();
            for (int i = 0; i < 10000; i++)
            {
                qtree.Add(new QTreeObject(new Rect(1, 1, 1, 1)));
            }

            var result = qtree.GetObjects(new Rect(-100, -100, 200, 200));
            Assert.AreEqual(result.Distinct().Count(), result.Count);
            Assert.AreEqual(10000, result.Count);
        }
    }
}
