using BaseVisitor;
using Example.AST;

namespace Example.VisitorImplementations;

public class SemanticCheckVisitor : VisitorBase<SemanticResult>
{
    public SemanticResult Visit(NumberNode node)
    {
        return SemanticResult.Success(typeof(int));
    }

    public SemanticResult Visit(ArithmeticBinaryNode node)
    {
        var left = VisitBase(node.Left);
        var right = VisitBase(node.Right);

        if (left?.Error != null) return left;
        if (right?.Error != null) return right;

        if (left?.Type != typeof(int) || right?.Type != typeof(int))
        {
            return SemanticResult.Failure("Arithmetic operands must be integers");
        }

        return SemanticResult.Success(typeof(int));
    }
}