using System;
using System.Collections;

namespace BinaryHeap
{
    internal class BinaryHeap : IEnumerable
    {
        private List<int> _items;

        public BinaryHeap()
        {
            _items = new List<int>();
        }

        public int Count => _items.Count;

        public int? Peek()
        {
            if (Count > 0)
            {
                return _items[0];
            }
            else
            {
                return null;
            }
        }

        public void Add(int item)
        {
            _items.Add(item);

            int currentIndex = _items.Count - 1;
            int parentIndex = GetParentIndex(currentIndex);

            while (currentIndex > 0 && _items[parentIndex] < _items[currentIndex])
            {
                Swap(currentIndex, parentIndex);

                currentIndex = parentIndex;
                parentIndex = GetParentIndex(currentIndex);
            }
        }

        public int GetMax() 
        {
            int max = _items[0];
            _items[0] = _items[_items.Count - 1];
            _items.RemoveAt(_items.Count - 1);
            Sort();

            return max;
        }

        public IEnumerator GetEnumerator()
        {
            while (Count > 0)
            { 
                yield return GetMax();
            }
        }

        private void Swap(int firstIndex, int secondIndex)
        {
            int temp = _items[firstIndex];
            _items[firstIndex] = _items[secondIndex];
            _items[secondIndex] = temp;
        }

        private void Sort()
        {
            int leftChild;
            int rightChild;
            int currentIndex = 0;

            while (true)
            {
                if (GetLeftChildIndex(currentIndex) == 0 || GetRightChildIndex(currentIndex) == 0)
                {
                    break;
                }

                int value = _items[currentIndex];
                leftChild = _items[GetLeftChildIndex(currentIndex)];
                rightChild = _items[GetRightChildIndex(currentIndex)];

                if (value < leftChild && leftChild >= rightChild)
                {
                    int temp = GetLeftChildIndex(currentIndex);
                    Swap(currentIndex, GetLeftChildIndex(currentIndex));
                    currentIndex = temp;
                }
                else if (value < rightChild && rightChild >= leftChild)
                {
                    int temp = GetRightChildIndex(currentIndex);
                    Swap(currentIndex, GetRightChildIndex(currentIndex));
                    currentIndex = temp;
                }
                else
                {
                    break;
                }
            }
        }

        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        private int GetLeftChildIndex(int parentIndex)
        {
            int index = (2 * parentIndex) + 1;

            if (index >= _items.Count)
                return 0;
            else
                return index;
        }

        private int GetRightChildIndex(int parentIndex)
        {
            int index = (2 * parentIndex) + 2;

            if (index >= _items.Count)
                return 0;
            else
                return index;
        }
    }
}
