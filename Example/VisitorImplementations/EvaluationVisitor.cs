using BaseVisitor;
using BaseVisitor.Interfaces;
using Example.AST;

namespace Example.VisitorImplementations;

public class EvaluationVisitor : VisitorBase<object>
{
    private Dictionary<string, INode> _variables = new();

    public object Visit(NumberNode node)
    {
        return node.Value;
    }

    public object? Visit(AdditionNode node)
    {
        var left = VisitBase(node.Left);
        var right = VisitBase(node.Right);

        if (left is int leftInt && right is int rightInt)
        {
            return leftInt + rightInt;
        }

        return null;
    }

    public object? Visit(MultiplicationNode node)
    {
        var left = VisitBase(node.Left);
        var right = VisitBase(node.Right);

        if (left is int leftInt && right is int rightInt)
        {
            return leftInt * rightInt;
        }

        return null;
    }

    public object? Visit(SubtractionNode node)
    {
        var left = VisitBase(node.Left);
        var right = VisitBase(node.Right);

        if (left is int leftInt && right is int rightInt)
        {
            return leftInt - rightInt;
        }

        return null;
    }

    public object? Visit(DivisionNode node)
    {
        var left = VisitBase(node.Left);
        var right = VisitBase(node.Right);

        if (left is int leftInt && right is int rightInt)
        {
            return leftInt / rightInt;
        }

        return null;
    }

    public object? Visit(VariableNode node)
    {
        return VisitBase(_variables[node.Name]);
    }

    public object? Visit(VariableDeclarationNode node)
    {
        var value = VisitBase(node.Value);
        _variables[node.Name] = node.Value;
        return value;
    }
}