# BinaryTree

![BinaryTree](https://github.com/pkirilin/BinaryTree/workflows/BinaryTree/badge.svg?branch=master)

## Introduction

This is the generic binary search tree implementation created for educational purposes.
It can store any data as a tree node value, but it must implement `IComparable<T>` interface.

## Usage

### Create a binary tree

```csharp
var tree = new BinaryTree<int>();
```

### Insert values into the tree

```csharp
tree.Insert(50);
tree.Insert(70);
tree.Insert(20);
tree.Insert(60);
tree.Insert(10);
tree.Insert(30);
tree.Insert(15);

// It will look like this:
//
//             50
//            /  \
//           /    \
//          /      \
//         /        \
//        20        70
//       /  \      /
//      /    \    /
//     10    30  60
//       \
//       15
```

### Walk the tree

#### In-order traversal

```csharp
tree.TraversalInOrder(node =>
{
    // Do something with each tree node
    // 10 -> 15 -> 20 -> 30 -> 50 -> 60 -> 70
});
```

#### In-order-reverse traversal

```csharp
tree.TraversalInOrderReverse(node =>
{
    // Do something with each tree node
    // 70 -> 60 -> 50 -> 30 -> 20 -> 15 -> 10
});
```

#### Pre-order traversal

```csharp
tree.TraversalPreOrder(node =>
{
    // Do something with each tree node
    // 50 -> 20 -> 10 -> 15 -> 30 -> 70 -> 60
});
```

#### Post-order traversal

```csharp
tree.TraversalPostOrder(node =>
{
    // Do something with each tree node
    // 15 -> 10 -> 30 -> 20 -> 60 -> 70 -> 50
});
```

### Search for value in the tree

```csharp
Console.WriteLine(tree.ContainsValue(15));      // true
Console.WriteLine(tree.ContainsValue(20));      // true
Console.WriteLine(tree.ContainsValue(100));     // false
```

### Get nodes count

```csharp
Console.WriteLine(tree.CountNodes);         // 7
Console.WriteLine(tree.CountLeafNodes);     // 3
Console.WriteLine(tree.CountNotFullNodes);  // 2
Console.WriteLine(tree.CountFullNodes);     // 2
```

### Get tree height

```csharp
Console.WriteLine(tree.Height);     // 3
```

### Get absolute path to node with specified value in the tree

```csharp
// 50 -> 20 -> 10 -> 15
tree.GetAbsolutePathToNode(15);
```

### Convert the tree to its array representation

```csharp
// 50, 20, 70, 10, 30, 60, 0, 0, 15, 0, 0, 0, 0, 0, 0
tree.ToArray();
```

### Delete a node from the tree

```csharp
tree.Delete(10);
```

### Clear the tree

```csharp
tree.Clear();
```
