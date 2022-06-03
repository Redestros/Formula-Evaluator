namespace FormulaEvaluator;

public abstract class Operand : Token
{
    protected Operand(string name, string syntax, IExtractStrategy extractStrategy) : base(name, syntax)
    {
        ExtractStrategy = extractStrategy;
    }

    public IExtractStrategy ExtractStrategy { get; }
}