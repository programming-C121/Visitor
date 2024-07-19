using BaseVisitor;
using Example.AST;
using Example.ASTNodes;

namespace Example.VisitorImplementations;

public class EvaluationVisitor : VisitorBase<int>
{
    private Dictionary<string, int> _variables = new();

    public int Visit(NumberNode node)
    {
        return node.Value;
    }

    public int Visit(AdditionNode node)
    {
        var left = VisitCore(node.Left);
        var right = VisitCore(node.Right);
        return left + right;
    }

    public int Visit(MultiplicationNode node)
    {
        var left = VisitCore(node.Left);
        var right = VisitCore(node.Right);
        return left * right;
    }

    public int Visit(SubtractionNode node)
    {
        var left = VisitCore(node.Left);
        var right = VisitCore(node.Right);
        return left - right;
    }

    public int Visit(DivisionNode node)
    {
        var left = VisitCore(node.Left);
        var right = VisitCore(node.Right);
        return left / right;
    }

    public int Visit(VariableNode node)
    {
        return _variables[node.Name];
    }

    public int Visit(VariableDeclarationNode node)
    {
        var value = VisitCore(node.Value);
        _variables[node.Name] = value;
        return value;
    }
}