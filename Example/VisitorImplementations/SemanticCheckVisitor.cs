using BaseVisitor;
using Example.AST;

namespace Example.VisitorImplementations;

public class SemanticCheckVisitor : VisitorBase<SemanticResult>
{
    public SemanticResult Visit(NumberNode node)
    {
        // Numbers are always valid and of type int
        return SemanticResult.Success(typeof(int));
    }

    public SemanticResult Visit(ArithmeticBinaryNode node)
    {
        // Perform semantic check on left and right child nodes
        var leftResult = VisitBase(node.Left);
        var rightResult = VisitBase(node.Right);

        // If there's an error in either child node, propagate that error
        if (leftResult?.Error != null) return leftResult;
        if (rightResult?.Error != null) return rightResult;

        // Verify that both operands are of type int
        if (leftResult?.Type != typeof(int) || rightResult?.Type != typeof(int))
        {
            // If either is not int, return a semantic error
            return SemanticResult.Failure("Arithmetic operands must be integers");
        }

        // If both operands are int, the operation is valid and the result will be int
        return SemanticResult.Success(typeof(int));
    }
}