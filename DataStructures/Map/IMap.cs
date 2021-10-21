using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map
{
    public interface IMap<K,V>
    {
        int Size();
        bool IsEmpty();

        void Clear();

        V Put(K key, V value);

        V Get(K key);

        V Remove(K key);

        bool ContainsKey(K key);

        bool ContainsValue(V value);

        void Traversal(Action<K, V> action);
    }
}
