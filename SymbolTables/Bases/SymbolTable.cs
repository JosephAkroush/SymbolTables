using System;
using System.Collections.Generic;
using SymbolTables.Interfaces;

namespace SymbolTables.Bases
{
    public abstract class SymbolTable<K, V> : ISymbolTable<K, V>
        where K : IComparable<K>
        where V : class
    {
        public abstract void Put(K key, V @value);

        public abstract V Get(K key);

        public virtual void Delete(K key)
        {
            Put(key, null);
        }

        public bool Contains(K key)
        {
            return Get(key) != null;
        }

        public bool IsEmpty()
        {
            return Size() == 0;
        }

        public abstract int Size();

        public abstract IEnumerable<K> Keys();
    }
}