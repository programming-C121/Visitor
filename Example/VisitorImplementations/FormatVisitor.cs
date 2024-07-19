using System.Text;
using BaseVisitor;
using Visitor.ASTNodes;

namespace Example.VisitorImplementations;

/// <summary>
/// A visitor that formats abstract syntax tree (AST) nodes into a human-readable string representation.
/// This visitor traverses the AST and produces an indented, hierarchical text output of the expression structure.
/// </summary>
public class FormatVisitor : ExpressionVisitorBase<string>
{
    private const string IndentString = "  "; // Two spaces per indentation level

    private static string FormatWithIndent(string content, int indentLevel)
    {
        var sb = new StringBuilder();
        using (var reader = new StringReader(content))
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                sb.AppendLine($"{new string(' ', indentLevel * IndentString.Length)}{line}");
            }
        }
        return sb.ToString().TrimEnd();
    }

    public string Visit(NumberExpression expression)
    {
        return $"Number: {expression.Value}";
    }

    public string Visit(AdditionExpression expression)
    {
        var sb = new StringBuilder();
        sb.AppendLine("Addition:");
        sb.AppendLine(FormatWithIndent($"{Visit(expression.Left)}", 1));
        sb.AppendLine(FormatWithIndent($"{Visit(expression.Right)}", 1));
        return sb.ToString().TrimEnd();
    }

    public string Visit(MultiplicationExpression expression)
    {
        var sb = new StringBuilder();
        sb.AppendLine("Multiplication:");
        sb.AppendLine(FormatWithIndent($"{Visit(expression.Left)}", 1));
        sb.AppendLine(FormatWithIndent($"{Visit(expression.Right)}", 1));
        return sb.ToString().TrimEnd();
    }
}