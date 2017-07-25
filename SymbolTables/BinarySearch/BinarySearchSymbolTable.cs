using System;
using System.Collections.Generic;
using SymbolTables.Bases;

namespace SymbolTables.BinarySearch
{
    public class BinarySearchSymbolTable<K, V> : OrderedSymbolTable<K, V> where K : IComparable<K>
    {
        private readonly K[] _keys;
        private readonly V[] _values;
        private int _size;

        public BinarySearchSymbolTable(int capacity)
        {
            _keys = new K[capacity];
            _values = new V[capacity];
        }

        public override void Put(K key, V value)
        {
            int rank = Rank(key);

            if (rank < _size && _keys[rank].CompareTo(key) == 0)
            {
                _values[rank] = value;
            }
            else
            {
                for (int i = _size; i > rank; i--)
                {
                    _keys[i] = _keys[i - 1];
                    _values[i] = _values[i - 1];
                }

                _keys[rank] = key;
                _values[rank] = value;
                _size++;
            }
        }

        public override V Get(K key)
        {
            if (IsEmpty())
            {
                return default(V);
            }

            int rank = Rank(key);

            if (rank < _size && _keys[rank].CompareTo(key) == 0)
            {
                return _values[rank];
            }

            return default(V);
        }

        public override void Delete(K key)
        {
            if (IsEmpty())
            {
                return;
            }

            int rank = Rank(key);

            if (rank == _size || _keys[rank].CompareTo(key) != 0)
            {
                return;
            }

            for (int i = rank; i < _size - 1; i++)
            {
                _keys[i] = _keys[i + 1];
                _values[i] = _values[i + 1];
            }

            _size--;
            _keys[_size] = default(K);
            _values[_size] = default(V);
        }

        public override int Size()
        {
            return _size;
        }

        public override K Min()
        {
            return _keys[0];
        }

        public override K Max()
        {
            if (_size == 0)
            {
                return _keys[0];
            }

            return _keys[_size - 1];
        }

        public override K Floor(K key)
        {
            int rank = Rank(key);

            if (rank < _size && key.CompareTo(_keys[rank]) == 0)
            {
                return _keys[rank];
            }
            else if (rank == 0)
            {
                return default(K);
            }
            else
            {
                return _keys[rank - 1];
            }
        }

        public override K Ceiling(K key)
        {
            int rank = Rank(key);

            return _keys[rank];
        }

        public override int Rank(K key)
        {
            int low = 0;
            int high = _size - 1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;

                int compare = key.CompareTo(_keys[mid]);

                if (compare < 0)
                {
                    high = mid - 1;
                }
                else if (compare > 0)
                {
                    low = mid + 1;
                }
                else
                {
                    return mid;
                }
            }

            return low;
        }

        public override K Select(int k)
        {
            return _keys[k];
        }

        public override IEnumerable<K> Keys(K low, K high)
        {
            if (IsEmpty())
            {
                return null;
            }

            int lowRank = Rank(low);
            int highRank = Rank(high);
            List<K> keys = new List<K>();

            for (int i = lowRank; i < highRank; i++)
            {
                keys.Add(_keys[i]);
            }

            if (Contains(high))
            {
                keys.Add(_keys[highRank]);
            }

            return keys;
        }
    }
}