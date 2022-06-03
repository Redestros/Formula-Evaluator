namespace FormulaEvaluator.Operands;

public class BonusMalusOperand : Operand
{
    public BonusMalusOperand() : base("Bonus Malus", "{bonusMalus}", new BonusMalusExtractionStrategy())
    {
    }
}

public class BonusMalusExtractionStrategy : IExtractStrategy
{
    public object GetValue(object source)
    {
        return 8;
    }
}