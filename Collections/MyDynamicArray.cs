using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//PsacalCase : 사용자정의 자료형 이름, 함수 이름, 프로퍼티 이름, public/protected 멤버 변수 이름
//camelCase : 지명변수 (unity API 활용할때는 public/protected 멤버 변수 이름도 이렇게 주로 씀
//_camelCase : private 멤버 변수 이름
//snake_case : 상수 정의시
//UPPER_CASE : 상수 정의시
//m_Hungarian, iNum, fX <- 요즘날에는 잘 사용하지 않으나 가끔 사용. 사용 예 : static 멤버변수,  s_Instance

namespace Collections
{

    internal class MyDynamicArray
    {
        public object this[int index]
        {
            get
            {
                if (index < 0 || index >= _count)
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
        private object[] _items = new object[DEFAULT_SIZE];

        public void Add(object item)
        {
            if (_count >= _items.Length)
            {
                {
                    object[] tmp = new object[_count * 2];
                    Array.Copy(_items, tmp, _count);
                    _items = tmp;
                }

                _items[_count++] = item;
            }
        }
            public object? Find(Predicate<object> match) //FInd = 물건을 찾고싶을때
            {
                for (int i = 0; i < _count; i++)
                {
                    if (match(_items[i]))
                        return _items[i];
                }
                return default;
            }

            public int FindIndex(Predicate<object> match) //FindIndex = 정보를 찾아서 수정하고싶을때
            {
                for (int i = 0; i < _count; i++)
                {
                    if (match(_items[i]))
                        return i;
                }
                return -1;
            }
            public bool Contains(object item)
            {
                for (int i = 0; i < _count; i++)
                {
                    if (_items[i] == item)
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

            public bool Remove(object item)
            {
                int index = FindIndex(X => X == item);

                if (index < 0)
                    return false;

                RemoveAt(index);
                return true;
            }
        }
    }
