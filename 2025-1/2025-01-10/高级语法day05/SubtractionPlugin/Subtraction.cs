using Calculator_Component_Rule;

namespace SubtractionPlugin
{
    public class Subtraction : ComponentRule
    {
        public override string Name => "-";
        public override int Num1 { get; set; }
        public override int Num2 { get; set; }
        public override int CalculationMethod()
        {
            return Num1 - Num2;
        }
    }
}