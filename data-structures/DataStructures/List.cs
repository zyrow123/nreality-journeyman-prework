using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class List<T>: DataStructures.Collection<T>
    {
        private Container<T>[] _index = new Container<T>[10];
        private int _indexPoint;
        private int _indexBucket = 10;


        public void Add(T value)
        {
            Push(value);
           // UpdateIndex();
        }

        public void UpdateIndex()
        {
            if (Length % _indexBucket == 0)
            {
                _index[_indexPoint] = GetTail();

                if(++_indexPoint > 9)
                {
                    _indexBucket *= 10;
                    _indexPoint = 0;
                }
                
            }
        }

        public T GetIndex(int index)
        {
            return GetContainerByIndex(index).Value;
        }

        private Container<T> GetContainerByIndex(int index)
        {
            if (index > Length - 1 || index < 0)
                throw new IndexOutOfRangeException("Don't do that");

            var counter = 0;

            var refPoint = GetHead();

            while (counter != index)
            {
                refPoint = refPoint.Tail;
                counter++;
            }

            return refPoint;
        }

        public int IndexOf(T value)
        {
            return BinarySearch(value, Length);
        }

        private int BinarySearch(T value, int rangeLength,int baseIndex = 0)
        {
            int currentRange = rangeLength % 2 == 0 ? (rangeLength / 2) : (rangeLength / 2) + 1;

            int index = currentRange;

            var stratPoint = GetContainerByIndex(baseIndex + index);

            while (!stratPoint.Value.Equals(value) && index > 0)
            {
                index--;
                stratPoint = stratPoint.Head;
            }

            if (stratPoint.Value.Equals(value))
            {
                return baseIndex + index;
            }

            if (rangeLength == 0)
            {
                return -1;
            }

            return BinarySearch(value, rangeLength - currentRange, baseIndex + currentRange);
        }

        public T GetIndexByIndex(int index)
        {
            if (index > Length - 1 || index < 0)
                throw new IndexOutOfRangeException("Don't do that");

            var counter = 0;


            var head = GetLookUpLocation(index, out counter);

            while (counter > 0)
            {
                head = head.Tail;
                counter--;
            }

            return head.Value;
        }

        public Container<T> GetLookUpLocation(int value, out int position)
        {
            if(value > _indexBucket)
            {
                position = value%_indexBucket;
                while (value >= 10)
                {
                    value /= 10;
                }

                return _index[value - 1];
            }

            position = value;
            return GetHead();

        }


    }
}
