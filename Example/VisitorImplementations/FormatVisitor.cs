using System.Text;
using BaseVisitor;
using Example.ASTNodes;

namespace Example.VisitorImplementations;

/// <summary>
/// A visitor that formats abstract syntax tree (AST) nodes into a human-readable string representation.
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
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                sb.AppendLine($"{new string(' ', indentLevel * IndentString.Length)}{line}");
            }
        }
        return sb.ToString().TrimEnd();
    }

    public string Visit(NumberNode node)
    {
        return $"Number: {node.Value}";
    }
    
    public string Visit(BinaryNode node)
    {
        var sb = new StringBuilder();
        var className = node.GetType().Name;
        sb.AppendLine(className);
        sb.AppendLine(FormatWithIndent($"{Visit(node.Left)}", 1));
        sb.AppendLine(FormatWithIndent($"{Visit(node.Right)}", 1));
        return sb.ToString().TrimEnd();
    }
}