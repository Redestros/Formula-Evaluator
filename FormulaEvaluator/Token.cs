namespace FormulaEvaluator;

public abstract class Token
{
    protected Token(string name, string syntax)
    {
        Name = name;
        Syntax = syntax;
    }

    public string Name { get; }
    public string Syntax { get; }
}