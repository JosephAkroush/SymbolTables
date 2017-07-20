using System;
using System.Collections.Generic;

namespace SymbolTables.Interfaces
{
    public interface IOrderedSymbolTable<K, V> : ISymbolTable<K, V>
        where K : IComparable<K>
        where V : class
    {
        /// <summary>
        /// Returns the smallest key.
        /// </summary>
        K Min();

		/// <summary>
		/// Returns the largest key.
		/// </summary>
		K Max();

		/// <summary>
		/// Returns the largest key less than or equal to the specified key.
		/// </summary>
		K Floor(K key);

		/// <summary>
		/// Returns the smallest key greater than or equal to the specified key.
		/// </summary>
		K Ceiling(K key);

		/// <summary>
		/// Returns the number of keys smaller than the specified key.
		/// </summary>
		int Rank(K key);

		/// <summary>
		/// Returns the key of rank k.
		/// </summary>
		K Select(int k);

        /// <summary>
        /// Deletes the smallest key.
        /// </summary>
        void DeleteMin();

        /// <summary>
        /// Deletes the largest key.
        /// </summary>
        void DeleteMax();

        /// <summary>
        /// Returns the number of keys between the specified range of keys.
        /// </summary>
        int Size(K low, K high);

		/// <summary>
		/// Returns the keys between the specified range of keys in sorted order.
		/// </summary>
		IEnumerable<K> Keys(K low, K high);
    }
}