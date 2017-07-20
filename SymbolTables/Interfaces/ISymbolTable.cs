using System;
using System.Collections.Generic;

namespace SymbolTables.Interfaces
{
    public interface ISymbolTable<K, V>
        where K : IComparable<K>
        where V : class
    {
        /// <summary>
        /// Inserts the key-value pair.
        /// If the key exists, the value will be replaced.
        /// If the value is null, the key will be removed.
        /// </summary>
		void Put(K key, V @value);

        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        V Get(K key);

        /// <summary>
        /// Deletes the specified key.
        /// </summary>
		void Delete(K key);

        /// <summary>
        /// Checks if the specified key exists.
        /// </summary>
        bool Contains(K key);

        /// <summary>
        /// Checks if the symbol table contains any key-value pairs.
        /// </summary>
		bool IsEmpty();

        /// <summary>
        /// Returns the number of key-value pairs.
        /// </summary>
		int Size();

        /// <summary>
        /// Returns a collection of keys stored.
        /// </summary>
		IEnumerable<K> Keys();
    }
}