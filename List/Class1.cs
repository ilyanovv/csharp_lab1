using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyListImpl
{
    public class MyList<T> : IList<T>
    {
        public class Node
        {
            public T value;
            public Node next;

            public Node(T value, Node next)
            {
                this.value = value;
                this.next = next;
            }
        }


        private int _size;
        private Node _first;
        private Node _last;

        public T this[int index]
        {
            get
            {
                if (index > _size - 1 || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                Node cur_node = _first;
                for(int i = 0; i < index; i++)
                {
                    cur_node = cur_node.next;
                }
                return cur_node.value;
            }

            set
            {
                if (index > _size - 1 || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }

                Node cur_node = _first;
                for (int i = 0; i < index; i++)
                {
                    cur_node = cur_node.next;
                }
                cur_node.value = value;
            }
        }

        public int Count
        {
            get
            {
                return _size;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(T item)
        {
            if (_size == 0)
            {
                _first = _last = new Node(item, null);
            }
            else
            {
                Node prev = _last;
                prev.next = new Node(item, null);
                _last = prev.next;
            }
            _size++;
        }

        public void Clear()
        {
            _size = 0;
            _first = null;
            _last = null;
        }

        public bool Contains(T item)
        {
            Node cur_node = _first;
            for (int i = 0; i < _size; i++)
            {
                if (cur_node.value.Equals(item))
                {
                    return true;
                }
                else
                {
                    cur_node = cur_node.next;
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            for (int i = 0; i < _size; i++)
            {
                array[arrayIndex + i] = this[i];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _size; i++)
            {
                yield return this[i];
            }
        }

        public int IndexOf(T item)
        {
            Node cur_node = _first;
            for (int i = 0; i < _size; i++)
            {
                if (cur_node.value.Equals(item))
                {
                    return i; 
                }
                else
                {
                    cur_node = cur_node.next;
                }  
            }
            return -1;
        }

  
        public void Insert(int index, T item)
        {
            if (index > _size - 1 || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            Node new_node = new Node(item, null);
            if (index == 0)
            {
                new_node.next = _first;
                _first = new_node;
            }
            else
            {
                Node prev = _first;
                Node next = _first.next;
                int i = 1; 
                while (i != index)
                {
                    prev = prev.next;
                    next = next.next;
                    i++;
                }
                prev.next = new_node;
                new_node.next = next;
            }
            _size++;
        }

        public bool Remove(T item)
        {
            Node cur_node = _first;
            Node prev_node = null;
            for (int i = 0; i < _size; i++)
            {
                if (cur_node.value.Equals(item))
                {
                    if (i == 0)
                    {
                        _first = cur_node.next;
                    }
                    else
                    {
                        prev_node.next = cur_node.next;
                        if (i == _size - 1)
                        {
                            _last = prev_node;
                        }
                    }

                    _size--;
                    return true;
                }
                prev_node = cur_node;
                cur_node = cur_node.next;
            }
            return false;
        }


        public void RemoveAt(int index)
        {
            if (index > _size - 1 || index < 0)
            {
                throw new IndexOutOfRangeException();
            }


            if (index == 0)
            {
                _first = _first.next;
            }

            else
            {
                Node prev_node = _first;
                Node cur_node = _first.next;
                for (int i = 1; i < index; i++)
                {
                    prev_node = cur_node;
                    cur_node = cur_node.next;
                }

                prev_node.next = cur_node.next;
                if(index == _size - 1)
                {
                    _last = prev_node;
                }
            }
            _size--;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public override string ToString()
        {
            if (_size == 0)
                return "";
            String str = "";
            for (int i = 0; i < _size - 1; i++)
            {
                str += this[i].ToString() + ", ";
            }
            str += this[_size - 1].ToString();
            return str;
        }

        public static MyList<T> fromArray(T[] arr)
        {
            MyList<T> list = new MyList<T>();
            foreach (T elem in arr)
            {
                list.Add(elem);
            }
            return list;
        }
    }
}
