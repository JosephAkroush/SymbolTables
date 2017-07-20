using System;
using System.Collections.Generic;
using SymbolTables.Bases;
using SymbolTables.Interfaces;

namespace SymbolTables.BinarySearch
{
    public class BinarySearchSymbolTable<K, V> : OrderedSymbolTable<K, V>, IOrderedSymbolTable<K, V>
        where K : IComparable<K>
        where V : class
    {
        public override void Put(K key, V value)
        {
            throw new NotImplementedException();
        }

        public override V Get(K key)
        {
            throw new NotImplementedException();
        }

        public override int Size()
        {
            throw new NotImplementedException();
        }

        public override K Min()
        {
            throw new NotImplementedException();
        }

        public override K Max()
        {
            throw new NotImplementedException();
        }

        public override K Floor(K key)
        {
            throw new NotImplementedException();
        }

        public override K Ceiling(K key)
        {
            throw new NotImplementedException();
        }

        public override int Rank(K key)
        {
            throw new NotImplementedException();
        }

        public override K Select(int k)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<K> Keys(K low, K high)
        {
            throw new NotImplementedException();
        }
    }
}