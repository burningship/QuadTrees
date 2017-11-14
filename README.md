# QuadTrees

[![Build Status](https://travis-ci.org/burningship/QuadTrees.png?branch=master)](https://travis-ci.org/burningship/QuadTrees)

High Performance Quad Tree Implementations for Unity3D C# (Vector2, Vector2Int, Rect & RectInt)

## Example

```
QuadTreeRect<QTreeObject> qtree = new QuadTreeRect<QTreeObject>();
qtree.AddRange(new List<QTreeObject>
{
	new QTreeObject(new Rect(10f,10f,10f,10f)), // Expected result
	new QTreeObject(new Rect(-1000f,1000f,10f,10f))
});

var list = new List<QTreeObject>();
qtree.GetObjects(new Rect(9f, 9f, 20f, 20f), list);
```