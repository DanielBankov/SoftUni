﻿using System;
using System.Collections;
using System.Collections.Generic;

public class DoublyLinkedList<T> : IEnumerable<T>
{
    private class ListNode<T>
    {
        public T Value { get; set; }

        public ListNode<T> NextNode { get; set; }

        public ListNode<T> PrevNode { get; set; }

        public ListNode(T value)
        {
            this.Value = value;
        }
    }

    private ListNode<T> head;
    private ListNode<T> tail;

    public int Count { get; private set; }

    public void AddFirst(T element)
    {
        var newNode = new ListNode<T>(element);

        if (Count == 0)
        {
            this.head = newNode;
            this.tail = newNode;
        }
        else
        {
            newNode.NextNode = this.head;
            this.head.PrevNode = newNode;
            this.head = newNode;
        }

        this.Count++;
    }

    public void AddLast(T element)
    {
        var newNode = new ListNode<T>(element);

        if (Count == 0)
        {
            this.head = newNode;
            this.tail = newNode;
        }
        else
        {
            newNode.PrevNode = this.tail;
            this.tail.NextNode = newNode;
            this.tail = newNode;
        }

        this.Count++;
    }

    public T RemoveFirst()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("List empty");
        }

        var firstElement = this.head.Value;
        this.head = this.head.NextNode;

        if (this.head != null)
        {
            this.head.PrevNode = null;
        }
        else
        {
            this.tail = null;
        }

        Count--;
        return firstElement;
    }

    public T RemoveLast()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("List empty");
        }

        var lastElement = this.tail.Value;
        this.tail = this.tail.PrevNode;

        if (this.tail != null)
        {
            this.tail.NextNode = null;
        }
        else
        {
            this.head = null;
        }

        Count--;
        return lastElement;
    }

    public void ForEach(Action<T> action)
    {
        var currentNode = this.head;

        while (currentNode != null)
        {
            action(currentNode.Value);
            currentNode = currentNode.NextNode;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        var currentNode = this.head;

        while (currentNode != null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.NextNode;
        }

    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public T[] ToArray()
    {
        var array = new T[Count];
        var currentNode = this.head;

        for (int i = 0; i < Count; i++)
        {
            array[i] = currentNode.Value;
            currentNode = currentNode.NextNode;
        }

        return array;
    }
}


class Example
{
    static void Main()
    {
        var list = new DoublyLinkedList<int>();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.AddLast(5);
        list.AddFirst(3);
        list.AddFirst(2);
        list.AddLast(10);
        Console.WriteLine("Count = {0}", list.Count);

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveFirst();
        list.RemoveLast();
        list.RemoveFirst();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveLast();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");
    }
}



// helper https://www.youtube.com/watch?v=FrnIMbAC2fE&feature=youtu.be 