using BaseVisitor;
using Example.AST;

namespace Example.VisitorImplementations;

public class EvaluationVisitor : VisitorBase<int>
{
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
}