using FormulaEvaluator.Operands;

namespace FormulaEvaluator;

public static class TokenDictionary
{
    public static Dictionary<string, Token> Get()
    {
        return new Dictionary<string, Token>()
        {
            {"{power}", new PowerOperand()},
            {"{bonusMalus}", new BonusMalusOperand()}
        };
    }
}