using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    public interface IHeap<T>
    {
        int Size();

        bool IsEmpty();

        void Clear();

        void Add(T element);

        /// <summary>
        /// 获得堆顶元素
        /// </summary>
        /// <returns></returns>
        T Get();

        /// <summary>
        /// 删除堆顶元素
        /// </summary>
        /// <returns></returns>
        T Remove();

        /// <summary>
        /// 删除堆顶元素的同时插入一个新的元素
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        T Replace(T element);

    }
}
