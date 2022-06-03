namespace FormulaEvaluator.Operands;

public class PowerOperand : Operand
{
    public PowerOperand() : base("Power", "{power}", new PowerExtractionStrategy())
    {
    }
}

public class PowerExtractionStrategy : IExtractStrategy
{
    public object GetValue(object source)
    {
        return 7;
    }
}