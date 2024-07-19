using BaseVisitor;
using Example.ASTNodes;

namespace Example.VisitorImplementations;

public class EvaluationVisitor : VisitorBase<int>
{

    public int Visit(NumberNode node)
    {
        return node.Value;
    }

    public int Visit(AdditionNode node)
    {
        
        var left = Visit(node.Left);
        var right = Visit(node.Right);
        return left + right;
    }

    public int Visit(MultiplicationNode node)
    {
        var left = Visit(node.Left);
        var right = Visit(node.Right);
        return left * right;
    }
}