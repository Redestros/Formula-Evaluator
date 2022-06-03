using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis.CSharp.Scripting;

namespace FormulaEvaluator;

public class Formula
{
    private readonly string _script;
    private List<Token> _tokens;

    public Formula(string script)
    {
        _script = script;
        _tokens = new List<Token>();
    }

    /// <summary>
    /// Evaluate given script
    /// </summary>
    /// <param name="source">Represents source of data which can be used in token value retrieval</param>
    /// <returns></returns>
    public async Task<object> Evaluate(object source)
    {
        // extract tokens from script
        _tokens = ExtractTokens(_script);
        // replace tokens with appropriate values
        var finalScript = _script;

        // construct script
        foreach (var token in _tokens)
            if (token is Operand operand)
            {
                // extract value using specified strategy
                var value = operand.ExtractStrategy.GetValue(source);
                // replace token with extracted value
                finalScript = finalScript.Replace(token.Syntax, value.ToString());
            }

        // evaluate new script
        var result = await CSharpScript.EvaluateAsync(finalScript);
        return result;
    }

    private static List<Token> ExtractTokens(string script, string pattern = "{.[a-zA-Z]*}")
    {
        var matches = Regex.Matches(script, pattern);

        var items = new HashSet<string>();
        foreach (Match match in matches) items.Add(match.Value);

        return ExtractTokens(items);
    }

    private static List<Token> ExtractTokens(HashSet<string> items)
    {
        var tokens = new List<Token>();
        foreach (var item in items)
        foreach (var (key, value) in TokenDictionary.Get())
        {
            if (!key.Equals(item)) continue;
            tokens.Add(value);
            break;
        }

        return tokens;
    }
}