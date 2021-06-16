using System;

namespace InterfaceDefine
{
    public interface IList<T>
    { 
        /// <summary>
        /// 元素数量
        /// </summary>
        /// <returns></returns>
        int Size();


        /// <summary>
        /// 是否为空
        /// </summary>
        /// <returns></returns>
        bool IsEmpty();

        /// <summary>
        /// 是否包含元素
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        bool Contains(T element);

        /// <summary>
        /// 添加元素到最后面
        /// </summary>
        /// <param name="element"></param>
        void Add(T element);


        /// <summary>
        /// 返回index位置对应的元素
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        T Get(int index);

        /// <summary>
        /// 设置index位置的元素
        /// </summary>
        /// <param name="index"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        T Set(int index, T element);

        /// <summary>
        /// 往index位置添加元素
        /// </summary>
        /// <param name="index"></param>
        /// <param name="element"></param>
        void Add(int index, T element);


        /// <summary>
        /// 删除index位置对应的元素
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        T Remove(int index);


        /// <summary>
        /// 查看元素的位置
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        int IndexOf(T element);


        /// <summary>
        /// 清除所有元素 引用类型需要使用default 赋值
        /// </summary>
        void Clear();
    }
}