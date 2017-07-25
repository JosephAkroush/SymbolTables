﻿using System;

namespace SymbolTables.SequentialSearch
{
    public class Node<K, V> where K : IComparable<K>
    {
        public K Key { get; set; }
        public V Value { get; set; }
        public Node<K, V> Next { get; set; }
    }
}