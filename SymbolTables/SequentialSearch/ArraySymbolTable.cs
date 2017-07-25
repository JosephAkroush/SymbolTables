using System;
using System.Collections.Generic;
using SymbolTables.Bases;

namespace SymbolTables.SequentialSearch
{
    public class ArraySymbolTable<K, V> : SymbolTable<K, V> where K : IComparable<K>
    {
        private readonly K[] _keys;
        private readonly V[] _values;
        private int _size;

        public ArraySymbolTable(int capacity)
        {
            _keys = new K[capacity];
            _values = new V[capacity];
        }

        public override void Put(K key, V value)
        {
            if (IsEmpty())
            {
                _keys[0] = key;
                _values[0] = value;
            }
            else
            {
                if (Get(key) == null)
                {
                    _keys[_size] = key;
                    _values[_size] = value;
                }
                else
                {
                    for (int i = 0; i < _size; i++)
                    {
                        if (_keys[i].CompareTo(key) == 0)
                        {
                            _values[i] = value;

                            return;
                        }
                    }
                }
            }

            _size++;
        }

        public override V Get(K key)
        {
            if (IsEmpty())
            {
                return default(V);
            }

            for (int i = 0; i < _size; i++)
            {
                if (_keys[i].CompareTo(key) == 0)
                {
                    return _values[i];
                }
            }

            return default(V);
        }

        public override void Delete(K key)
        {
            if (IsEmpty())
            {
                return;
            }

            for (int i = 0; i < _size; i++)
            {
                if (_keys[i].CompareTo(key) == 0)
                {
                    _keys[i] = _keys[_size - 1];
                    _values[i] = _values[_size - 1];

                    _keys[_size - 1] = default(K);
                    _values[_size - 1] = default(V);

                    _size--;
                }
            }
        }

        public override int Size()
        {
            return _size;
        }

        public override IEnumerable<K> Keys()
        {
            if (IsEmpty())
            {
                return null;
            }

            K[] keys = new K[_size];

            for (int i = 0; i < _size; i++)
            {
                keys[i] = _keys[i];
            }

            return keys;
        }
    }
}