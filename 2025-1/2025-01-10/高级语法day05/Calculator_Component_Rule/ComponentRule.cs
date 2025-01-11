namespace Calculator_Component_Rule
{
    public abstract class ComponentRule
    {
        public abstract string Name { get; }
        public abstract int Num1 { get; set; }
        public abstract int Num2 { get; set; }

        /// <summary>
        /// 计算方法
        /// </summary>
        /// <returns></returns>
        public abstract int CalculationMethod();

    }
}