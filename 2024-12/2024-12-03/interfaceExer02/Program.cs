/*
 •	根据需要我们来模拟下面的场景：
•	我们需要建立一个制造工厂，里面有很多各种各样的工人，比如：
•	生产工人：可以制造原材料，加工塑形等。
•	生产经理：比生产工人高级，还具有管理指挥能力。
•	搬运工人：搬运货物。
•	维修工人：维修生产设备（比如车床，汽车等设备）
•	为了提高工厂的生产效率，厂长提出要改革工厂生产方式实施一些自动化设备。则要求
•	如下：
•	1 每个生产工人都必须知道使用自动化设备
•	2 每个维修工人必须除了使用自动化设备外，必须还有知道维修信息化设备（如电脑）的能力
•	3 搬运工人要学会使用搬运机械提高搬运能力
•	此外针对安全要求，安全部门提出每个人必须都具备基本逃生能力（后续可能会要求具有使用逃生设备的能力）

 */
using interfaceExer02;

ProductionWorker productionWorkers = new ProductionWorker("李嘉明",66,0);
productionWorkers.clockIn();
productionWorkers.ProcessingMolding();
productionWorkers.RawMaterialsForProduction();
productionWorkers.UseEscapeEquipment();
productionWorkers.UsingAutomatedEquipment();

