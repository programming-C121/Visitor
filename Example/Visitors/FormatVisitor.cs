using System.Text;
using BaseVisitor;
using Example.AST;

namespace Example.Visitors;

/// <summary>
/// Visitor that formats abstract syntax tree (AST) nodes into a human-readable string representation.
/// This visitor traverses the AST and produces an indented, hierarchical text output of the expression structure.
/// </summary>
public class FormatVisitor : VisitorBase<string>
{
    private const string IndentString = "    "; // Four spaces per indentation level

    private static string FormatWithIndent(string content, int indentLevel)
    {
        var sb = new StringBuilder();
        using (var reader = new StringReader(content))
        {
            while (reader.ReadLine() is { } line)
            {
                sb.AppendLine($"{new string(' ', indentLevel * IndentString.Length)}{line}");
            }
        }

        return sb.ToString().TrimEnd();
    }

    public string Visit(NumberNode node)
    {
        return $"NumberNode: {node.Value}";
    }

    public string Visit(BinaryNode node)
    {
        var sb = new StringBuilder();
        var className = node.GetType().Name;
        sb.AppendLine($"{className}:");
        sb.AppendLine(FormatWithIndent($"{VisitBase(node.Left)}", 1));
        sb.AppendLine(FormatWithIndent($"{VisitBase(node.Right)}", 1));
        return sb.ToString().TrimEnd();
    }

    public string Visit(VariableNode node)
    {
        return $"VariableNode: {node.Name}";
    }

    public string Visit(VariableDeclarationNode node)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"VariableDeclarationNode: {node.Name}");
        sb.AppendLine(FormatWithIndent($"{VisitBase(node.Value)}", 1));
        return sb.ToString().TrimEnd();
    }

    public string Visit(ProgramNode node)
    {
        var sb = new StringBuilder();
        sb.AppendLine("ProgramNode:");
        foreach (var statement in node.Statements)
        {
            sb.AppendLine(FormatWithIndent($"{VisitBase(statement)}", 1));
        }

        return sb.ToString().TrimEnd();
    }
}