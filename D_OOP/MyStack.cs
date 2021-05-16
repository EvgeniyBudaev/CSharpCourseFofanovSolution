using System;
using System.Collections;
using System.Collections.Generic;

namespace D_OOP
{
    public class MyStack<T> : IEnumerable<T>
    {
        private T[] _items;

        // кол-во реально хранимых объектов в массиве _items. По-умолчанию Count = 0
        public int Count { get; private set; } 

        // Возвращает длину массива. По-умолчанию Capacity = 4
        public int Capacity
        {
            get
            {
                return _items.Length;
            }
        }

        public MyStack()
        {
            const int defaultCapacity = 4;
            _items = new T[defaultCapacity];
        }

        public MyStack(int capacity)
        {
            _items = new T[capacity];
        }

        public void Push(T item)
        {
            if (_items.Length == Count)
            {
                T[] largerArray = new T[Count * 2];
                Array.Copy(_items, largerArray, Count);
                _items = largerArray;
            }

            _items[Count++] = item;
        }

        public void Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            _items[--Count] = default; // default вместо null
        }

        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            return _items[Count - 1];
        }

        // public IEnumerator<T> GetEnumerator()
        // {
        //     return new StackEnumerator<T>(_items, Count);
        // }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    // public class StackEnumerator<T>: IEnumerator<T>
    // {
    //     private readonly T[] array;
    //     private readonly int count;
    //     private int position;
    //
    //     public StackEnumerator(T[] array, int count)
    //     {
    //         this.array = array;
    //         this.count = count;
    //         position = count;
    //     }
    //     
    //     public bool MoveNext()
    //     {
    //         position--;
    //         return position >= 0;
    //     }
    //
    //     public void Reset()
    //     {
    //         position = count;
    //     }
    //
    //     public T Current
    //     {
    //         get
    //         {
    //             return array[position];
    //         }
    //     }
    //
    //     object IEnumerator.Current => Current;
    //
    //     public void Dispose()
    //     {
    //     }
    // }
}