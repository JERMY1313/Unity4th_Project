﻿namespace Collections
{
    
    internal class MyDynamicArray<T>
        where T : IComparable<T> //where 제한자 : 타입을 제한하는 한정자 (T에 넣을 타입은 ICompareable<T>로 공변 가능해야 한다.
    {
        public T this[int index]
        {
            get
            {
                if(index < 0 || index >= _count)
                    throw new IndexOutOfRangeException();

                return _items[index];
            }
            set
            {
                if (index < 0 || index >= _count)
                    throw new IndexOutOfRangeException();

                _items[index] = value;
            }
        }

        // Count => _count; 는 
        //public int Count
        //{
        //   get
        //   {
        //      return _count;
        //   }
        //를 줄인 문장이다
        public int Count => _count;

        public int Capacity => _items.Length;

        private int _count;
        private const int DEFAULT_SIZE = 1;
        private T[] _items = new T[DEFAULT_SIZE];

        public void Add(T item)
        {
            if(_count >= _items.Length)
            {
                T[] tmp = new T[_count * 2];
                Array.Copy(_items, tmp, _count);
                _items = tmp;
            }

            _items[_count++] = item;
        }

        public T? Find(Predicate<T> match) //FInd = 물건을 찾고싶을때
        {
            for (int i = 0; i < _count; i++)
            {
                if (match(_items[i]))
                    return _items[i];
            }
            return default;
        }

        public int FindIndex(Predicate<T> match) //FindIndex = 정보를 찾아서 수정하고싶을때
        {
            for (int i = 0; i < _count; i++)
            {
                if (match(_items[i]))
                    return i;
            }
            return -1;
        }
        public bool Contains(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                //Default 비교연산
                if (Comparer<T>.Default.Compare(_items[i], item) == 0)
                    return true;  
                //IComparable 비교연산.. (내가 비교연산내용을 직접 구현해서 쓸때) 보통적으로 사용됨.
                if (item.CompareTo(_items[i]) == 0)
                    return true;
            }

            return false;
        }
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
                throw new IndexOutOfRangeException();

            for (int i = 0; i < _count - 1; i++)
            {
                _items[i] = _items[i * 1];
            }
            _count--;
        }

        public bool Remove(T item)
        {
            int index = FindIndex(X => item.CompareTo(X) == 0);

            if (index < 0)
                return false;

            RemoveAt(index);
            return true;
        }
    }
}
