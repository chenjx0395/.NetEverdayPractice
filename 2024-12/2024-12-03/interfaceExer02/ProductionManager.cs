using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//生产经理
namespace interfaceExer02
{
    internal class ProductionManager : AbstractProductionWorker , IUsingAutomatedEquipment, IUseEscapeEquipment
    {
        public ProductionManager(string name, byte age, byte sex) : base(name, age, sex)
        {

        }
        // 管理指挥
        public void ManagementCommand()
        {
            Console.WriteLine("管理指挥");
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
