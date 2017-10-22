using System;

namespace Assignment1
{
    public class IntegerList : IIntegerList
    {
        private const int DefaultSize = 4;

        private int[] _internalStorage;
        private int _size;

        public int Count
        {
            get { return _size; }
        }

        public IntegerList()
        {
            _internalStorage = new int[DefaultSize];
            _size = 0;
        }

        public IntegerList(int initialSize)
        {
            if (initialSize <= 0)
            {
                throw new ArgumentException("Initial size has to be greater than zero");
            }
            _internalStorage = new int[DefaultSize];
            _size = 0;
        }

        public void Add(int item)
        {
            if (_size >= _internalStorage.Length)
            {
                if (_size == Int32.MaxValue)
                {
                    throw new IndexOutOfRangeException("Can't add more items because the array is filled");
                }
                else if ((uint) _internalStorage.Length * 2 >= Int32.MaxValue)
                {
                    ResizeInternalStorage(Int32.MaxValue);
                }
                else
                {
                    ResizeInternalStorage(_size * 2);
                }
            }
            _internalStorage[_size] = item;
            _size++;
        }

        public bool Remove(int item)
        {
            for (int i = 0; i < _size; ++i)
            {
                if (_internalStorage[i] == item)
                {
                    return RemoveAt(i) == true ? true : false;
                }
            }
            return false;
        }

        public bool RemoveAt(int index)
        {
            if (index >= _size || index < 0)
            {
                throw new IndexOutOfRangeException("There is no item in array at given index.");
            }
            for (int i = index + 1; i < _size; ++i)
            {
                _internalStorage[i - 1] = _internalStorage[i];
            }
            _size--;
            return true;
        }

        public int GetElement(int index)
        {
            if (index >= _size || index < 0)
            {
                throw new IndexOutOfRangeException("There is no item in array at given index.");
            }
            return _internalStorage[index];
        }

        public int IndexOf(int item)
        {
            for (int i = 0; i < _size; ++i)
            {
                if (_internalStorage[i] == item) return i;
            }
            return - 1;
        }

        public void Clear()
        {
            _size = 0;
        }

        public bool Contains(int item)
        {
            for (int i = 0; i < _size; ++i)
            {
                if (_internalStorage[i] == item) return true;
            }
            return false;
        }

        private void ResizeInternalStorage(int newSize)
        {
            int[] newStorage = new int[newSize];
            int oldLength = _internalStorage.Length;

            for (int i = 0; i < oldLength; ++i)
            {
                newStorage[i] = _internalStorage[i];
            }

            _internalStorage = newStorage;
        }
    }
}