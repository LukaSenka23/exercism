using System;
using System.Collections;
using System.Collections.Generic;

public class SimpleLinkedList<T> : IEnumerable<T>
{
    private int count;
    private Node? head;
    
    class Node
    {
        public T Value;
        public Node? Next { get; set; }

            public Node(T value)
            {
                Value = value;
            }
    }
    public SimpleLinkedList() { }

    public SimpleLinkedList(T value)
    {
        Push(value);
    }

    public SimpleLinkedList(T[] values)
    {
        for (int i = 0; i < values.Length; i++)
        {
            Push(values[i]);
        }
    }
    
    public int Count => count;
    
    public void Push(T value)
    {
        var node = new Node(value);
        node.Next = head;
        head = node;
        count++;
    }

    public T Pop()
    {
        if (head == null)
            throw new InvalidOperationException();
        var value = head.Value;
        head = head.Next;
        count--;
        return value;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var current = head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}