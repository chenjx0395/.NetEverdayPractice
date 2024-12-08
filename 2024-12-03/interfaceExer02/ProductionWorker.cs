using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// 生产工人
namespace interfaceExer02
{
    internal class ProductionWorker : AbstractProductionWorker , IUsingAutomatedEquipment, IUseEscapeEquipment
    {
        public ProductionWorker(string name, byte age, byte sex) : base(name, age, sex)
        {
        }
        public void UseEscapeEquipment()
        {
            Console.WriteLine($"{Name}使用了逃生装置");
        }

        public void UsingAutomatedEquipment()
        {
            Console.WriteLine($"{Name}自动化设备使用");
        }
    }
}
