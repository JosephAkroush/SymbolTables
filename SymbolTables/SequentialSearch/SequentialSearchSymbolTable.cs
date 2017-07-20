using System;
using System.Collections.Generic;
using SymbolTables.Bases;
using SymbolTables.Interfaces;

namespace SymbolTables.SequentialSearch
{
    public class SequentialSearchSymbolTable<K, V> : SymbolTable<K, V>, ISymbolTable<K, V>
        where K : IComparable<K>
        where V : class
    {
        private Node<K, V> _head;

        public override void Put(K key, V @value)
        {
            if (IsEmpty())
            {
                _head = new Node<K, V>();
                _head.Key = key;
                _head.Value = @value;

                return;
            }

            Node<K, V> node = _head;

            while (node != null)
            {
                if (node.Key.CompareTo(key) == 0)
                {
                    node.Value = @value;

                    return;
                }

                node = node.Next;
            }

            node = new Node<K, V>();
            node.Key = key;
            node.Value = @value;
            node.Next = _head;

            _head = node;
        }

        public override V Get(K key)
        {
            Node<K, V> node = _head;

            while (node != null)
            {
                if (node.Key.CompareTo(key) == 0)
                {
                    return node.Value;
                }

                node = node.Next;
            }

            return null;
        }

        public override void Delete(K key)
        {
            if (IsEmpty())
            {
                return;
            }

            Node<K, V> node = _head;
            Node<K, V> previous = null;

            while (node != null)
            {
                if (node.Key.CompareTo(key) == 0)
                {
                    if (node.Next == null)
                    {
                        if (previous == null)
                        {
                            _head = null;
                        }
                        else
                        {
                            previous.Next = null;
                        }
                    }
                    else
                    {
                        node.Key = node.Next.Key;
                        node.Value = node.Next.Value;
                        node.Next = node.Next.Next;
                    }

                    return;
                }

                previous = node;
                node = node.Next;
            }
        }

        public override int Size()
        {
            if (_head == null)
            {
                return 0;
            }

            int size = 0;

            Node<K, V> node = _head;

            while (node != null)
            {
                size++;

                node = node.Next;
            }

            return size;
        }

        public override IEnumerable<K> Keys()
        {
            if (IsEmpty())
            {
                return null;
            }

            int size = Size();
            K[] keys = new K[size];

            Node<K, V> node = _head;

            while (node != null)
            {
                keys[--size] = node.Key;

                node = node.Next;
            }

            return keys;
        }
    }
}