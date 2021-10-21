using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set
{
    public interface ISet<T>
    {
        int Size();

        bool IsEmpty();

        void Clear();

        bool Contains();

        void Add(T element);

        void Remove(T element);


        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="action"></param>
        void Traversal(Action<T> action);

        
    }
}
