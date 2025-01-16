using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 为了实现开放封闭原则，功能的设计遵循单一职责原则，模块间的关系遵循依赖倒置原则。
            // 接口设计应该也符合 单一职责原则。
            /*
                接口的设计不应该冗余，如果一个类实现了一个接口，但其实并不需要实现该接口的所有方法。
                那么接口的设计需要进行拆分。
                增强复用性，减少代码冗余。
             */
        }

        interface IScoreSelect
        {
            
            void SelectScore();
        }

        interface IIScoreFix
        {
            void AddScore();
            void DeleteScore();
            void UpdateScore();
        }


        class Student : IScoreSelect
        {
            public void SelectScore() {}
        }

        class Teacher : IScoreSelect, IIScoreFix
        {
            public void SelectScore() { }

            public void AddScore() { }

            public void DeleteScore() { }

            public void UpdateScore() { }
        }
        
    }
}
