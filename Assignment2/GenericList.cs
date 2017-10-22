using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class GenericList<X> : IGenericList<X>
    {
        private const int DefaultSize = 4;

        private X[] _internalStorage;
        private int _size;

        public GenericList()
        {
            _internalStorage = new X[DefaultSize];
            _size = 0;
        }

        public GenericList(int initialSize)
        {
            if (initialSize <= 0)
            {
                throw new ArgumentException("Initial size has to be greater than zero");
            }
            _internalStorage = new X[DefaultSize];
            _size = 0;
        }

        public void Add(X item)
        {
            if (_size >= _internalStorage.Length)
            {
                if (_size == Int32.MaxValue)
                {
                    throw new IndexOutOfRangeException("Can't add more items because the array is filled");
                }
                else if ((uint)_internalStorage.Length * 2 >= Int32.MaxValue)
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

        public bool Remove(X item)
        {
            for (int i = 0; i < _size; ++i)
            {
                if (_internalStorage[i].Equals(item))
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

        public X GetElement(int index)
        {
            if (index >= _size || index < 0)
            {
                throw new IndexOutOfRangeException("There is no item in array at given index.");
            }
            return _internalStorage[index];
        }

        public int IndexOf(X item)
        {
            for (int i = 0; i < _size; ++i)
            {
                if (_internalStorage[i].Equals(item)) return i;
            }
            return -1;
        }


        public int Count
        {
            get { return _size; }
        }

        public void Clear()
        {
            _size = 0;
        }

        public bool Contains(X item)
        {
            for (int i = 0; i < _size; ++i)
            {
                if (_internalStorage[i].Equals(item)) return true;
            }
            return false;
        }

        private void ResizeInternalStorage(int newSize)
        {
            X[] newStorage = new X[newSize];
            int oldLength = _internalStorage.Length;

            for (int i = 0; i < oldLength; ++i)
            {
                newStorage[i] = _internalStorage[i];
            }

            _internalStorage = newStorage;
        }
    }
}
