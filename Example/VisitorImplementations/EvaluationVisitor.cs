using BaseVisitor;
using Visitor.ASTNodes;

namespace Example.VisitorImplementations;

public class EvaluationVisitor : ExpressionVisitorBase<int>
{

    public int Visit(NumberExpression expression)
    {
        return expression.Value;
    }

    public int Visit(AdditionExpression expression)
    {
        
        var left = Visit(expression.Left);
        var right = Visit(expression.Right);
        return left + right;
    }

    public int Visit(MultiplicationExpression expression)
    {
        var left = Visit(expression.Left);
        var right = Visit(expression.Right);
        return left * right;
    }
}