using System;
using System.Collections.Generic;
using SymbolTables.Interfaces;

namespace SymbolTables.Bases
{
    public abstract class OrderedSymbolTable<K, V> : SymbolTable<K, V>, IOrderedSymbolTable<K, V> where K : IComparable<K>
    {
        public abstract K Min();

        public abstract K Max();

        public abstract K Floor(K key);

        public abstract K Ceiling(K key);

        public abstract int Rank(K key);

        public abstract K Select(int k);

        public virtual void DeleteMin()
        {
            if (IsEmpty())
            {
                // Throw an exception.
            }

            Delete(Min());
        }

        public virtual void DeleteMax()
        {
            if (IsEmpty())
            {
                // Throw an exception.
            }

            Delete(Max());
        }

        public virtual int Size(K low, K high)
        {
            if (high.CompareTo(low) < 0)
            {
                return 0;
            }
            else if (Contains(high))
            {
                return Rank(high) - Rank(low) + 1;
            }
            else
            {
                return Rank(high) - Rank(low);
            }
        }

        public override IEnumerable<K> Keys()
        {
            return Keys(Min(), Max());
        }

        public abstract IEnumerable<K> Keys(K low, K high);
    }
}