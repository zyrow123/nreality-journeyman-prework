using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public abstract class Collection<T>
    {
        private Container<T> _tail;
        private Container<T> _head;
        private int _length;

        public int Length
        {
            get { return GetLength(); }
        }

        protected Collection()
        {
            Clear();
        }

        protected void Push(T anything)
        {
            if (_head.Tail == null)
            {
               _head = _tail;
            }
            else
            {
                _tail = _tail.Tail;
            }

            _tail.Value = anything;
            _tail.Tail = new Container<T> { Head = _tail };

            _length++;
        }

        public void Pop()
        {
            _tail = _tail.Head;
            _length--;
        }

        public void Clear()
        {
            _tail = new Container<T>();
            _head = new Container<T>();
        }

        public T GetTailValue()
        {
            return _tail.Value;
        }

        public T GetHeadValue()
        {
            return _head.Value;
        }

        protected Container<T> GetTail()
        {
            return _tail;
        }

        protected Container<T> GetHead()
        {
            return _head;
        }

        protected int GetLength()
        {
            return _length;
        }

        
    }
}
