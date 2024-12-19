using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// 维修工人
namespace interfaceExer02 
{
    internal class MaintenanceWorker : Worker , IRepairInformationTechnologyEquipment, IUseEscapeEquipment
    {
        public MaintenanceWorker(string name, byte age, byte sex) : base(name, age, sex)
        {
        }
        // 维修现代化设备
        public void RepairInformationTechnologyEquipment()
        {
            Console.WriteLine("维修现代化设备");
        }

        // 维修生产设备
        public void RepairProductionEquipment()
        {
            Console.WriteLine("维修生产设备");
        }
        public void UseEscapeEquipment()
        {
            Console.WriteLine($"{Name}使用了逃生装置");
        }
    }
}
