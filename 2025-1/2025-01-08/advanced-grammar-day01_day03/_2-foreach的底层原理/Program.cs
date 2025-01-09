using System;
using System.Collections;

namespace foreach的底层原理
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] a = { 1, 2, 3, 4, 5 };
            foreach (var item in a)
            {
                Console.WriteLine(item);
            }

            var test = new Test();

            // 原生使用迭代器模式遍历
            var enumerator = test.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.Write(enumerator.Current);
            }
            enumerator.Reset();
            // 利用foreach语法糖使用迭代器模式遍历
            foreach (var item in test)
            {
                Console.Write(item);
            }
        }
    }

    class Test : IEnumerable
    {
        private readonly string[] _name = new[] { "a", "b", "c" };

        /// <summary>
        /// 获取枚举器对象
        /// </summary>
        /// <returns>枚举器对象</returns>
        public IEnumerator GetEnumerator()
        {
            return new TestEnumerator(_name);
        }
    }

    class TestEnumerator : IEnumerator
    {
        /// <summary>
        /// 待迭代的数组
        /// </summary>
        private readonly string[] _name;

        /// <summary>
        /// 数组索引
        /// </summary>
        private int _index = -1;

        public TestEnumerator(string[] name)
        {
            this._name = name;
        }

        /// <summary>
        /// 获取当前的元素
        /// </summary>
        public object Current
        {
            get
            {
                if (_index >= _name.Length || _index < 0) return null;
                return _name[_index];
            }
        }

        /// <summary>
        /// 将索引移动到下一个元素
        /// </summary>  
        /// <returns>如果存在下一个元素,返回true</returns>
        public bool MoveNext()
        {
            if (_index + 1 >= _name.Length) return false;
            _index++;
            return true;
        }

        /// <summary>
        /// 重置索引
        /// </summary>
        public void Reset()
        {
            _index = -1;
        }
    }
}