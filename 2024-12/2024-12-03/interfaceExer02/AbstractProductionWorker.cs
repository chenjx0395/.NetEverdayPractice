using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 抽象工人类
 */
namespace interfaceExer02
{
    internal abstract class AbstractProductionWorker : Worker
    {
        protected AbstractProductionWorker(string name, byte age, byte sex) : base(name, age, sex)
        {
        }

        //制作原材料
        public void RawMaterialsForProduction() {
            Console.WriteLine($"{base.Name}开始制作原材料~~~");
        }
        //加工塑型

        public void ProcessingMolding()
        {
            Console.WriteLine($"{base.Name}开始加工塑型~~~");
        }
    }
}
