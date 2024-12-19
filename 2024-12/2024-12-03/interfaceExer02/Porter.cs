using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// 搬运工人
namespace interfaceExer02
{
    internal class Porter : Worker , IMechanicalHandling , IUseEscapeEquipment
    {
        public Porter(string name, byte age, byte sex) : base(name, age, sex)
        {
        }

        //搬运货物
        public void CargoHandling()
        {
            Console.WriteLine("搬运货物");
        }
        // 机械搬运
        public void MechanicalHandling()
        {
            Console.WriteLine("机械搬运");
        }

        public void UseEscapeEquipment()
        {
            Console.WriteLine($"{Name}使用了逃生装置");
        }
    }
}
