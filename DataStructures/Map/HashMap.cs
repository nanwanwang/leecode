using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map
{

    /// <summary>
    /// Todo 红黑树再学习
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    public class HashMap<K, V> : IMap<K, V>
    {
        private int _size;
        public void Clear()
        {
            _size = 0;
        }

        public bool ContainsKey(K key)
        {
            throw new NotImplementedException();
        }

        public bool ContainsValue(V value)
        {
            throw new NotImplementedException();
        }

        public V Get(K key)
        {
            throw new NotImplementedException();
        }

        public bool IsEmpty()
        {
            return _size == 0;
        }

        public V Put(K key, V value)
        {
            throw new NotImplementedException();
        }

        public V Remove(K key)
        {
            throw new NotImplementedException();
        }

        public int Size()
        {
            return _size;
        }

        public void Traversal(Action<K, V> action)
        {
            throw new NotImplementedException();
        }
    }
}
